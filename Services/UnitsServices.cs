using Repository;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Services
{
    public class UnitsServices
    {
        public UnitsServices() 
        {

        }

        UnitsServices unitsServices = new UnitsServices();

        UnitsRepo _unitsRepo = new UnitsRepo();
        public UnitsServices(UnitsRepo unitsRepo)
        {
            _unitsRepo = unitsRepo;
        }

        public Units Create(Units unit)
        {
            return _unitsRepo.Create(unit);
        }

        //public List<Units> Retrieve()
        //{

        //    DataTable dt = _unitsRepo.Retrieve(1);


        //    List<Units> employees = new List<Units>();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        //Units unit = new Units(
        //        //        dr ["id"].ToString() ?? "", //This solution is called an elvis operator, its here to ensure the received data doesn not reach the codebase as a null
        //        //        dr ["unitName"]?.ToString() ?? "",

        //        //    );
        //        //units.Add(unit);


        //    }
        //    return Units;


        //}

    }
}
