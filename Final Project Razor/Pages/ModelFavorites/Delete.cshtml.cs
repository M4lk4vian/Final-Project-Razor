using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;
using System.Text.Json;

namespace Final_Project_Razor.Pages.ModelFavorites
{
    public class DeleteModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public DeleteModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly FavoritesServices _favoritesServices = new FavoritesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();

        public int FavoriteId { get; set; }

        public int RecipeId { get; set; }
        public int UserId { get; set; }

        public int Id_user { get; set; }

        public Favorites Favorite { get; set; }
    
        public List<Favorites> Favorites = new List<Favorites>();

        public Recipes Recipe {  get; set; }

        public Users User { get; set; }

        public void OnGet(int FavoriteId, int RecipeId)
        {
            
            Favorite = new Favorites();
            Favorite.FavoriteId = FavoriteId;

            
        }
        public IActionResult OnPost()
        {
            Favorites Favorite = new Favorites();
            Favorite.User = new Users();
            Favorite.Recipe = new Recipes();
            Favorite.FavoriteId = Convert.ToInt32(Request.Form["FavoriteId"]);
            Favorite.User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));
            Favorite.Recipe = _recipesServices.RetrieveById(RecipeId);

            _favoritesServices.Delete(Favorite.FavoriteId);

            return Redirect("/ModelFavorites/GetAllByUserId?Id={Favorite.Recipe.Id}");
        }
    }
}
