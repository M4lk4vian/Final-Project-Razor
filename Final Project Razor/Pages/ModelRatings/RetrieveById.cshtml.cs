using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;

namespace Final_Project_Razor.Pages.ModelRatings
{
    public class RetrieveByIdModel : PageModel
    {
        private readonly RatingsServices _ratingsServices = new RatingsServices();

        public double Average { get; set; }

        public Ratings Rating = new Ratings();

        public void OnGet(int RatingId)
        {
            Rating = _ratingsServices.RetrieveById(RatingId);
            Average = _ratingsServices.Average(Average);
        }
    }
}
