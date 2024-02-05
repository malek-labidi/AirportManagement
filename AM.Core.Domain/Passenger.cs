using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string PassportNumber { get; set; }
        public string EmailAddress { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string TelNumber { get; set; }
        public IList<Flight> Flights { get; set; }

        public override string ToString()
        {
            return "BirthDate: "+ BirthDate
                + "PassportNumber: "+ PassportNumber
                + "EmailAddress: "+ EmailAddress
                + "FirstName: "+ FirstName
                + "LastName: "+ LastName
                + "TelNumber: "+ TelNumber;
        }
        public bool CheckProfile(string firstName, string lastName)
        {
            
            return this.FirstName == firstName && this.LastName == lastName;

        }

        /*
         * * Overloaded method to check profile with additional email address parameter.
         * * This method is currently commented out, but it can be uncommented and used if needed.
         */
        //public bool CheckProfile(string firstName, string lastName,string emailAddress)
        //{

        //  return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == emailAddress;

        // }

        /*
         * * Method to check profile with optional email address parameter.
         * * If the email address is provided, it is also checked against the current profile's email address.
         */
        public bool CheckProfile(string firstName, string lastName, string emailAddress = null)
        {
            if(emailAddress == null)
            {
                return this.FirstName == firstName && this.LastName == lastName;
            }
            else
            {
                return this.FirstName == firstName && this.LastName == lastName && this.EmailAddress == emailAddress;
            }
          
        }
        public virtual string GetPassengerType()
        {
            // Return a string indicating that the object is a passenger
            return "I am a passenger";
        }



    }
}
