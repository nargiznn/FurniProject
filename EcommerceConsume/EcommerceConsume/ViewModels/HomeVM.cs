using System;
using EcommerceConsume.Models;

namespace EcommerceConsume.ViewModels
{
	public class HomeVM
	{
        public IEnumerable<Slider> Sliders { get; set; } = new List<Slider>();
    }
}

