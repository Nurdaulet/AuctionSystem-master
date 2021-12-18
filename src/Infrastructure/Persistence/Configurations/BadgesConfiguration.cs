namespace Persistence.Configurations
{
    using Common;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class BadgesConfiguration : IEntityTypeConfiguration<Badges>
    {
        public void Configure(EntityTypeBuilder<Badges> builder)
        {
            builder
                .ToTable("Badges");

            builder
                .HasKey(p => p.Id);
        }
    }
}