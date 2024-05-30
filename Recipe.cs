using System.Collections.Generic;

namespace CookBook
{
    public class Recipe
    {
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();
    }
}
