using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Models;

namespace FootballAcademyPlatform.Services
{
    /// <summary>
    /// An interface implements all the CRUD actions of the service layer for Player model
    /// </summary>
    public interface IPlayerService
    {
        void InsertPLayer(PlayerCreateDTO? pDto);
        void UpdatePlayer(PlayerUpdateDTO? pDto);
        void UpdateCoachPlayer(CoachPlayerUpdateDTO coachPlayerUpdate);
        PlayerReadOnlyDTO? DeletePlayer(int id);
        PlayerReadOnlyDTO? GetPlayerById(int id);
        PlayerReadOnlyDTO? GetPlayerByEmail(string email);
        List<PlayerReadOnlyDTO> GetAllPlayers();
    }
}
