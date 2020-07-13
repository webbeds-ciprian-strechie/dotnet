using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HotelApiClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            const string baseUtrl = "http://localhost:5003/";

            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseUtrl);

            HttpResponseMessage response = await httpClient.GetAsync("api/hotels/1");
            var data = await response.Content.ReadAsStringAsync();

            Console.WriteLine(data);

        }




    }

    public class HotelsApiClient
    {
        private readonly HttpClient client;

        public HotelsApiClient(HttpClient client)
        {
            this.client = client;
            this.client.BaseAddress = new Uri("http://localhost:5005/");
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<HotelModel> GetHotel(int id)
        {
            var response = await this.client.GetAsync($"api/hotels/{id}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<HotelModel>(result);
        }
    }

    class HotelModel
    {
        public string Name { get; set; }

        public string City { get; set; }
    }
}
