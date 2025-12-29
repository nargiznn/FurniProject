using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Service.Helpers.DTOs.Slider;
using Service.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ECommerceApp.Controllers.UI
{
    public class SliderController : BaseController
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<SliderDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _sliderService.GetAllAsync());
        }

        // GET: api/admin/slider/active
        [HttpGet("active")]
        [ProducesResponseType(typeof(IEnumerable<SliderDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllActive()
        {
            return Ok(await _sliderService.GetAllActiveAsync());
        }

        // GET: api/admin/slider/{id}
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(SliderDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _sliderService.GetByIdAsync(id));
        }
    }
}

