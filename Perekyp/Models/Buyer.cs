using System;
using System.Collections.Generic;

namespace Perekyp.Models
{
    public partial class Buyer
    {
        public Buyer()
        {
            PurchaseStatuses = new HashSet<PurchaseStatus>();
        }

        public int IdBuyer { get; set; }
        public string SurnameBuyer { get; set; } = null!;
        public string NameBuyer { get; set; } = null!;
        public string PatronymicBuyer { get; set; } = null!;
        public string SeriNumBuyer { get; set; } = null!;
        public string MobileNumberBuyer { get; set; } = null!;
        public string LoginBuyer { get; set; } = null!;
        public string PasswordBuyer { get; set; } = null!;

        public virtual ICollection<PurchaseStatus> PurchaseStatuses { get; set; }
    }
}
