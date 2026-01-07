using System;
namespace EcommerceConsume.Models
{
	public class Testimonial
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string FullName { get; set; } = null!;
        public string Profession { get; set; } = null!;
        public string Message { get; set; } = null!;
        public string? Image { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

