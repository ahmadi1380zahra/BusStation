using BusStationEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusStationEF
{
    public class EFDataContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<JourneySeat> JourneySeats { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=BusStationEF;User ID = sa; Password = 123;TrustServerCertificate = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFDataContext).Assembly);
        }
    }
}
