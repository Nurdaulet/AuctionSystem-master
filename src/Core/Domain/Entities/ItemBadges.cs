namespace Domain.Entities
{
    using System;
    using Common;

    public class ItemBadges : AuditableEntity
    {
        public Guid ItemId { get; set; }
        public Item Item { get; set; }
        public Guid BadgesId { get; set; }
        public Badges Badges { get; set; }
    }
}