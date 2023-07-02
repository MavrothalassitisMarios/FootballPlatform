using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Coach
{
    /// <summary>
    /// This controller fills the CoachCreateDTO fields with params of the form
    /// and calls the Coach service layer for the insert action
    /// </summary>
    public class InsertCoachModel : PageModel
    {
        private readonly ITeamService teamService;
        private readonly ICoachService coachService;
        public string ErrorMessage { get; set; } = "";
        public CoachCreateDTO CoachDto { get; set; } = new();
        public List<TeamReadOnlyDTO> TeamsList { get; set; } = new();
        public List<CoachReadOnlyDTO> CoachesList { get; set; } = new();


        public InsertCoachModel(ICoachService coachService, ITeamService teamService)
        {
            this.coachService = coachService;
            this.teamService = teamService;
        }
        public void OnGet()
        {
            ErrorMessage = "";
            try
            {
                TeamsList = teamService.GetAllTeams();
                CoachesList = coachService.GetAllCoaches();
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
                CoachDto.Username = Request.Form["username"];
                CoachDto.Password = Request.Form["password"];
                CoachDto.Firstname = Request.Form["firstname"];
                CoachDto.Lastname = Request.Form["lastname"];
                CoachDto.Phone = Request.Form["phone"];
                CoachDto.Address = Request.Form["address"];
                CoachDto.Email = Request.Form["email"];
                CoachDto.TeamId = int.Parse(Request.Form["teamId"]);

                ModelState.AddModelError("CoachDto.Username", ErrorMessage);
                ModelState.AddModelError("CoachDto.Password", ErrorMessage);
                ModelState.AddModelError("CoachDto.Firstname", ErrorMessage);
                ModelState.AddModelError("CoachDto.Lastname", ErrorMessage);
                ModelState.AddModelError("CoachDto.Phone", ErrorMessage);
                ModelState.AddModelError("CoachDto.Address", ErrorMessage);
                ModelState.AddModelError("CoachDto.Email", ErrorMessage);
                ModelState.AddModelError("CoachDto.TeamId.ToString()", ErrorMessage);
                
                if (!ModelState.IsValid)
                {
                    Console.WriteLine("we are here");
                    Response.Redirect("/Error");
                }

                coachService.InsertCoach(CoachDto);
                Response.Redirect("/Coach/Login");
            }catch (Exception e) 
            {
                ErrorMessage = e.Message;
                Response.Redirect("/Error");
                 
            }
        }
    }
}
