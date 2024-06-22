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


        //IMPORTANT NEEDS TO RECEIVE RECIPE ID VIA URI
        //LIKE THIS ModelRatings/Create?Id={Model.Recipe.Id}
        public void OnGet(int Id)
        {
            Rating = new Ratings();
            Rating.User = new Users();
            Rating.Recipe = new Recipes();


            Rating.User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));
            Rating.Recipe.Id = Id;
        }

        public IActionResult OnPost()
        {
            Rating = new Ratings();
            Rating.User = new Users();
            Rating.Recipe = new Recipes();
            //implementar  if com x < 10 || x > 0 if not Redirect to the same page
            Rating.Rating = Convert.ToInt32(Request.Form["Rating"]);
            Rating.Recipe.Id = Convert.ToInt32(Request.Form["Id"]);
            Rating.User.Id = Convert.ToInt32(Request.Form["userId"]);

            Rating = _ratingsServices.Create(Rating);

            return Redirect($"/ModelRecipes/RetrieveById?Id={Rating.Recipe.Id}"); 
        }

    }
}
