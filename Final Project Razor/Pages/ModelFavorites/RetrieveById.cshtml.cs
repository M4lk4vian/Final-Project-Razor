using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelFavorites
{
    public class RetrieveByIdModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveByIdModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly FavoritesServices _favoritesServices = new FavoritesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        public int FavoriteId { get; set; }
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public Favorites Favorite { get; set; }
        public Users User { get; set; }
        public Recipes Recipe {  get; set; }

        public void OnGet(int FavoriteId, int UserId, int RecipeId)
        {
            Favorite = _favoritesServices.RetrieveById(FavoriteId);
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Recipe = _recipesServices.RetrieveById(RecipeId);
        }
    }
}
