using System;
using System.Collections.Generic;

#nullable disable

namespace Q2.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Contracts = new HashSet<Contract>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public bool Male { get; set; }
        public DateTime Dob { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
