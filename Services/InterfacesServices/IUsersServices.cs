using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public interface IUsersServices 
    {
        public Users Register(Users user);
        public List<Users> RetrieveAllAccepted();

        public List<Users> RetrieveAllBlocked();
        public Users RetrieveById(int id);
        public Users Update(Users user);
    }
}
