using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Teams
{
    /// <summary>
    /// This controller gets the Team Id from the query string and then calls the Team service layer
    /// to relate correctly the Coach with the Team and all the Players with the same Team.
    /// </summary>
    public class TeamOfCoachPlayersModel : PageModel
    {
        private readonly ICoachService coachService;
        private readonly ITeamService teamService;
        public TeamCoachReadDTO? TeamCoachDto { get; set; } = new();
        public List<TeamPlrsReadDTO> CoachPlayers { get; set; } = new();
        public TeamReadOnlyDTO? Team { get; set; } = new();
        public string ErrorMessage { get; set; } = "";

        public TeamOfCoachPlayersModel(ICoachService coachService, ITeamService teamService)
        {
            this.coachService = coachService;
            this.teamService = teamService;
        }

        public void OnGet()
        {

            try
            {
                int id = int.Parse(Request.Query["id"]);
                CoachReadOnlyDTO? coach = coachService.GetCoachById(id);
                int teamId = coach!.TeamId;
                TeamCoachDto = teamService.GetTeamsCoachById(teamId);

                CoachPlayers = teamService.GetTeamPlayers(teamId);

                Team = teamService.GetTeamById(teamId);   
            }catch(Exception ex) 
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
