using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlightManager.Model
{
    public class Airport
    {
        public Airport()
        {
            this.Flights = new List<Flight>();
        }
        [Key]
        public int AirportId { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
