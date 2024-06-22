using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Models;
using Services;

namespace Final_Project_Razor.Pages.ModelRecipes
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IMemoryCache _memoryCache;
        public RetrieveAllModel(IMemoryCache memoryCache) => _memoryCache = memoryCache;
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly CategoriesServices _categoriesServices = new CategoriesServices();
        private readonly IngredientsRecipesServices _ingredientsRecipesServices = new IngredientsRecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        private readonly CommentsServices _commentsServices = new CommentsServices();

        public Users user { get; set; }
        public Recipes Recipe { get; set; }
        public Categories Category { get; set; }
        public List<Categories> Categories = new List<Categories>();
        public List<Recipes> Recipes = new List<Recipes>();
        public List<IngredientsRecipes> IngredientsRecipes = new List<IngredientsRecipes>();
        public List<Comments> Comments = new List<Comments>();
        public void OnGet(int Id)
        {
            Recipe = _recipesServices.RetrieveById(Id);
            Recipes = _recipesServices.RetrieveAll();
            int id_recipe = Recipe.Id;
            IngredientsRecipes = _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(id_recipe);
            Category = _categoriesServices.RetrieveById(Id);

            int userId = Convert.ToInt32(_memoryCache.Get("userKey"));
            user = _usersServices.RetrieveById(userId);
        }
    }
}
