using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Model
{
    /// <summary>
    /// Flight class
    /// </summary>
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        public int DepartureAirportID { get; set; }
        
        public int DestinationAirportID { get; set; }

        [DisplayFormat(DataFormatString = "{0:n0}")]
        public double FuelConsuption { get; set; }

        [ForeignKey("DepartureAirportID")]
        public virtual Airport DepartureAirport { get; set; }

        [ForeignKey("DestinationAirportID")]
        public virtual Airport DestinationAirport { get; set; }
    }
}
