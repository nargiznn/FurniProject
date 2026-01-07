using System;
using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace ECommerceApp.Controllers.UI
{
	public class TeamController:BaseController
	{
		private readonly ITeamService _teamService;
		public TeamController(ITeamService teamService)
		{
			_teamService = teamService;
		}
        [HttpGet]
        public async Task<IActionResult> GetAll()
		{
			var datas = await _teamService.GetAllAsync();
			return Ok(datas);
		}

	}
}

