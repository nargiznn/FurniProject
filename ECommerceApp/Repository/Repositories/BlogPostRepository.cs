using System;
using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
	public class BlogPostRepository: BaseRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(AppDbContext context) : base(context) { }
    }
}


