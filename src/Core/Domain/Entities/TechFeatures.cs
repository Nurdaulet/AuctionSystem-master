namespace Domain.Entities
{
    using System;
    using Common;

    public class TechFeatures : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}