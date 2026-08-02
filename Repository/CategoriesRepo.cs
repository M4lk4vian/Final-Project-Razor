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
using System.ComponentModel;

namespace Repository
{
    public class CategoriesRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        public Categories Create(Categories category)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Categories(categoryName) VALUES(@categoryName)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@categoryName", SqlDbType.NVarChar).Value = category.CategoryName;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return category;
        }

        public DataTable RetrieveAll()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Categories";

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

        public DataTable RetrieveById(int categoryId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Categories WHERE categoryId = @categoryId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@categoryId", SqlDbType.Int).Value = categoryId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public Categories Update(Categories category)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Categories SET categoryName = @categoryName WHERE CategoryId = @CategoryId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@categoryId", SqlDbType.Int).Value = category.CategoryId;
                    cmd.Parameters.Add("@categoryName", SqlDbType.NVarChar).Value = category.CategoryName;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    category.CategoryId = cmd.ExecuteNonQuery();

                }

            }
            return category;
        }



    }

}
