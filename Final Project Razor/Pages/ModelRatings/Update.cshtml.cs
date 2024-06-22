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

        public int Id { get; set; }

        public int UserId { get; set; }
        public int Id_recipe { get; set; }
        public Ratings Rating { get; set; }

        public Recipes Recipe { get; set; }

        public double Average { get; set; }

        public Users User { get; set; }

        public void OnGet(int Id, int UserId, double Average, int Id_recipe)
        {
            Rating = _ratingsServices.RetrieveById(Id);
            Average = _ratingsServices.Average(Average);
            Recipe = _recipesServices.RetrieveById(Id_recipe);
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
        }

        public IActionResult OnPost()
        {
            Ratings Rating = new Ratings();
            Rating.Recipe = new Recipes();
            Rating.User = new Users();


            Rating.Id = Convert.ToInt32(Request.Form["Id"]);
            Rating.Rating = Convert.ToInt32(Request.Form["Rating"]);
            Rating.Recipe.Id = Convert.ToInt32(Request.Form["Recipe"]);
            Rating.User.Id = Convert.ToInt32(Request.Form["User"]);

            Rating = _ratingsServices.Update(Rating);

            return Redirect("/ModelRatings/Average");
        }

    }
}
