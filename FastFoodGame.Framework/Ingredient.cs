using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodGame.Framework
{
    public class Ingredient
    {
        public enum IngredientType { Unknown = 0, Bread, Sauce, Meat, Toppings };

        public int Id { get; set; }
        public string Name { get; set; }
        public int SingleContainerCapacity { get; set; }
        public int LifeSpan { get; set; }
        public int ContainerRefilTime { get; set; }
        public IngredientType Type { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
