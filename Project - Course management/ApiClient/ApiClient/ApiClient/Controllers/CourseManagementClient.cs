using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseManagementClient : ControllerBase
    {
        private readonly IHttpClientFactory factory;

        public CourseManagementClient(IHttpClientFactory factory)
        {
            this.factory = factory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var client = this.factory.CreateClient("course");

            //Authenticate
            var json = JsonConvert.SerializeObject(new { username = "test", password = "test" });

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"Users/authenticate/", data);

            if (!response.IsSuccessStatusCode)
            {
                if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return this.NotFound();
                }
            }

            var result = await response.Content.ReadAsStringAsync();

            dynamic authData = JsonConvert.DeserializeObject<dynamic>(result);
            string token = authData.token;
            //Sudent request

            var clientStud = this.factory.CreateClient("course");

            clientStud.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            //HttpResponseMessage responseStudents = await clientStud.GetAsync($"/api/Student/");
            List<Task<HttpResponseMessage>> tasks = new List<Task<HttpResponseMessage>>();
            for (var i = 0; i < 100; i++)
            {
                tasks.Add(clientStud.GetAsync($"/api/Student/"));
            }
            Task.WaitAll(tasks.ToArray());

            HttpResponseMessage responseStudents = tasks.First().Result;
            var resultStudents = await responseStudents.Content.ReadAsStringAsync();

            dynamic studentsData = JsonConvert.DeserializeObject<dynamic>(resultStudents);

            return this.Ok(resultStudents);
        }
    }
}
