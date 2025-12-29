using System;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using Service.Helpers.DTOs.Product;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class ProductService: IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,
                            IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(ProductCreateDto productDto)
        {
            var existProduct = await _productRepository.GetAllWithExpressions(
                x => x.Name.ToLower().Trim() == productDto.Name.ToLower().Trim()
            );

            if (existProduct.Any())
                throw new BadRequestException("Product name already exists.");

            await _productRepository.CreateAsync(_mapper.Map<Product>(productDto));
        }
        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);

        }
        public async Task EditAsync(int id, ProductEditDto productDto)
        {
            var existProduct = await _productRepository.GetByIdAsync(id);

            if (existProduct is null)
                throw new NotFoundException("Product not found");

            if (!string.IsNullOrWhiteSpace(productDto.Name))
            {
                var duplicate = await _productRepository.GetAllWithExpressions(
                    x => x.Id != id && x.Name.ToLower() == productDto.Name.ToLower()
                );

                if (duplicate.Any())
                    throw new BadRequestException("Product name already exists.");
            }
            _mapper.Map(productDto, existProduct);

            await _productRepository.EditAsync(existProduct);
        }
        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var data = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(data);
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var data = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(data);
        }

        public async Task<IEnumerable<ProductDto>> SearchAsycn(string str)
        {
            str = str.Trim();

            var products = await _productRepository.GetAllWithExpressions(
                m =>
                    EF.Functions.Like(m.Name, $"%{str}%"));

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}

