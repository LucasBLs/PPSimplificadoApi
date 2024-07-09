using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Core.Enums;
using PicPaySimplificado.Core.Handlers;
using PicPaySimplificado.Core.Requests.Users;

namespace PicPaySimplificado.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController(IUserHandler handler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request)
    {
        var response = await handler.Create(request);
        if(response.IsSuccess == false)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateUserRequest request)
    {
        var response = await handler.Update(request);
        if(response.IsSuccess == false)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var request = new DeleteUserRequest { Id = id };
        var response = await handler.Delete(request);
        if(response.IsSuccess == false)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("get-all")]
    public async Task<IActionResult> GetAllUsersAsync()
    {
        var response = await handler.GetAllUsersAsync();
        if(response.IsSuccess == false)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserByIdAsync(int id)
    {
        var response = await handler.GetUserByIdAsync(id);
        if(response.IsSuccess == false)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("email/{email}")]
    public async Task<IActionResult> GetUserByEmailAsync(string email)
    {
        var response = await handler.GetUserByEmailAsync(email);
        if(response.IsSuccess == false)
            return BadRequest(response);
    
        return Ok(response);
    }

    [HttpGet("document/{document}")]
    public async Task<IActionResult> GetUserByDocumentAsync(string document)
    {
        var response = await handler.GetUserByDocumentAsync(document);
        if(response.IsSuccess == false)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpGet("type/{type}")]
    public async Task<IActionResult> GetUsersByTypeAsync(EUser type)
    {
        var response = await handler.GetUsersByTypeAsync(type);
        if(response.IsSuccess == false)
            return BadRequest(response);

        return Ok(response);
    }
}