using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public  interface IDifficultiesServices
    {

        public Difficulties Create(Difficulties difficulty);
        public List<Difficulties> RetrieveAll();

        public Difficulties RetrieveById(int id);
        public Difficulties Update(Difficulties difficulty);
    }
}
