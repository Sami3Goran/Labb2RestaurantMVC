using Labb2RestaurantMVC.Models.Menu;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Labb2RestaurantMVC.Controllers
{
    public class MenuController : Controller
    {
        private readonly HttpClient _client;
        private string baseUri = "https://localhost:7003/";
        public MenuController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Menu";
            ViewBag.PageTitle = "Menu List";

            var response = await _client.GetAsync($"{baseUri}api/Menu/GetAllAvailableFoodMenu");

            var json = await response.Content.ReadAsStringAsync();

            var menuList = JsonConvert.DeserializeObject<List<Menu>>(json);

            return View(menuList);
        }

        //public IActionResult CreateFood()
        //{
        //    ViewData["Title"] = "New Food";

        //    return View();
        //}

        //    [HttpPost]
        //    public async Task<IActionResult> CreateFood(Menu menu)
        //    {
        //        var json = JsonConvert.SerializeObject(menu);

        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await _client.PostAsync($"{baseUri}api/Menu/AddFood", content);

        //        return RedirectToAction("Index");
        //    }

        //    public async Task<IActionResult> EditFood(int menuId)
        //    {
        //        var response = await _client.GetAsync($"{baseUri}GetDishById/{menuId}");

        //        var json = await response.Content.ReadAsStringAsync();

        //        var menu = JsonConvert.DeserializeObject<Menu>(json);

        //        return View(menu);
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> EditFood(Menu menu)
        //    {
        //        var json = JsonConvert.SerializeObject(menu);

        //        var content = new StringContent(json, Encoding.UTF8 , "application/json");

        //        await _client.PutAsync($"{baseUri}api/Menu/UpdateFood/{menu.MenuId}", content);

        //        return RedirectToAction("Index");
        //    }

        //    [HttpPost]
        //    public async Task<IActionResult> DeleteFood(int menuId)
        //    {
        //        var response = await _client.DeleteAsync($"{baseUri}api/Menu/DeleteFood/{menuId}");

        //        return RedirectToAction("Index");
        //    }

        //}
    }
}
