using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Models;

namespace FootballAcademyPlatform.Services
{
    /// <summary>
    /// An interface implements all the CRUD actions of the service layer for Coach model
    /// </summary>
    public interface ICoachService
    {
        void InsertCoach(CoachCreateDTO? dto);
        void UpdateCoach(CoachUpdateDTO? dto);
        CoachReadOnlyDTO? DeleteCoach(int id);
        CoachReadOnlyDTO? GetCoachById(int id);
        CoachReadOnlyDTO? GetCoachByUsnmPass(string username, string password);
        List<CoachReadOnlyDTO> GetAllCoaches();
    }
}
