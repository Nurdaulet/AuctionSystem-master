namespace Domain.Entities
{
    using System;
    using Common;

    public class ItemExtras : AuditableEntity
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid ExtrasId { get; set; }
        public Extras Extras { get; set; }
    }
}