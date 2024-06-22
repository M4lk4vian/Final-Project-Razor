using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelUsers
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveAllModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly UsersServices _usersServices = new UsersServices();

        public int Id { get; set; }

        public Users UserId { get; set; }
        public string UserName { get; set; }
        
        public Users User { get; set; }
        
        public List<Users> AcceptedUsers { get; set; }
        public List<Users> BlockedUsers { get; set; }

        public void OnGet(int Id, int UserId)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            AcceptedUsers = _usersServices.RetrieveAllAccepted();
            BlockedUsers = _usersServices.RetrieveAllBlocked();

        }
    }
}
