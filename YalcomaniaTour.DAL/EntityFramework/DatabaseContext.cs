using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YalcomaniaTour.Entities;

namespace YalcomaniaTour.DAL.EntityFramework
{
    public class DatabaseContext:DbContext
    {
        public DbSet<TourUser> TourUsers { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Revenue> Revenues { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Pas> Pas { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new MyInitializer());
        }
    }
}
