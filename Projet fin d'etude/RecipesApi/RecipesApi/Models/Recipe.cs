using System;
using System.Collections.Generic;

#nullable disable

namespace RecipesApi.Models
{
    public partial class Recipe
    {
        public int IngrediantId { get; set; }
        public string FoodName { get; set; }
        public decimal? Quantity { get; set; }
        public string Name { get; set; }

        public virtual Food FoodNameNavigation { get; set; }
    }
}
