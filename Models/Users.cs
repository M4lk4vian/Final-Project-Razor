using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace Models
{
    public class Users
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool BlockedStatus { get; set; }

        public Users() 
        {

        }
        public Users(int userId, string userName, string password, bool isAdmin, bool blockedStatus)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Password = password;
            this.IsAdmin = isAdmin;
            this.BlockedStatus = blockedStatus;
        }


    }


}
