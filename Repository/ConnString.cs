using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Threading;

namespace Repository
{
    public class Generic
    {
        

        private static string _connectionString;

        public static void SetConnectionString(string connectionString) 
        {
            _connectionString = connectionString;
        }
        
        
        public string ConnectionString() 
        {
            return _connectionString;
        }

        public static void OpenWithRetry(SqlConnection connection, int maxAttempts = 3)
        {
            int attempt = 0;
            while (true)
            {
                attempt++;
                try
                {
                    connection.Open();
                    return;
                }
                catch(SqlException) when (attempt < maxAttempts)
                {
                    Thread.Sleep(2000);
                }

            }
        }
    }
}
