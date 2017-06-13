using System;
using System.Collections.Generic;
using System.Linq;

namespace Lessons._01
{
    /// <summary>
    /// Use the most suitable system delegates (Action, Func, Predicate) for the problems below. 
    /// For each case write an example and print results for functions.
    /// ---
    /// (1) An anonymous method that prints the first char from input string to the console.
    /// (2) An anonymous method with an integer array as an input that prints all values to the console. 
    /// Each value is preceded by the number of spaces according to the position of the item.
    /// "(itemAtPosition0)"
    /// " (itemAtPosition1)"
    /// "  (itemAtPosition2)"
    /// ...
    /// (3) An anonymous function that returns True for a char that is a letter or a digit, otherwise False.
    /// (4) An anonymous method that prints longer string from a pair of strings to the console.
    /// (5) An anonymous function that returns current date in "yyyymmdd" format.
    /// (6) An anonymous function that returns XOR result of two input boolean values.
    /// (7) An anonymous empty method.
    /// (8) An anonymous method that gets apr parameterless action as an input and invokes that action.
    /// </summary>
    public class TaskE
    {
        public static void Run()
        {
            // E.g. Action<DateTime> problem42 = dt => { Console.WriteLine(dt...)};

            //1
            Console.WriteLine("Write your string for task 1");

            var command = Console.ReadLine();

            Action<string> problem1 = r =>
            {
                if (!string.IsNullOrEmpty(command))
                {
                    Console.WriteLine("First letter of the command is {0}", command.First());
                }
                else
                {
                    Console.WriteLine("Command cannot be null");
                }
            };

            //2
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            Action<List<int>> problem2 = r =>
            {
                numbers.ForEach(n =>
                {
                    Console.WriteLine(n.ToString().PadLeft(n, ' '));
                });
            };

            //3

            char entry = ')';

            Func<bool> problem3 = () => char.IsLetterOrDigit(entry);

            //4

            var string1 = "12345";
            var string2 = "0123456789";

            Action<string, string> printBiggerString = (string s1, string s2) =>
            { Console.WriteLine(s1.Length > s2.Length ? s1 : s2); };

            //5
            Func<string> currentDateFormat = () => DateTime.Today.ToString("yyyyMMdd");

            //6
            Func<bool, bool, bool> xorValue = (bool b1, bool b2) => b1 ^ b2;

            //7
            Action emptyMethod = () => { };

            //8
            Action parameterlessAction = () => { Console.WriteLine("My Action Without parameters"); };

            Action<Action> masterAction = (Action pa) => { pa.Invoke(); };

            problem1.Invoke(command);
            problem2.Invoke(numbers);
            Console.WriteLine(problem3.Invoke().ToString());
            printBiggerString.Invoke(string1,string2);
            Console.WriteLine(currentDateFormat.Invoke());
            masterAction.Invoke(parameterlessAction);
           
        }
    }
}