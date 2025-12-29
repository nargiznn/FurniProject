using System;
using Domain.Entities;

namespace Service.Helpers.DTOs.Product
{
	public class ProductDto
	{
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Date { get; set; }
        public string Slug { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsFeatured { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}

