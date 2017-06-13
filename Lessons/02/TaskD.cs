using System;
using System.Diagnostics;
using System.Threading;

namespace Lessons._02
{
    /// <summary>
    /// Set capacity of ThreadPool to 10 and start 15 tasks. Let them run at least 1000 miliseconds. 
    /// Print out the time used for creation of each task.
    /// </summary>
    public class TaskD
    {
        public static void Run()
        {
            int workerThreads = 10;
            int completionPortThreads = 10;

            ThreadPool.SetMaxThreads(workerThreads,completionPortThreads);

            for (int i = 0; i < 15; i++)
            {
                var stopWatch = new Stopwatch();

                stopWatch.Start();

                ThreadPool.QueueUserWorkItem(state =>
                {
                    Console.WriteLine("working on a thread {0}", (i + 1));
                    Thread.Sleep(1000);
                });

                stopWatch.Stop();

                Console.WriteLine(stopWatch.Elapsed);
            }
            
        }
    }
}