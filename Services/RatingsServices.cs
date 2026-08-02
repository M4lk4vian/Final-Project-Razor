using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Services
{
    public class RatingsServices : IRatingsServices
    {

        private readonly RatingsRepo _ratingsRepo = new RatingsRepo();
        public Users user = new Users();

        public RatingsServices() { }

        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();

        public Ratings Create(Ratings rating)
        {
            if (rating.Rating >= 0 && rating.Rating <= 10)
            {
                if (RatedAlready(rating.User.UserId, rating.Recipe.RecipeId) == false)
                {
                    return _ratingsRepo.Create(rating);
                }
                else
                {
                    DataTable dt = _ratingsRepo.GetByUserAndRecipe(rating.User.UserId, rating.Recipe.RecipeId);
                    rating.RatingId = Convert.ToInt32(dt.Rows[0]["ratingId"]);
                    return _ratingsRepo.Update(rating);
                }
            }
            else 
            {
                return null;
            }
  
        }

        public List<Ratings> RetrieveAllByUserId(int Id_user)
        {
            DataTable dt = _ratingsRepo.RetrieveAllByUserId(Id_user);


            List<Ratings> ratings = new List<Ratings>();

            foreach (DataRow dr in dt.Rows)
            {

                Ratings rating = new Ratings(
                        Convert.ToInt32(dr["ratingId"].ToString()),
                        Convert.ToInt32(dr["rating"]),
                        _recipesServices.RetrieveById(Convert.ToInt32(dr["recipeId"])),
                        user
                    );
                ratings.Add(rating);


            }
            return ratings;
        }

        public Ratings RetrieveById(int ratingId)
        {

            DataTable dt = _ratingsRepo.RetrieveById(ratingId);
            if (dt.Rows.Count == 0)
            {
                return null;  
            }
            DataRow dr = dt.Rows[0];
            Ratings rating = new Ratings(
                    Convert.ToInt32(dr["ratingId"]),
                    Convert.ToInt32(dr["rating"]),
                    _recipesServices.RetrieveById(Convert.ToInt32(dr["id_recipe"])),
                    _usersServices.RetrieveById(Convert.ToInt32(dr["id_user"]))

                );
            return rating;
        }


        public Ratings Update(Ratings rating)
        {
            if (rating.Rating >= 0 && rating.Rating <= 10)
            {
                return _ratingsRepo.Update(rating);
            }
            else 
            {
                return null;
            }

                
        }

        public double Average(double average) 
        {
            DataTable dt = _ratingsRepo.Average();
            if (dt.Rows.Count == 0 || dt.Rows[0][0] == DBNull.Value)
                return 0;
            average = Convert.ToDouble(dt.Rows[0][0]);
            return average;
            
        }

        public bool RatedAlready(int id_user, int id_recipe)
        {
            return _ratingsRepo.RatedAlready(id_user, id_recipe);
        }
    }
}
