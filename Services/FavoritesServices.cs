using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Repository;
using Models;

namespace Services
{
    public class FavoritesServices : IFavoritesServices
    {

        FavoritesRepo _favoritesRepo = new FavoritesRepo();

        public FavoritesServices() { }
        private readonly RecipesServices _recipesServices = new RecipesServices();
        private readonly UsersServices _usersServices = new UsersServices();
        public Favorites favorite = new Favorites();
        public List <Favorites> favorites = new List<Favorites>();
        public Users user = new Users();
        public Recipes recipe = new Recipes();
        
        public Favorites Create(Favorites favorite)
        {
            return _favoritesRepo.Create(favorite);
        }

        public Favorites RetrieveById(int favoriteId)  
        {

            DataTable dt = _favoritesRepo.RetrieveById(favoriteId);
            DataRow dr = dt.Rows[0];

            Favorites favorite = new Favorites(
                Convert.ToInt32(dr["favoriteId"]),
                _usersServices.RetrieveById(Convert.ToInt32(dr["userId"])),
                _recipesServices.RetrieveById(Convert.ToInt32(dr["recipeId"]))

                );
            return favorite;
        }

        public List<Favorites> GetAllByRecipeId(int id_recipe)
        {
            DataTable dt = _favoritesRepo.RetrieveByRecipeId(id_recipe);
            
            foreach (DataRow dr in dt.Rows)
            {
                Favorites favorite = new Favorites(
                Convert.ToInt32(dr["favoriteId"]),
                _usersServices.RetrieveById(Convert.ToInt32(dr["userId"])),
                recipe);

                favorites.Add(favorite);
            }
            return favorites;
        }

        public List<Favorites> GetAllByUserId(int id_user)
        {
            DataTable dt = _favoritesRepo.GetByUserId(id_user);
            List<Favorites> favorites = new List<Favorites>();
            foreach (DataRow dr in dt.Rows)
            {
                Favorites favorite = new Favorites(
                Convert.ToInt32(dr["favoriteId"]),
                user,
                _recipesServices.RetrieveById(Convert.ToInt32(dr["id_recipe"]))
                );

                favorites.Add(favorite);
            }



            return favorites;
        }

        public Favorites Update(Favorites favorite)
        {
            return _favoritesRepo.Update(favorite);
        }

        public void Delete(int id)
        {

            _favoritesRepo.Delete(id);
        }
    }
}
