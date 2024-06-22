using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace Final_Project_Razor.Pages.ModelFavorites
{
    public class UpdateModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public UpdateModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly FavoritesServices _favoritesServices = new FavoritesServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        public int UserId { get; set; }
        public Favorites Favorite { get; set; }
        public Users User { get; set; }

        public Recipes Recipe { get; set; }
        public List<Recipes> Recipes { get; set; }
        public void OnGet(int id)
        {
            Favorite = _favoritesServices.RetrieveById(id);
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Recipes = _recipesServices.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            Favorites favorite = new Favorites();
            favorite.User = new Users();
            favorite.Recipe = new Recipes();
            favorite.User.Id = Convert.ToInt32(Request.Form["id"]);
            favorite.Recipe.Id = Convert.ToInt32(Request.Form["title"]);

            favorite = _favoritesServices.Update(favorite);

            return Redirect("/ModelFavorites/RetrieveFavoritesByUserId");


        }
    }
}
