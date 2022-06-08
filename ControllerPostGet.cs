using System;
using System.Net.Http;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using(HttpClient client = new HttpClient())
            {
               using (HttpResponseMessage response = await client.GetAsync("http://www.google.com"));
               {
                   using(HttpContent content = response.Content)
               }
            }
        }
    }
}