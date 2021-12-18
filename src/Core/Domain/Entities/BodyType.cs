namespace Domain.Entities
{
    using System;
    using Common;

    public class BodyType : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}