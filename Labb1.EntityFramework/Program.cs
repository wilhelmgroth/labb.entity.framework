using Labb1.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace Labb1.EntityFramework
{
    class Program
    {
        private static WGABContext context = new WGABContext();
        private static List<Employee> employees = context.Employees.ToList();
        private static List<HolidayType> holidayTypes = context.HolidayTypes.ToList();
        private static HolidayApplication holidayApplicationCurrent = new HolidayApplication();
        private static List<HolidayApplication> holidayApplications = context.HolidayApplications.ToList();




        static void Main(string[] args)
        {
            Startup.SeedThis(context);
            bool menu = true;

            while (menu)
            {
                Console.WriteLine("Hello there and welcome to your holiday");

                Console.WriteLine("1: Create a leave application.");
                Console.WriteLine("2: Search for a certain employee.");
                Console.WriteLine("3: Get all leave applications for a certain month. ");
                int number = int.Parse(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Create a holiday application - Login");
                        HandleMenu(() => Login());
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine(" Search for a certain employee.");
                        HandleMenu(() => SearchEmployee());
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Get all leave applications for a certain month.");
                        HandleMenu(() => GetAllApplications());
                        break;

                    default:
                        Console.WriteLine("lol");
                        break;
                }

            };



        }

        private static void HandleMenu(Action action)
        {
            action();
            Console.ReadLine();
            Console.Clear();
        }

        public static void AddPerson()
        {

        }


        public static void Login()
        {
            Console.WriteLine("Employees: ");
            foreach (var x in employees)
                Console.WriteLine(x.Firstname + " " + x.Lastname);

            Console.WriteLine(" ");
            Console.WriteLine(" Enter your firstname and then click enter to login. Your firstname must be in the list above. ");
            string name = Console.ReadLine();

            if (employees.Any(x => x.Firstname == name))
            {
                Console.WriteLine("Succesful login");
                holidayApplicationCurrent.Employee = employees.Where(x => x.Firstname == name).FirstOrDefault();
                HandleMenu(() => ChooseHoliday());
            }
            else
                Console.WriteLine("incorrext");
        }


        public static void ChooseHoliday()
        {
            foreach (var x in holidayTypes)
                Console.WriteLine(x.Name);

            Console.WriteLine("");
            Console.WriteLine("Enter your holiday type and then click enter to continue. Your holidaytype must be in the list above");
            string holidayType = Console.ReadLine();

            if (holidayTypes.Any(x => x.Name == holidayType))
            {
                Console.WriteLine("Succesful");
                holidayApplicationCurrent.Type = holidayTypes.Where(x => x.Name == holidayType).FirstOrDefault();
                HandleMenu(() => ChooseStartDate());
            }
            else
                Console.WriteLine("Do better....");
        }

        public static void ChooseStartDate()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Choose Start date - Input Format 'MM/DD/YYYY' ");
                var inputtedStartData = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(inputtedStartData.Date.ToShortDateString());
                Console.WriteLine("");
                Console.WriteLine($"Your startdate is {inputtedStartData.ToLongDateString()}");
                Console.WriteLine(" ");
                Console.WriteLine("Verify by click 1 for continue to choose End date or 2 for change");
                int number = int.Parse(Console.ReadLine());
                if (number == 1)
                    ChooseEndDate(inputtedStartData);
                if (number == 2)
                    ChooseStartDate();
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ajajajajaj....");
                Console.ReadKey();
                ChooseStartDate();
            };
        }

        public static void ChooseEndDate(DateTime inputtedStartData)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Choose End date - Input Format 'MM/DD/YYYY' ");
                var inputtedEndData = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(inputtedEndData.Date.ToShortDateString());
                Console.WriteLine("");
                Console.WriteLine($"Your End is {inputtedEndData.ToLongDateString()}");
                Console.WriteLine(" ");

                Console.WriteLine($"Your holiday starts {inputtedStartData.ToLongDateString()} and ends {inputtedEndData.ToLongDateString()}");

                holidayApplicationCurrent.StartDate = new DateTime(inputtedStartData.Ticks);
                holidayApplicationCurrent.EndDate = new DateTime(inputtedEndData.Ticks);
                holidayApplicationCurrent.ApplicationDate = DateTime.Now;

                context.HolidayApplications.Add(holidayApplicationCurrent);
                context.SaveChanges();

                Console.WriteLine("Application succesfully confirmed");
            }
            catch (FormatException e)
            {
                Console.WriteLine("Wrong input format");
                Console.ReadKey();
                ChooseEndDate(inputtedStartData);
            }
        }

        public static void SearchEmployee()
        {
            Console.WriteLine("Search for a certain person. Only firstname. (Case-sensitive)");
            Console.WriteLine("");
            foreach (var x in employees)
                Console.WriteLine(x.Firstname + " " + x.Lastname);


            var nameSearch = Console.ReadLine();

            foreach (var x in holidayApplications)
            {
                if (nameSearch == x.Employee.Firstname)
                {
                    Console.WriteLine($"Its a match.  {x.StartDate.ToLongDateString()} to {x.EndDate.ToLongDateString()} ");
                }
            }

        }

        public static void GetAllApplications()
        {
            Console.WriteLine("Search for months: ");

            int number = int.Parse(Console.ReadLine());
            var applications = context.HolidayApplications.Where(x => x.StartDate.Month == number).ToList();
            Console.WriteLine(CultureInfo.CurrentUICulture.DateTimeFormat.MonthNames[number - 1]);


            if (applications.Count != 0)
            {
                foreach (var x in applications)
                {
                    if (number == x.StartDate.Month)
                    {
                        Console.WriteLine($"Name: {x.Employee.Firstname} {x.Employee.Lastname} \nApplication date: {x.ApplicationDate.ToLongDateString()}  ");
                        Console.WriteLine($"Holiday from {x.StartDate.ToLongDateString()} to {x.EndDate.ToLongDateString()}");
                        Console.WriteLine($"Reason: {x.Type.Name}");
                        Console.WriteLine();

                    }
                }
            }
            else
                Console.WriteLine("No leave applications this month.");


        }

    }
}

