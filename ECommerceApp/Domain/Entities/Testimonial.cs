using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Testimonial:BaseEntity
	{
        public string FullName { get; set; } = null!;  
        public string Profession { get; set; } = null!; 
        public string Message { get; set; } = null!; 
        public string? Image { get; set; } 
        public bool IsActive { get; set; } = true;
    }
}

