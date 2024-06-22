using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelUnits
{
    public class RetrieveAllModel : PageModel
    {
        private readonly UnitsServices _unitsServices = new UnitsServices();

        public List<Units> Units;

        public void OnGet()
        {
            Units = _unitsServices.RetrieveAll();
        }
    }
}
