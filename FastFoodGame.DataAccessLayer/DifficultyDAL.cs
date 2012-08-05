using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FastFoodGame.Framework;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace FastFoodGame.DataAccessLayer
{
    public class DifficultyDAL
    {
        #region Methods

        public static void AddDiffuculty(Difficulty difficulty)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_AddDifficulty", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100));
                    cmd.Parameters["@Name"].Value = difficulty.Name;
                    cmd.Parameters.Add(new SqlParameter("@MaxNumberOfSandwiches", SqlDbType.Int));
                    cmd.Parameters["@MaxNumberOfSandwiches"].Value = difficulty.MaxNumberOfSandwiches;
                    cmd.Parameters.Add(new SqlParameter("@MinNumberOfSandwiches", SqlDbType.Int));
                    cmd.Parameters["@MinNumberOfSandwiches"].Value = difficulty.MinNumberOfSandwiches;
                    cmd.Parameters.Add(new SqlParameter("@MaxTimeBetweenOrders", SqlDbType.Int));
                    cmd.Parameters["@MaxTimeBetweenOrders"].Value = difficulty.MaxTimeBetweenOrders;
                    cmd.Parameters.Add(new SqlParameter("@MinTimeBetweenOrders", SqlDbType.Int));
                    cmd.Parameters["@MinTimeBetweenOrders"].Value = difficulty.MinTimeBetweenOrders;

                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EditDiffuculty(Difficulty difficulty)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_EditDifficulty", conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int, 100));
                    cmd.Parameters["@Id"].Value = difficulty.Id;
                    cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100));
                    cmd.Parameters["@Name"].Value = difficulty.Name;
                    cmd.Parameters.Add(new SqlParameter("@MaxNumberOfSandwiches", SqlDbType.Int));
                    cmd.Parameters["@MaxNumberOfSandwiches"].Value = difficulty.MaxNumberOfSandwiches;
                    cmd.Parameters.Add(new SqlParameter("@MinNumberOfSandwiches", SqlDbType.Int));
                    cmd.Parameters["@MinNumberOfSandwiches"].Value = difficulty.MinNumberOfSandwiches;
                    cmd.Parameters.Add(new SqlParameter("@MaxTimeBetweenOrders", SqlDbType.Int));
                    cmd.Parameters["@MaxTimeBetweenOrders"].Value = difficulty.MaxTimeBetweenOrders;
                    cmd.Parameters.Add(new SqlParameter("@MinTimeBetweenOrders", SqlDbType.Int));
                    cmd.Parameters["@MinTimeBetweenOrders"].Value = difficulty.MinTimeBetweenOrders;

                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Difficulty> GetAllDifficulties()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_GetAllDifficulties", conn))
                {
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return null;
                        }

                        var difficulties = new List<Difficulty>();
                        while (reader.Read())
                        {
                            difficulties.Add(new Difficulty
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                MaxNumberOfSandwiches = Convert.ToInt32(reader["MaxNumberOfSandwiches"].ToString()),
                                MinNumberOfSandwiches = Convert.ToInt32(reader["MinNumberOfSandwiches"].ToString()),
                                MaxTimeBetweenOrders = Convert.ToInt32(reader["MaxTimeBetweenOrders"].ToString()),
                                MinTimeBetweenOrders = Convert.ToInt32(reader["MinTimeBetweenOrders"].ToString())
                            });
                        }

                        return difficulties;
                    }
                }
            }
        }

        #endregion
    }
}
