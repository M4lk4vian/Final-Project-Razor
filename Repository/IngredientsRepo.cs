using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Repository
{
    public class IngredientsRepo
    {

        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        public Ingredients ingredientsList = new Ingredients();


        public Ingredients Create(Ingredients ingredient)
        {
            using(SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Ingredients(ingredientName) VALUES (@ingredientName)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@ingredientName", SqlDbType.NVarChar, 20).Value = ingredient.IngredientName;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    return ingredient;

                }
            }
        }

        public DataTable RetrieveAll()
        {
            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                int? Id = null;
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Ingredients";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                }
            }
            return dt;
        }

        public DataTable RetrieveById(int ingredientId)
        {
            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT ingredientId, ingredientName FROM Ingredients WHERE ingredientId = @ingredientId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@ingredientId", SqlDbType.Int).Value = ingredientId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);


                }
            }
            return dt;
        }



        public Ingredients RetrieveById(Ingredients ingredient)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT ingredientId, ingredientName FROM Ingredients WHERE ingredientId = @ingredientId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@ingredientId", SqlDbType.Int).Value = ingredient.IngredientName;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        ingredient.IngredientName = dataReader["ingredientName"].ToString();
                    }


                }
            }
            return ingredient;
        }


        public Ingredients Update(Ingredients ingredient)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Ingredients SET ingredientName = @ingredientName WHERE ingredientId = @ingredientId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    ingredient.IngredientId = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            return ingredient;
        }
    }
}
