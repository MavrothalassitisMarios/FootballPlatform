using FootballAcademyPlatform.Models;

namespace FootballAcademyPlatform.DAO
{
    /// <summary>
    /// An interface with all the CRUD actions of the Coach Entity
    /// </summary>
    public interface ICoachDAO
    {
        void InsertC(Coach? coach);
        void UpdateC(Coach? coach);
        void DeleteC(int id);
        Coach? GetCById(int id);
        Coach? GetCByUsnmPass(string username, string password);
        List<Coach> GetAllC();
    }
}
