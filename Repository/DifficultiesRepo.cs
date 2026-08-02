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
    public class DifficultiesRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        public Difficulties Create(Difficulties difficulty)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Difficulties(difficultyName) VALUES(@difficultyName)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@difficultyName", SqlDbType.NVarChar).Value = difficulty.DifficultyName;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return difficulty;
        }

        public DataTable RetrieveAll()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Difficulties";

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

        public DataTable RetrieveById(int difficultyId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Difficulties WHERE difficultyId = @DifficultyId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@DifficultyId", SqlDbType.Int).Value = difficultyId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }


        public Difficulties Update(Difficulties difficulty)
        {
            int? DifficultyId = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Difficulties SET difficultyName = @difficultyName WHERE DifficultyId = @DifficultyId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.Add("@difficultyId", SqlDbType.Int).Value = difficulty.DifficultyId;
                    cmd.Parameters.Add("@difficultyName", SqlDbType.NVarChar).Value = difficulty.DifficultyName;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    difficulty.DifficultyId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return difficulty;
        }

    }
}
