﻿using System;
using System.Collections.Generic;

namespace Zoo_API.Models
{
    public partial class VaccinationCard
    {
        public int? IdVaccination { get; set; }
        public int? NumberCardVaccination { get; set; }
        public string? Drug { get; set; } = null!;
        public DateTime? DateTimeVaccination { get; set; }
        public int? AnimalId { get; set; }
    }
}
