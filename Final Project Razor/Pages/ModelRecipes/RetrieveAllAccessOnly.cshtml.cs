using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;
using System.Text.Json;

namespace Final_Project_Razor.Pages
{
    public class ReceitaModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public ReceitaModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();


        public Users user { get; set; }
        public List <Recipes> AcceptedRecipes = new List<Recipes>();
        public List <Recipes> BlockedRecipes = new List<Recipes> ();

        public void OnGet()
        {
            AcceptedRecipes = _recipesServices.RetrieveAllAccepted();
            BlockedRecipes = _recipesServices.RetrieveAllBlocked();
            
            user = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));
            
        }


    }
}
