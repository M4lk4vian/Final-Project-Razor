using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Final_Project_Razor.Pages.ModelRatings
{
    public class CreateModel : PageModel
    {

        private readonly RatingsServices _ratingsServices = new RatingsServices();
        public Ratings Rating { get; set; }


        public void OnGet(int RecipeId)
        {
            Rating = new Ratings();
            Rating.User = new Users();
            Rating.Recipe = new Recipes();


            string sessionUser = HttpContext.Session.GetString("user");
            if (sessionUser != null)
                Rating.User = JsonSerializer.Deserialize<Users>(sessionUser);
            Rating.Recipe.RecipeId = RecipeId;
        }

        public IActionResult OnPost()
        {
            Rating = new Ratings();
            Rating.User = new Users();
            Rating.Recipe = new Recipes();
            if (!int.TryParse(Request.Form["Rating"], out int ratingValue))
                return Redirect($"/ModelRatings/Create?RecipeId={Rating.Recipe.RecipeId}&error=true");
            Rating.Rating = ratingValue;
            Rating.Recipe.RecipeId = Convert.ToInt32(Request.Form["RecipeId"]);
            Rating.User.UserId = Convert.ToInt32(Request.Form["UserId"]);

            int recipeId = Rating.Recipe.RecipeId;
            Rating = _ratingsServices.Create(Rating);

            if (Rating == null)
                return Redirect($"/ModelRatings/Create?RecipeId={recipeId}&error=true");

            return Redirect($"/ModelRecipes/RetrieveById?recipeId={recipeId}");
        }

    }
}
