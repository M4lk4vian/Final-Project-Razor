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

        public int UserId{ get; set; }
        public int RecipeId { get; set; }
        public int CommentId { get; set; }
        public Comments comment {get; set;}

        public Users user { get; set;}
        public Recipes recipe{ get; set; }

        public void OnGet(int UserId, int RecipeId, int CommentId)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            user = _usersServices.RetrieveById(UserId);
            recipe = _recipesServices.RetrieveById(RecipeId);
            comment = _commentsServices.RetrieveById(CommentId);

        }

        public IActionResult OnPost()
        {
            Comments comment = new Comments();
            comment.Recipe = new Recipes();
            comment.User = new Users();
            comment.CommentId = Convert.ToInt32(Request.Form["CommentId"]);
            comment.Content = Convert.ToString(Request.Form["Content"]);
            comment.Recipe.RecipeId = Convert.ToInt32(Request.Form["Id_recipe"]);
            comment.User.UserId = Convert.ToInt32(Request.Form["Id_user"]);

            comment = _commentsServices.Update(comment);
            return Redirect("/ModelComments/Update");

        }
    }
}
