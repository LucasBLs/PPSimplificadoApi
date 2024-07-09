namespace PicPaySimplificado.Core.Models;

public class UserTransaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }

    public User? Payer { get; set; }
    public int PayerId { get; set; }

    public User? Payee { get; set; }
    public int PayeeId { get; set; }
}