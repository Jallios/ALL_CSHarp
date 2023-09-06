using System;
using System.Collections.Generic;

namespace Zoo_API.Models
{
    public partial class AnimalView
    {
        public string? Животное { get; set; } = null!;
        public decimal? Вес { get; set; }
        public decimal? Рост { get; set; }
        public int? НомерКарточкиБолезни { get; set; }
        public int? НомерВольера { get; set; }
    }
}
