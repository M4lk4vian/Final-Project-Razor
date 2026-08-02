using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;
using Repository;

namespace Services
{
    public class ValidationServices
    {
        public ValidationServices()
        {

        }

        private readonly ValidationRepo _validationRepo = new ValidationRepo();

        public ValidationServices(ValidationRepo validationRepo)
        {
            _validationRepo = validationRepo;
        }


        public bool LoginValidation(Users user)
        {
            _validationRepo.LoginValidation(user);
            return true;
        }

        public bool RegisterValidation(Users user)
        {
            _validationRepo.RegisterValidation(user);
            return true;

        }

    }
}
