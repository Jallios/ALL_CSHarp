using System;
using System.Collections.Generic;

namespace PEREKYP2.Models
{
    public partial class HistoryAuto
    {
        public HistoryAuto()
        {
            Autos = new HashSet<Auto>();
        }

        public int IdHistoryAuto { get; set; }
        public int Milleage { get; set; }
        public int Accidents { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
