using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;
using System.ComponentModel;

namespace Final_Project_Razor.Pages.ModelCategories
{
    public class CreateModel : PageModel
    {
        private readonly CategoriesServices _categoriesServices = new CategoriesServices();
        Categories category { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName {  get; set; }
        
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Categories category = new Categories();
            category.CategoryName = Convert.ToString(Request.Form["CategoryName"]);

            _categoriesServices.Create(category);

            return Redirect("/ModelCategories/RetrieveAll");

        }
       
    }
}
