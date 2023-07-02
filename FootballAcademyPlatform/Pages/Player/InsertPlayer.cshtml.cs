using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PlattformForFootballAcademy.DTO;

namespace FootballAcademyPlatform.Pages.Player
{
    /// <summary>
    /// This controller gets the Team Id to be related with the foreign key of the new Player instance
    ///  and then fills the PlayerCreateDTO fields with params of the form
    /// and calls the Player service layer for the insert action.
    /// Then redirect to an another page passing the same Team Id into the url.
    /// </summary>
    public class InsertPlayerModel : PageModel
    {
        private readonly ITeamService teamService;
        private readonly IPlayerService playerService;
        public int TeamId { get; set; }
        public PlayerCreateDTO PlayerDto { get; set; } = new();
        public string ErrorMessage { get; set; } = "";

        public InsertPlayerModel(ITeamService teamService, IPlayerService playerService)
        {
            this.teamService = teamService;
            this.playerService = playerService;
        }

        public void OnGet()
        {
            ErrorMessage = "";
            try
            {
                TeamId = int.Parse(Request.Query["id"]);
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
                PlayerDto.Firstname = Request.Form["firstname"];
                PlayerDto.Lastname = Request.Form["lastname"];
                PlayerDto.Phone = Request.Form["phone"];
                PlayerDto.HomePhone = Request.Form["home-phone"];
                PlayerDto.Address = Request.Form["address"];
                PlayerDto.DateOfBirth = DateTime.Parse(Request.Form["birthday"]);
                PlayerDto.Email = Request.Form["email"];
                PlayerDto.Height = Decimal.Parse(Request.Form["height"]);
                PlayerDto.Weight = Decimal.Parse(Request.Form["weight"]);
                PlayerDto.Position = Request.Form["position"];
                PlayerDto.KeyAttribute = Request.Form["kAtr"];
                PlayerDto.StrongFoot = Request.Form["strFoot"];
                PlayerDto.TeamId = int.Parse(Request.Form["teamId"]);

                ModelState.AddModelError(PlayerDto.Firstname, ErrorMessage);
                ModelState.AddModelError(PlayerDto.Lastname, ErrorMessage);
                ModelState.AddModelError(PlayerDto.Phone, ErrorMessage);
                ModelState.AddModelError(PlayerDto.HomePhone, ErrorMessage);
                ModelState.AddModelError(PlayerDto.Address, ErrorMessage);
                ModelState.AddModelError(PlayerDto.Email, ErrorMessage); 

                

                if (!ModelState.IsValid) 
                {
                    Console.WriteLine("we are here");
                    Response.Redirect("/Error");
                }
                    

                playerService.InsertPLayer(PlayerDto);
                Response.Redirect($"/Player/SeeTeam?id={PlayerDto.TeamId}");
            }
            catch (Exception e)
            {
                
                ErrorMessage = e.Message;
                Response.Redirect("/Error");

            }
        }
    }
}
