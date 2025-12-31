using System;
namespace EcommerceConsume.Common
{
	public class BaseEntity
	{
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}

