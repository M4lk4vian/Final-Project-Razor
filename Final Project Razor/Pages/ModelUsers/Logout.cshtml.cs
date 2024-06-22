using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using System.ComponentModel.DataAnnotations;
using Models;
using Services;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Final_Project_Razor.Pages
{
    public class LogoutModel : PageModel
    {

        private readonly IMemoryCache _memoryCache;
        public LogoutModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        public IActionResult OnGet()
        {
            LogOut();

            return RedirectToPage("/Index");
        }

        public bool LogOut()
        {
            HttpContext.Session.Clear();
            _memoryCache.Remove("user");
            return true;
        }



    }
}
