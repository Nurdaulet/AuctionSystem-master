namespace Persistence.Configurations
{
    using Common;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemTechFeaturesConfiguration : IEntityTypeConfiguration<ItemTechFeatures>
    {
        public void Configure(EntityTypeBuilder<ItemTechFeatures> builder)
        {
            builder
                .ToTable("ItemTechFeatures");

            builder
                .HasKey(p => new { p.TechFeaturesId, p.ItemId });
            builder
            .HasOne(x => x.Item)
            .WithMany(u => u.TechFeatures)
            .HasForeignKey(aa => aa.ItemId);
        }
    }
}