using System;
using System.Collections.Generic;

namespace Q3.Models
{
    public partial class Contract
    {
        public int Id { get; set; }
        public string Code { get; set; } = null!;
        public int CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SignedDate { get; set; }
        public string Type { get; set; } = null!;

        public virtual Customer Customer { get; set; } = null!;
        public virtual Employee Employee { get; set; } = null!;


    }
}
