using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.ComponentModel;
using System.Reflection;
using System.Collections;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Core;

namespace Repository
{
    public  class RecipesRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        public Categories category = new Categories();
        public Difficulties difficulty = new Difficulties();
        public Recipes recipe = new Recipes();
        public Ingredients ingredient = new Ingredients();
        public List<Ingredients> ingredients = new List<Ingredients>();

        //public class IndexModel : PageModel
        //{
        //    private readonly ILogger<IndexModel> _logger;

        //    public IndexModel(ILogger<IndexModel> logger)
        //    {
        //        _logger = logger;
        //    }


        //}


        public Recipes Create(Recipes recipe)
        {
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                

                string query = "INSERT INTO Recipes(Title, PrepMethod, PrepTime, BlockedStatus, id_category, id_difficulty) VALUES(@Title, @PrepMethod, @PrepTime, @BlockedStatus, @id_category, @id_difficulty)";

                using (SqlCommand cmd = new SqlCommand())
                {


                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = recipe.Title;
                    cmd.Parameters.Add("@prepMethod", SqlDbType.NVarChar).Value = recipe.PrepMethod;
                    cmd.Parameters.Add("@prepTime", SqlDbType.NVarChar).Value = recipe.PrepTime;
                    cmd.Parameters.Add("@blockedStatus", SqlDbType.NVarChar).Value = true;
                    cmd.Parameters.Add("@id_category", SqlDbType.Int).Value = recipe.Category.CategoryId;
                    cmd.Parameters.Add("@id_difficulty", SqlDbType.Int).Value = recipe.Difficulty.DifficultyId;



                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();


                }


            }
            return recipe;
        }

        public DataTable RetrieveAll() 
        {       

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = @"SELECT " +
                        "    Recipes.recipeId, " +
                        "    Recipes.title AS 'Recipe Title', " +
                        "    Recipes.prepMethod AS 'Preparation Method', " +
                        "    Recipes.prepTime AS 'Preparation Time', " +
                        "    STRING_AGG(Ingredients.ingredientName, ', ') AS 'Ingredients', " +
                        "    Recipes.blockedStatus AS 'Blocked Status', " +
                        "    Categories.categoryId AS 'categoryId'," +
                        "    Categories.categoryName AS 'Category', " +
                        "    Difficulties.difficultyId AS 'difficultyId', " +  
                        "    Difficulties.difficultyName AS 'Difficulty' " +
                        "FROM Recipes " +
                        "INNER JOIN Categories ON Recipes.id_category = Categories.categoryId " +
                        "INNER JOIN Difficulties ON Recipes.id_difficulty = Difficulties.difficultyId " +
                        "INNER JOIN Ingredients_Recipes ON Recipes.recipeId = Ingredients_Recipes.id_recipe " +
                        "INNER JOIN Ingredients ON Ingredients.ingredientId = Ingredients_Recipes.id_ingredient " +
                        "GROUP BY " +
                        "    Recipes.recipeId, " +
                        "    Recipes.title, " +
                        "    Recipes.prepMethod, " +
                        "    Recipes.prepTime, " +
                        "    Recipes.blockedStatus, " +
                        "    Categories.categoryId, " +
                        "    Categories.categoryName, " +
                        "    Difficulties.difficultyId, " +
                        "    Difficulties.difficultyName;";

                    //string query = @"SELECT Recipes.id, Recipes.title AS 'Recipe Title', Recipes.prepMethod AS 'Preparation Method', Recipes.prepTime AS 'Preparation Time', Ingredients.ingredientName AS 'Ingredients', Recipes.blockedStatus AS 'Blocked Status', Categories.categoryName AS 'Category', Difficulties.difficultyName AS 'Difficulty' FROM Recipes INNER JOIN Categories ON Recipes.id = Categories.id INNER JOIN Difficulties ON Recipes.id = Difficulties.id INNER JOIN Ingredients_Recipes ON Recipes.id = Ingredients_Recipes.id_recipe INNER JOIN Ingredients ON Ingredients.id = Ingredients_Recipes.id_ingredient";

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

        public DataTable RetrieveById(int recipeId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = @"SELECT Recipes.recipeId," +
                                    "Recipes.title, " +
                                    "Recipes.prepMethod, " +
                                    "Recipes.prepTime, " +
                                    "Ingredients.ingredientName, " +
                                    "Recipes.blockedStatus, " +
                                    "Categories.categoryId, " +
                                    "Categories.categoryName, " +
                                    "Difficulties.difficultyId, " +
                                    "Difficulties.difficultyName " +
                                    "FROM Recipes " +
                                    "INNER JOIN Categories ON Recipes.id_category = Categories.categoryId " +
                                    "INNER JOIN Difficulties ON Recipes.id_difficulty = Difficulties.difficultyId " +
                                    "INNER JOIN Ingredients_Recipes ON Recipes.recipeId = Ingredients_Recipes.id_recipe " +
                                    "INNER JOIN Ingredients ON Ingredients.ingredientId = Ingredients_Recipes.id_ingredient " +
                                    "WHERE Recipes.recipeId = @recipeId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@recipeId", SqlDbType.Int).Value = recipeId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);


                }
            }

            return dt;
        }

        public DataTable RetrieveAllAccepted()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Recipes WHERE blockedStatus = 0";

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

        public DataTable RetrieveAllBlocked()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Recipes WHERE blockedStatus = 1";

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

        public Recipes Update(Recipes recipe)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    string query = $"UPDATE Recipes " +
                                   $"SET title = @title, " +
                                   $"prepMethod = @prepMethod, " +
                                   $"prepTime = @prepTime, " +
                                   $"blockedStatus = @blockedStatus," +
                                   $"id_category = @id_category, " +
                                   $"id_difficulty = @id_difficulty " +
                                   $"WHERE recipeId = @recipeId";

                    cmd.Parameters.AddWithValue("@recipeId", SqlDbType.Int).Value = recipe.RecipeId;
                    cmd.Parameters.AddWithValue("@title", SqlDbType.NVarChar).Value = recipe.Title;
                    cmd.Parameters.AddWithValue("@prepMethod", SqlDbType.NVarChar).Value = recipe.PrepMethod;
                    cmd.Parameters.AddWithValue("@blockedStatus", SqlDbType.Bit).Value = true;
                    cmd.Parameters.AddWithValue("@prepTime", SqlDbType.NVarChar).Value = recipe.PrepTime;
                    cmd.Parameters.AddWithValue("@id_category", SqlDbType.Int).Value = recipe.Category.CategoryId;
                    cmd.Parameters.AddWithValue("@id_difficulty", SqlDbType.Int).Value = recipe.Difficulty.DifficultyId;

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    recipe.RecipeId = cmd.ExecuteNonQuery();


                }

            }
            return recipe;
        }


        public bool UpdateRecipesBlockedStatus(bool blockedStatus)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Recipes SET blockedStatus = @blockedStatus";

                using (SqlCommand command = new SqlCommand(query, connection))
                {



                    command.CommandText = query;
                    command.Connection = connection;
                    command.Parameters.AddWithValue("@blockedStatus", SqlDbType.Bit).Value = blockedStatus;

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();

                    return blockedStatus;


                }


            }
        }
        public Recipes FindLastInsertedRecipe()
        {

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                Recipes recipe = new Recipes();
                string query = "SELECT IDENT_CURRENT ('Recipes')";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        command.CommandText = query;
                        command.Connection = connection;

                        if (connection.State != ConnectionState.Open)
                            connection.Open();

                        recipe.RecipeId = Convert.ToInt32(command.ExecuteScalar());

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }


                    return recipe;
                }
            }
        }
    }
}
