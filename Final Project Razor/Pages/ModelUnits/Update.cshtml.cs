using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelUnits
{
    public class UpdateModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;

        public UpdateModel(IMemoryCache memoryCache) => memoryCache = _memoryCache;
        private readonly UsersServices _usersServices = new UsersServices();
        private readonly UnitsServices _unitsServices = new UnitsServices();

        public int UnitId { get; set; }

        public int UserId { get; set; }

        public Users User { get; set; }
        public Units Unit { get; set; }

        public void OnGet(int Id, int UserId)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Unit = _unitsServices.RetrieveById(UnitId);
        }

        public IActionResult OnPost()
        {
            Units Unit = new Units();
            Unit.UnitId = Convert.ToInt32(Request.Form["UnitId"]);
            Unit.UnitName = Convert.ToString(Request.Form["UnitName"]);

            Unit = _unitsServices.Update(Unit);

            return Redirect("/ModelUnits/RetrieveAll");

        }
    }
}
