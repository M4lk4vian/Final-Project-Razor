using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Models;
using Services.InterfacesServices;

namespace Services
{
    public class IngredientsRecipesServices : IIngredientsRecipesServices
    {
        public IngredientsRecipesServices()
        {

        }

        private readonly IngredientsRepo _ingredientsRepo = new IngredientsRepo();
        private readonly IngredientsRecipesRepo _ingredientsRecipeRepo = new IngredientsRecipesRepo();
        private readonly IngredientsServices _ingredientsServices = new IngredientsServices();
        private readonly UnitsServices _unitsServices = new UnitsServices();
        public IngredientsRecipes ingredientRecipe = new IngredientsRecipes();
        public List<IngredientsRecipes> ingredientsRecipes = new List<IngredientsRecipes>();
        public Recipes recipe = new Recipes();
        public Ingredients ingredient = new Ingredients();
        public Units unit = new Units();

        public IngredientsRecipes Create(IngredientsRecipes ingredientRecipe)
        {
            return _ingredientsRecipeRepo.Create(ingredientRecipe);
        }

        public List<IngredientsRecipes> RetrieveAll()
        {
            DataTable dt = _ingredientsRecipeRepo.RetrieveAll();

            foreach (DataRow dr in dt.Rows)
            {

                IngredientsRecipes ingredientRecipe = new IngredientsRecipes(
                    //id_recipe, id_ingredient, quantity, id_unit, description
                    Convert.ToInt32(dr["ingredientRecipeId"]),
                    Convert.ToInt32(dr["id_recipe"]),
                    Convert.ToInt32(dr["id_ingredient"]),
                    Convert.ToDouble(dr["quantity"]),
                    Convert.ToInt32(dr["id_unit"])
                    );

                ingredientRecipe.Unit = _unitsServices.RetrieveById(ingredientRecipe.Unit.UnitId);
                ingredientRecipe.Ingredient = _ingredientsServices.RetrieveById(ingredientRecipe.Ingredient.IngredientId);

                ingredientsRecipes.Add(ingredientRecipe);


            }
            return ingredientsRecipes;
        }

        public IngredientsRecipes RetrieveById(int ingredientRecipeId)
        {

            DataTable dt = _ingredientsRecipeRepo.RetrieveById(ingredientRecipeId);
            DataRow dr = dt.Rows[0];
            IngredientsRecipes ingredientsRecipe = new IngredientsRecipes(
                Convert.ToInt32(dr["ingredientRecipeId"]),
                _ingredientsServices.RetrieveById(Convert.ToInt32(dr["ingredientId"])),
                recipe,
                Convert.ToDouble(dr["quantity"]),
                _unitsServices.RetrieveById(Convert.ToInt32(dr["unitId"]))
                );


            return ingredientsRecipe;
        }

        public List<IngredientsRecipes> RetrieveIngredientsByRecipeId(int id_recipe)
        {

            DataTable dt = _ingredientsRecipeRepo.RetrieveIngredientsByRecipeId(id_recipe);
            foreach (DataRow dr in dt.Rows)
            {

                IngredientsRecipes ingredientRecipe = new IngredientsRecipes(
                    //id_recipe, id_ingredient, quantity, id_unit, description
                    Convert.ToInt32(dr["ingredientRecipeId"]),
                    Convert.ToInt32(dr["id_ingredient"]),
                    Convert.ToInt32(dr["id_recipe"]),
                    Convert.ToDouble(dr["quantity"]),
                    Convert.ToInt32(dr["id_unit"])
                    );

                ingredientRecipe.Unit = _unitsServices.RetrieveById(ingredientRecipe.Unit.UnitId);
                ingredientRecipe.Ingredient = _ingredientsServices.RetrieveById(ingredientRecipe.Ingredient.IngredientId);

                ingredientsRecipes.Add(ingredientRecipe);


            }
            return ingredientsRecipes;
        }

        public IngredientsRecipes Update(IngredientsRecipes ingredientsRecipe)
        {
            return _ingredientsRecipeRepo.Update(ingredientsRecipe);
        }



    }
}
