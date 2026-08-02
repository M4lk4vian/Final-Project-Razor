using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ICategoriesServices
    {
        public Categories Create(Categories category);
        public List<Categories> RetrieveAll();
        public Categories RetrieveById(int id);
        public Categories Update(Categories category);
    }
}
