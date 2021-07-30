using System;

namespace Recipes.Domain
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan Hour { get; set; }
    }
}
