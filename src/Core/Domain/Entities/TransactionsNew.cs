
using System;
using Domain.Common;

namespace Domain.Entities
{
    public class TransactionsNew: AuditableEntity
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public decimal SaldoAccount { get; set; }
        public string UserId { get; set; }
        public AuctionUser User { get; set; }
        public int ClassOfTransaction { get; set; }
        public Guid? ItemId { get; set; }
    }
}