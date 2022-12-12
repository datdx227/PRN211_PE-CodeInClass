using System;
using System.Collections.Generic;

namespace PT3.Models
{
    public partial class Customer
    {
        public string CustomerCode { get; set; } = null!;
        public string CustomerName { get; set; } = null!;
        public bool Gender { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
    }
}
