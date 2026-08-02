using System.Collections.Generic;

namespace Models
{
    public class IngredientsRecipes
    {
        public int IngredientRecipeId {  get; set; }
        public Ingredients Ingredient { get; set; }
        public Recipes Recipe { get; set; }
        public double Quantity { get; set; }
        public Units Unit { get; set; }

        public IngredientsRecipes() { }

        public IngredientsRecipes(int ingredientRecipeId, Ingredients ingredient, Recipes recipe, double quantity, Units unit)
        {
            this.IngredientRecipeId = ingredientRecipeId;
            this.Ingredient = ingredient;
            this.Recipe = recipe;
            this.Quantity = quantity;
            this.Unit = unit;
        }

        public IngredientsRecipes(int ingredientRecipeId, int ingredient_id, int recipe_id, double quantity, int unit_id)
        {
            this.IngredientRecipeId = ingredientRecipeId;
            this.Ingredient = new Ingredients() { IngredientId = ingredient_id };
            this.Recipe = new Recipes() { RecipeId = recipe_id };
            this.Quantity = quantity;
            this.Unit = new Units() { UnitId = unit_id };
        }


    }

}