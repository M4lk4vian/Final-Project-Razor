using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;
using System.Reflection.Metadata.Ecma335;

namespace Final_Project_Razor.Pages.ModelIngredientsRecipes
{
    public class CreateModel : PageModel
    {
        private readonly IngredientsRecipesServices _ingredientsRecipesServices = new IngredientsRecipesServices();
        private readonly IngredientsServices _ingredientsServices = new IngredientsServices();
        public readonly UnitsServices _unitServices  = new UnitsServices();
        public readonly RecipesServices _recipesServices = new RecipesServices();


        public List<Ingredients> Ingredients { get; set; }
        public List<Units> Units { get; set; }
        public int Id { get; set; }
        public IngredientsRecipes ingredientsRecipe { get; set; }        
        public Recipes Recipe { get; set; }

        public void OnGet()
        {
            Recipe = _recipesServices.FindLastInsertedRecipe();
            Ingredients = _ingredientsServices.RetrieveAll();
            Units = _unitServices.RetrieveAll();

        }

        public IActionResult OnPostCreateIngredients()
        {

            IngredientsRecipes ingredientsRecipe = new IngredientsRecipes();
            ingredientsRecipe.Recipe = new Recipes();
            ingredientsRecipe.Ingredient = new Ingredients();
            ingredientsRecipe.Unit = new Units();
            ingredientsRecipe.Recipe.RecipeId = Convert.ToInt32(Request.Form["Recipe"]);
            ingredientsRecipe.Ingredient.IngredientId = Convert.ToInt32(Request.Form["Ingredient"]);
            ingredientsRecipe.Quantity = Convert.ToDouble(Request.Form["Quantity"]);
            ingredientsRecipe.Unit.UnitId = Convert.ToInt32(Request.Form["Unit"]);
            
            _ingredientsRecipesServices.Create(ingredientsRecipe);

            Recipes lastInsertedId = _recipesServices.FindLastInsertedRecipe();

            return new RedirectToPageResult("/ModelIngredientsRecipes/Create");


        }
    }
}
