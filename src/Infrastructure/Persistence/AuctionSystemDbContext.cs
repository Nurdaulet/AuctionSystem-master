namespace Persistence
{
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Common;
    using Domain.Common;
    using Domain.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class AuctionSystemDbContext : IdentityDbContext<AuctionUser>, IAuctionSystemDbContext
    {
        private readonly ICurrentUserService currentUserService;
        private readonly IDateTime dateTime;

        public AuctionSystemDbContext(DbContextOptions<AuctionSystemDbContext> options)
            : base(options) { }

        public AuctionSystemDbContext(
            DbContextOptions<AuctionSystemDbContext> options,
            IDateTime dateTime,
            ICurrentUserService currentUserService)
            : base(options)
        {
            this.dateTime = dateTime;
            this.currentUserService = currentUserService;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Badges> Badges { get; set; }
        public DbSet<BodyType> BodyTypes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Extras> Extras { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<ItemBadges> ItemBadges { get; set; }
        public DbSet<ItemExtras> ItemExtras { get; set; }
        public DbSet<ItemTechFeatures> ItemTechFeatures { get; set; }
        public DbSet<RegionalSpecs> RegionalSpecs { get; set; }
        public DbSet<SellerType> SellerTypes { get; set; }
        public DbSet<TechFeatures> TechFeatures { get; set; }
        public DbSet<TransmissionType> TransmissionTypes { get; set; }
        public DbSet<Warranty> Warranties { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<TransactionsNew> TransactionsNew { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<SaldoUser> SaldoUsers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in this.ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = this.currentUserService?.UserId;
                        entry.Entity.Created = this.dateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = this.currentUserService?.UserId;
                        entry.Entity.LastModified = this.dateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuctionSystemDbContext).Assembly);
        }
    }
}