using System;
using Service.Helpers.DTOs.BlogPost;

namespace Service.Services.Interfaces
{
	public interface IBlogPostService
	{
        Task<IEnumerable<BlogPostDto>> GetAllAsync();
    }
}

