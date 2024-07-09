using PicPaySimplificado.Core.Models;
using PicPaySimplificado.Core.Requests;
using PicPaySimplificado.Core.Responses;

namespace PicPaySimplificado.Core.Handlers;

public interface IAuthorizedServiceHandler
{
    Task<Response<Authorized>?> GetAuthorizedAsync();
    Task<Response<bool>> NotifyUsers(TransferRequest request);
}