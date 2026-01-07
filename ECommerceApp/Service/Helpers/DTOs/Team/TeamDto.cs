using System;
namespace Service.Helpers.DTOs.Team
{
	public class TeamDto
	{
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}

