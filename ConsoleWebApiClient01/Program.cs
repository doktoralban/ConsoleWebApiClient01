using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleWebApiClient01
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var urun = await EnUcuzUrun();             
                Console.WriteLine(string.Format("ID : {0} ", urun.ProductID));
                Console.WriteLine(string.Format("NAME : {0} ", urun.ProductName));
                Console.WriteLine(string.Format("PRICE : {0} ", urun.UnitPrice));
              
                Console.WriteLine("-------------------------------------------");
 
            Console.ReadLine();
        }

        private static async Task<Product> EnUcuzUrun()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", "aydin");

            var strmUrun = client.GetStreamAsync("http://192.168.137.1/WebApiNW/EnUcuz");

            Product urun = await JsonSerializer.DeserializeAsync<Product>(await strmUrun);

 
            return urun;
        } 

    }
}
