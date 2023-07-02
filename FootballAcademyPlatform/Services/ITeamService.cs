using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Models;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Services
{
    /// <summary>
    /// An interface implements all the CRUD actions of the service layer for Team model
    /// </summary>
    public interface ITeamService
    {
        void InsertTeam(TeamCreateDTO? teamCreate);
        void UpdateTeam(TeamUpdateDto? teamUpdate);

        TeamReadOnlyDTO? GetTeamById(int id);
        List<TeamReadOnlyDTO> GetAllTeams();

        TeamCoachReadDTO? GetTeamsCoachById(int teamId);
        List<TeamPlrsReadDTO> GetTeamPlayers(int teamId);
    }
}
