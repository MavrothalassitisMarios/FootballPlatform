using FootballAcademyPlatform.DAO;
using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballAcademyPlatform.Pages.Coach
{
    /// <summary>
    /// This controller gets the Coach id from the query string and call the  Coach service layer for the update
    ///  by passing the UpdateCoach DTO
    /// </summary>
    public class UpdateCoachModel : PageModel
    {
        private readonly ICoachService coachService;
        public string ErrorMessage { get; set; } = "";
        public CoachReadOnlyDTO? CoachRead { get; set; } = new();
        public int Id { get; set; }
        public UpdateCoachModel(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        public void OnGet()
        {
            try
            {
                Id = int.Parse(Request.Query["id"]);
                CoachRead = coachService.GetCoachById(Id);
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
                CoachUpdateDTO coachUpdate = new()
                {
                    Id = int.Parse(Request.Form["id"]),
                    Username = Request.Form["username"],
                    Password = Request.Form["password"],
                    Firstname = Request.Form["firstname"],
                    Lastname = Request.Form["lastname"],
                    Phone = Request.Form["phone"],
                    Address = Request.Form["address"],
                    Email = Request.Form["email"],
                };                

                
                if (!ErrorMessage.Equals("")) return;

                coachService.UpdateCoach(coachUpdate);
                Response.Redirect($"/Teams/TeamOfCoachPlayers?id={coachUpdate.Id}");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Response.Redirect("/Error");
            }
        }
    }
}
