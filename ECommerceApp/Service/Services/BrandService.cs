using System;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Exceptions;
using Repository.Repositories.Interfaces;
using Service.Helpers.DTOs.Brand;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class BrandService:IBrandService
	{
        private readonly IBrandRepository _brandRepository;
        private readonly IMapper _mapper;
		public BrandService(IBrandRepository brandRepository,
                            IMapper mapper)
		{
            _brandRepository = brandRepository;
            _mapper = mapper;
		}
        public async Task CreateAsync(BrandCreateDto brandDto)
        {
            var existBrand = await _brandRepository.GetAllWithExpressions(
                x => x.Name.ToLower().Trim() == brandDto.Name.ToLower().Trim()
            );

            if (existBrand.Any())
                throw new BadRequestException("Brand name already exists.");

            await _brandRepository.CreateAsync(_mapper.Map<Brand>(brandDto));
        }
        public async Task DeleteAsync(int id)
        {
            await _brandRepository.DeleteAsync(id);

        }
        public async Task EditAsync(int id, BrandEditDto brandDto)
        {
            var existBrand = await _brandRepository.GetByIdAsync(id);

            if (existBrand is null)
                throw new NotFoundException("Brand not found");

            if (!string.IsNullOrWhiteSpace(brandDto.Name))
            {
                var duplicate = await _brandRepository.GetAllWithExpressions(
                    x => x.Id != id && x.Name.ToLower() == brandDto.Name.ToLower()
                );

                if (duplicate.Any())
                    throw new BadRequestException("Brand name already exists.");
            }
            _mapper.Map(brandDto, existBrand);

            await _brandRepository.EditAsync(existBrand);
        }
        public async Task<IEnumerable<BrandDto>> GetAllAsync()
        {
            var datas = await _brandRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BrandDto>>(datas);
        }

        public async Task<BrandDto> GetByIdAsync(int id)
        {
            var data = await _brandRepository.GetByIdAsync(id);
            return _mapper.Map<BrandDto>(data);
        }

        public async Task<IEnumerable<BrandDto>> SearchAsycn(string str)
        {
            str = str.Trim();

            var brands = await _brandRepository.GetAllWithExpressions(
                m =>
                    EF.Functions.Like(m.Name, $"%{str}%"));

            return _mapper.Map<IEnumerable<BrandDto>>(brands);
        }
    }
}

