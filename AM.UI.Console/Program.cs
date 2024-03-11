// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;
using AM.Data;


Console.WriteLine("Hello, World!");

//default constructor
/*Plane plane1 = new Plane();
plane1.Capacity = 1;
plane1.ManufactureDate = DateTime.Now;
plane1.MyPlaneType = PlaneType.Boing;

//Parameterized constructor
Plane plane2 = new Plane(PlaneType.Airbus,100,DateTime.Now);

//object initializer
Plane plane3 = new Plane (){ Capacity =50,MyPlaneType=PlaneType.Boing };



// Testing polymorphism through inheritance
Passenger passenger = new Passenger();   // Creating an instance of the Passenger class
Passenger passenger1 = new Staff();           // Creating an instance of the Staff class
Passenger passenger2 = new Traveller();   // Creating an instance of the Traveller class

// Calling the GetPassengerType method on each object to demonstrate polymorphic behavior
Console.WriteLine(passenger.GetPassengerType()); // Outputs: "I am a passenger"
Console.WriteLine(passenger1.GetPassengerType()); // Outputs: "I am a Staff" (assuming you update the Staff class as mentioned before)
Console.WriteLine(passenger2.GetPassengerType()); // Outputs: "I am a Traveller"*/

Plane planeAirbus = new Plane() { Capacity = 160, MyPlaneType = PlaneType.Boing };


Flight flight = new Flight()
{
    Comment ="Hello comment",
    Departure= "paris",
    Destination="tunis",
    EffectiveArrival= DateTime.Now,
    EstimatedDuration= 60,
    FlightDate= DateTime.Now,
    MyPlane = planeAirbus,
};
AMContext aMContext = new AMContext();

aMContext.Add(planeAirbus);
aMContext.Add(flight);

aMContext.SaveChanges();








