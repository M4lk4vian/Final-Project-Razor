using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelIngredientsRecipes
{
    public class RetrieveIngredientsByRecipeIdModel : PageModel
    {
        private readonly IngredientsRecipesServices _ingredientsRecipesServices = new IngredientsRecipesServices();

        public List<IngredientsRecipes> IngredientsRecipes { get; set; }

        public Recipes Recipe { get; set; }

        public void OnGet(int id_recipe)
        {
            Recipe.Id = id_recipe;
            IngredientsRecipes = _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(id_recipe);


        }
    }
}
