using FootballAcademyPlatform.DAO;
using FootballAcademyPlatform.DTO;
using FootballAcademyPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballAcademyPlatform.Pages.Player
{
    /// <summary>
    /// This controller gets the Player id from the query string and call the  Player service layer for the update
    ///  by passing the UpdatePlayer DTO
    /// </summary>
    public class UpdatePlayerModel : PageModel
    {
        private readonly IPlayerService playerService;
        public PlayerReadOnlyDTO? PlayerRead { get; set; } = new();
        public string ErrorMessage { get; set; } = "";

        public UpdatePlayerModel(IPlayerService playerService)
        {
            this.playerService = playerService;
        }

        public void OnGet()
        {
            try
            {
                int id = int.Parse(Request.Query["id"]);
                PlayerRead = playerService.GetPlayerById(id);
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
                PlayerUpdateDTO playerUpdateDTO = new()
                {
                    Id = int.Parse(Request.Form["id"]),
                    Firstname = Request.Form["firstname"],
                    Lastname = Request.Form["lastname"],
                    Phone = Request.Form["phone"],
                    HomePhone = Request.Form["home-phone"],
                    Address = Request.Form["address"],
                    DateOfBirth = DateTime.Parse(Request.Form["birthday"]),
                    Email = Request.Form["email"],
                    Height = Decimal.Parse(Request.Form["height"]),
                    Weight = Decimal.Parse(Request.Form["weight"]),
                    Position = Request.Form["position"],
                    KeyAttribute = Request.Form["kAtr"],
                    StrongFoot = Request.Form["strFoot"],
                    TeamId = int.Parse(Request.Form["teamId"])
                };


                if (!ErrorMessage.Equals("")) return;

                playerService.UpdatePlayer(playerUpdateDTO);
                Response.Redirect($"/Player/SeeTeam?id={playerUpdateDTO.TeamId}");
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                Response.Redirect("/Error");
            }
        }
    }
}
