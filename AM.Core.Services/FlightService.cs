﻿using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }

       
         public IList<DateTime> GetFlightDates(string destination)
        {
            //List<DateTime> flightDates = new List<DateTime>();
            //foreach (Flight flight in Flights)
            //{
                //if (flight.Destination == destination)
                //{
                    //flightDates.Add(flight.FlightDate);
                //}
           // }
           // return flightDates;

            //method LINQ intégré
           // return (from flight in Flights
                  // where flight.Destination == destination
                   //select flight.FlightDate).ToList();

            //method LINQ fct avancé
            return Flights.Where(f=> f.Destination == destination)
                .Select(f => f.FlightDate)
                .ToList();
        }

        

        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            switch (filterType)
            {
                case "Destination":
                    return Flights.Where(f => f.Destination == filterValue).ToList();
                case "Departure":
                    return Flights.Where(f => f.Departure == filterValue).ToList();
                case "FlightDate":
                    if (DateTime.TryParse(filterValue, out DateTime flightDate))
                    {
                        return Flights.Where(f => f.FlightDate.Date == flightDate.Date).ToList();
                    }
                    break;
                case "FlightId":
                    if (int.TryParse(filterValue, out int flightId))
                    {
                        return Flights.Where(f => f.FlightId == flightId).ToList();
                    }
                    break;
                case "EffectiveArrival":
                    if (DateTime.TryParse(filterValue, out DateTime effectiveArrival))
                    {
                        return Flights.Where(f => f.EffectiveArrival == effectiveArrival).ToList();
                    }
                    break;
                case "EstimatedDuration":
                    if (int.TryParse(filterValue, out int estimatedDuration))
                    {
                        return Flights.Where(f => f.EstimatedDuration == estimatedDuration).ToList();
                    }
                    break;
            }

            return new List<Flight>();
        }


       public void ShowFlightDetails(Plane plane)
        {
           foreach (Flight flight in Flights.Where(f=> f.MyPlane.PlaneId == plane.PlaneId).ToList())
            {
                Console.WriteLine("Destination: "+flight.Destination+" Flight Date: "+flight.FlightDate);

            };

            //avec type anonyme 
            var result = Flights.Where(f => f.MyPlane.PlaneId == plane.PlaneId)
                .Select(f => new { f.FlightDate, f.Destination });
            foreach (var item in result)
            {
                Console.WriteLine("Destination: " + item.Destination + "Flight Date: " + item.FlightDate);

            }
        }

        public int GetWeeklyFlightNumber(DateTime startDate)
        {
           return Flights.Where(f => f.FlightDate >= startDate && f.FlightDate > startDate.AddDays(7)).Count();
        }

        public float GetDurationAverage(string destination)
        {
            return (float)Flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);
        }

        public IList<Flight> SortFlights()
        {
            return Flights.OrderByDescending(f => f.EstimatedDuration).ToList();
        }

      

        public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
           return flight.Passengers.OrderByDescending(p => p.Age)
                .TakeLast(3)
                .ToList();
        }

        public void ShowGroupedFlights()
        {
            foreach(Flight item in Flights.GroupBy(f => f.Destination).ToList())
            {
                Console.WriteLine(item);
            }
        }

       
    }
}
