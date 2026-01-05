using System;
using EcommerceConsume.Models;

namespace EcommerceConsume.ViewModels
{
	public class BlogVM
	{
        public IEnumerable<BlogPost> BlogPosts { get; set; }
        public IEnumerable<Slider> Sliders { get; set; } = new List<Slider>();
        public Dictionary<string, string> Settings { get; set; } = new Dictionary<string, string>();
    }
}

