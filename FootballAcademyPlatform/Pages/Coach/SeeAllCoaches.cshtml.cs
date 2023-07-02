using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballAcademyPlatform.Pages.Coach
{
    /// <summary>
    /// This controller shows all the existing Coach instances
    /// </summary>
    public class SeeAllCoachesModel : PageModel
    {
        private readonly ICoachService coachService;
        public string ErrorMessage { get; set; } = "";
        public List<CoachReadOnlyDTO> CoachesList { get; set; } = new();

        public SeeAllCoachesModel(ICoachService coachService)
        {
            this.coachService = coachService;
        }

        public void OnGet()
        {
            ErrorMessage = "";
            try
            {
                CoachesList = coachService.GetAllCoaches();
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
        }
    }
}
