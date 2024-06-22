using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelUsers
{
    public class RetrieveAllBlockedModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveAllBlockedModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private readonly UsersServices _usersServices = new UsersServices();

        public int Id;

        public int UserId;

        public Users User { get; set; }

        public List <Users> Users { get; set; }

        public void OnGet(int Id, int UserId)
        {
            Users = _usersServices.RetrieveAllBlocked();
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
        }
    }
}
