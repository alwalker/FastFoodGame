using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFoodGame.DataAccessLayer;
using FastFoodGame.Framework;

namespace FastFoodGame.BusinessLayer
{
    public class UserController
    {
        #region Methods

        public static void AddUser(User user)
        {
            UserDAL.AddUser(user);
        }

        public static List<User> GetAllUsers()
        {
            return UserDAL.GetAllUsers();
        }

        public static void EditUser(User user)
        {
            UserDAL.EditUser(user);
        }

        #endregion
    }
}
