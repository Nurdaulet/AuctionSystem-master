namespace Persistence.Configurations
{
    using Common;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class TechFeaturesConfiguration : IEntityTypeConfiguration<TechFeatures>
    {
        public void Configure(EntityTypeBuilder<TechFeatures> builder)
        {
            builder
                .ToTable("TechFeatures");
            builder
                .HasKey(p => p.Id);
        }
    }
}