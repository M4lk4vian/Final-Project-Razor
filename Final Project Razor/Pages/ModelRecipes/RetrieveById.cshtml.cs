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

        public Users User {  get; set; }
        public Recipes Recipe { get; set; }
        public Favorites Favorite { get; set; }

        [BindProperty]
        public int ToggleRecipeId { get; set; }
        public Comments Comment { get; set; } 
        public List<Comments> Comments { get; set; }

        public List<IngredientsRecipes> IngredientsRecipes = new List<IngredientsRecipes>();
        public Ratings Rating { get; set; }
        public double Average { get; set; }

        public int UserId { get; set; }

        public int Id_user { get; set; }

        public int RecipeId { get; set; }

        public void OnGet(int ratingId, int userId, int id_user, int recipeId, int id_recipe, int id_ingredient)
        {

            int? cachedUserId = _memoryCache.Get("userKey") as int?;
            if (cachedUserId == null)
            {
                RedirectToPage("/Login");
                return;
            }
            UserId = cachedUserId.Value;
            User = _usersServices.RetrieveById(UserId);
            Recipe = _recipesServices.RetrieveById(recipeId);
            id_recipe = Recipe.RecipeId;
            Average = _ratingsServices.Average(Average);
            Rating = _ratingsServices.RetrieveById(ratingId);
            IngredientsRecipes = _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(id_recipe);
            Comments = _commentsServices.RetrieveCommentsByUserId(id_user);

        }
        public IActionResult OnPostToggleFavorite()
        {
            int? cachedUserId = _memoryCache.Get("userKey") as int?;
            if (cachedUserId == null)
                return new JsonResult(new { success = false, message = "Not logged in" });

            int userId = cachedUserId.Value;

            Favorite = _favoritesServices.GetAllByUserId(userId)
                           .FirstOrDefault(f => f.Recipe.RecipeId == ToggleRecipeId);

            if (Favorite == null)
            {
                Favorites newFavorite = new Favorites();
                newFavorite.User = _usersServices.RetrieveById(userId);
                newFavorite.Recipe = _recipesServices.RetrieveById(ToggleRecipeId);
                _favoritesServices.Create(newFavorite);
                return new JsonResult(new { success = true, isFavorite = true });
            }
            else
            {
                _favoritesServices.Delete(Favorite.FavoriteId);
                return new JsonResult(new { success = true, isFavorite = false });
            }
        }


    }
}
