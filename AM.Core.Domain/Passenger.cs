using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Passenger
    {
        [DataType(DataType.DateTime,ErrorMessage ="date non valide"),Display(Name = "date of birth")]
        public DateTime BirthDate { get; set; }

        private int age;
       // public int passengerId { get; set; }
        public int Age {

            get
            {
                age = DateTime.Now.Year - BirthDate.Year;
                //if (DateTime.Now.Month < BirthDate.Month )
                //{
                    //age--;
                //}
                //if(DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day)
                //{
                    //age--;
               // }
                
                //proposition 2
                if(DateTime.Now< BirthDate.AddYears(age))
                {
                    age--;
                }


                return age;
            }
        
        }
        [Key,MaxLength(7,ErrorMessage ="Taille maximale 7"),//controle dans bd
            MinLength(7, ErrorMessage = "Taille mainimale 7"),//controle dans bd
            StringLength(7,MinimumLength =7, ErrorMessage ="taille 7")//controle au niveau de front
            ]
        public string PassportNumber { get; set; }
        [EmailAddress(ErrorMessage ="email invalide")]
        public string EmailAddress { get; set; }
        [MaxLength(25, ErrorMessage = "taille maximale 25"), MinLength(3, ErrorMessage = "taille minimale 3")]
        // public string FirstName { get; set; }
        //public string LastName { get; set; }

        public FullName MyFullName { get; set; }

        [Phone(ErrorMessage ="num tel invalide")]
        public string TelNumber { get; set; }
        //public IList<Flight> Flights { get; set; }
        public IList<Reservation> Reservations { get; set; }
        public override string ToString()
        {
            return "BirthDate: "+ BirthDate
                + "PassportNumber: "+ PassportNumber
                + "EmailAddress: "+ EmailAddress
                + "FirstName: "+ MyFullName.FirstName
                + "LastName: "+ MyFullName.LastName
                + "TelNumber: "+ TelNumber;
        }
        public bool CheckProfile(string firstName, string lastName)
        {
            
            return this.MyFullName.FirstName == firstName && this.MyFullName.LastName == lastName;

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
                return this.MyFullName.FirstName == firstName && this.MyFullName.LastName == lastName;
            }
            else
            {
                return this.MyFullName.FirstName == firstName && this.MyFullName.LastName == lastName && this.EmailAddress == emailAddress;
            }
          
        }
        public virtual string GetPassengerType()
        {
            // Return a string indicating that the object is a passenger
            return "I am a passenger";
        }



    }
}
