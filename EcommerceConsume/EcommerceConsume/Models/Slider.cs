using System;
using EcommerceConsume.Common;

namespace EcommerceConsume.Models
{
	public class Slider:BaseEntity
	{
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public string? PrimaryButtonText { get; set; }
        public string? PrimaryButtonUrl { get; set; }

        public string? SecondaryButtonText { get; set; }
        public string? SecondaryButtonUrl { get; set; }

        public bool IsActive { get; set; }
        public int Order { get; set; }
    }
}

