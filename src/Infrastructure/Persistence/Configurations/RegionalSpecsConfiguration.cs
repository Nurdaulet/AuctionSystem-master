namespace Persistence.Configurations
{
    using Common;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RegionalSpecsConfiguration : IEntityTypeConfiguration<RegionalSpecs>
    {
        public void Configure(EntityTypeBuilder<RegionalSpecs> builder)
        {
            builder
                .ToTable("RegionalSpecs");      
            builder
                .HasKey(p => p.Id);
        }
    }
}