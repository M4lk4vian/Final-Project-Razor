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
            ingredient.Id = Convert.ToInt32(Request.Form["id"]);
            ingredient.IngredientName = Request.Form["IngredientName"];

            ingredient = _ingredientsServices.Create(ingredient);

            return Redirect("/ModelIngredients/RetrieveAll");
        }
    }
}
