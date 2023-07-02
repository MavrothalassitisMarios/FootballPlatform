using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Player
{
    /// <summary>
    /// This controller gets the Team Id from the query string and then calls the Team service layer
    /// to relate correctly the Coach with the Team and all the Players with the same Team.
    /// </summary>
    public class SeeTeamModel : PageModel
    {
        private readonly ITeamService teamService;
        public string ErrorMessage { get; set; } = "";
        public TeamReadOnlyDTO? Team { get; set; } = new();
        public TeamCoachReadDTO? TeamCoachDto { get; set; } = new();
        public List<TeamPlrsReadDTO> TeamPlayers { get; set; } = new();
        public SeeTeamModel(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public void OnGet()
        {
            
            try
            {
                int id = int.Parse(Request.Query["id"]);
                Team = teamService.GetTeamById(id);

                TeamPlayers = teamService.GetTeamPlayers(id);
                TeamCoachDto = teamService.GetTeamsCoachById(id);
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
