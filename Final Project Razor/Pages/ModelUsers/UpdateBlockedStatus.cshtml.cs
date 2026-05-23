using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelUsers
{
    public class UpdateBlockedStatusModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public UpdateBlockedStatusModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private readonly UsersServices _usersServices = new UsersServices();

        public int UserId { get; set; }

        public bool IsAdmin { get; set; }

        public Users UserLogged { get; set; }
        public Users User {  get; set; }

        public void OnGet(int UserId)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            UserLogged = _usersServices.RetrieveById(UserId);
            User = _usersServices.RetrieveById(UserId);

        }

        public IActionResult OnPost()
        {
            Users User = new Users();
            UserId = Convert.ToInt32(Request.Form["UserId"]);
            bool BlockedStatus = Convert.ToBoolean(Request.Form["blockedStatus"]);

            BlockedStatus = _usersServices.UpdateBlockedStatus(UserId);

            return Redirect("/ModelUsers/RetrieveAll");
        }
    }
}
