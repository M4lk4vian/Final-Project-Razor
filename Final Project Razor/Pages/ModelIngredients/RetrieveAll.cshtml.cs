using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelIngredients
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IngredientsServices _ingredientsServices = new IngredientsServices();

        public List<Ingredients> ingredients;

        public void OnGet()
        {
            ingredients = _ingredientsServices.RetrieveAll();
        }
    }
}
