using System;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace ECommerceApp.Controllers.UI
{
	public class BlogPostController:BaseController
    {
        private readonly IBlogPostService _blogService;

        public BlogPostController(IBlogPostService blogService)
        {
            _blogService = blogService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas = await _blogService.GetAllAsync();
            return Ok(datas);
        }
    }
}

