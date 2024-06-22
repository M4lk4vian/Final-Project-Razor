using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;
using System.Text.Json;

namespace Final_Project_Razor.Pages.ModelRecipes
{
    public class RetrieveAllBlockedModel : PageModel
    {
        private readonly RecipesServices _recipesServices = new RecipesServices();

        public Recipes Recipe { get; set; }

        public Users User { get; set; }

        public List<Recipes> Recipes = new List<Recipes>();

        public void OnGet()
        {
            User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));
            Recipes = _recipesServices.RetrieveAllBlocked();
        }
    }
}
