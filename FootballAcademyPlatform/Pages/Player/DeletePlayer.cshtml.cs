using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballAcademyPlatform.Pages.Player
{
    /// <summary>
    /// This controller gets the Player id from the query string and call the Player service layer for the delete
    /// After that it redirects to another page passing the coach id into the url
    /// </summary>
    public class DeletePlayerModel : PageModel
    {
        private readonly IPlayerService playerService;
        private readonly ITeamService teamService;

        public DeletePlayerModel(IPlayerService playerService, ITeamService teamService)
        {
            this.playerService = playerService;
            this.teamService = teamService;
        }

        public void OnGet()
        {
            int id = int.Parse(Request.Query["id"]);
            PlayerReadOnlyDTO? playerDto = playerService.GetPlayerById(id);
            int idOfTeam = playerDto!.TeamId;
            TeamCoachReadDTO? coachDto = teamService.GetTeamsCoachById(idOfTeam);

            playerService.DeletePlayer(id);
            Response.Redirect($"/Teams/TeamOfCoachPlayers?id={coachDto!.Id}");
        }
    }
}
