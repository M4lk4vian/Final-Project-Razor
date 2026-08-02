using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IIngredientsServices
    {
        public Ingredients Create(Ingredients ingredient);
        public List<Ingredients> RetrieveAll();
        public Ingredients RetrieveById(int id);
        public Ingredients Update(Ingredients ingredient);
    }
}
