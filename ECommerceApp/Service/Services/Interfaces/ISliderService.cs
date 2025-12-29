using System;
using Domain.Entities;
using Service.Helpers.DTOs.Brand;
using Service.Helpers.DTOs.Slider;

namespace Service.Services.Interfaces
{
	public interface ISliderService
	{
        //Task<string> CreateAsync(SliderCreateDto slider);
        //Task<string> EditAsync(int id, SliderEditDto slider);
        Task<IEnumerable<SliderDto>> GetAllActiveAsync();
        Task<IEnumerable<SliderDto>> GetAllAsync();
        Task<SliderDto?> GetByIdAsync(int id);

    }
}

//Task CreateAsync(BrandCreateDto brand);
//Task<BrandDto> GetByIdAsync(int id);
//Task<IEnumerable<BrandDto>> SearchAsycn(string str);
//Task<IEnumerable<BrandDto>> GetAllAsync();
//Task DeleteAsync(int id);
//Task EditAsync(int id, BrandEditDto brand);

//Task<IEnumerable<SliderDto>> GetAllActiveAsync();
//Task<IEnumerable<SliderDto>> GetAllAsync();
//Task<SliderDto?> GetByIdAsync(int id);

//Task CreateAsync(SliderCreateDto dto);
//Task EditAsync(int id, SliderEditDto dto);
//Task DeleteAsync(int id);