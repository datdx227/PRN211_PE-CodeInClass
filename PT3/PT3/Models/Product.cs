using System;
using System.Collections.Generic;

namespace PT3.Models
{
    public partial class Product
    {
        public string ProductCode { get; set; } = null!;
        public string ProductName { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public float? Price { get; set; }
        public string? Image { get; set; }
    }
}
