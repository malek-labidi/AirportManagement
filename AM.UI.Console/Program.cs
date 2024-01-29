// See https://aka.ms/new-console-template for more information
using AM.Core.Domain;

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