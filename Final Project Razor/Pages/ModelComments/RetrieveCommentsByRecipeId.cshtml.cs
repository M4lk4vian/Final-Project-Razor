using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelComments
{
    public class RetrieveCommentsByRecipeIdModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;

        public RetrieveCommentsByRecipeIdModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private readonly CommentsServices _commentsServices = new CommentsServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        public List<Comments> Comments { get; set; }

        public Recipes Recipe { get; set; }

        public Users User { get; set; }
        public int UserId { get; set; }
        public void OnGet(int RecipeId)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Recipe = _recipesServices.RetrieveById(RecipeId);
            Comments = _commentsServices.RetrieveCommentsByRecipeId(RecipeId);            
        }
    }
}
