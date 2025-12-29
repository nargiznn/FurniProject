using System;
using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.Helpers.DTOs.Slider;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class SliderService:ISliderService
	{
        private readonly ISliderRepository _sliderRepository;
        private readonly IMapper _mapper;

        public SliderService(ISliderRepository sliderRepository, IMapper mapper)
        {
            _sliderRepository = sliderRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SliderDto>> GetAllActiveAsync()
        {
            var sliders = await _sliderRepository
                .GetAllWithExpressions(s => s.IsActive);

            return _mapper.Map<IEnumerable<SliderDto>>(sliders);
        }


        public async Task<IEnumerable<SliderDto>> GetAllAsync()
        {
            var sliders = await _sliderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SliderDto>>(sliders);
        }

        public async Task<SliderDto?> GetByIdAsync(int id)
        {
            var slider = await _sliderRepository.GetByIdAsync(id);
            return slider == null ? null : _mapper.Map<SliderDto>(slider);
        }
    }
}

