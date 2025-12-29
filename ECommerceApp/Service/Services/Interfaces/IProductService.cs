using System;
using Service.Helpers.DTOs.Product;

namespace Service.Services.Interfaces
{
	public interface IProductService
	{
        Task CreateAsync(ProductCreateDto product);
        Task<ProductDto> GetByIdAsync(int id);
        Task<IEnumerable<ProductDto>> SearchAsycn(string str);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task DeleteAsync(int id);
        Task EditAsync(int id, ProductEditDto product);
    }
}

