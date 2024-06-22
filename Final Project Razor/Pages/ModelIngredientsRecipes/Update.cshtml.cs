using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelIngredientsRecipes
{
    public class UpdateModel : PageModel
    {
        private readonly IngredientsRecipesServices _ingredientsRecipeServices = new IngredientsRecipesServices();
        
        public IngredientsRecipes ingredientsRecipe {  get; set; }
        public List <IngredientsRecipes> ingredientsRecipes { get; set; }

        public void OnGet(int id_recipe)
        {
            ingredientsRecipes = _ingredientsRecipeServices.RetrieveIngredientsByRecipeId(id_recipe);
        }

        public IActionResult OnPost() 
        {
            IngredientsRecipes ingredientsRecipe = new IngredientsRecipes();        

            ingredientsRecipe = _ingredientsRecipeServices.Update(ingredientsRecipe);

            return Redirect("/ModelRecipe/RetrieveAll");
        }
    }
}
