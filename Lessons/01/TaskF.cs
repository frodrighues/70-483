using System;
using System.Timers;

namespace Lessons._01
{
    /// <summary>
    /// Implement a class that raises OnMarketUpdated event each second. 
    /// The event passes a decimal number that represents current market value.
    /// It can be a random number from 20 to 80.
    /// Register for the event from a class and print a message with the value to console.
    /// After you press a key, unregister from the event, but keep application live.
    /// After you press next key, stop the application.
    /// </summary>
    public class TaskF
    {
        public static void Run()
        {
            var time = new Timer(1000);
            
            //time.Elapsed += new ElapsedEventHandler(TimeEvent);

            time.Start();

        }

    }

    public static class MyEventClass
    {
        public static event Func<decimal, decimal> OnmarketUpdated;

        public static void Raise()
        {
            if (OnmarketUpdated != null)
            {
                var random1 = new Random();

                OnmarketUpdated(random1.Next(20,80));
            }
        }
    }
}