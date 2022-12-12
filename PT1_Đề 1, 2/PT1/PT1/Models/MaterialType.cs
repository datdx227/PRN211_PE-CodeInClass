using System;
using System.Collections.Generic;

namespace PT1.Models
{
    public partial class MaterialType
    {
        public int MaterialTypeId { get; set; }
        public string MaterialTypeCode { get; set; } = null!;
        public string MaterialTypeName { get; set; } = null!;
        public byte MaterialGroupId { get; set; }
        public bool IsDetail { get; set; }
    }
}
