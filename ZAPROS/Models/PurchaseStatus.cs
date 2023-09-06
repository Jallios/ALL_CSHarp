using System;
using System.Collections.Generic;

namespace ZAPROS.Models
{
    public partial class PurchaseStatus
    {
        public int? IdPurchaseStatus { get; set; }
        public string? PurchaseStatus1 { get; set; } = null!;
        public int? AutoId { get; set; }
        public int? UserId { get; set; }

    }
}
