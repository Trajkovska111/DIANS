using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AtmLocator.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AtmLocator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //_ = GetUserLocationMicroServiceAsync();

            //link to the microservice - hardcoded
            String microServiceURI = "https://localhost:49161/";

            var client = new HttpClient();

            // Passing service base url
            client.BaseAddress = new Uri(microServiceURI);

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Sending request to find web api REST service resource GetUserLocation using HttpClient  
            HttpResponseMessage Res = await client.GetAsync("api/Default");

            //Checking the response is successful or not which is sent using HttpClient 
            UserLocation user = new UserLocation();
            if (Res.IsSuccessStatusCode)
            {
                var ObjResponse = Res.Content.ReadAsStringAsync().Result;
                user.Location = ObjResponse.ToString().Substring(1, 15);
                string[] parts = ObjResponse.ToString().Substring(1, 15).Split(',');
                user.Longitude = parts[1];
                user.Latitude = parts[0];
            }
            return View(user);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
