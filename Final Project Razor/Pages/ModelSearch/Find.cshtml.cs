using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelSearch
{
    public class FindModel : PageModel
    {
        private readonly SearchServices _searchServices = new SearchServices();

        public string searchTerm;

        public void OnGet()
        {
            searchTerm = _searchServices.Find();
        }
    }
}
