using System;
using System.Collections.Generic;

namespace Lessons._01
{
    /// <summary>
    /// Write your own example to demonstrate "covariance" of delegates.
    /// </summary>
    public class TaskD
    {

        delegate Car GetCar();

        delegate Bus GetBus();

        public static void Run()
        {
            GetCar getCar = GetSmallCar;

            GetCar getBus = GetBigBus; //covariance

            var cars = new List<Car>
            {
                getCar(),
                getBus()
            };

            cars.ForEach(x => { Console.WriteLine("This is the car {0}", x.GetType().Name); });

        }


        private static Car GetSmallCar()
        {
            Console.WriteLine("Getting a small car");
            return new Car();
        }


        private static Bus GetBigBus()
        {
            Console.WriteLine("Getting a big bus");

            return new Bus();
        }

        private static Truck GetNormalTruck()
        {
            Console.WriteLine("Get new truck");
            return new Truck();
        }
    }
}
public class Car { }

public class Bus : Car { }

public class Truck : Car { }