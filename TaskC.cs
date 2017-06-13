using System;
using System.Collections.Generic;

namespace Lessons._01
{
    /// <summary>
    /// Have a class Car and its descendant Bus. 
    /// Declare delegates "void ServiceCar(Car car)" and "void ServiceBus(Bus bus)". 
    /// Define a method to change the tyres of a car.
    /// Define a method to clean up an interier of a bus.
    /// Demonstrate all possible combinations of assigning the methods to the delegates. Apply "contravariance".
    /// </summary>

    public delegate void ServiceCar(Car car);

    public delegate void ServiceBus(Bus bus);
    
    public class TaskC
    {
        public static void Run()
        {
            ServiceCar serviceCar = ChangeTyres;
            serviceCar(new Car());
            serviceCar(new Bus());

            ServiceBus serviceBus = CleanBus;
            serviceBus(new Bus());
            
        }

        public static void ChangeTyres(Car car)
        {
            Console.WriteLine("Change tyres of {0}", car.GetType().Name);
        }

        public static void CleanBus(Bus bus)
        {
            Console.WriteLine("Cleaning a {0}", bus.GetType().Name);
        }
    }

    public class Car { }
    public class Bus : Car { }
}