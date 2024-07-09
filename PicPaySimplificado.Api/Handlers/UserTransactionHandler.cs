using PicPaySimplificado.Api.Data;
using PicPaySimplificado.Core.Handlers;
using PicPaySimplificado.Core.Models;
using PicPaySimplificado.Core.Requests;
using PicPaySimplificado.Core.Responses;

namespace PicPaySimplificado.Api.Handlers;

public class UserTransactionHandler(
    DataContext context) : IUserTransactionHandler
{
   
    public async Task<Response<TransferRequest>> CreateAsync(TransferRequest request)
    {
        var payer = await context.Users.FindAsync(request.Payer);
        if (payer == null)
            return new Response<TransferRequest>(request, 404, "Usuário pagador não encontrado.");

        if (payer.Amount == 0 || payer.Amount < request.Value)
            return new Response<TransferRequest>(request, 400, "Usuário pagador sem saldo suficiente.");

        if (payer.UserType == Core.Enums.EUser.Merchant)
            return new Response<TransferRequest>(request, 400, "Logistas só recebem transferencias.");

        var payee = await context.Users.FindAsync(request.Payee);
        if (payee == null)
            return new Response<TransferRequest>(request, 404, "Usuário recebedor não encontrado.");
        
        try
        {
             await ProcessTransaction(context, request, payer, payee);
        }
        catch (Exception ex)
        {
            return new Response<TransferRequest>(request, 500, ex.Message);
        }     

        return new Response<TransferRequest>(request, 200, "Transferencia realizada com sucesso.");
    }
    private static async Task ProcessTransaction(DataContext context, TransferRequest request, User payer, User payee)
    {
        payer.Amount -= request.Value;
        payee.Amount += request.Value;

        var transaction = new UserTransaction
        {
            Amount = request.Value,
            Payer = payer,
            PayerId = payer.Id,
            Payee = payee,
            PayeeId = payee.Id,
            CreatedAt = DateTime.Now
        };

        context.Users.Update(payer);
        context.Users.Update(payee);
        await context.UserTransactions.AddAsync(transaction);
        await context.SaveChangesAsync();
    }
}
