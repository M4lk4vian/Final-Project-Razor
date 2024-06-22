using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelRatings
{
    public class AverageModel : PageModel
    {
        private readonly RatingsServices _ratingsServices = new RatingsServices();

        public double Average { get; set; }

        public void OnGet(double Average)
        {
            Average = _ratingsServices.Average(Average);
        }
    }
}
