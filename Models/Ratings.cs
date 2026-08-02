namespace Models
{
    public class Ratings
    {
        public int RatingId {  get; set; }
        public int Rating { get; set; }
        public Recipes Recipe {  get; set; }
        public Users User { get; set; }


        public Ratings() { }

        public Ratings(int ratingId, int rating, Recipes recipe, Users user) 
        {
            this.RatingId = ratingId;
            this.Rating = rating;
            this.Recipe = recipe;
            this.User = user;
        }

    }

}
