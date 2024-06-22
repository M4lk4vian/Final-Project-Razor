using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Final_Project_Razor.Pages.ModelFavorites
{
    public class CreateModel : PageModel
    {
        private FavoritesServices _favoritesServices = new FavoritesServices();

        public Favorites Favorite { get; set; }

        public void OnGet(int Id)
        {
            Favorite = new Favorites();
            Favorite.User = new Users();
            Favorite.Recipe = new Recipes();
            Favorite.User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));
            Favorite.Recipe.Id = Id;


        }

        public IActionResult OnPost()
        {
            Favorite = new Favorites();
            Favorite.User = new Users();
            Favorite.Recipe = new Recipes();
            Favorite.User.Id = Convert.ToInt32(Request.Form["Id_user"]);
            Favorite.Recipe.Id = Convert.ToInt32(Request.Form["Id_recipe"]);

            Favorite = _favoritesServices.Create(Favorite);

            return Redirect($"/ModelFavorites/RetrieveFavoritesByUserId?Id={Favorite.User.Id}");
        }
    }
}
