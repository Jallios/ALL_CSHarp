﻿using System;
using System.Collections.Generic;

namespace Zoo_API.Models
{
    public partial class Aviary
    {
        public int? IdAviary { get; set; }
        public decimal? Square { get; set; }
        public string? Parametrs { get; set; } = null!;
    }
}
