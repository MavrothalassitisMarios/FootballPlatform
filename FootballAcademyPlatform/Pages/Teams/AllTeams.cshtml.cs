using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Teams
{
    /// <summary>
    /// This controller gets and shows us all the existed Teams calling the Team service layer
    /// </summary>
    public class AllTeamsModel : PageModel
    {
        private readonly ITeamService teamService;
        public List<TeamReadOnlyDTO> TeamsList { get; set; } = new();
        public string? ErrorMessage { get; set; }

        public AllTeamsModel(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        public void OnGet()
        {
            ErrorMessage = "";
            try
            {
                TeamsList = teamService.GetAllTeams();
            }catch(Exception e) 
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
