using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;
using System.Security.Cryptography.X509Certificates;

namespace Final_Project_Razor.Pages.ModelRecipes
{
    public class RetrieveByIdModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveByIdModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly CommentsServices _commentsServices = new CommentsServices();
        private readonly FavoritesServices _favoritesServices = new FavoritesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        private readonly RatingsServices _ratingsServices = new RatingsServices();
        private readonly IngredientsServices _ingredientsServices = new IngredientsServices();
        private readonly IngredientsRecipesServices _ingredientsRecipesServices = new IngredientsRecipesServices();

        public int Id { get; set; }

        public int UserId { get; set; }

        public int Id_user { get; set; }
        public Users User {  get; set; }

        public Recipes Recipe { get; set; }

        public Favorites Favorite { get; set; }
        public Comments Comment { get; set; } 
        public List<Comments> Comments { get; set; }

        public List<IngredientsRecipes> IngredientsRecipes = new List<IngredientsRecipes>();
        public Ratings Rating { get; set; }

        public double Average { get; set; }

        public void OnGet(int Id, int UserId, int Id_user, int Id_recipe, int Id_ingredient)
        {
            UserId = Convert.ToInt32(_memoryCache.Get("userKey"));
            User = _usersServices.RetrieveById(UserId);
            Average = _ratingsServices.Average(Average);
            Rating = _ratingsServices.RetrieveById(Id);
            Recipe = _recipesServices.RetrieveById(Id);
            Id_recipe = Recipe.Id;
            IngredientsRecipes = _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(Id_recipe);
            Comments = _commentsServices.RetrieveCommentsByUserId(Id_user);

        }
    }
}
