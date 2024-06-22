using Final_Project_Razor.Pages.ModelUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;
using System.Dynamic;
using System.Text.Json;

namespace Final_Project_Razor.Pages.ModelComments
{
    public class CreateModel : PageModel
    {

        private readonly CommentsServices _commentsServices = new CommentsServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();

        public Recipes Recipe { get; set; }

        public Users User { get; set; }

        public Comments Comment { get; set; }
        
        public void OnGet(int Id)
        {
            Comment = new Comments();
            Comment.Recipe = _recipesServices.RetrieveById(Id);
            Comment.User = new Users();

            Comment.User = JsonSerializer.Deserialize<Users>(HttpContext.Session.GetString("user"));
        }
        public IActionResult OnPost()
        {
            Comments Comment = new Comments();
            Comment.Recipe = new Recipes();
            Comment.User = new Users();

            Comment.Content = Convert.ToString(Request.Form["Content"]);
            Comment.Recipe.Id = Convert.ToInt32(Request.Form["Id_recipe"]);
            Comment.User.Id = Convert.ToInt32(Request.Form["Id_user"]);

            Comment = _commentsServices.Create(Comment);


            return Redirect("/ModelRecipes/RetrieveAll");

        }
    }
}
