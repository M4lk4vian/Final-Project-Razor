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
        public void OnGet(int Id_recipe, int Id, int Id_user)
        {
            Comments = _commentsServices.RetrieveCommentsByRecipeId(Id_recipe);
            Recipe = _recipesServices.RetrieveById(Id);
            Id = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(Id);
            User.Id = Id_user;
        }
    }
}
