

namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TransactionsNewConfiguration : IEntityTypeConfiguration<TransactionsNew>
    {
        public void Configure(EntityTypeBuilder<TransactionsNew> builder)
        {
            builder
                .ToTable("TransactionsNew");

            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Amount)
                .IsRequired();
            builder
                .Property(p => p.UserId)
                .IsRequired();
            builder
                .Property(p => p.SaldoAccount)
                .IsRequired();
        }
    }
}