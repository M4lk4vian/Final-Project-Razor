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

        public int Id { get; set; }

        public bool IsAdmin { get; set; }

        public Users UserLogged { get; set; }
        public Users User {  get; set; }

        public void OnGet(int Id, int userId)
        {
            userId = Convert.ToInt32(_memoryCache.Get("userKey"));
            UserLogged = _usersServices.RetrieveById(userId);
            User = _usersServices.RetrieveById(Id);

        }

        public IActionResult OnPost()
        {
            Users User = new Users();
            Id = Convert.ToInt32(Request.Form["id"]);
            bool BlockedStatus = Convert.ToBoolean(Request.Form["blockedStatus"]);

            BlockedStatus = _usersServices.UpdateBlockedStatus(Id);

            return Redirect("/ModelUsers/RetrieveAll");
        }
    }
}
