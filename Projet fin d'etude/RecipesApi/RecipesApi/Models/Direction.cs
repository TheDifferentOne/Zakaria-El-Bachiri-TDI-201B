using System;
using System.Collections.Generic;

#nullable disable

namespace RecipesApi.Models
{
    public partial class Direction
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public string Directions { get; set; }

        public virtual Food FoodNameNavigation { get; set; }
    }
}
