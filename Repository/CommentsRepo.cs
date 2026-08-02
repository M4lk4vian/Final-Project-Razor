using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public class CommentsRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        public Comments Create(Comments comment)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Comments(content, id_recipe, id_user) VALUES(@content, @id_recipe, @id_user)";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@content", SqlDbType.NVarChar).Value = comment.Content;
                    cmd.Parameters.Add("@id_recipe", SqlDbType.Int).Value = comment.Recipe.RecipeId;
                    cmd.Parameters.Add("@id_user", SqlDbType.Int).Value = comment.User.UserId;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return comment;
        }

        public DataTable RetrieveById(int commentId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Comments WHERE commentId = @commentId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@commentId", SqlDbType.Int).Value = commentId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public DataTable RetrieveCommentsByUserId(int id_user)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Comments WHERE Comments.id_user = @id_user";

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

        public DataTable RetrieveCommentsByRecipeId(int id_recipe)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Comments WHERE Comments.Id_recipe = @Id_recipe";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@Id_recipe", SqlDbType.Int).Value = id_recipe;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public Comments Update(Comments comment)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Comments SET content = @content WHERE commentId = @commentId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@commentId", SqlDbType.Int).Value = comment.CommentId;
                    cmd.Parameters.AddWithValue("@content", SqlDbType.NVarChar).Value = comment.Content;
                    //cmd.Parameters.Add("id_recipe", SqlDbType.Int).Value = comment.Recipe.Id; //Serão estes doias mesmo necessários visto não os querer alterar?
                    //cmd.Parameters.Add("id_user", SqlDbType.Int).Value = comment.User.Id;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    comment.CommentId = cmd.ExecuteNonQuery();
                }

            }
            return comment;
        }

    }
}
