using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace Final_Project_Razor.Pages.ModelDifficulties
{
    public class CreateModel : PageModel
    {
        private IMemoryCache _memoryCache { get; set; }
        public CreateModel(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        private readonly DifficultiesServices _difficultiesServices = new DifficultiesServices();
        private readonly UsersServices _usersServices = new UsersServices();

        public Users User { get; set; }

        public Difficulties difficulty { get; set; }

        public void OnGet()
        {
            IMemoryCache memoryCache = _memoryCache;

            if (_memoryCache != null)
            {

                int id = Convert.ToInt32(_memoryCache.Get("userKey"));
                User = _usersServices.RetrieveById(id);
            }
        }

        public IActionResult OnPost()
        {
            Difficulties difficulty = new Difficulties();
            difficulty.DifficultyName = Convert.ToString(Request.Form["DifficultyName"]);

            _difficultiesServices.Create(difficulty);

            return Redirect("/ModelDifficulties/RetrieveAll");
        }
    }
}
