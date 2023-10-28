using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DProduct
    {
        public static string connectionString = "Data Source=LAB1504-32\\SQLEXPRESS;Initial Catalog=master; User ID=andrito; Password=andrew";

        public List<Product> GetAllP()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ListProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                products.Add(new Product
                                {
                                    ProductId = (int)reader["product_id"],
                                    Name = reader["name"].ToString(),
                                    Price = (decimal)reader["price"],
                                    Stock = (int)reader["stock"],
                                    Active = (bool)reader["active"],
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }
            return products;
        }
    }
}
