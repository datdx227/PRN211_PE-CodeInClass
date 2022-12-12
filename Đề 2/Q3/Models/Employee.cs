using System;
using System.Collections.Generic;

namespace Q3.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Services = new HashSet<Service>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string? Phone { get; set; }
        public string? Idnumber { get; set; }

        public virtual ICollection<Service> Services { get; set; }
    }
}
