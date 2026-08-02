using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class UsersServices : IUsersServices
    {
        public UsersServices() 
        {

        }



        private UsersRepo _usersRepo = new UsersRepo();


        public Users Register(Users user)
        {
            return _usersRepo.Register(user);
        }

        public List<Users> RetrieveAllAccepted()
        {
            DataTable dt = _usersRepo.RetrieveAllAccepted();


            List<Users> users = new List<Users>();
            foreach (DataRow dr in dt.Rows)
            {
                Users user = new Users(
                        Convert.ToInt32(dr["userId"].ToString()),
                        dr["userName"].ToString(),
                        dr["password"].ToString(),
                        Convert.ToBoolean(dr["blockedStatus"]),
                        Convert.ToBoolean(dr["isAdmin"])

                    );
                users.Add(user);


            }
            return users;
        }

        public List <Users> RetrieveAllBlocked()
        {
            DataTable dt = _usersRepo.RetrieveAllBlocked();

            List<Users> Users = new List<Users>();
            foreach(DataRow dr in dt.Rows)
            {
                Users User = new Users(
                    Convert.ToInt32(dr["userId"].ToString()),
                    dr["userName"].ToString(),
                    dr["password"].ToString(),
                    Convert.ToBoolean(dr["blockedStatus"]),
                    Convert.ToBoolean(dr["isAdmin"])
                    );
                Users.Add(User);
            }
            return Users;
        }

        public Users RetrieveById(int userId)
        {
            DataTable dt = _usersRepo.RetrieveById(userId);

            if (dt.Rows.Count == 0)
                return null;

            DataRow dr = dt.Rows[0];

            Users user = new Users(
                    Convert.ToInt32(dr["userId"]),
                    dr["userName"].ToString(),
                    dr["password"].ToString(),
                    Convert.ToBoolean(dr["isAdmin"]),
                    Convert.ToBoolean(dr["blockedStatus"])

                );
            return user;
        }


        public Users Update(Users user)
        {
            return _usersRepo.Update(user);
        }

        public Users Login(string userName, string password)
        {
            DataTable dt = _usersRepo.Login(userName, password);
            DataRow dr = dt.Rows[0];
            Users user = new Users(
                Convert.ToInt32(dr["userId"]),
                    dr["userName"].ToString(),
                    dr["password"].ToString(),
                    Convert.ToBoolean(dr["isAdmin"]),
                    Convert.ToBoolean(dr["blockedStatus"])


                );
            
            return user;
        }

        public bool UpdateBlockedStatus(int id)
        {
            return _usersRepo.UpdateBlockedStatus(id);
        }

        public Users UpdateUserInfo(Users User)
        {
            return _usersRepo.UpdateUserInfo(User);
        }

    }
}
