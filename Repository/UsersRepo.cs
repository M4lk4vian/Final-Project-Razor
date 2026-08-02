using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Collections;


namespace Repository
{
    public class UsersRepo
    {
        private static Generic _generic = new Generic();
        private static string connectionString = _generic.ConnectionString();

        bool BlockedStatus;
        List<Users> users = new List<Users>();




        public Users Register(Users user)
        {
           
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (userName, password, blockedStatus, isAdmin) VALUES (@userName, @password, @blockedStatus, @isAdmin)";


                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@userName", user.UserName);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@blockedStatus", user.BlockedStatus = true);
                    command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);
                    
                    users.Add(user);

                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    command.ExecuteNonQuery();

                }

            }
            return user;
        }

        public DataTable RetrieveAllAccepted()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Users WHERE blockedStatus = 0";

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
                    string query = "SELECT * FROM Users WHERE blockedStatus = 1";

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

        public DataTable Login(string userName, string password)
        {
            DataTable dt = new DataTable();

            using(SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE userName = @userName AND password = @password";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.CommandText = query;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@userName", SqlDbType.NVarChar).Value = userName;
                    cmd.Parameters.AddWithValue("@password", SqlDbType.NVarChar).Value = password;

                    

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }

                return dt;
            }
        }

        public DataTable RetrieveById(int userId)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = "SELECT * FROM Users WHERE userId = @userId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@userId", SqlDbType.Int).Value = userId;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                }
            }

            return dt;
        }

        public Users Update(Users user)
        {
            int? UserId = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    string query = $"UPDATE Users SET userName = @userName, " +
                                   $"password = @password " +
                                   $"WHERE UserId = @UserId";
                    cmd.CommandText = query;
                    cmd.Connection = con;

                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    UserId = Convert.ToInt32(cmd.ExecuteNonQuery());
                }

            }
            return user;
        }


        public bool UpdateBlockedStatus(int UserId)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    string query = $"UPDATE Users SET blockedStatus = @blockedStatus WHERE userId = @UserId";

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = UserId;
                    cmd.Parameters.AddWithValue("@blockedStatus", SqlDbType.Bit).Value = BlockedStatus;

                    if (con.State != ConnectionState.Open)
                        con.Open();

                    BlockedStatus = Convert.ToBoolean(cmd.ExecuteNonQuery());

                }
                
                
            }
            return BlockedStatus;


            

        }
        public Users UpdateUserInfo(Users User)
        {
            int? UserId = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {                                                    
                    string query = $"UPDATE Users SET userName = @userName, password = @password WHERE userId = @UserId";
                    
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@userId", SqlDbType.Int).Value = User.UserId;
                    cmd.Parameters.AddWithValue("@userName", SqlDbType.Int).Value = User.UserName;
                    cmd.Parameters.AddWithValue("@password", SqlDbType.Int).Value = User.Password;


                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();

                    User.UserId = Convert.ToInt32(cmd.ExecuteNonQuery());
                }

            }
            return User;
        }
        





    }
}
