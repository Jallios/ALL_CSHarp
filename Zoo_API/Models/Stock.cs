using System;
using System.Collections.Generic;

namespace Zoo_API.Models
{
    public partial class Stock
    {
        public int? IdComponent { get; set; }
        public string? NameComponent { get; set; } = null!;
        public decimal? Quality { get; set; }
    }
}
