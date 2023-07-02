using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballAcademyPlatform.Pages.Coach
{
    /// <summary>
    /// This controller authenticates the Coach inastance and if the credentials 
    /// are correct redirect to an another page only for Coaches
    /// </summary>
    public class LoginModel : PageModel
    {
        private readonly ICoachService coachService;
        public string ErrorMessage { get; set; } = "";
        public CoachReadOnlyDTO? CoachDto { get; set; } = new();
        public CoachReadOnlyDTO? DtoRedirect { get; set; } = new();
        public int IdOfDto { get; set; }
        public LoginModel(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            try 
            {
                CoachDto!.Username = Request.Form["username"];
                CoachDto.Password = Request.Form["password"];

                DtoRedirect = coachService.GetCoachByUsnmPass(CoachDto.Username,CoachDto.Password);
                
                if(DtoRedirect is not null)
                {
                    int IdOfDto = DtoRedirect.Id;
                    Response.Redirect($"/Teams/TeamOfCoachPlayers?id={IdOfDto}");

                }
                else
                {
                    ErrorMessage = "Wrong Credentials!! Try Again..";
                    return;
                }

            }catch(Exception ex) 
            {
                ErrorMessage = ex.Message;
                Response.Redirect("/Error");
            }
            
        }
    }
}
