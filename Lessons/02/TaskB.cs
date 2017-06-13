using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Implement processes to read the sites [www.visualstudio.com, www.microsoft.com, www.google.com]. 
    /// A version with sequential processing, the second version with parallel processing. 
    /// Print out total duration. You can use System.Diagnostics.Stopwatch type.
    /// </summary>
    public class TaskB
    {
        public static void Run()
        {
            SequencialProcess();
            Console.WriteLine("----------------");
            ParallelProcess();
        }


        private static void SequencialProcess()
        {
            var timer = new Stopwatch();
            timer.Start();
            ReadWebsite("http://www.visualstudio.com");
            ReadWebsite("http://www.microsoft.com");
            ReadWebsite("http://www.google.com");
            timer.Stop();
            Console.WriteLine("Sequencial processing took {0} milliseconds", timer.Elapsed.TotalMilliseconds);
        }

        private static void ParallelProcess()
        {
            var timer = new Stopwatch();

            var webSites = new List<string>
            {
                "http://www.visualstudio.com",
                "http://www.microsoft.com",
                "http://www.google.com"
            };

            timer.Start();

            Parallel.ForEach(webSites, ReadWebsite);

            timer.Stop();
            
            Console.WriteLine("Parallel processing took {0} milliseconds", timer.Elapsed.TotalMilliseconds);
        }

        private static void ReadWebsite(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);

            var response = (HttpWebResponse)request.GetResponse();

            var data = string.Empty;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }

                data = readStream.ReadToEnd();

                response.Close();
                readStream.Close();
            }
        }
    }

}