using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class CategoriesServices : ICategoriesServices
    {

        private readonly CategoriesRepo _categoriesRepo = new CategoriesRepo();

        public Categories Create(Categories category)
        {
            return _categoriesRepo.Create(category);
        }


        public List<Categories> RetrieveAll()
        {
            DataTable dt = _categoriesRepo.RetrieveAll();


            List<Categories> categories = new List<Categories>();
            foreach (DataRow dr in dt.Rows)
            {
                Categories category = new Categories(
                        Convert.ToInt32(dr["categoryId"]), 
                        dr["categoryName"].ToString()

                    );
                categories.Add(category);


            }
            return categories;
        }

        public Categories RetrieveById(int categoryId)
        {
            DataTable dt = _categoriesRepo.RetrieveById(categoryId);
            DataRow dr = dt.Rows[0];
            Categories category = new Categories(
                    Convert.ToInt32(dr["categoryId"]),
                    dr["categoryName"].ToString());
            return category;
        }

        public Categories Update(Categories category)
        {
            return _categoriesRepo.Update(category);
        }

    }
}
