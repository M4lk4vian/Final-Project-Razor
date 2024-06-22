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

        public int Id { get; set; }

        public int Id_user { get; set; }
        public List<Comments> Comments = new List<Comments>();

        public Users user { get; set; }

        public void OnGet(int Id_user, int Id)
        {

            Comments = _commentsServices.RetrieveCommentsByUserId(Id_user);
            Id = Convert.ToInt32(_memoryCache.Get("userKey"));
            user = _usersServices.RetrieveById(Id);
            user.Id = Id_user;
        }
    }
}
