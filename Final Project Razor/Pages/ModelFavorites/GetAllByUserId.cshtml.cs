using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;
using System.Text.Json;

namespace Final_Project_Razor.Pages.ModelFavorites
{
    public class GetAllByUserIdModel : PageModel
    {
        private readonly FavoritesServices _favoritesServices = new FavoritesServices();

        public List<Favorites> Favorites { get; set; }
        public Users User { get; set; }


        public void OnGet(int Id)
        {

            User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));

            Favorites = _favoritesServices.GetAllByUserId(User.Id);
        }
    }
}
