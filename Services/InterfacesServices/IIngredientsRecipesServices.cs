using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services.InterfacesServices
{
    public interface IIngredientsRecipesServices
    {
        public IngredientsRecipes Create(IngredientsRecipes ingredientsRecipe);

        public List<IngredientsRecipes> RetrieveIngredientsByRecipeId(int id_recipe);

        public IngredientsRecipes Update(IngredientsRecipes ingredient);

    }
}
