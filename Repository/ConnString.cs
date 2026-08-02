using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
