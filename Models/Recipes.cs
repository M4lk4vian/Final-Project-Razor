using System.Collections.Generic;
using System.Formats.Asn1;
using System.Threading;

namespace Models
{
    public class Recipes
    {
        public int RecipeId {  get; set; }
        public string Title { get;set;}
        public string PrepMethod{ get; set;}
        public string PrepTime { get; set;}
        public List <IngredientsRecipes> IngredientsRecipes { get; set; }
        public bool BlockedStatus { get; set;}
        public Categories Category { get; set; }
        public Difficulties Difficulty { get; set; }

        public Recipes() 
        {

        }

        public Recipes(int recipeId, string title, string prepMethod, string prepTime, List <IngredientsRecipes> ingredientsRecipes, bool blockedStatus, Categories category, Difficulties difficulty)
        {
            this.RecipeId = recipeId;
            this.Title = title;
            this.PrepMethod = prepMethod;
            this.PrepTime = prepTime;
            this.IngredientsRecipes = ingredientsRecipes;
            this.BlockedStatus = blockedStatus;
            this.Category = category;
            this.Difficulty = difficulty;
        }


    }

}
