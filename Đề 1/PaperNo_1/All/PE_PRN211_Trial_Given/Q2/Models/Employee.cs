using System;
using System.Collections.Generic;

#nullable disable

namespace Q2.Models
{
    public partial class Employee
    {
        public Employee()
        {
            Contracts = new HashSet<Contract>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public bool Male { get; set; }
        public float Salary { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }
    }
}
