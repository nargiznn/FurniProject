using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Team:BaseEntity
	{
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public bool IsActive { get; set; }

    }
}

