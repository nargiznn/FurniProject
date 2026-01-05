using System;
using EcommerceConsume.Models;
using EcommerceConsume.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceConsume.Controllers
{
    public class BlogController : Controller
    {
        private readonly string BaseURl = "http://localhost:5178";
        public async Task<IActionResult> Index()
        {
            BlogVM blogVM = new BlogVM();
            using (var client = new HttpClient())
            {
                try
                {

                    //var testimonialResponse = await client.GetAsync($"{BaseURl}/api/Testimonial/GetAll");
                    //if (testimonialResponse.IsSuccessStatusCode)
                    //{
                    //    string testimonialApiResponse = await testimonialResponse.Content.ReadAsStringAsync();
                    //    blogVM.Testimonials = (IEnumerable<Testimonial>)JsonConvert.DeserializeObject<IEnumerable<Testimonial>>(testimonialApiResponse);

                    //}
                    //else
                    //{
                    //    ViewData["Error"] = "API request failed with status code: " + testimonialResponse.StatusCode;
                    //    blogVM.Testimonials = new List<Testimonial>();
                    //}

                    var blogPostResponse = await client.GetAsync($"{BaseURl}/api/blogPost/GetAll");
                    if (blogPostResponse.IsSuccessStatusCode)
                    {
                        string blogPostApiResponse = await blogPostResponse.Content.ReadAsStringAsync();
                        blogVM.BlogPosts = JsonConvert.DeserializeObject<IEnumerable<BlogPost>>(blogPostApiResponse);
                    }
                    else
                    {
                        ViewData["Error"] = "API request failed with status code: " + blogPostResponse.StatusCode;
                        blogVM.BlogPosts = new List<BlogPost>();
                    }


                    var settingResponse = await client.GetAsync($"{BaseURl}/api/setting/GetAll");
                    if (settingResponse.IsSuccessStatusCode)
                    {
                        string settingApiResponse = await settingResponse.Content.ReadAsStringAsync();
                        var settings = JsonConvert.DeserializeObject<IEnumerable<Setting>>(settingApiResponse);
                        blogVM.Settings = settings.ToDictionary(s => s.Key, s => s.Value);
                    }

                    else
                    {
                        ViewData["Error"] = "API request failed with status code: " + settingResponse.StatusCode;
                        blogVM.Settings = new Dictionary<string, string>();
                    }
                    var sliderResponse = await client.GetAsync(
                        $"{BaseURl}/api/Slider/GetAllActive/active"
                    );

                    if (sliderResponse.IsSuccessStatusCode)
                    {
                        string sliderApiResponse = await sliderResponse.Content.ReadAsStringAsync();
                        blogVM.Sliders =
                            JsonConvert.DeserializeObject<IEnumerable<Slider>>(sliderApiResponse)
                            ?? new List<Slider>();


                    }
                    else
                    {
                        ViewData["Error"] = "API request failed with status code: " + sliderResponse.StatusCode;
                        blogVM.Sliders = new List<Slider>();
                    }

                }
                catch (HttpRequestException ex)
                {
                    ViewData["Error"] = $"API request failes:{ex.Message}";
                }


            }
            return View(blogVM);
        }
    }
}

