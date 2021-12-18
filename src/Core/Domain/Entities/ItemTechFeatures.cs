namespace Domain.Entities
{
    using System;
    using Common;

    public class ItemTechFeatures : AuditableEntity
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid TechFeaturesId { get; set; }
        public TechFeatures TechFeatures { get; set; }
    }
}