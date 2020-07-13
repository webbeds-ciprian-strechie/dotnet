using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationClient.Controllers
{
    [ApiController]
    public class HomeController : Controller
    {

        private readonly IHttpClientFactory factory;

        private readonly HotelClient hotelClient;

        public HomeController(IHttpClientFactory factory, HotelClient hotelClient)
        {
            this.factory = factory;
            this.hotelClient = hotelClient;
        }
        /* [HttpGet]
                 public async Task<ActionResult<string>> Get(int id)
                 {
                     var client = new HttpClient();

                     client.BaseAddress = new Uri("http://localhost:5003/");

                     client.DefaultRequestHeaders.Accept.Clear();
                     client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                     var response = await client.GetAsync($"api/hotels/{id}");

                     var result = await response.Content.ReadAsStringAsync();

                     return result;


                 }*/

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id)
        {
            //var client = new HttpClient();

            var client = this.factory.CreateClient("hotels-api");

            var response = await client.GetAsync($"api/hotels/{id}");


            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }

                var error = await response.Content.ReadAsStringAsync();

                //this.logger.LogError()

                return this.BadRequest();
            }

            var result = await response.Content.ReadAsStringAsync();

            return result;


        }

        public class HotelClient
        {

        } 
    }
}
