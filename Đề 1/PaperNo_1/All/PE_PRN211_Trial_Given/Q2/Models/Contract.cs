using System;
using System.Collections.Generic;

#nullable disable

namespace Q2.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SignedDate { get; set; }
        public string Type { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
