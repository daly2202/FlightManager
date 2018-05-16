namespace FlightManager.DAL
{
    using FlightManager.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Configuration;

    /// <summary>
    /// Flight manager context
    /// </summary>
    public partial class FlightManagerContext : DbContext
    {
        static FlightManagerContext()
        {
            Database.SetInitializer<FlightManagerContext>(null);
        }

        public FlightManagerContext()
            : base("Name=FlightManagerContext")
        {
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>()
                .HasRequired<Airport>(s => s.DepartureAirport)
                .WithMany(g => g.Flights)
                .HasForeignKey<int>(s => s.DepartureAirportID);
        }
    }
}
