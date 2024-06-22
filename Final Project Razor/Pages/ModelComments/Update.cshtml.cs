using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services;
using Models;
using Microsoft.Extensions.Caching.Memory;

namespace Final_Project_Razor.Pages.ModelComments
{
    public class UpdateModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public UpdateModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly CommentsServices _commentsServices = new CommentsServices();
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();

        public int Id_user { get; set; }
        public int Id_recipe { get; set; }
        public int Id_comment { get; set; }
        public Comments comment {get; set;}

        public Users user { get; set;}
        public Recipes recipe{ get; set; }

        public void OnGet(int Id_user, int Id_recipe, int Id_comment)
        {
            Id_user = Convert.ToInt32(_memoryCache.Get("userKey"));
            user = _usersServices.RetrieveById(Id_user);
            recipe = _recipesServices.RetrieveById(Id_recipe);
            comment = _commentsServices.RetrieveById(Id_comment);

        }

        public IActionResult OnPost()
        {
            Comments comment = new Comments();
            comment.Recipe = new Recipes();
            comment.User = new Users();
            comment.Id = Convert.ToInt32(Request.Form["Id"]);
            comment.Content = Convert.ToString(Request.Form["Content"]);
            comment.Recipe.Id = Convert.ToInt32(Request.Form["Id_recipe"]);
            comment.User.Id = Convert.ToInt32(Request.Form["Id_user"]);

            comment = _commentsServices.Update(comment);
            return Redirect("/ModelComments/Update");

        }
    }
}
