using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ingredients
    {
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }

        public Ingredients() { }

        public Ingredients(int ingredientId, string ingredientName)
        {
            this.IngredientId = ingredientId;
            this.IngredientName = ingredientName;
        }

    }
}
