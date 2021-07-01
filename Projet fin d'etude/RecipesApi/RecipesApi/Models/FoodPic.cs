using System;
using System.Collections.Generic;

#nullable disable

namespace RecipesApi.Models
{
    public partial class FoodPic
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public byte[] Pic1 { get; set; }
        public byte[] Pic2 { get; set; }
        public byte[] Pic3 { get; set; }
        public byte[] Pic4 { get; set; }

        public virtual Food FoodNameNavigation { get; set; }
    }
}
