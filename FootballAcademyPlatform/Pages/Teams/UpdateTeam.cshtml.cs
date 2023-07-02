using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Teams
{
    /// <summary>
    /// This controller gets all the Teams existing to choose which one to be updated.
    /// Then calls the  Team service layer for the update
    /// by passing the UpdateTeam DTO
    /// </summary>
    public class UpdateTeamModel : PageModel
    {
        private readonly ITeamService teamService;
        public List<TeamReadOnlyDTO> TeamsList { get; set; } = new();
        public string? ErrorMessage { get; set; } = "";

        public UpdateTeamModel(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public void OnGet()
        {
            try
            {
                TeamsList = teamService.GetAllTeams();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }

        }
        public void OnPost() 
        {
            try
            {
                TeamUpdateDto updateDto = new()
                {
                    Id = int.Parse(Request.Form["teamId"]),
                    TeamName = Request.Form["teamName"],
                    Logo = Request.Form["logo"]
                };

                if (!ErrorMessage!.Equals("")) return;
                
                teamService.UpdateTeam(updateDto);
                Response.Redirect($"/Teams/AllTeams");

            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Response.Redirect("/Error");
            }
        }
    }
}
