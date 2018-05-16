
namespace FlightManager.Model.Mapping
{
using System.Data.Entity.ModelConfiguration;

    public class AirportMap : EntityTypeConfiguration<Airport>
    {
        public AirportMap()
        {
            this.HasKey(t => t.ID);

            this.ToTable("Airport");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.Name).HasColumnName("Name");

            this.HasMany(t => t.Flights)
                .WithMany(t => t.DepartureAirportID)
                .HasForeignKey(d => d.);
        }
    }
}
