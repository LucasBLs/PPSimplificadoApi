using System.Text.Json.Serialization;
using PicPaySimplificado.Core.Enums;

namespace PicPaySimplificado.Core.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    public string Password { get; set; } = string.Empty;
    public decimal Amount { get; set; }

    public EUser UserType { get; set; } = EUser.Common;

    [JsonIgnore]
    public List<UserTransaction> PayerTransactions { get; set; } = [];
    [JsonIgnore]
    public List<UserTransaction> PayeeTransactions { get; set; } = [];
}