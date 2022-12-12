using System;
using System.Collections.Generic;

namespace Q2.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string? Sex { get; set; }
        public string? Position { get; set; }
        public int? Department { get; set; }

        public virtual Department? DepartmentNavigation { get; set; }
    }
}
