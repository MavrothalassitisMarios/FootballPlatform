using AutoMapper;
using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Models;
using PlattformForFootballAcademy.DTO;


namespace FootballAcademyPlatform.Configuration
{
    /// <summary>
    /// A Configuration Mapping class that does the mapping of the DTO's with the related models
    /// </summary>
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<TeamCreateDTO,Team>().ReverseMap();
            CreateMap<TeamUpdateDto, Team>().ReverseMap();
            CreateMap<TeamReadOnlyDTO, Team>().ReverseMap();
            CreateMap<TeamCoachReadDTO,Coach>().ReverseMap();
            CreateMap<TeamPlrsReadDTO,Player>().ReverseMap();

            CreateMap<CoachCreateDTO, Coach>().ReverseMap();
            CreateMap<CoachUpdateDTO, Coach>().ReverseMap();
            CreateMap<CoachReadOnlyDTO, Coach>().ReverseMap();

            CreateMap<PlayerCreateDTO, Player>().ReverseMap();
            CreateMap<PlayerUpdateDTO, Player>().ReverseMap();
            CreateMap<PlayerReadOnlyDTO, Player>().ReverseMap();
            CreateMap<CoachPlayerUpdateDTO, Player>().ReverseMap();
        }
    }
}
