using Labb2RestaurantMVC.Models;
using Labb2RestaurantMVC.Models.Booking;
using Labb2RestaurantMVC.Models.Menu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Labb2RestaurantMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly HttpClient _client;
        private readonly ILogger<MenuController> _logger;
        private string baseUri = "https://localhost:7003/";

        public AdminController(HttpClient client, ILogger<MenuController> logger)
        {
            _client = client;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> BookingsAll()
        {
            ViewData["Title"] = "All Bookings";

            var response = await _client.GetAsync($"{baseUri}api/Booking/getallbookings");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();

            var bookings = JsonConvert.DeserializeObject<List<BookingNew>>(json);

            var booklist = bookings.OrderBy(b => b.BookingDate ).ThenBy(b => b.BookingStart).ThenBy(b => b.CustomerFullName).ToList();

            return View(booklist);
        }

        public IActionResult BookingAdd()
        {
            ViewData["Title"] = "New Booking";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BookingAdd(Booking book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            var json = JsonConvert.SerializeObject(book);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{baseUri}api/Booking/addbooking", content);

            return RedirectToAction("BookingsAll");
        }

        public async Task<IActionResult> BookingUpdate(int Id)
        {
            var response = await _client.GetAsync($"{baseUri}api/Booking/getbookingbyid/{Id}");

            if (!response.IsSuccessStatusCode)
                return NotFound();

            var json = await response.Content.ReadAsStringAsync();

            var booking = JsonConvert.DeserializeObject<BookingInfoAllDTO>(json);

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> BookingUpdate(BookingInfoAllDTO book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            var json = JsonConvert.SerializeObject(book);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{baseUri}api/Booking/UpdateBooking/{book.Id}", content);

            return RedirectToAction("BookingsAll");
        }

        [HttpPost]
        public async Task<IActionResult> BookingDelete(int Id)
        {
            var response = await _client.DeleteAsync($"{baseUri}api/Booking/DeleteBooking/{Id}");

            return RedirectToAction("BookingsAll");
        }


        // Start of Menu

        public async Task<IActionResult> Menu()
        {
            ViewData["Title"] = "Menu Dishes";

            var response = await _client.GetAsync($"{baseUri}api/Menu/GetAllMenu");

            var json = await response.Content.ReadAsStringAsync();

            var menu = JsonConvert.DeserializeObject<List<Menu>>(json);

            return View(menu);
        }

        public IActionResult CreateFood()
        {
            ViewData["Title"] = "New Foods";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return View(menu);
            }
            var json = JsonConvert.SerializeObject(menu);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{baseUri}api/Menu/AddFood", content);

            return RedirectToAction("Menu");
        }

        public async Task<IActionResult> UpdateFood(int Id)
        {
            var resopnse = await _client.GetAsync($"{baseUri}api/Menus/GetDishById/{Id}");

            var json = await resopnse.Content.ReadAsStringAsync();

            var menu = JsonConvert.DeserializeObject<Menu>(json);

            return View(menu);
        }

        
        [HttpPost]
        public async Task<IActionResult> UpdateFood(Menu menu)
        {
            if (!ModelState.IsValid)
            {
                return View(menu);
            }
            var json = JsonConvert.SerializeObject(menu);

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{baseUri}api/Menu/UpdateFood/{menu.Id}", content);

            return RedirectToAction("Menu");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteFood(int Id)
        {
            var response = await _client.DeleteAsync($"{baseUri}api/Menu/DeleteFood/{Id}");

            return RedirectToAction("Menu");
        }
    }
}
