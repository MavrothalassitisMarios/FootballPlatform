
using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace FootballAcademyPlatform.Pages.Player
{
    /// <summary>
    /// This controller shows all the Details of a Player instance
    /// </summary>
    public class InfoModel : PageModel
    {
        private readonly IPlayerService playerService;
        public string ErrorMessage { get; set; } = "";
        public PlayerReadOnlyDTO? PlayerRead { get; set; } = new();
        public InfoModel(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void OnGet()
        {
            try
            {
                int id = int.Parse(Request.Query["id"]);
                PlayerRead = playerService.GetPlayerById(id);
                
                if (PlayerRead == null) 
                {
                    ErrorMessage = "No Data for this Player in the Plattform!!!";
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
