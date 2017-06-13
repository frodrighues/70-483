using System;
using System.Collections.Generic;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "PrintDateTimeFunnyInfo" with DateTime type as a parameter without any return value.
    /// Create a method (M1) with the same signature like the delegate that prints the number of minutes to lunch (at noon).
    /// E.g. For 11:26 it prints "Next lunch is in 34 minutes".
    /// Create a method (M2) with the same signature like the delegate that prints the number of current day of week.
    /// E.g. For Monday it prints "today is the day number 2 in this week".
    /// Create a delegate instance for M1 and invoke it for current date and time.
    /// Create a delegate instance for M1 + M2 and invoke it for current date and time.
    /// Create a delegate instance for M1 + M2 - M1 and invoke it for current date and time.
    /// </summary>
    public delegate void PrintDateTimeFunnyInfo(DateTime dateTime);

    public static class TaskA
    {
        public static void Run()
        {
            //1
            PrintDateTimeFunnyInfo firstTask = MinutesToLunch;

            firstTask(DateTime.Now);
            Console.WriteLine("--------------------------------------------");
            //2
            List<PrintDateTimeFunnyInfo> secondTask = new List<PrintDateTimeFunnyInfo>
            {
                MinutesToLunch,
                NumberOfDayOfWeek
            };

            secondTask.ForEach(x => x.Invoke(DateTime.Now));
            Console.WriteLine("--------------------------------------------");
            //3
            List<PrintDateTimeFunnyInfo> thirdTask = new List<PrintDateTimeFunnyInfo>
            {
                MinutesToLunch,
                NumberOfDayOfWeek
            };

            thirdTask.Remove(MinutesToLunch);

            thirdTask.ForEach(x => x.Invoke(DateTime.Now));
            Console.WriteLine("--------------------------------------------");
        }

        public static void MinutesToLunch(DateTime dateTimeToLunch)
        {
            var timeToLunch = new DateTime(2017,01,01,12,0,0,0).TimeOfDay - dateTimeToLunch.TimeOfDay;
            var result = timeToLunch.Minutes;


            Console.WriteLine("Next lunch in {0} minutes", result);
        }

        public static void NumberOfDayOfWeek(DateTime dateTimeWeek)
        {
            var numberWeek = (int) dateTimeWeek.DayOfWeek + 1;

            Console.WriteLine("Today is the day number {0} in this week.", numberWeek);
        }
    }
}