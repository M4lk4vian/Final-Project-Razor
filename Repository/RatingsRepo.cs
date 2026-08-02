using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Models;
using System.Configuration;

namespace Repository
{
    public  class RatingsRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();
        public Ratings Create(Ratings rating)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Ratings(rating, id_recipe, id_user) VALUES(@rating, @id_recipe, @id_user)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@rating", SqlDbType.Float).Value = rating.Rating;
                    cmd.Parameters.Add("@id_recipe", SqlDbType.Int).Value = rating.Recipe.RecipeId;
                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = rating.User.UserId;
                    
                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return rating;
        }



        public DataTable RetrieveAllByUserId(int Id_user)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Ratings WHERE Id_user = @Id_user";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = Id_user;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable RetrieveById(int ratingId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Ratings WHERE ratingId = @ratingId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@ratingId", SqlDbType.Int).Value = ratingId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public Ratings Update(Ratings rating)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {   
                    string query = $"UPDATE Ratings SET rating = @rating WHERE RatingId = @RatingId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@rating", SqlDbType.Float).Value = rating.Rating;
                    cmd.Parameters.Add("@RatingId", SqlDbType.Int).Value = rating.RatingId;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    rating.RatingId = Convert.ToInt32(cmd.ExecuteNonQuery());
                }

            }
            return rating;

            
        }

        public DataTable Average()
        {
            DataTable dt = new DataTable();
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    string query = $"SELECT AVG(rating) FROM Ratings";


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

        public bool RatedAlready(int id_user, int id_recipe)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT COUNT (*) FROM RATINGS WHERE id_user = @id_user AND id_recipe = @id_recipe";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                    cmd.Parameters.Add("@id_recipe", SqlDbType.Int).Value = id_recipe;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        public DataTable GetByUserAndRecipe(int id_user, int id_recipe)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Ratings WHERE id_user = @id_user AND id_recipe = @id_recipe";
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = id_user;
                    cmd.Parameters.Add("@id_recipe", SqlDbType.Int).Value = id_recipe;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
      
                }

            }
            return dt;
            
        }
    }
}
