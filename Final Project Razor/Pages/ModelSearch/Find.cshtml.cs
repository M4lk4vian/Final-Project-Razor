using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using System.Data;

namespace Final_Project_Razor.Pages.ModelSearch
{
    public class FindModel : PageModel
    {
        private readonly SearchServices _searchServices = new SearchServices();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public DataTable Results { get; set; } = new DataTable();

        public void OnGet()
        {
            if (!string.IsNullOrEmpty(SearchTerm))
            {
                Results = _searchServices.Find(SearchTerm);
            }
        }
    }
}