using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelCategories
{
    public class CategoriesModel : PageModel
    {
        private readonly CategoriesServices _categoriesServices = new CategoriesServices();

        public List<Categories> Categories { get; set; }


        public void OnGet()
        {
            Categories = _categoriesServices.RetrieveAll();
        }
    }
}
