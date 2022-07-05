using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace KanyeWest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var kanyeURL = "https://api.kanye.rest/";      

            var client2 = new HttpClient();

            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";            

            for (int i = 0; i < 5 ; i++ )
            {
                var kanyeResponse = client.GetStringAsync(kanyeURL).Result;

                var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();
                
                var ronResponse = client2.GetStringAsync(ronURL).Result;

                var ronQuote = JArray.Parse(ronResponse).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                
                Console.WriteLine($"Ye says: {kanyeQuote}");
                Console.WriteLine($"Ron says: {ronQuote}");
            }
        }
    }
}
