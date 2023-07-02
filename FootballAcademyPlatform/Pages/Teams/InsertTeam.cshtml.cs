using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Teams
{
    /// <summary>
    /// This controller fills the TeamCreateDTO fields with params of the form
    /// and calls the Team service layer for the insert action
    /// </summary>
    public class InsertTeamModel : PageModel
    {
        private readonly ITeamService teamService;
        public string? ErrorMessage { get; set; } = "";
        public TeamCreateDTO TeamDto { get; set; } = new TeamCreateDTO();

        public InsertTeamModel(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public void OnGet()
        {
        }
        public void OnPost() 
        {
            try
            {

                TeamDto.TeamName = Request.Form["teamName"];
                TeamDto.Logo = Request.Form["logo"];
                
                if (!ErrorMessage!.Equals("")) return;
                teamService.InsertTeam(TeamDto);
                Response.Redirect("/Teams/AllTeams");
                
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
