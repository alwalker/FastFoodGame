using FastFoodGame.DataAccessLayer;
using FastFoodGame.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodGame.BusinessLayer
{
    public class IngredientController
    {
        public static void AddIngredient(Ingredient ingredient)
        {
            IngredientDAL.AddIngredient(ingredient);
        }

        public static List<Ingredient> GetAllIngredients()
        {
            return IngredientDAL.GetAllIngredients();
        }

        public static void EditIngredient(Ingredient ingredient)
        {
            IngredientDAL.EditIngredient(ingredient);
        }
    }
}
