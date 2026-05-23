using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelRatings
{
    public class UpdateModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public UpdateModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;

        private readonly RatingsServices _ratingsServices = new RatingsServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        public int UserId { get; set; }
        public int RecipeId { get; set; }
        public Ratings Rating { get; set; }

        public Recipes Recipe { get; set; }

        public double Average { get; set; }

        public Users User { get; set; }

        public void OnGet(int RatingId, int UserId, double Average, int RecipeId)
        {
            Rating = _ratingsServices.RetrieveById(RatingId);
            Average = _ratingsServices.Average(Average);
            Recipe = _recipesServices.RetrieveById(RecipeId);
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
        }

        public IActionResult OnPost()
        {
            Rating = new Ratings();
            Rating.Recipe = new Recipes();
            Rating.User = new Users();



            Rating.Rating = Convert.ToInt32(Request.Form["Rating"]);
            Rating.RatingId = Convert.ToInt32(Request.Form["RatingId"]);
            Rating.Recipe.RecipeId = Convert.ToInt32(Request.Form["RecipeId"]);
            Rating.User.UserId = Convert.ToInt32(Request.Form["UserId"]);

            Rating = _ratingsServices.Update(Rating);

            if (Rating == null)
                return Redirect($"/ModelRatings/Create?RecipeId={RecipeId}&error=true");

            return Redirect($"/ModelRecipes/RetrieveById?recipeId={RecipeId}");
        }

    }
}
