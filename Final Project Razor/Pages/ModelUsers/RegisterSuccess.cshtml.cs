using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project_Razor.Pages.User
{
    public class RegisterSuccessModel : PageModel
    {
        public string UserName { get; set; } = string.Empty;

        public void OnGet(string userName)
        {
            UserName = userName;
        }
    }
}
