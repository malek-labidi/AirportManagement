// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;
using AM.Core.Services;

Console.WriteLine("Hello, World!");

//default constructor
Plane plane1 = new Plane();
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
Console.WriteLine(passenger2.GetPassengerType()); // Outputs: "I am a Traveller"




// Create an instance of the flight service
IFlightService flightService = new FlightService();
FlightService flightServices = new FlightService();

// Create a list of flights as an example
flightServices.Flights.Add(new Flight { Destination = "Paris", FlightDate = new DateTime(2024, 2, 10) });
flightServices.Flights.Add(new Flight { Destination = "New York", FlightDate = new DateTime(2024, 3, 15) });
flightServices.Flights.Add(new Flight { Destination = "Paris", FlightDate = new DateTime(2024, 4, 20) });

// Use the methods to obtain flight dates for a given destination
List<DateTime> parisFlightDates = (List<DateTime>)flightService.GetFlightDates("Paris");
Console.WriteLine("Flight dates for Paris: ");
foreach (DateTime date in parisFlightDates)
{
    Console.WriteLine(date.ToShortDateString());
}

// Use the methods to filter flights based on the filter type and value
List<Flight> filteredFlights = (List<Flight>)flightService.GetFlights("Destination", "Paris");
Console.WriteLine("\nFlights for the destination Paris: ");
foreach (Flight flight in filteredFlights)
{
    Console.WriteLine($"Destination: {flight.Destination}, Departure: {flight.FlightDate.ToShortDateString()}");
}
flightService.ShowFlightDetails(plane3);




