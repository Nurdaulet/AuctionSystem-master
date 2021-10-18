

namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SaldoUserConfiguration : IEntityTypeConfiguration<SaldoUser>
    {
        public void Configure(EntityTypeBuilder<SaldoUser> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder
                .Property(p => p.Saldo)
                .IsRequired();
        }
    }
}
