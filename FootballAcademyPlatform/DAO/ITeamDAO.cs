using FootballAcademyPlatform.Models;

namespace FootballAcademyPlatform.DAO
{
    /// <summary>
    /// An interface with all the CRUD actions of the Team Entity
    /// </summary>
    public interface ITeamDAO
    {
        void Insert(Team team);
        void Update(Team team);
        
        Team? GetById(int id);
        List<Team> GetAll();

        Coach? GetTCById(int teamId);
        List<Player> GetPlayers(int teamId);
    }
}
