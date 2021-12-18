namespace Persistence.Configurations
{
    using Common;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class SellerTypeConfiguration : IEntityTypeConfiguration<SellerType>
    {
        public void Configure(EntityTypeBuilder<SellerType> builder)
        {
            builder
                .ToTable("SellerTypes");
            builder
                .HasKey(p => p.Id);

        }
    }
}