using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballAcademyPlatform.Pages.Coach
{
    /// <summary>
    /// This controller gets the Coach id from the query string and call the service layer for the delete
    /// </summary>
    public class DeleteCoachModel : PageModel
    {
        private readonly ICoachService coachService;
        public string ErrorMessage { get; set; } = "";
        public CoachReadOnlyDTO? CoachRead { get; set; } = new();
        public int Id { get; set; }
        public DeleteCoachModel(ICoachService coachService)
        {
            this.coachService = coachService;
        }
        public void OnGet()
        {
           
            try
            {
                Id = int.Parse(Request.Query["id"]);
                CoachRead = coachService.DeleteCoach(Id);
                if (CoachRead == null) 
                {
                    ErrorMessage = "Error in deleteing Coach";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
  
    }
}
