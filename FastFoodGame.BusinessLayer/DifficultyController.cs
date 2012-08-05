using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFoodGame.DataAccessLayer;
using FastFoodGame.Framework;

namespace FastFoodGame.BusinessLayer
{
    public class DifficultyController
    {
        #region Methods

        public static void AddDifficulty(Difficulty difficulty)
        {
            DifficultyDAL.AddDiffuculty(difficulty);
        }

        public static void EditDifficulty(Difficulty difficulty)
        {
            DifficultyDAL.EditDiffuculty(difficulty);
        }

        public static List<Difficulty> GetAllDifficulties()
        {
            return DifficultyDAL.GetAllDifficulties();
        }

        #endregion
    }
}
