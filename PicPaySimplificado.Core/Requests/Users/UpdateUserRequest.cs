using PicPaySimplificado.Core.Enums;

namespace PicPaySimplificado.Core.Requests.Users;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public decimal Amount { get; set; }

    public EUser UserType { get; set; } = EUser.Common;
}