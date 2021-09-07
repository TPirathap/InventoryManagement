using InventoryManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryManagementAPI.Controllers
{
    public class ProductController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();

        public HttpResponseMessage Get()
        {
            string query = "SELECT * FROM Product";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        //this api use to product edit page
        [HttpGet]
        [Route("api/Product/GetProductDetails/{productId}")]
        public HttpResponseMessage GetProductDetails(int productId)
        {
            string query = "SELECT * FROM Product WHERE ProductID='" + productId + "'";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        //this api use to purchase and order page
        [HttpGet]
        [Route("api/Product/GetProduct")]
        public HttpResponseMessage GetProduct()
        {
            string query = "SELECT ProductID, ProductName FROM Product";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Product product)
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

                var cmd = new SqlCommand(query, con);
                var data = new SqlDataAdapter(cmd);
                {
                    cmd.CommandType = CommandType.Text;
                    data.Fill(table);
                }
                //table.Clear();
                return "Add Successfully!!";
            }

            catch
            {
                return "Failed to Add!!";
            }
        }

        public string Put(Product product)
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

                    var cmd = new SqlCommand(query, con);
                    var data = new SqlDataAdapter(cmd);
                    {
                        cmd.CommandType = CommandType.Text;
                        data.Fill(table);
                    }
                    return "Update Successfully!!";
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

        public string Delete(int id)
        {
            try
            {
                string query = "DELETE FROM Product WHERE ProductID='" + id + "'";

                var cmd = new SqlCommand(query, con);
                var data = new SqlDataAdapter(cmd);
                {
                    cmd.CommandType = CommandType.Text;
                    data.Fill(table);
                }
                return "Delete Successfully!!";
            }

            catch
            {
                return "Failed to Delete!!";
            }
        }
    }
}
