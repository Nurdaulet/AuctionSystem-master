namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ExtrasConfiguration : IEntityTypeConfiguration<Extras>
    {
        public void Configure(EntityTypeBuilder<Extras> builder)
        {
            builder
                .ToTable("Extras");

            builder
                .HasKey(p => p.Id);
        }
    }
}