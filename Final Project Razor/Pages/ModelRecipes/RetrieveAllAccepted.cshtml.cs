using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelRecipes
{
    public class RetrieveAllAcceptedModel : PageModel
    {
        private readonly RecipesServices _recipesServices = new RecipesServices();

        public Recipes Recipe { get; set; }

        public Users User { get; set; }

        public List<Recipes> Recipes = new List<Recipes>();
        public void OnGet()
        {
            
            User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));
            Recipes = _recipesServices.RetrieveAllAccepted();

        }
    }
}
