using System;
using System.Collections.Generic;
using System.Text;

namespace Labb1.EntityFramework.Entities
{
    public class HolidayApplication
    {
        public long Id { get; set; }
        public Employee Employee { get; set; }
        public HolidayType Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ApplicationDate { get; set; }
    }
}
