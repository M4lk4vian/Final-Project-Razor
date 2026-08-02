using System.Data;
using System.Data.SqlClient;
using Models;

namespace Repository
{
    public class SearchRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        public DataTable Find(string searchTerm)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string searched = "%" + searchTerm + "%";

                string query = @"SELECT DISTINCT r.recipeId, r.title, d.difficultyName, c.categoryName
                    FROM Recipes r 
                    INNER JOIN Difficulties d ON r.id_difficulty = d.difficultyId
                    INNER JOIN Categories c ON r.id_category = c.categoryId
                    INNER JOIN Ingredients_Recipes ir ON r.recipeId = ir.id_recipe
                    INNER JOIN Ingredients i ON ir.id_ingredient = i.ingredientId
                    WHERE r.title LIKE @searched
                    OR d.difficultyName LIKE @searched
                    OR c.categoryName LIKE @searched
                    OR i.ingredientName LIKE @searched";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.Add("@searched", SqlDbType.NVarChar).Value = searched;

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