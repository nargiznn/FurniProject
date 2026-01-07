using System;
namespace EcommerceConsume.Models
{
	public class Team
	{
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}

