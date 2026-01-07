using System;
using AutoMapper;
using Repository.Repositories.Interfaces;
using Service.Helpers.DTOs.Team;
using Service.Services.Interfaces;

namespace Service.Services
{
	public class TeamService:ITeamService
	{
        private readonly ITeamRepository _repository;
        private readonly IMapper _mapper;
		public TeamService(ITeamRepository repository,IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
		}

        public async Task<IEnumerable<TeamDto>> GetAllAsync()
        {
            var datas = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TeamDto>>(datas);
        }
    }
}

