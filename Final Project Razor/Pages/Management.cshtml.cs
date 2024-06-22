using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace Final_Project_Razor.Pages.ModelUsers
{
    public class ManagementModel : PageModel
    {

        private readonly UsersServices _usersServices = new UsersServices();

        private readonly CategoriesServices _categoriesServices = new CategoriesServices();

        public Users User { get; set; } //No OnGet nunca se mete objectos, apenas estas propriedades com get e set

        public int Id { get; set; }

        public string UserName { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public bool IsAdmin { get; set; }

        public Categories Category { get; set; }

        public void OnGet(int Id_user)
        {

            User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user")); ;
            Id_user = User.Id;
        }



    }
}
