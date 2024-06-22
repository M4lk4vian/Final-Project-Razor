using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelDifficulties
{
    public class UpdateModel : PageModel
    {
        private readonly DifficultiesServices _difficultiesServices = new DifficultiesServices();

        public Difficulties difficulty { get; set; }
        public void OnGet(int id)
        {
            difficulty = _difficultiesServices.RetrieveById(id);
        }

        public IActionResult OnPost()
        {
            Difficulties difficulty = new Difficulties();

            difficulty.Id = Convert.ToInt32(Request.Form["id"]);
            difficulty.DifficultyName = Convert.ToString(Request.Form["difficultyName"]);

            difficulty = _difficultiesServices.Update(difficulty);

            return Redirect("/ModelDifficulties/RetrieveAll");                                              
        }
    }
}
