using System;
using EcommerceConsume.Models;

namespace EcommerceConsume.ViewModels
{
	public class HomeVM
	{
        public IEnumerable<Slider> Sliders { get; set; } = new List<Slider>();
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Testimonial> Testimonials { get; set; }
        public Dictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();
    }
}

