namespace Domain.Entities
{
    using System;
    using Common;

    public class Extras : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}