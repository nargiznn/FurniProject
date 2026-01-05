using System;
using Domain.Common;

namespace Domain.Entities
{
	public class BlogPost:BaseEntity
	{
        public string Title { get; set; }
        public string Image { get; set; }
        public string Author { get; set; }
    }
}

