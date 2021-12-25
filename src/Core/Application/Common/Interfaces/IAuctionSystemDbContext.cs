namespace Application.Common.Interfaces
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public interface IAuctionSystemDbContext
    {
        DbSet<Category> Categories { get; set; }

        DbSet<SubCategory> SubCategories { get; set; }

        DbSet<Item> Items { get; set; }

        DbSet<Bid> Bids { get; set; }
        DbSet<TransactionsNew> TransactionsNew { get; set; }
        DbSet<Picture> Pictures { get; set; }

        DbSet<AuctionUser> Users { get; set; }
        DbSet<SaldoUser> SaldoUsers { get; set; }

        DbSet<RefreshToken> RefreshTokens { get; set; }
        DbSet<Badges> Badges { get; set; }
        DbSet<BodyType> BodyTypes { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Extras> Extras { get; set; }
        DbSet<FuelType> FuelTypes { get; set; }
        DbSet<ItemBadges> ItemBadges { get; set; }
        DbSet<ItemExtras> ItemExtras { get; set; }
        DbSet<ItemTechFeatures> ItemTechFeatures { get; set; }
        DbSet<RegionalSpecs> RegionalSpecs { get; set; }
        DbSet<SellerType> SellerTypes { get; set; }
        DbSet<TechFeatures> TechFeatures { get; set; }
        DbSet<TransmissionType> TransmissionTypes { get; set; }
        DbSet<Warranty> Warranties { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}