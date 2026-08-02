using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Configuration;

namespace Repository
{   
    public class IngredientsRecipesRepo
    {

        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        public IngredientsRecipes Create(IngredientsRecipes ingredientsRecipe)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Ingredients_Recipes (id_recipe, id_ingredient, quantity, id_unit) VALUES (@id_recipe, @id_ingredient, @quantity, @id_unit)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@id_recipe", SqlDbType.Int).Value = ingredientsRecipe.Recipe.RecipeId;
                    cmd.Parameters.Add("@id_ingredient", SqlDbType.Int).Value = ingredientsRecipe.Ingredient.IngredientId;
                    cmd.Parameters.Add("@quantity", SqlDbType.NVarChar).Value = ingredientsRecipe.Quantity;
                    cmd.Parameters.Add("@id_unit", SqlDbType.NVarChar).Value = ingredientsRecipe.Unit.UnitId;
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return ingredientsRecipe;
        }

        public DataTable RetrieveAll()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Ingredients_Recipes";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable RetrieveById(int ingredientRecipeId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Ingredients_Recipes WHERE ingredientRecipeId = @ingredientRecipeId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@ingredientRecipeId", SqlDbType.Int).Value = ingredientRecipeId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable RetrieveIngredientsByRecipeId(int id_recipe)
        {
    
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                int? ingredientRecipeId = null;
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = @"SELECT ingredientRecipeId, id_recipe, id_ingredient, quantity, id_unit FROM Ingredients_Recipes WHERE Ingredients_Recipes.id_recipe = @id_recipe";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id_recipe", SqlDbType.Int).Value = id_recipe;

                    if(con.State != ConnectionState.Open)
                        con.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

       
        
        public IngredientsRecipes Update(IngredientsRecipes ingredientsRecipe)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Ingredients_Recipes SET quantity = @quantity, id_unit = @id_unit WHERE RecipeId = @RecipeId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@quantity", SqlDbType.NVarChar).Value = ingredientsRecipe.Quantity;
                    cmd.Parameters.Add("@id_unit", SqlDbType.Int).Value = ingredientsRecipe.Unit.UnitId;
                    
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    ingredientsRecipe.IngredientRecipeId = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            return ingredientsRecipe;
        }

        

    }
}
