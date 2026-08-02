using System;
using System.Data;

using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class IngredientsServices : IIngredientsServices
    {

        IngredientsRepo _ingredientsRepo = new IngredientsRepo();

        public Ingredients ingredient = new Ingredients();
        public List<Ingredients> ingredients = new List<Ingredients>();



        public Ingredients Create(Ingredients ingredient)
        {
            return _ingredientsRepo.Create(ingredient);
        }

        public List<Ingredients> RetrieveAll()
        {
            DataTable dt = _ingredientsRepo.RetrieveAll();




            foreach(DataRow dr in dt.Rows)
            {
                Ingredients ingredient = new Ingredients(
                     Convert.ToInt32(dr["ingredientId"]),
                     dr["ingredientName"].ToString()

                    );

                ingredients.Add(ingredient);
                                                              
            }
            return ingredients;
        }


        public Ingredients RetrieveById(int ingredientId)
        {
            DataTable dt = _ingredientsRepo.RetrieveById(ingredientId);
            DataRow dr = dt.Rows[0];
            Ingredients ingredient = new Ingredients(
                    Convert.ToInt32(dr["ingredientId"]),
                    dr["ingredientName"].ToString()
                    );

            return ingredient;
        }

        public Ingredients Update(Ingredients ingredient)
        {
            return _ingredientsRepo.Update(ingredient);
        }

    }

}
