using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPaySimplificado.Core.Models;

namespace PicPaySimplificado.Api.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
       builder.ToTable("Users").HasKey(x => x.Id);

       builder.Property(x => x.Id);

       builder.Property(x => x.Name).HasMaxLength(50);
       builder.Property(x => x.LastName).HasMaxLength(50);
       builder.Property(x => x.Document).HasMaxLength(11);
       builder.Property(x => x.Email).HasMaxLength(150);
       builder.Property(x => x.Password).HasMaxLength(100);
       builder.Property(x => x.UserType);
       builder.Property(x => x.Amount).HasPrecision(18,4);

       builder.HasIndex(x => x.Document).IsUnique();
       builder.HasIndex(x => x.Email).IsUnique();

       builder.HasMany(x => x.PayerTransactions)
        .WithOne(x => x.Payer)
        .HasForeignKey(x => x.PayerId)
        .OnDelete(DeleteBehavior.NoAction);
        
       builder.HasMany(x => x.PayeeTransactions)
        .WithOne(x => x.Payee)
        .HasForeignKey(x => x.PayeeId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}