using PicPaySimplificado.Core.Requests;
using PicPaySimplificado.Core.Responses;

namespace PicPaySimplificado.Core.Handlers;

public interface IUserTransactionHandler
{
    Task<Response<TransferRequest>> CreateAsync(TransferRequest request);
}