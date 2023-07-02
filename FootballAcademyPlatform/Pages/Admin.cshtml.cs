using FootballAcademyPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballAcademyPlatform.Pages
{
    /// <summary>
    /// This controller confirms if the credentials passed by the form are correct
    /// with our singleton instance of admin and then gives access only for administrator
    /// to do actions into another page
    /// </summary>
    public class AdminModel : PageModel
    {
        public Admin? admin;

        public string? FormUsername { get; set; }
        public string? FormPassword { get; set; }
        public string ErrorMessage { get; set; } = "";

        public void OnGet()
        {
            
        }

        public void OnPost() 
        {
            admin = Admin.GetInstance();

            FormUsername = Request.Form["username"];
            FormPassword = Request.Form["password"];
            if( (admin!.AdminUsername == FormUsername) && (admin.AdminPassword == FormPassword))
            {
                Response.Redirect("/Teams/InsertTeam");
            }
            else
            {
                ErrorMessage = "Wrong Credentials!!!";
            }
        }
    }
}
