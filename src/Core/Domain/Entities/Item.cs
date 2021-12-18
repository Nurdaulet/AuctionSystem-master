namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common;

    public class Item : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ItemCreatedYear { get; set; }
        public int Odometer { get; set; }
        public int HorsePower { get; set; }
        public int Doors { get; set; }
        public int Cylinders { get; set; }
        public string SteeringSide { get; set; }
        public decimal StartingPrice { get; set; }
        public decimal MinIncrease { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsEmailSent { get; set; } = false;
        public string UserId { get; set; }
        public AuctionUser User { get; set; }
        [ForeignKey("Category")]
        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }
        public Guid BodyTypeId { get; set; }
        public BodyType BodyType { get; set; }
        public Guid TransmissionTypeId { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public Guid ColorId { get; set; }
        public Color Color { get; set; }
        public Guid WarrantyId { get; set; }
        public Warranty Warranty { get; set; }
        public Guid FuelTypeId { get; set; }
        public FuelType FuelType { get; set; }
        public Guid RegionalSpecsId { get; set; }
        public RegionalSpecs RegionalSpecs { get; set; }
        public Guid SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public string WinnerUserId { get; set; }
        public ICollection<Bid> Bids { get; set; } = new HashSet<Bid>();
        public ICollection<Picture> Pictures { get; set; } = new HashSet<Picture>();
        public ICollection<ItemBadges> Badges { get; set; } = new List<ItemBadges>();
        public ICollection<ItemExtras> Extras { get; set; } = new List<ItemExtras>();
        public ICollection<ItemTechFeatures> TechFeatures { get; set; } = new List<ItemTechFeatures>();
    }
}