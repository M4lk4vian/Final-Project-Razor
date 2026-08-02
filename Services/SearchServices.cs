using System.Data;
using Models;
using Repository;

namespace Services
{
    public class SearchServices
    {
        private readonly SearchRepo _searchRepo = new SearchRepo();

        public DataTable Find(string searchTerm)
        {
            return _searchRepo.Find(searchTerm);
        }
    }
}
