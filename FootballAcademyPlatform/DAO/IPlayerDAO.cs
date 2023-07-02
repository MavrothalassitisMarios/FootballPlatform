using FootballAcademyPlatform.Models;

namespace FootballAcademyPlatform.DAO
{
    /// <summary>
    /// An interface with all the CRUD actions of the Player Entity
    /// </summary>
    public interface IPlayerDAO
    {
        void InsertP(Player? player);
        void UpdateP(Player? player);
        void UpdateCoachP(Player? player);
        void DeleteP(int id);
        Player? GetPById(int id);
        Player? GetPByEmail(string email);
        List<Player> GetAllP();
    }
}
