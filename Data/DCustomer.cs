using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DCustomer
    {
        public static string connectionString = "Data Source=LAB1504-32\\SQLEXPRESS;Initial Catalog=master; User ID=andrito; Password=andrew";

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ListCustomers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) 
                        {
                            while (reader.Read())
                            {
                                customers.Add(new Customer
                                {
                                    CustomerId = (int)reader["customer_id"],
                                    Name = reader["name"].ToString(),
                                    Address = reader["address"].ToString(),
                                    Phone = reader["phone"].ToString(),
                                    Active = (bool)reader["active"],
                                });
                            }
                        }
                    }
                }
                connection.Close();
            }
            return customers;
        }
    }
}
