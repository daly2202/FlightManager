using FlightManager.Business;
using FlightManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlightManager.Web.Controllers
{
    public class FlightController : Controller
    {
        private FlightManagement _flightProvider = null;
        private AirportManagement _airportProvider = null;

        public FlightController()
        {
            _flightProvider = new FlightManagement();
            _airportProvider = new AirportManagement();
        }

        public ActionResult Index()
        {
            ViewBag.Message = "List all flights.";
            
            var flightList = _flightProvider.GetFlights();
            return View(flightList);
        }

        // GET: /Flight/Create
        public ActionResult Create()
        {
            var listAirports = _airportProvider.GetAirports().Select(p => new { Name = p.Name, Id = p.AirportId.ToString() });
            listAirports.Select(i => i.ToString()).ToList();

            ViewBag.DepartureAirport = listAirports;
            ViewBag.DestinationAirport = listAirports;

            return View();
        }

        // POST: /Flight/Create
        [HttpPost]
        public ActionResult Create(Flight flight)
        {
            if (ModelState.IsValid)
            {
                _flightProvider.AddFlight(flight);
                return RedirectToAction("Index");
            }
            return View(flight);
        }
    }
}