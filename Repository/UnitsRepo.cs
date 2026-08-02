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
    public class UnitsRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        Units unit = new Units();
        public Units Create(Units unit)
        {


            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "INSERT INTO Units(unitName) VALUES(@unitName)";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    #region Insert query values
                    cmd.Parameters.Add("@unitName", SqlDbType.NVarChar).Value = unit.UnitName;

                    #endregion

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            return unit;
        }

        public DataTable RetrieveAll()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Units";

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

        public DataTable RetrieveById(int unitId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Units WHERE unitId = @unitId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = unitId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public Units RetrieveById(Units unit)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT unitName FROM Units WHERE unitId = @unitId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@unitId", SqlDbType.Int).Value = unit.UnitId;


                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataReader dataReader = cmd.ExecuteReader();
                    if (dataReader.Read())
                    {
                        unit.UnitName = dataReader["unitName"].ToString();
                    }
                }

            }
            return unit;
        }
        public Units Update(Units unit)
        {
            int? UnitId = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Units SET unitName = @unitName WHERE UnitId = @UnitId";

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    UnitId = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            return unit;
        }

        
    }
}
