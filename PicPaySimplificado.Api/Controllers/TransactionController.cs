using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Core.Handlers;
using PicPaySimplificado.Core.Models;
using PicPaySimplificado.Core.Requests;
using PicPaySimplificado.Core.Responses;

namespace PicPaySimplificado.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController(
    IUserTransactionHandler transactionHandler,
    IAuthorizedServiceHandler authorizedHandler) : ControllerBase
{
    [HttpPost("transfer")]
    public async Task<IActionResult> UserValuesTransferAsync(
        TransferRequest request)
    {
        var authorized = await authorizedHandler.GetAuthorizedAsync();
        if(authorized?.IsSuccess == false)
            return BadRequest(authorized);

        var result = await transactionHandler.CreateAsync(request);

        if(!result.IsSuccess)
            return BadRequest(result);

        var userNotified = await authorizedHandler.NotifyUsers(request);
        if(userNotified.IsSuccess == false)
            return BadRequest(userNotified);

        return result.IsSuccess ? Created($"/{result.Data?.Payer}", result) : BadRequest(result);
    }
}