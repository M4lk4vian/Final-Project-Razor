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
        private readonly UsersServices _usersServices = new UsersServices();
        public List<Favorites> Favorites { get; set; }
        public Users User { get; set; }

        public void OnGet(int UserId)
        {

            string sessionUser = HttpContext.Session.GetString("user");
            //Favorites = _favoritesServices.GetAllByUserId(User.UserId);
            if (sessionUser == null)
            {
                Favorites = new List<Favorites>();
                return;
            }
            Users tempUser = JsonSerializer.Deserialize<Users>(sessionUser);
            Console.WriteLine($"DEBUG tempUser.UserId: {tempUser?.UserId}");
            User = _usersServices.RetrieveById(tempUser.UserId);
            Favorites = _favoritesServices.GetAllByUserId(User.UserId);
            Console.WriteLine($"DEBUG Favorites count: {Favorites.Count}");

        }
    }
}
