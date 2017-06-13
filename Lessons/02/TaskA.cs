using System;
using System.Threading.Tasks;


namespace Lessons._02
{
    /// <summary>
    /// Create a task and print out all information about its execution context.
    /// </summary>
    public class TaskA
    {
        public static void Run()
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Task started");

                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Task line {0}", i);
                }
            });

            Console.WriteLine("Finish the task");

            task.Wait(1000);
        }

    }

}