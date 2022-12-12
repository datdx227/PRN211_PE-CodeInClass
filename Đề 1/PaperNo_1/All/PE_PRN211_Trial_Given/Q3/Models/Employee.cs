using System;
using System.Collections.Generic;

namespace Q3.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Contracts = new HashSet<Contract>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public bool Male { get; set; }
        public float Salary { get; set; }
        public string Phone { get; set; } = null!;

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
