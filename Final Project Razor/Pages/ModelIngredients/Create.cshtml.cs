using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelIngredients
{
    public class CreateModel : PageModel
    {
        private readonly IngredientsServices _ingredientsServices = new IngredientsServices();

        public Ingredients ingredient = new Ingredients();
        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            ingredient.IngredientId = Convert.ToInt32(Request.Form["IngredientId"]);
            ingredient.IngredientName = Request.Form["IngredientName"];

            ingredient = _ingredientsServices.Create(ingredient);

            return Redirect("/ModelIngredients/RetrieveAll");
        }
    }
}
