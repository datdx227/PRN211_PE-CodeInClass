using System;
using System.Collections.Generic;

namespace Q3.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public bool Male { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; } = null!;

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
