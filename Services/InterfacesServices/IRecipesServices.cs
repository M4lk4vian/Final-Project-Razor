using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IRecipesServices 
    {
        public Recipes Create(Recipes recipe);
        public List<Recipes> RetrieveAll();
        public Recipes RetrieveById(int recipeId);
        public Recipes Update(Recipes recipe);
    }
}
