using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelDifficulties
{
    public class RetrieveAllModel : PageModel
    {
        private readonly DifficultiesServices _difficultiesServices = new DifficultiesServices();

        public List <Difficulties> Difficulties = new List<Difficulties>();

        public void OnGet()
        {
            Difficulties = _difficultiesServices.RetrieveAll();        
        }
    }
}
