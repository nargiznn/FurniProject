using System;
using Service.Helpers.DTOs.Testimonial;

namespace Service.Services.Interfaces
{
	public interface ITestimonialService
	{
		Task<IEnumerable<TestimonialDto>> GetAllAsync();
	}
}

