using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IUnitsServices
    {
        public Units Create(Units unit);
        public List<Units> RetrieveAll();
        public Units RetrieveById(int id);
        public Units Update(Units unit);
    }
}
