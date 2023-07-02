using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Coach
{
    /// <summary>
    /// This controller gets the Player id from the query string to relate the correct
    /// Team with the Player and Coach all together using the Team service layer
    /// and then calls the Player service to pass the UpdateDTO and make the update
    /// </summary>
    public class PlayerDetailUpdateModel : PageModel
    {
        private readonly ITeamService teamService;
        private readonly IPlayerService playerService;
        public PlayerReadOnlyDTO? PlayerDto { get; set; } = new();
        public TeamCoachReadDTO? TeamCoachDto { get; set; } = new();
        public List<TeamReadOnlyDTO> TeamsList { get; set; } = new();
        public int IdOfTeam { get; set; }
        public string ErrorMessage { get; set; } = "";

        public PlayerDetailUpdateModel(ITeamService teamService, IPlayerService playerService)
        {
            this.teamService = teamService;
            this.playerService = playerService;
        }

        public void OnGet()
        {
            try
            {
                int id = int.Parse(Request.Query["id"]);
                PlayerDto = playerService.GetPlayerById(id);
                IdOfTeam = PlayerDto!.TeamId;

                TeamsList = teamService.GetAllTeams();

                TeamCoachDto = teamService.GetTeamsCoachById(IdOfTeam);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            
        }

        public void OnPost()
        {
            try
            {
                CoachPlayerUpdateDTO? coachPlayerUpdate = new()
                {
                    Id = int.Parse(Request.Form["id"]),
                    Height = Decimal.Parse(Request.Form["height"]),
                    Weight = Decimal.Parse(Request.Form["weight"]),
                    Position = Request.Form["position"],
                    KeyAttribute = Request.Form["kAtr"],
                    TeamId = int.Parse(Request.Form["teamId"])
                };
                if (!ErrorMessage.Equals("")) return;
                int id = int.Parse(Request.Form["coachId"]);
                playerService.UpdateCoachPlayer(coachPlayerUpdate);
                Response.Redirect($"/Teams/TeamOfCoachPlayers?id={id}");

            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Response.Redirect("/Error");
            }
        }
    }
}
