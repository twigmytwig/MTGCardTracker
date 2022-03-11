using Card_Tracker_v3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Card_Tracker_v3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        const string BASE_PATH = "https://api.scryfall.com/";
        HttpClient client = new HttpClient();

        void RunAsync()
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            RunAsync();
            
            HttpResponseMessage message = await client.GetAsync(BASE_PATH + "cards/named?fuzzy=aust+com");
            var test = message.Content.ReadAsStringAsync();
            var strongTEst = message.Content.ToString();
            var test2 = JsonSerializer.Deserialize<ScryFallSearchResults>(test.Result);
            ViewData["Image"] = test2.image_uris.small;
            ViewData["TypeLine"] = test2.type_line;
            ViewData["Name"] = test2.name;
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
