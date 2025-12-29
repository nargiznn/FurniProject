using System;
namespace Service.Helpers.DTOs.Product
{
	public class ProductEditDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsFeatured { get; set; }

        public int CategoryId { get; set; }
    }
}

