using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelUsers
{
    public class RetrieveAllAcceptedModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;

        public RetrieveAllAcceptedModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private readonly UsersServices _usersServices = new UsersServices();

        public int UserId;

        public Users User { get; set; }
        public List<Users> Users { get; set; }

        public void OnGet(int UserId)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Users = _usersServices.RetrieveAllAccepted();

        }
    }
}
