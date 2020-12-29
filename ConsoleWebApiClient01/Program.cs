//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
 

namespace ConsoleWebApiClient01
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Uri url = new Uri("http://192.168.137.1/WebApiNW/Urunler/UretimdenKaldirilanlar?dsApiPass=1234");


            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.json"));
            client.DefaultRequestHeaders.Add("User-Agent", "aydin");

            UserModel usr = new UserModel();
            usr.KulaniciAdi = "a.turker";
            usr.Sifre = "1234"; 

            var contentUser = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(usr), Encoding.UTF8, "application/json");
             var ctn = await client.PostAsync(url.ToString(), contentUser);

            var result = await ctn.Content.ReadAsStreamAsync();

            List<Product> Urunler = Utils.Deserialize<List<Product>>(result);

            foreach (var urun in Urunler)
            {
                Console.WriteLine(string.Format("ID : {0} ", urun.ProductID));
                Console.WriteLine(string.Format("NAME : {0} ", urun.ProductName));
                Console.WriteLine(string.Format("PRICE : {0} ", urun.UnitPrice));

                Console.WriteLine("-------------------------------------------");
            } 
 
            Console.ReadLine();
        }



        #region" En ucuz ürün "


        //   static async Task Main(string[] args)
        //{

        //    var urun = await EnUcuzUrun();
        //    Console.WriteLine(string.Format("ID : {0} ", urun.ProductID));
        //    Console.WriteLine(string.Format("NAME : {0} ", urun.ProductName));
        //    Console.WriteLine(string.Format("PRICE : {0} ", urun.UnitPrice));
        //}



        //private static async Task<Product> EnUcuzUrun()
        //{
        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        //    client.DefaultRequestHeaders.Add("User-Agent", "aydin");

        //    var strmUrun = client.GetStreamAsync("http://192.168.137.1/WebApiNW/EnUcuz");

        //    Product urun = await JsonSerializer.DeserializeAsync<Product>(await strmUrun);


        //    return urun;
        //}

        #endregion


        #region" Stokta Kalmayanlar "
        //static async Task Main(string[] args)
        //{
        //    Uri url = new Uri("http://localhost:51062/Urunler/StoktaKalmayanlar?dsApiPass=1234");


        //    client.DefaultRequestHeaders.Accept.Clear();
        //    client.DefaultRequestHeaders.Accept.Add(
        //        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        //    client.DefaultRequestHeaders.Add("User-Agent", "aydin");

        //    UserModel usr = new UserModel();
        //    usr.KulaniciAdi = "a.turker";
        //    usr.KulaniciAdi = "1234";

        //    var contentUser = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(usr), Encoding.UTF8, "application/json");



        //    var ctn = await client.PostAsync(url.ToString(), contentUser);

        //    var result = await ctn.Content.ReadAsStreamAsync();

        //    List<Product> Urunler = Utils.Deserialize<List<Product>>(result);

        //    foreach (var urun in Urunler)
        //    {
        //        Console.WriteLine(string.Format("ID : {0} ", urun.ProductID));
        //        Console.WriteLine(string.Format("NAME : {0} ", urun.ProductName));
        //        Console.WriteLine(string.Format("PRICE : {0} ", urun.UnitPrice));

        //        Console.WriteLine("-------------------------------------------");
        //    }





        //    Console.ReadLine();
        //}


        #endregion


    }
}
