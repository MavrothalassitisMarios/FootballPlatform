using AutoMapper;
using FootballAcademyPlatform.DAO;
using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Models;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Services
{
    /// <summary>
    /// A  Team Service layer that communicates with the controllers by getting
    /// Team DTO's and then pass simple model instances to the DAO layer for the CRUD actions
    /// </summary>
    public class TeamServiceImpl : ITeamService
    {
        private readonly IMapper mapper;
        private readonly ITeamDAO teamDAO;

        public TeamServiceImpl(IMapper mapper, ITeamDAO teamDAO)
        {
            this.mapper = mapper;
            this.teamDAO = teamDAO;
        }

        /// <summary>
        /// mapping the DTO to Team instance and pass it to the DAO for the insert
        /// </summary>
        /// <param name="teamCreate">The DTO for the insert action</param>
        public void InsertTeam(TeamCreateDTO? teamCreate)
        {
            if (teamCreate == null) return;
            Team team = mapper.Map<Team>(teamCreate);
            try
            {
                teamDAO.Insert(team);
            }catch (Exception e) 
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// mapping the DTO to Team instance and pass it to the DAO for the update
        /// </summary>
        /// <param name="teamUpdate">The DTO for the update action</param>
        public void UpdateTeam(TeamUpdateDto? teamUpdate)
        {
            if (teamUpdate == null) return;
            Team team = mapper.Map<Team>(teamUpdate);
            try
            {
                teamDAO.Update(team);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        /// <summary>
        /// Get the instance from DAO and then do the mapping
        /// </summary>
        /// <param name="id">the id of Team to be found</param>
        /// <returns>A Team DTO instance</returns>
        public TeamReadOnlyDTO? GetTeamById(int id)
        {
            Team? team = null;
            

            try
            {
                team = teamDAO.GetById(id);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            TeamReadOnlyDTO? dtoReturn = mapper.Map<TeamReadOnlyDTO>(team);
            return dtoReturn;
        }

        /// <summary>
        /// Get the instances from DAO and then do the mapping into a List
        /// </summary>
        /// <returns>A List of Team DTO's or empty list if there is none</returns>
        public List<TeamReadOnlyDTO> GetAllTeams()
        {
            List<TeamReadOnlyDTO> dtoTeams = new List<TeamReadOnlyDTO>();
            List<Team> teams = new List<Team>();

            try
            {
                teams = teamDAO.GetAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            
            dtoTeams = mapper.Map<List<TeamReadOnlyDTO>>(teams);
            return dtoTeams;
        }

        /// <summary>
        /// Get the Coach instance from DAO related with the specific Team instance
        /// and then do the mapping
        /// </summary>
        /// <param name="teamId">the id relates the Coach and Team</param>
        /// <returns>A Team-Coach DTO</returns>
        public TeamCoachReadDTO? GetTeamsCoachById(int teamId)
        {
            Coach? coach = null;

            try
            {
                coach = teamDAO.GetTCById(teamId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }

            TeamCoachReadDTO teamCoach = mapper.Map<TeamCoachReadDTO>(coach);
            return teamCoach;
        }

        /// <summary>
        /// Get the PLayers instances from DAO related with the specific Team instance
        /// and then do the mapping
        /// </summary>
        /// <param name="teamId">the id relates the Player and Team</param>
        /// <returns>A List of Team-Players DTO</returns>
        public List<TeamPlrsReadDTO> GetTeamPlayers(int teamId)
        {
            List<Player> players = new List<Player>();
            List<TeamPlrsReadDTO> teamPlayers = new List<TeamPlrsReadDTO>();

            try
            {
                players = teamDAO.GetPlayers(teamId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            teamPlayers = mapper.Map<List<TeamPlrsReadDTO>>(players);
            return teamPlayers;
        }
    }
}
