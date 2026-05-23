using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace Final_Project_Razor.Pages.ModelComments
{
    public class RetrieveByIdModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveByIdModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly CommentsServices _commentsServices = new CommentsServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        public int CommentId { get; set; }

        public int UserId {  get; set; }

        public int RecipeId { get; set; }

        public Comments Comment { get; set; }
        public Recipes Recipe { get; set; }

        public Users User { get; set; }


        public void OnGet(int CommentId, int RecipeId)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Comment = _commentsServices.RetrieveById(CommentId);
            Recipe = _recipesServices.RetrieveById(RecipeId);
        }
    }
}
