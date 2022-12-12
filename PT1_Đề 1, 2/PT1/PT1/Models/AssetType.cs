using System;
using System.Collections.Generic;

namespace PT1.Models
{
    public partial class AssetType
    {
        public int AssetTypeId { get; set; }
        public string AssetTypeCode { get; set; } = null!;
        public string AssetTypeName { get; set; } = null!;
        public byte AssetTypeGroupId { get; set; }
        public bool IsDetail { get; set; }
    }
}
