using AM.Core.Domain;
using AM.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class PlaneService : Service<Plane>, IPlaneService
    {
        private readonly IRepository<Plane> repository;
        private readonly IRepository<Flight> flightRepository;
        private readonly IRepository<Passenger> passengerRepository;
        private readonly IUnitOfWork unitOfWork;
        public IList<Flight> Flights { get; set; }
        public IList<Plane> Planes { get; set; }


        public PlaneService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            repository = unitOfWork.GetRepository<Plane>();
            flightRepository = unitOfWork.GetRepository<Flight>();
            passengerRepository = unitOfWork.GetRepository<Passenger>();
            this.unitOfWork = unitOfWork;
         
            
        }

        public void DeleteUselessPlanes()
        {
            var today = DateTime.Now;
            var planesToDelete = repository.GetAll()
                .Where(p => !p.Flights.Any(f => f.FlightDate > today.AddYears(-1)))
                .ToList();

            foreach (var plane in planesToDelete)
            {
                repository.Delete(plane);
            }
            unitOfWork.Save();
        }

        public IList<Flight> GetFlights(int nbrplanes)
        {
            return GetAll()
                .OrderByDescending(p=>p.ManufactureDate)
                .Take(nbrplanes)
                .SelectMany(p=>p.Flights)
                .OrderBy(f=>f.FlightDate)
                .ToList();

           
        }

        public IList<Passenger> GetPassengers(Plane plane)
        {
            return plane.Flights //tous les vols
                .SelectMany(f=>f.Reservations) //toutes les reservations
                .Select(r=>r.MyPassenger).Distinct().ToList();

            //return passengerRepository.GetAll()
            //    .Where(p => p.Reservations.Any(r => r.MyFlight.PlaneId == plane.PlaneId))
            //    .ToList();
        }

        public bool IsAvailable(Flight flight)
        {
            return !flightRepository.GetAll()
                .Any(f => f.PlaneId == flight.PlaneId &&
                          f.FlightDate.Date == flight.FlightDate.Date &&
                          f.FlightId != flight.FlightId);
        }
    }
}
