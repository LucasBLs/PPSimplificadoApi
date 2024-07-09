using PicPaySimplificado.Core.Enums;
using PicPaySimplificado.Core.Models;
using PicPaySimplificado.Core.Requests.Users;
using PicPaySimplificado.Core.Responses;

namespace PicPaySimplificado.Core.Handlers;

public interface IUserHandler
{
    Task<Response<User>> GetUserByIdAsync(int id);
    Task<Response<User>> GetUserByDocumentAsync(string document);
    Task<Response<User>> GetUserByEmailAsync(string email);
    Task<Response<List<User>>> GetUsersByTypeAsync(EUser type);
    Task<Response<List<User>>> GetAllUsersAsync();

    Task<Response<User>> Create(CreateUserRequest request);
    Task<Response<User>> Update(UpdateUserRequest request);
    Task<Response<User>> Delete(DeleteUserRequest request);
}