using System;
using System.Collections.Generic;

namespace PEREKYP2.Models
{
    public partial class PurchaseStatus
    {
        public int IdPurchaseStatus { get; set; }
        public string PurchaseStatus1 { get; set; } = null!;
        public int AutoId { get; set; }
        public int UserId { get; set; }

        public virtual Auto Auto { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
