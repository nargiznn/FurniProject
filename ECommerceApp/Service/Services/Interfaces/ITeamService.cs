using System;
using Service.Helpers.DTOs.Team;

namespace Service.Services.Interfaces
{
	public interface ITeamService
	{
		Task<IEnumerable<TeamDto>> GetAllAsync();
	}
}

