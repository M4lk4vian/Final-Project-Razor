using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelUnits
{
    public class CreateModel : PageModel
    {
        private readonly UnitsServices _unitsServices = new UnitsServices();

        public Units unit = new Units();
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            unit.UnitName = Convert.ToString(Request.Form["UnitName"]); 

            _unitsServices.Create(unit);

            return Redirect("/ModelUnits/RetrieveAll");
        }
    }

}
