using System;
using System.Collections.Generic;

namespace Perekyp.Models
{
    public partial class PurchaseStatus
    {
        public int IdPurchaseStatus { get; set; }
        public string PurchaseStatus1 { get; set; } = null!;
        public int IdBuyer { get; set; }
        public int IdAuto { get; set; }
        public int IdSalesman { get; set; }

        public virtual Auto IdAutoNavigation { get; set; } = null!;
        public virtual Buyer IdBuyerNavigation { get; set; } = null!;
        public virtual Salesman IdSalesmanNavigation { get; set; } = null!;
    }
}
