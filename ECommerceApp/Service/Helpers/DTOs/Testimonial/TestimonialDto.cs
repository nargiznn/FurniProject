using System;
namespace Service.Helpers.DTOs.Testimonial
{
	public class TestimonialDto
	{
        public string FullName { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Image { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

