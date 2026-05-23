using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelRecipes
{
    public class RetrieveAllDetailsModel : PageModel
    {
        //private readonly IMemoryCache _memoryCache;
        //public RetrieveAllDetailsModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly IngredientsRecipesServices _ingredientsRecipesServices = new IngredientsRecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        private readonly CommentsServices _commentsServices = new CommentsServices();

        public int RecipeId { get; set; }
        //public Users user { get; set; }
        public Recipes Recipe {  get; set; }
        public List<Recipes> Recipes = new List<Recipes>();
        public List<IngredientsRecipes> IngredientsRecipes = new List<IngredientsRecipes>();
        public List<Comments> Comments = new List<Comments>();
        public void OnGet(int Id_recipe, int commentId, int userId)
        {
            Recipe = new Recipes();
            Recipes = _recipesServices.RetrieveAll();
            Recipe.RecipeId = RecipeId;
            IngredientsRecipes = _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(Id_recipe);
            Comments = _commentsServices.RetrieveCommentsByUserId(commentId);
        }
    }
}
