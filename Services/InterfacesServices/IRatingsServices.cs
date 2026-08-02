using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IRatingsServices
    {
        public Ratings Create(Ratings rating);
        public List<Ratings> RetrieveAllByUserId(int Id_user);
        public Ratings RetrieveById (int id);
        public Ratings Update(Ratings rating);

        public double Average(double Average);
    }
}
