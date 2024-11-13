using Labb2RestaurantMVC.Models.Auth;
using Labb2RestaurantMVC.Models.Menu;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Labb2RestaurantMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7003/";

        public HomeController(ILogger<HomeController> logger, HttpClient client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["IsLandingPage"] = true;

            List<Menu> menu = new List<Menu>();
            try
            {
                var response = await _client.GetAsync($"{baseUri}api/Menu/GetAllPopularFoodMenu");
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.ErrorMessage = $"Cant get the popular food, there may be something wrong.";
                    return View();
                }

                var json = await response.Content.ReadAsStringAsync();

                menu = JsonConvert.DeserializeObject<List<Menu>>(json);
            }
            catch
            {
                ViewBag.ErrorMessage = $"Could not get the data, must be an api problem.";
            }


            return View(menu);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
