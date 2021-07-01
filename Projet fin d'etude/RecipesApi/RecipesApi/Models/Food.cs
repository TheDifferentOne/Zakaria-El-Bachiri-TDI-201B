using System;
using System.Collections.Generic;

#nullable disable

namespace RecipesApi.Models
{
    public partial class Food
    {
        public Food()
        {
            Directions = new HashSet<Direction>();
            FoodPics = new HashSet<FoodPic>();
            Recipes = new HashSet<Recipe>();
        }

        public string Name { get; set; }
        public int CookingTime { get; set; }
        public int Servings { get; set; }
        public string Country { get; set; }

        public virtual Country CountryNavigation { get; set; }
        public virtual ICollection<Direction> Directions { get; set; }
        public virtual ICollection<FoodPic> FoodPics { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}
