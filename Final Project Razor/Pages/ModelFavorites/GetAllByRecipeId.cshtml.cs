using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelFavorites
{
    public class GetAllByRecipeIdModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public GetAllByRecipeIdModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly FavoritesServices _favoritesServices = new FavoritesServices();
        private readonly UsersServices _usersServices = new UsersServices();



        public List<Favorites> Favorites = new List<Favorites>();
        public Users User { get; set; }

        public Recipes Recipe { get; set; }

        public void OnGet(int UserId, int RecipeId)
        {
            Recipe.RecipeId = RecipeId;
            Favorites = _favoritesServices.GetAllByRecipeId(RecipeId);
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
        }
    }
}
