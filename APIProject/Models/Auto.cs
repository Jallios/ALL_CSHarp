using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class Auto
    {
        public int? IdAuto { get; set; }
        public string? Brand { get; set; } = null!;
        public int? IdHistoryAuto { get; set; }
        public string? BodyType { get; set; } = null!;
        public string? Kpp { get; set; } = null!;
        public int? EnginePower { get; set; }
        public string? DriveUnit { get; set; } = null!;
        public int? WeightKg { get; set; }
        public DateTime? YearOfIssue { get; set; }

    }
}
