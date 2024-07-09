using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Api.Data;
using PicPaySimplificado.Core.Enums;
using PicPaySimplificado.Core.Handlers;
using PicPaySimplificado.Core.Models;
using PicPaySimplificado.Core.Requests.Users;
using PicPaySimplificado.Core.Responses;

namespace PicPaySimplificado.Api.Handlers;

public class UserHandler(DataContext context) : IUserHandler
{
    public async Task<Response<User>> Create(CreateUserRequest request)
    {
        try
        {
            var userExists = await context.Users.AnyAsync(x => x.Email == request.Email || x.Document == request.Document);
            if (userExists)
                return new Response<User>(null, 400, "usuário já cadastrado.");

            var user = new User
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Document = request.Document,
                Password = request.Password,
                UserType = request.UserType,
                Amount = request.Amount
            };

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            return new Response<User>(user, 200);
        }
        catch (System.Exception ex)
        {
            return new Response<User>(null, 500, ex.Message);
        }
    }
       public async Task<Response<User>> Update(UpdateUserRequest request)
    {
        try
        {
            var user = await context.Users.FindAsync(request.Id);

            if (user == null)
                return new Response<User>(null, 404, "User not found");

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Password = request.Password;
            user.UserType = request.UserType;
            user.Amount = request.Amount;

            context.Users.Update(user);
            await context.SaveChangesAsync();

            return new Response<User>(user, 200);
        }
        catch (Exception ex)
        {
            return new Response<User>(null, 500, ex.Message);
        }
    }
    public async Task<Response<User>> Delete(DeleteUserRequest request)
    {
        try
        {
            var user = await context.Users.FindAsync(request.Id);

            if (user == null)
                return new Response<User>(null, 404, "User not found");

            context.Users.Remove(user);
            await context.SaveChangesAsync();

            return new Response<User>(user, 200);
        }
        catch (Exception ex)
        {
            return new Response<User>(null, 500, ex.Message);
        }
    }

    public async Task<Response<List<User>>> GetAllUsersAsync()
    {
        try
        {
            var users = await context.Users.AsNoTracking().ToListAsync();
            return new Response<List<User>>(users, 200);
        }
        catch (Exception ex)
        {
            return new Response<List<User>>(null, 500, ex.Message);
        }
    }
    public async Task<Response<User>> GetUserByDocumentAsync(string document)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Document == document);
            return new Response<User>(user, 200);
        }
        catch (Exception ex)
        {
            return new Response<User>(null, 500, ex.Message);
        }
    }
    public async Task<Response<User>> GetUserByEmailAsync(string email)
    {
        try
        {
            var user = await context.Users.FirstOrDefaultAsync(x => x.Email == email);
            return new Response<User>(user, 200);
        }
        catch (Exception ex)
        {
            return new Response<User>(null, 500, ex.Message);
        }
    }
    public async Task<Response<User>> GetUserByIdAsync(int id)
    {
        try
        {
            var user = await context.Users.FindAsync(id);
            return new Response<User>(user, 200);
        }
        catch (Exception ex)
        {
            return new Response<User>(null, 500, ex.Message);
        }
    }
    public async Task<Response<List<User>>> GetUsersByTypeAsync(EUser type)
    {
        try
        {
            var users = await context.Users.Where(x => x.UserType == type).ToListAsync();
            return new Response<List<User>>(users, 200);
        }
        catch (Exception ex)
        {
            return new Response<List<User>>(null, 500, ex.Message);
        }
    }
}