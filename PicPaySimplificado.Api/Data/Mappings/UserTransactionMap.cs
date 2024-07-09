using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PicPaySimplificado.Core.Models;

namespace PicPaySimplificado.Api.Data.Mappings;

public class UserTransactionMap : IEntityTypeConfiguration<UserTransaction>
{
    public void Configure(EntityTypeBuilder<UserTransaction> builder)
    {
        builder.ToTable("Transactions").HasKey(x => x.Id);

        builder.Property(x => x.Id);

        builder.Property(x => x.Amount).HasPrecision(18,4);
        builder.Property(x => x.CreatedAt);

         builder.Property(x => x.PayerId);
         builder.Property(x => x.PayeeId);
    }
}