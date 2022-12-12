using System;
using System.Collections.Generic;

namespace Q2.Models
{
    public partial class Service
    {
        public int Id { get; set; }
        public string? RoomTitle { get; set; }
        public byte? Month { get; set; }
        public int? Year { get; set; }
        public string? FeeType { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Employee { get; set; }

        public virtual Employee? EmployeeNavigation { get; set; }
        public virtual Room? RoomTitleNavigation { get; set; }
    }
}
