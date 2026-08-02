using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Models;
using Repository;
using System.ComponentModel;
using System.Net.Sockets;
using System.Data.Common;

namespace Services
{
    public class RecipesServices : IRecipesServices
    {
        private readonly RecipesRepo _recipesRepo = new RecipesRepo();

        public List<IngredientsRecipes> ingredientsRecipes = new List<IngredientsRecipes>();

        private readonly IngredientsRecipesServices _ingredientsRecipesServices = new IngredientsRecipesServices();

        private readonly CategoriesServices _categoriesServices = new CategoriesServices();

        private readonly DifficultiesServices _difficultiesServices = new DifficultiesServices();


        
        public List<Recipes> recipes = new List<Recipes>();


        public Recipes Create(Recipes recipe)
        {
            return _recipesRepo.Create(recipe);
        }



        public List<Recipes> RetrieveAll()
        {
            DataTable dt = _recipesRepo.RetrieveAll();

            foreach (DataRow dr in dt.Rows)
            {

                Recipes recipe = new Recipes(
                        Convert.ToInt32(dr["recipeId"]),
                        dr["Recipe Title"].ToString(),
                        dr["Preparation Method"].ToString(),
                        dr["Preparation Time"].ToString(),
                        _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(Convert.ToInt32(dr["recipeId"])),
                        Convert.ToBoolean(dr["Blocked Status"]),
                        _categoriesServices.RetrieveById(Convert.ToInt32(dr["categoryId"])),
                        _difficultiesServices.RetrieveById(Convert.ToInt32(dr["difficultyId"]))

                    );
                recipes.Add(recipe);


            }
            return recipes;
        }

        public Recipes RetrieveById(int recipeId)
        {
            DataTable dt = _recipesRepo.RetrieveById(recipeId);
            if (dt.Rows.Count == 0) return null;
            DataRow dr = dt.Rows[0];


            Recipes recipe = new Recipes(
                        Convert.ToInt32(dr["recipeId"]),
                        dr["title"].ToString(),
                        dr["prepMethod"].ToString(),
                        dr["prepTime"].ToString(),
                        _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(Convert.ToInt32(dr["recipeId"])),
                        Convert.ToBoolean(dr["blockedStatus"]),
                        _categoriesServices.RetrieveById(Convert.ToInt32(dr["categoryId"])),
                        _difficultiesServices.RetrieveById(Convert.ToInt32(dr["difficultyId"]))

                );
            return recipe;

        }

        public List<Recipes> RetrieveAllAccepted()
        {
            DataTable dt = _recipesRepo.RetrieveAllAccepted();

            List<Recipes> recipes = new List<Recipes>();
            foreach (DataRow dr in dt.Rows)
            {
                Recipes recipe = new Recipes(
                        Convert.ToInt32(dr["recipeId"]),
                        dr["title"].ToString(),
                        dr["prepMethod"].ToString(),
                        dr["prepTime"].ToString(),
                        _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(Convert.ToInt32(dr["recipeId"])),
                        Convert.ToBoolean(dr["blockedStatus"]),
                        _categoriesServices.RetrieveById(Convert.ToInt32(dr["categoryId"])),
                        _difficultiesServices.RetrieveById(Convert.ToInt32(dr["difficultyId"]))
                        );
                recipes.Add(recipe);
            }
            return recipes;
        }

        public List<Recipes> RetrieveAllBlocked()
        {
            DataTable dt = _recipesRepo.RetrieveAllBlocked();

            List<Recipes> recipes = new List<Recipes>();
            foreach (DataRow dr in dt.Rows)
            {
                Recipes recipe = new Recipes(
                        Convert.ToInt32(dr["recipeId"]),
                        dr["Title"].ToString(),
                        dr["PrepMethod"].ToString(),
                        dr["PrepTime"].ToString(),
                        _ingredientsRecipesServices.RetrieveIngredientsByRecipeId(Convert.ToInt32(dr["recipeId"])),
                        Convert.ToBoolean(dr["blockedStatus"]),
                        _categoriesServices.RetrieveById(Convert.ToInt32(dr["categoryId"])),
                        _difficultiesServices.RetrieveById(Convert.ToInt32(dr["difficultyId"]))
                        );
                recipes.Add(recipe);
            }
            return recipes;
        }

        public Recipes Update(Recipes recipe)
        {
            return _recipesRepo.Update(recipe);
        }


        public bool UpdateRecipesBlockedStatus(bool BlockedStatus)
        {
            return _recipesRepo.UpdateRecipesBlockedStatus(BlockedStatus);

        }

        public Recipes FindLastInsertedRecipe()
        {
            return _recipesRepo.FindLastInsertedRecipe();
        }
    }
}
