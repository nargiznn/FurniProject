using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Product:BaseEntity
	{
        public string Name { get; set; } = null!;
        public string Slug { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsFeatured { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

