using System;
using Service.Helpers.DTOs.Brand;
namespace Service.Services.Interfaces
{
	public interface IBrandService
	{
		Task CreateAsync(BrandCreateDto brand);
        Task<BrandDto> GetByIdAsync(int id);
        Task<IEnumerable<BrandDto>> SearchAsycn(string str);
        Task<IEnumerable<BrandDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task EditAsync(int id, BrandEditDto brand);
    }
}

