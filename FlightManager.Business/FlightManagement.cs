using FlightManager.Business.Implementation;
using FlightManager.Business.Interfaces;
using FlightManager.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Device.Location;
using System.Linq;

namespace FlightManager.Business
{
    public class FlightManagement
    {
        private IRepository<Flight> _flightProvider = null;
        private double FuelConsuptionPer100Km;

        public FlightManagement()
        {
            _flightProvider = new Repository<Flight>();
            FuelConsuptionPer100Km = Convert.ToDouble(ConfigurationManager.AppSettings["FuelConsuptionPer100Km"]);
        }

        public int AddFlight(Flight newFlight)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                // Calculate Fuel Consuption
                newFlight.DepartureAirport = unitOfWork.DataContext.Airports.Where(e => e.AirportId == newFlight.DepartureAirportID).FirstOrDefault();
                newFlight.DestinationAirport = unitOfWork.DataContext.Airports.Where(e => e.AirportId == newFlight.DestinationAirportID).FirstOrDefault();
                newFlight.FuelConsuption = GetFuelConsuption(newFlight.DepartureAirport, newFlight.DestinationAirport);
                unitOfWork.DataContext.Flights.Add(newFlight);
                unitOfWork.Commit();
                return newFlight.FlightId;
            }
        }

        public List<Flight> GetFlights()
        {
            string[] includs = { "DepartureAirport", "DestinationAirport"};
            return _flightProvider.GetAll(q => q.OrderBy(d => d.FlightId), includs).ToList();
        }

        public double GetFuelConsuption(Airport departureAirport, Airport destinationAirport)
        {
            var sCoord = new GeoCoordinate(departureAirport.Latitude, departureAirport.Longitude);
            var eCoord = new GeoCoordinate(destinationAirport.Latitude, destinationAirport.Longitude);
            var kmDistance  = sCoord.GetDistanceTo(eCoord) / 1000;
            return (kmDistance / 100) * FuelConsuptionPer100Km;
        }
    }
}
