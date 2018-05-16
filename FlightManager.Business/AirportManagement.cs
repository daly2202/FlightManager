using FlightManager.Business.Implementation;
using FlightManager.Business.Interfaces;
using FlightManager.Model;
using System.Collections.Generic;
using System.Linq;

namespace FlightManager.Business
{
    public class AirportManagement
    {
        private IRepository<Airport> _airportProvider = null;

        public AirportManagement()
        {
            _airportProvider = new Repository<Airport>();
        }

        public int AddAirport(Airport newAirport)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                unitOfWork.DataContext.Airports.Add(newAirport);
                unitOfWork.Commit();
                return newAirport.AirportId;
            }
        }

        public List<Airport> GetAirports()
        {
            return _airportProvider.GetAll(q => q.OrderBy(d => d.AirportId)).ToList();
        }
    }
}
