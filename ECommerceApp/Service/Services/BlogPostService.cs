using System;
using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.Helpers.DTOs.BlogPost;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class BlogPostService:IBlogPostService
	{
        private readonly IBlogPostRepository _blogRepository;
        private readonly IMapper _mapper;
        public BlogPostService(IBlogPostRepository blogRepository,
                               IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<BlogPostDto>> GetAllAsync()
        {
            var data = await _blogRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<BlogPostDto>>(data);
        }
    }
}

