using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DesginPatternExample
{

    public interface IVehicle { void Drive(); }

    public class Car : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Driving Car");
        }
    }

    public class Bike : IVehicle
    {
        public void Drive()
        {
            Console.WriteLine("Bike is Ride");
        }
    }
    internal class FactoryDesignPatter
    {
        public static IVehicle CreateCar(string argType)
        {
            
            switch (argType)
            {
                case "Car":
                    return new Car();
                case "Bike":
                    return new Bike();
                default:
                    throw new ArgumentException("Invalid vehicle type");
            }
            
        }
    }
}
