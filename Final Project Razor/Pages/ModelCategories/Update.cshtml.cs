using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Runtime.CompilerServices;
using Models;
using System.ComponentModel;
using System.Diagnostics;
using System.Dynamic;

namespace Final_Project_Razor.Pages.ModelCategories
{
    public class UpdateModel : PageModel
    {

        private readonly CategoriesServices _categoriesServices = new CategoriesServices();

        public int CategoryId { get; set; }
        public Categories Category { get; set; }
        //public List<Categories> categories { get; set; }

        public void OnGet(int CategoryId)
        {

            Category = _categoriesServices.RetrieveById(CategoryId);

        }

        public IActionResult OnPost()
        {
            Categories category = new Categories();
            
            category.CategoryId = Convert.ToInt32(Request.Form["CategoryId"]);
            category.CategoryName = Convert.ToString(Request.Form["CategoryName"]);

            category = _categoriesServices.Update(category);

            return Redirect("/ModelCategories/RetrieveAll");
        }
    }
}
