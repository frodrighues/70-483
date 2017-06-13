using System;

namespace Lessons._01
{
    /// <summary>
    /// Define a delegate "string MapString(string @string)" and write all possible forms according to _03_LambdaExpressionBasics.
    /// Print results from each expression.
    /// </summary>

    public delegate string MapString(string @string);

    public class TaskB
    {
        public static void Run()
        {
            MapString operation1 = delegate (string x) { return x ; };   // Anonymous method
            MapString operation2 = (string x) => { return x ; };   // Lambda expression (explicitly typed parameter)
            MapString operation3 = (x) => { return x ; };   // Lambda expression (implicitly typed parameter)
            MapString operation4 = x => { return x ; };   // Lambda expression (implicitly typed parameter)
            MapString operation5 = x => x ;   // Lambda expression (implicitly typed parameter)

            Console.WriteLine($"operation1(A) = {operation1("A")}");
            Console.WriteLine($"operation2(A) = {operation2("A")}");
            Console.WriteLine($"operation3(A) = {operation3("A")}");
            Console.WriteLine($"operation4(A) = {operation4("A")}");
            Console.WriteLine($"operation5(A) = {operation5("A")}");
        }
    }
}