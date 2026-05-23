using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.User
{
    public class RegisterModel : PageModel
    {
        private readonly UsersServices _usersServices = new UsersServices();
        public Users User { get; set; } = new Users();

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Users user = new Users();
            user.UserName = Convert.ToString(Request.Form["UserName"]);
            user.Password = Convert.ToString(Request.Form["Password"]);
            user.IsAdmin = Convert.ToBoolean(Request.Form["IsAdmin"]);

            _usersServices.Register(user);

            return Redirect("/ModelUsers/Login");
        }
    }
}
