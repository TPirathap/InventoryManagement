using InventoryManagementAPI.Models;
using InventoryManagementAPI.Models.Provider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace InventoryManagementAPI.DataAccess
{
    public class ProductData : ProductsProvider
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();
        public List<Product> GetProduct()
        {
            List<Product> productList = new List<Product>();
            try
            {
                string query = "SELECT * FROM Product";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (System.Data.IDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        Product product = new Product();
                        product.ProductID = data.GetInt32(0);
                        product.ProductName = data["ProductName"].ToString();
                        product.BrandName = data["BrandName"].ToString();
                        product.Label = data["Label"].ToString();
                        product.StartInventory = data["StartInventory"].ToString();
                        product.MinimumInventory = data["MinimumInventory"].ToString();
                        product.UnitPrice = data["UnitPrice"].ToString();
                        product.SellPrice = data["SellPrice"].ToString();
                        productList.Add(product);
                    }
                    return productList;
                }
                con.Close();
            }
            catch
            {
                return null;
            }
        }
        public List<Product> GetProductById(int productId)
        {
            List<Product> productList = new List<Product>();
            try
            {
                string query = "SELECT * FROM Product WHERE ProductID='" + productId + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (System.Data.IDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        Product product = new Product();
                        product.ProductID = data.GetInt32(0);
                        product.ProductName = data["ProductName"].ToString();
                        product.BrandName = data["BrandName"].ToString();
                        product.Label = data["Label"].ToString();
                        product.StartInventory = data["StartInventory"].ToString();
                        product.MinimumInventory = data["MinimumInventory"].ToString();
                        product.UnitPrice = data["UnitPrice"].ToString();
                        product.SellPrice = data["SellPrice"].ToString();
                        productList.Add(product);
                    }
                    return productList;
                }
                con.Close();
            }
            catch
            {
                return null;
            }
        }
        public string StoreProduct(Product product)
        {
            try
            {
                string query = @"INSERT INTO Product 
                                VALUES('" + product.ProductName + @"',
                                        '" + product.BrandName + @"',
                                        '" + product.Label + @"',
                                        '" + product.StartInventory + @"',
                                        '" + product.MinimumInventory + @"',
                                        '" + product.UnitPrice + @"',
                                        '" + product.SellPrice + @"')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                IDataReader data = cmd.ExecuteReader();
                {
                    return "Add Successfully!!";
                }
                
            }

            catch
            {
                return "Failed to Add!!";
            }
        }
        public string ModifyProduct(Product product)
        {
            if (product.ProductID != null)
            {
                try
                {
                    string query = @"UPDATE Product SET 
                                ProductName='" + product.ProductName + @"', 
                                BrandName='" + product.BrandName + @"', 
                                Label='" + product.Label + @"', 
                                StartInventory='" + product.StartInventory + @"', 
                                MinimumInventory='" + product.MinimumInventory + @"', 
                                UnitPrice='" + product.UnitPrice + @"', 
                                SellPrice='" + product.SellPrice + @"'
                                WHERE ProductID='" + product.ProductID + @"'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    IDataReader data = cmd.ExecuteReader();
                    {
                        return "Update Successfully!!";
                    }
                }

                catch
                {
                    return "Failed to Update!!";
                }
            }
            else
            {
                return "Some data are missing!!";
            }
        }
        public string DeleteProduct(int id)
        {
            try
            {
                string query = "DELETE FROM Product WHERE ProductID='" + id + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                IDataReader data = cmd.ExecuteReader();
                {
                    return "Delete Successfully!!";
                }
            }

            catch
            {
                return "Failed to Delete!!";
            }
        }
    }

}