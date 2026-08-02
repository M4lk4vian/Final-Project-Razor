using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Data.Common;

namespace Repository
{
    public class ValidationRepo
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["SqlServerAssembly"].ConnectionString.ToString();

        public ValidationRepo()
        {

        }


        public bool LoginValidation(Users user)
        {

            using (SqlConnection _connection = new SqlConnection(_connectionString))
            {


                string query = "SELECT * FROM Users WHERE userName = @userName AND password = @password AND blockedStatus = @blockedStatus AND isAdmin = @isAdmin";
                // 

                using (SqlCommand command = new SqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Password", user.Password);



                    if (_connection.State != ConnectionState.Open)
                        _connection.Open();
                    SqlDataReader dt = command.ExecuteReader();
                    
                    dt.Read();
                    if (dt["username"].ToString() == user.UserName && dt["password"].ToString() == user.Password)
                    {
                        Console.WriteLine("Login completed");
                        return true;
                    }
                }
                Console.WriteLine("Your Username or Password don't match, try again.");
                return false;
            }


        }

        public bool RegisterValidation(Users user)
        {


            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                

                string query = "SELECT * FROM Users WHERE UserName = @UserName";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    

                    command.Parameters.AddWithValue("@UserName", user.UserName);

                    if (connection.State != ConnectionState.Open)
                        connection.Open(); 

                    SqlDataReader dt = command.ExecuteReader();

                    while (dt.Read())
                    {
                        if (dt["username"].ToString() == user.UserName)
                        {
                            Console.WriteLine("User already exists, please choose another name");
                            return false;
                        }
                    }


                    return true;

                }
                
            }


                
        }       


    }


    
}
