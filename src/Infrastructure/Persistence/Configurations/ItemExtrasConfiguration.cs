namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemExtrasConfiguration : IEntityTypeConfiguration<ItemExtras>
    {
        public void Configure(EntityTypeBuilder<ItemExtras> builder)
        {
            builder
                .ToTable("ItemExtras");
            builder
                .HasKey(p => new { p.ExtrasId, p.ItemId });
            builder
            .HasOne(x => x.Item)
            .WithMany(u => u.Extras)
            .HasForeignKey(aa => aa.ItemId);
        }
    }
}