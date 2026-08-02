using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IFavoritesServices
    {
        public Favorites Create(Favorites favorites);
        public Favorites RetrieveById(int id);
        public Favorites Update(Favorites favorite);
        public void Delete(int id);
    }
}
