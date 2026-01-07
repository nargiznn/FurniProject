using System;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace ECommerceApp.Controllers.UI
{
	public class TestimonialController:BaseController
	{
		private readonly ITestimonialService _testimonialService;
		public TestimonialController(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var datas = await _testimonialService.GetAllAsync();
			return Ok(datas);
		}
	}
}

