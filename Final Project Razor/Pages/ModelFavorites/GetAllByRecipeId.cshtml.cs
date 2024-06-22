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

        public void OnGet(int id, int id_recipe)
        {
            Recipe.Id = id_recipe;
            Favorites = _favoritesServices.GetAllByRecipeId(id_recipe);
            id = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(id);
        }
    }
}
