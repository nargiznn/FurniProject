using System;
using EcommerceConsume.Models;
using EcommerceConsume.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EcommerceConsume.Controllers
{
	public class AboutController: Controller
    {
        private readonly string BaseURl = "http://localhost:5178";
        public async Task<IActionResult> Index()
        {
            AboutVM aboutVM = new AboutVM();
            using (var client = new HttpClient())
            {
                try
                {

                    var testimonialResponse = await client.GetAsync($"{BaseURl}/api/Testimonial/GetAll");
                    if (testimonialResponse.IsSuccessStatusCode)
                    {
                        string testimonialApiResponse = await testimonialResponse.Content.ReadAsStringAsync();
                        aboutVM.Testimonials = (IEnumerable<Testimonial>)JsonConvert.DeserializeObject<IEnumerable<Testimonial>>(testimonialApiResponse);

                    }
                    else
                    {
                        ViewData["Error"] = "API request failed with status code: " + testimonialResponse.StatusCode;
                        aboutVM.Testimonials = new List<Testimonial>();
                    }

                    var settingResponse = await client.GetAsync($"{BaseURl}/api/setting/GetAll");
                    if (settingResponse.IsSuccessStatusCode)
                    {
                        string settingApiResponse = await settingResponse.Content.ReadAsStringAsync();
                        var settings = JsonConvert.DeserializeObject<IEnumerable<Setting>>(settingApiResponse);
                        aboutVM.Settings = settings.ToDictionary(s => s.Key, s => s.Value);
                    }

                    else
                    {
                        ViewData["Error"] = "API request failed with status code: " + settingResponse.StatusCode;
                        aboutVM.Settings = new Dictionary<string, string>();
                    }
                    var sliderResponse = await client.GetAsync(
                        $"{BaseURl}/api/Slider/GetAllActive/active"
                    );

                    if (sliderResponse.IsSuccessStatusCode)
                    {
                        string sliderApiResponse = await sliderResponse.Content.ReadAsStringAsync();
                        aboutVM.Sliders =
                            JsonConvert.DeserializeObject<IEnumerable<Slider>>(sliderApiResponse)
                            ?? new List<Slider>();


                    }
                    else
                    {
                        ViewData["Error"] = "API request failed with status code: " + sliderResponse.StatusCode;
                        aboutVM.Sliders = new List<Slider>();
                    }
                    var teamResponse = await client.GetAsync($"{BaseURl}/api/team/GetAll");
                    if (teamResponse.IsSuccessStatusCode)
                    {
                        string teamApiResponse = await teamResponse.Content.ReadAsStringAsync();
                        aboutVM.Teams =
                            JsonConvert.DeserializeObject<IEnumerable<Team>>(teamApiResponse)
                            ?? new List<Team>();


                    }
                    else
                    {
                        ViewData["Error"] = "API request failed with status code: " + teamResponse.StatusCode;
                        aboutVM.Teams = new List<Team>();
                    }

                }
                catch (HttpRequestException ex)
                {
                    ViewData["Error"] = $"API request failes:{ex.Message}";
                }


            }
            return View(aboutVM);
        }
    }
}

