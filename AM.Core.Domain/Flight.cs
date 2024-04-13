using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    //[Table("Flight")]
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimatedDuration { get; set; }
        public string Comment { get; set; }

        //public IList<Passenger> Passengers { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
      
        public int? PlaneId { get; set; }

        [ForeignKey(nameof(PlaneId))]
        public virtual Plane MyPlane { get; set; }

        /** Or 
         
        [ForeignKey(nameof(MyPlane))]
        public int PlaneId { get; set; }

        public Plane MyPlane { get; set; }
         */

        public override string ToString()
        {
            return "EffectiveArrival:"+ EffectiveArrival 
                + "EstimatedDuration:" + EstimatedDuration
                + "FlightId: "+ FlightId
                + "FlightDate: "+ FlightDate
                + "Destination: " + Destination
                + "Departure: "+ Departure;
        }

    }
}
