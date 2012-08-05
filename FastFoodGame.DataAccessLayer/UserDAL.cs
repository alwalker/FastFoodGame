﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using FastFoodGame.Framework;

namespace FastFoodGame.DataAccessLayer
{
    public class UserDAL
    {
        #region Methods

        public static void AddUser(User user)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_AddUser", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100));
                    cmd.Parameters["@Name"].Value = user.Name;
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        #endregion
    }
}