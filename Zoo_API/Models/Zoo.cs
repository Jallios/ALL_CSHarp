using System;
using System.Collections.Generic;

namespace Zoo_API.Models
{
    public partial class Zoo
    {
        public int? IdZoo { get; set; }
        public string? NameZoo { get; set; } = null!;
        public string? Adress { get; set; } = null!;
        public DateTime? DateSwap { get; set; }
        public int? SsId { get; set; }
    }
}
