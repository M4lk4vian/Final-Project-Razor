using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Models;

namespace Repository
{
    public class FavoritesRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();


        public Favorites Create(Favorites favorite)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Favorites VALUES (@id_user, @id_recipe)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@id_user", SqlDbType.Int).Value = favorite.User.UserId;
                    cmd.Parameters.AddWithValue("@id_recipe", SqlDbType.Int).Value = favorite.Recipe.RecipeId;



                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();

                }
            }


            return favorite;
        }


        public DataTable RetrieveById(int favoriteId)
        {

            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Favorites WHERE favoriteId = @favoriteId";


                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@favoriteId", SqlDbType.Int).Value = favoriteId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable RetrieveByRecipeId(int id_recipe)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"SELECT * " +
                                   $"FROM Favorites " +
                                   $"WHERE id_recipe = @id_recipe";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@id_recipe", SqlDbType.Int).Value = id_recipe;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }

            }
            return dt;
        }


        public DataTable GetByUserId(int id_user)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT favoriteId, id_recipe FROM Favorites WHERE id_user = @id_user";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }
            return dt;
        }
        public Favorites Update(Favorites favorite)
        {
            int? FavoriteId = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Favorites SET Id_user = @Id_user, Id_recipe = @Id_recipe WHERE FavoriteId = @FavoriteId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    FavoriteId = Convert.ToInt32(cmd.ExecuteScalar());
                }


            }
            return favorite;
        }

        public void Delete(int favoriteId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"DELETE FROM Favorites WHERE favoriteId = @favoriteId";


                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@favoriteId", SqlDbType.Int).Value = favoriteId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
