using System;
namespace Service.Helpers.DTOs.BlogPost
{
	public class BlogPostDto
	{
        public string Title { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

