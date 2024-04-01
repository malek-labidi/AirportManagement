using AM.Core.Domain;
using AM.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data
{
    public class AMContext : DbContext
    {
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Staff> staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = Airport; 
                                        Integrated Security = true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new FlightConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());

            //modify all the properties "string" from nvarchar(max) to nvarchar(30)
            //fluent Api
            /* 
             * foreach (var entityType in modelBuilder.Model.GetEntityTypes())
             {
                 foreach (var property in entityType.GetProperties())
                 {
                     if (property.ClrType == typeof(string))
                     {
                         property.SetMaxLength(30);
                     }
                 }
             }**/

            //modify all the properties "dateTime" from datetime2 to date
            //Fluent api
            /*
             * foreach (var entityType in modelBuilder.Model.GetEntityTypes()) //all entities
            {
                foreach (var property in entityType.GetProperties()) //all properties
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        property.SetColumnType("date");
                    }
                }
            }*/
            


        }
        //with conventions
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //modify all the properties "string" from nvarchar(max) to nvarchar(30)
            //configurationBuilder.Properties<String>().HaveMaxLength(30);
            
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }
    }
}
