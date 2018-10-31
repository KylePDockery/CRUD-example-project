using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using System.IO;

namespace CRUDprojectV2
{
    class ProductRepository
    {
        public ProductRepository()
        {
#if DEBUG
            string jsonText = File.ReadAllText("appsettings.development.json");
#else
<<<<<<< HEAD
            string jsonText = File.ReadAllText("appesttings.release.json")
=======
            string jsonText = File.ReadAllText("appsettings.release.json")
>>>>>>> fe1f394c906248ea6f277336e391e58aa7197902
#endif
            string connStr = JObject.Parse(jsonText)["ConnectionStrings"]["DefaultConnection"].ToString();

            this.connStr = connStr;
        }

        private string connStr;

        public void CreateProduct(string name, decimal price, int CategoryID) //create
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "INSERT INTO products (Name, Price, CategoryID) Values (@n , @p, @cID)";
                cmd.Parameters.AddWithValue("n", name);
                cmd.Parameters.AddWithValue("p", price);
                cmd.Parameters.AddWithValue("cID", CategoryID);
                cmd.ExecuteNonQuery();
            }
        }
        public List<Product> ReadCatalogue()//read
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT productid, name, price FROM products";
                MySqlDataReader dr = cmd.ExecuteReader();
                List<Product> products = new List<Product>();

                while (dr.Read())
                {
                    Product product = new Product();
                    product.Name = dr["Name"].ToString();
                    product.CategoryID = (int)dr["productid"];
                    product.Price = (decimal)dr["price"];
                    products.Add(product);
                }

                return products;
            }
        }

        public void UpdateProductPrice(string name, decimal price,int CategoryID) //update
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "UPDATE Products SET Name = @n, Price = @p WHERE CategoryID = @pi";
                cmd.Parameters.AddWithValue("n", name);
                cmd.Parameters.AddWithValue("p", price);
                cmd.Parameters.AddWithValue("pi", CategoryID);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteProductByName(string name) //delete
        {
            MySqlConnection conn = new MySqlConnection(connStr);

            using (conn)
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "DELETE FROM Products WHERE Name = @n;";
                cmd.Parameters.AddWithValue("n", name);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

