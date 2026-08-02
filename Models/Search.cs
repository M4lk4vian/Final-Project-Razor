using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Search
    {
        public string SearchTerm;
        public string SearchedTerm;

        public Search() 
        {

        }

        public Search(string searchTerm, string searchedTerm) 
        {
            SearchTerm = searchTerm;
            SearchedTerm = searchedTerm;

        }
        
    }
}
