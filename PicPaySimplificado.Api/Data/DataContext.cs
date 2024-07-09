using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PicPaySimplificado.Core.Models;

namespace PicPaySimplificado.Api.Data;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserTransaction> UserTransactions { get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
}
