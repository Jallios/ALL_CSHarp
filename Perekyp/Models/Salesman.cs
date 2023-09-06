using System;
using System.Collections.Generic;

namespace Perekyp.Models
{
    public partial class Salesman
    {
        public Salesman()
        {
            PurchaseStatuses = new HashSet<PurchaseStatus>();
        }

        public int IdSalesman { get; set; }
        public string SurnameSalesman { get; set; } = null!;
        public string NameSalesman { get; set; } = null!;
        public string PatronymicSalesman { get; set; } = null!;
        public string SeriNumSalesman { get; set; } = null!;
        public string MobileNumberSalesman { get; set; } = null!;
        public string LoginSalesman { get; set; } = null!;
        public string PasswordSalesman { get; set; } = null!;

        public virtual ICollection<PurchaseStatus> PurchaseStatuses { get; set; }
    }
}
