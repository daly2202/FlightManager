namespace FlightManager.Model.Mapping
{
    using System.Data.Entity.ModelConfiguration;

    public class FlightMap : EntityTypeConfiguration<Flight>
    {
        public FlightMap()
        {
            this.HasKey(t => t.ID);

            this.ToTable("Flight");
            this.Property(t => t.ID).HasColumnName("ID");
            //this.Property(t => t.DepartureAirportID).HasColumnName("DepartureAirportID");
            this.Property(t => t.DestinationAirportID).HasColumnName("DestinationAirportID");
            this.Property(t => t.FuelConsuption).HasColumnName("FuelConsuption");
            
            
        }
    }
}
