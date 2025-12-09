using System;
using Domain.Entities;
using Service.Helpers.DTOs.Categories;

namespace Service.Services.Interfaces
{
	public interface ICategoryService
	{
		Task CreateAsync(CategoryCreateDto category);
		Task<CategoryDto> GetByIdAsync(int id);
		Task<IEnumerable<CategoryDto>> SearchAsycn(string str);
		Task<IEnumerable<CategoryDto>> GetAllAsync();
		Task DeleteAsync(int id);
        Task EditAsync(int id, CategoryEditDto category);


    }
}
