using System.Diagnostics;
using System.Diagnostics.Metrics;
using EcommerceConsume.Models;
using EcommerceConsume.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EcommerceConsume.Controllers;

public class HomeController : Controller
{
    private readonly string BaseURl = "http://localhost:5178";
    public async Task<IActionResult> Index()
    {
        HomeVM homeVM = new HomeVM();
        using (var client = new HttpClient())
        {
            try
            {

                var testimonialResponse = await client.GetAsync($"{BaseURl}/api/Testimonial/GetAll");
                if (testimonialResponse.IsSuccessStatusCode)
                {
                    string testimonialApiResponse = await testimonialResponse.Content.ReadAsStringAsync();
                    homeVM.Testimonials = (IEnumerable<Testimonial>)JsonConvert.DeserializeObject<IEnumerable<Testimonial>>(testimonialApiResponse);

                }
                else
                {
                    ViewData["Error"] = "API request failed with status code: " + testimonialResponse.StatusCode;
                    homeVM.Testimonials = new List<Testimonial>();
                }

                var productResponse = await client.GetAsync($"{BaseURl}/api/Product/GetAll");
                if (productResponse.IsSuccessStatusCode)
                {
                    string productApiResponse = await productResponse.Content.ReadAsStringAsync();
                    homeVM.Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(productApiResponse);
                }
                else
                {
                    ViewData["Error"] = "API request failed with status code: " + productResponse.StatusCode;
                    homeVM.Products = new List<Product>();
                }

                var blogPostResponse = await client.GetAsync($"{BaseURl}/api/blogPost/GetAll");
                if (blogPostResponse.IsSuccessStatusCode)
                {
                    string blogPostApiResponse = await blogPostResponse.Content.ReadAsStringAsync();
                    homeVM.BlogPosts = JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(blogPostApiResponse);
                }
                else
                {
                    ViewData["Error"] = "API request failed with status code: " + blogPostResponse.StatusCode;
                    homeVM.BlogPosts = new List<BlogPost>();
                }


                var settingResponse = await client.GetAsync($"{BaseURl}/api/setting/GetAll");
                if (settingResponse.IsSuccessStatusCode)
                {
                    string settingApiResponse = await settingResponse.Content.ReadAsStringAsync();
                    var settings = JsonConvert.DeserializeObject<IEnumerable<Setting>>(settingApiResponse);
                    homeVM.Settings = settings.ToDictionary(s => s.Key, s => s.Value);
                }

                else
                {
                    ViewData["Error"] = "API request failed with status code: " + settingResponse.StatusCode;
                    homeVM.Settings = new Dictionary<string, string>();
                }
                var sliderResponse = await client.GetAsync(
                    $"{BaseURl}/api/Slider/GetAllActive/active"
                );

                if (sliderResponse.IsSuccessStatusCode)
                {
                    string sliderApiResponse = await sliderResponse.Content.ReadAsStringAsync();
                    homeVM.Sliders =
                        JsonConvert.DeserializeObject<IEnumerable<Slider>>(sliderApiResponse)
                        ?? new List<Slider>();


                }
                else
                {
                    ViewData["Error"] = "API request failed with status code: " + sliderResponse.StatusCode;
                    homeVM.Sliders = new List<Slider>();
                }

            }
            catch (HttpRequestException ex)
            {
                ViewData["Error"] = $"API request failes:{ex.Message}";
            }


        }
        return View(homeVM);
    }

}

