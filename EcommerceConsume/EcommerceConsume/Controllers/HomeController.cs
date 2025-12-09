using System.Diagnostics;
using System.Diagnostics.Metrics;
using EcommerceConsume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceConsume.Controllers;

public class HomeController : Controller
{
    public async Task<IActionResult> Index()
    {
        IEnumerable<Category> categories = null;
        using (var httpClient = new HttpClient())
        {
            using (var response = await httpClient.GetAsync("http://localhost:5178/api/admin/Category/GetAll"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<IEnumerable<Category>>(apiResponse);
            }
        }

        return View(categories);
    }


}
