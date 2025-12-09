using System;
namespace Service.Helpers.DTOs.Categories
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Date { get; set; }
        public string? Description { get; set; }
    }
}

