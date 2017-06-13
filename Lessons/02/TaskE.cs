using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Lessons._02
{
    /// <summary>
    /// Declare an interface ISiteReader with a method ReadAsync(string requestUrl) that returns string in asynchronous way.
    /// Implement the interface and keep the asynchronous approach.
    /// Use await to call the method with "http://www.google.com" parameter.
    /// Print out the content of the page.
    /// </summary>
    
    public class TaskE
    {
        private static ISiteReader MySiteReader
        {
            get
            {
                return new SiteReader();
            }
        }


        public static void Run()
        {
            //Console.WriteLine(await MySiteReader.ReadAsync("http://www.google.com"));
        }
    }

    public class SiteReader : ISiteReader
    {
        public async Task<string> ReadAsync(string requestUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync(requestUrl);
                Console.WriteLine("Request was sent.");
                return result;
            }
        }

    }


    public interface ISiteReader
    {
        Task<string> ReadAsync(string requestUrl);
    }
}