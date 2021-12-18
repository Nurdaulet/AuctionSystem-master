namespace Domain.Entities
{
    using System;
    using Common;

    public class Color : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}