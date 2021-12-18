namespace Persistence.Configurations
{
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemBadgesConfiguration : IEntityTypeConfiguration<ItemBadges>
    {
        public void Configure(EntityTypeBuilder<ItemBadges> builder)
        {
            builder
                .ToTable("ItemBadges");
            builder
                .HasKey(p => new { p.BadgesId, p.ItemId });
            builder
            .HasOne(x => x.Item)
            .WithMany(u => u.Badges) 
            .HasForeignKey(aa => aa.ItemId);
        }
    }
}