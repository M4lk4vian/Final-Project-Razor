using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelIngredientsRecipes
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IngredientsRecipesServices _ingredientsRecipesServices = new IngredientsRecipesServices();

        public List<IngredientsRecipes> IngredientsRecipes { get; set; }
        public void OnGet()
        {
            IngredientsRecipes = _ingredientsRecipesServices.RetrieveAll();
        }
    }
}
