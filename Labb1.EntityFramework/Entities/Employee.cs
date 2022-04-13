using System;
using System.Collections.Generic;
using System.Text;

namespace Labb1.EntityFramework.Entities
{
    public class Employee
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<HolidayApplication> HolidayApplications { get; set; }

    }



}
