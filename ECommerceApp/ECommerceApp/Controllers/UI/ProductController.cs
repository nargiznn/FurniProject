using System;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace ECommerceApp.Controllers.UI
{
	public class ProductController:BaseController
	{
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var datas = await _productService.GetAllAsync();
            return Ok(datas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }
    }
}

