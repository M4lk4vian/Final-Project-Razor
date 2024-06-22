using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelRecipes
{
    public class UpdateRecipesBlockedStatusModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public UpdateRecipesBlockedStatusModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();

        public int Id;

        public int UserId;

        public bool BlockedStatus { get; set; }

        public Recipes Recipe { get; set; }

        public List<Recipes> Recipes = new List<Recipes>();

        public Users User { get; set; }

        public void OnGet(int Id)
        {
            Recipe = new Recipes();
            Recipe.Id = Id;
            Recipes = _recipesServices.RetrieveAll();
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            User.Id = UserId;
        }

        public IActionResult OnPost()
        {
            Recipes Recipe = new Recipes();
            Recipe.BlockedStatus = Convert.ToBoolean(Request.Form["BlockedStatus"]);
            
            Recipe.BlockedStatus = _recipesServices.UpdateRecipesBlockedStatus(BlockedStatus);

            return Redirect("/ModelRecipes/Management");
        }
    }
}
