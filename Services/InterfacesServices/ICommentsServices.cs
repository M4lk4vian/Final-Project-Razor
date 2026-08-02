using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface ICommentsServices
    {
        public Comments Create(Comments comment);
        public Comments RetrieveById(int id);

        public List<Comments> RetrieveCommentsByUserId(int id_user);
        public Comments Update(Comments comment);
    }
}

