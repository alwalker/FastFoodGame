using FastFoodGame.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodGame.DataAccessLayer
{
    public class IngredientDAL
    {
        public static void AddIngredient(Ingredient ingredient)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_AddIngredient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = ingredient.Name;
                    cmd.Parameters.Add("@SingleContainerCapacity", SqlDbType.Int).Value = ingredient.SingleContainerCapacity;
                    cmd.Parameters.Add("@LifeSpan", SqlDbType.Int).Value = ingredient.LifeSpan;
                    cmd.Parameters.Add("@ContainerRefilTime", SqlDbType.Int).Value = ingredient.ContainerRefilTime;
                    cmd.Parameters.Add("@Type", SqlDbType.Int).Value = (int)ingredient.Type;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void EditIngredient(Ingredient ingredient)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_EditIngredient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = ingredient.Id;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = ingredient.Name;
                    cmd.Parameters.Add("@SingleContainerCapacity", SqlDbType.Int).Value = ingredient.SingleContainerCapacity;
                    cmd.Parameters.Add("@LifeSpan", SqlDbType.Int).Value = ingredient.LifeSpan;
                    cmd.Parameters.Add("@ContainerRefilTime", SqlDbType.Int).Value = ingredient.ContainerRefilTime;
                    cmd.Parameters.Add("@Type", SqlDbType.Int).Value = (int)ingredient.Type;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static List<Ingredient> GetAllIngredients()
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
            {
                using (var cmd = new SqlCommand("usp_GetAllIngredients", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            return null;
                        }

                        var ingredients = new List<Ingredient>();
                        while (reader.Read())
                        {
                            ingredients.Add(new Ingredient
                            {
                                Id = Convert.ToInt32(reader["Id"].ToString()),
                                Name = reader["Name"].ToString(),
                                SingleContainerCapacity = Convert.ToInt32(reader["SingleContainerCapacity"].ToString()),
                                LifeSpan = Convert.ToInt32(reader["LifeSpan"].ToString()),
                                ContainerRefilTime = Convert.ToInt32(reader["ContainerRefileTime"].ToString()),
                                Type = (Ingredient.IngredientType)Convert.ToInt32(reader["Type"].ToString())
                            });
                        }

                        return ingredients;
                    }
                }
            }
        }
    }
}
