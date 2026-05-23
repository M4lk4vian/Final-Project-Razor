using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelUsers
{
    public class UpdateUserInfoModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public UpdateUserInfoModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly UsersServices _usersServices = new UsersServices();
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public Users User { get; set; }

        public void OnGet(int Id, int userId)
        {
            userId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(userId);
        }

        public IActionResult OnPost() 
        {
            Users User = new Users();
            User.UserId = Convert.ToInt32(Request.Form["UserId"]);
            User.UserName = Convert.ToString(Request.Form["UserName"]);
            User.Password = Convert.ToString(Request.Form["Password"]);
            User.IsAdmin = Convert.ToBoolean(Request.Form["IsAdmin"]);

            User = _usersServices.UpdateUserInfo(User);

            return Redirect("/Management");
        }

    }

}
