using System;
using System.Collections.Generic;

namespace WinForms_EF.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public DateTime Birthdate { get; set; }
        public bool Gender { get; set; }
        public string? Address { get; set; }
    }
}
