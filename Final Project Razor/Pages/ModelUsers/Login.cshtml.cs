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
    public class LoginModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public LoginModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
       

        private readonly string cacheKey = "userKey";

        public int Id { get; set; }
        public string UserName { get; set; }
        [BindProperty]

        public string Password { get; set; }
        [BindProperty]
        public bool IsAdmin { get; set; }


        private readonly UsersServices _usersServices = new UsersServices();

        public Users user { get; set; }

        public void OnGet()
        {

           
        }

        public IActionResult OnPost() 
        { 
            Users user = new Users();
            user.UserName = Request.Form["userName"];
            user.Password = Request.Form["password"];
            user = _usersServices.Login(user.UserName, user.Password);
           
            HttpContext.Session.SetString("user", JsonSerializer.Serialize(user));

            //JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));

            _memoryCache.Set("userKey", user.Id);

            return RedirectToPage("/Management");

        }


    }
}
