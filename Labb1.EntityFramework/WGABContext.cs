using Labb1.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Labb1.EntityFramework
{
    public class WGABContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<HolidayApplication> HolidayApplications { get; set; }
        public DbSet<HolidayType> HolidayTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-D1QEIP0J\SQLEXPRESS;Initial Catalog=People;Integrated Security=True;");
        }
    }
}


