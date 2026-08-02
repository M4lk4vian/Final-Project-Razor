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
    public class UnitsServices : IUnitsServices
    {
        public UnitsServices() 
        {

        }

        UnitsRepo _unitsRepo = new UnitsRepo();
        public UnitsServices(UnitsRepo unitsRepo)
        {
            _unitsRepo = unitsRepo;
        }

        public Units Create(Units unit)
        {
            return _unitsRepo.Create(unit);
        }

        public List<Units> RetrieveAll()
        {

            DataTable dt = _unitsRepo.RetrieveAll();


            List<Units> units = new List<Units>();
            foreach (DataRow dr in dt.Rows)
            {
                Units unit = new Units(
                        Convert.ToInt32(dr["unitId"].ToString()), 
                        dr["unitName"].ToString()

                    ); ;
                units.Add(unit);


            }
            return units;


        }

        public Units RetrieveById(int unitId)
        {
            DataTable dt = _unitsRepo.RetrieveById(unitId);
            DataRow dr = dt.Rows[0];
            Units unit = new Units(
                    Convert.ToInt32(dr["unitId"]),
                    dr["UnitName"].ToString()
                    
                );
            return unit;
        }

        public Units Update(Units unit)
        {
            return _unitsRepo.Update(unit);
        }



    }
}
