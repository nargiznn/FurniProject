using System;
using AutoMapper;
using Repository.Data;
using Repository.Repositories.Interfaces;
using Service.Helpers.DTOs.Testimonial;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;
        private readonly IMapper _mapper;
        public TestimonialService(ITestimonialRepository testimonialRepository,IMapper mapper)
        {
            _testimonialRepository = testimonialRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TestimonialDto>> GetAllAsync()
        {
            var data = await _testimonialRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TestimonialDto>>(data);
        }
    }
}

