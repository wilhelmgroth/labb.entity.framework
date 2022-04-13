using Labb1.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labb1.EntityFramework
{
    public class Startup
    {
        private static HolidayType[] holidayTypes = new HolidayType[]
        {
            new HolidayType { Name = "VAB" },
            new HolidayType { Name = "Semester" },
            new HolidayType { Name = "Sjuk" },
            new HolidayType { Name = "Övrigt" },
            new HolidayType { Name = "Begravning" }
        };

        private static Employee[] employees = new Employee[]
        {
            new Employee { Firstname = "Phoebe", Lastname = "Buffay"},
            new Employee { Firstname = "Ross", Lastname = "Geller"},
            new Employee { Firstname = "Chandler", Lastname = "Bing"},
            new Employee { Firstname = "Monica", Lastname = "Geller"},
        };

        public static void SeedThis(WGABContext context)
        {
            var holidayTypesInDb = context.HolidayTypes.ToList();
            var employeesInDb = context.Employees.ToList();

            foreach (var row in holidayTypes)
            {
                if (!holidayTypesInDb.Any(x => x.Name == row.Name))
                {
                    context.HolidayTypes.Add(row);
                }
            }

            foreach (var row in employees)
            {
                if (!employeesInDb.Any(x => x.Firstname == row.Firstname && x.Lastname == row.Lastname))
                {
                    context.Employees.Add(row);
                }
            }



            context.SaveChanges();
        }
    }
}
