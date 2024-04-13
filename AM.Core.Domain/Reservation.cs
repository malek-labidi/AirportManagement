using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Reservation
    {
        //public int Id { get; set; }
        public float Price { get; set; }
        public string Seat { get; set; }
        public bool VIP { get; set; }
        public virtual Passenger MyPassenger { get; set; }
        public virtual Flight MyFlight { get; set; }

        //[ForeignKey("MyPassenger")]
        public string PassengerId { get; set; }

        //[ForeignKey("MyFlight")]
        public int FlightId { get; set;}
    }
}
