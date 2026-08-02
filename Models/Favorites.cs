namespace Models
{
    public class Favorites
    {
        public int FavoriteId { get; set; }
        public Users User { get; set; }

        public Recipes Recipe {  get; set; }


        public Favorites()
        {

        }

        public Favorites(int favoriteId, Users user, Recipes recipe) 
        {
            this.FavoriteId = favoriteId;
            this.User = user;
            this.Recipe = recipe;

        }
    }
}
