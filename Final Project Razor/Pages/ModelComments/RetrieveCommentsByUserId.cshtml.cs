using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelComments
{
    public class RetrieveCommentsByUserIdModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveCommentsByUserIdModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly CommentsServices _commentsServices = new CommentsServices();
        private readonly UsersServices _usersServices = new UsersServices();

        public int UserId { get; set; }
        public List<Comments> Comments = new List<Comments>();

        public Users User { get; set; }

        public void OnGet(int UserId)
        {

            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Comments = _commentsServices.RetrieveCommentsByUserId(UserId);

        }
    }
}
