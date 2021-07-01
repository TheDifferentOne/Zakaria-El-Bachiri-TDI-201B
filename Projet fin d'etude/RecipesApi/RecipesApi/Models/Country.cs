using System;
using System.Collections.Generic;

#nullable disable

namespace RecipesApi.Models
{
    public partial class Country
    {
        public Country()
        {
            Foods = new HashSet<Food>();
        }

        public string Name { get; set; }

        public virtual ICollection<Food> Foods { get; set; }
    }
}
