using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelCategories
{
    public class RetrieveByIdModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveByIdModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly CategoriesServices _categoriesServices = new CategoriesServices();
        private readonly UsersServices _usersServices = new UsersServices();


        public int CategoryId { get; set; }

        public string CategoryName {get; set;}

        public Categories Category { get; set; }

        Users User { get; set; }
        public void OnGet(int UserId)
        {
            User.UserId = UserId;
            Category = _categoriesServices.RetrieveById(Category.CategoryId);
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
        }
    }
}
