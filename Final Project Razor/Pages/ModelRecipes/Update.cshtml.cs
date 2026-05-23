using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelRecipes
{
    public class UpdateModel : PageModel
    {
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly CategoriesServices _categoriesServices = new CategoriesServices();
        private readonly DifficultiesServices _difficultiesServices = new DifficultiesServices();

        public Recipes Recipe {  get; set; }
        public List<Categories> Categories { get; set; }

        public List<Difficulties> Difficulties { get; set; }

        public void OnGet(int Id)
        {
            Recipe = _recipesServices.RetrieveById(Id);
            Categories = _categoriesServices.RetrieveAll();
            Difficulties = _difficultiesServices.RetrieveAll();
        }

        public IActionResult OnPost()
        {
            Recipes recipe = new Recipes();
            recipe.Category = new Categories();
            recipe.Difficulty = new Difficulties();
            recipe.RecipeId = Convert.ToInt32(Request.Form["RecipeId"]);
            recipe.Title = Convert.ToString(Request.Form["Title"]);
            recipe.PrepMethod = Convert.ToString(Request.Form["PrepMethod"]);
            recipe.PrepTime = Convert.ToString(Request.Form["PrepTime"]);
            recipe.Category.CategoryId = Convert.ToInt32(Request.Form["Category"]);
            recipe.Difficulty.DifficultyId = Convert.ToInt32(Request.Form["Difficulty"]);


            recipe = _recipesServices.Update(recipe);

            return Redirect("/ModelRecipes/Update");
        }
    }
}
