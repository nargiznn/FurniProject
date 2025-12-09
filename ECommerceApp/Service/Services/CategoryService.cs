using System;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using Service.Helpers.DTOs.Categories;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _cateRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,
                               IMapper mapper)
        {
            _cateRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task CreateAsync(CategoryCreateDto category)
        {
            await _cateRepository.CreateAsync(_mapper.Map<Category>(category));
        }

        public async Task DeleteAsync(int id)
        {
            await _cateRepository.DeleteAsync(id);

        }

        public async Task EditAsync(int id, CategoryEditDto categoryDto)
        {
            var existCategory = await _cateRepository.GetByIdAsync(id);

            if (existCategory is null)
                throw new NotFoundException("Category not found");
            _mapper.Map(categoryDto, existCategory);

            await _cateRepository.EditAsync(existCategory);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var data = await _cateRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDto>>(data);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var data = await _cateRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDto>(data);
        }

        public async Task<IEnumerable<CategoryDto>> SearchAsycn(string str)
        {
            var categories = await _cateRepository.GetAllWithExpressions(
                m => EF.Functions.Like(m.Name, $"%{str}%")
            );
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

    }
}

