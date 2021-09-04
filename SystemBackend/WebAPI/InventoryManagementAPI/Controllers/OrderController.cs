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
    public class OrderController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();

        public HttpResponseMessage Get()
        {
            string query = "SELECT * FROM Order";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        /*[HttpGet]
        [Route("api/Order/GetOrderProductDetails")]
        public HttpResponseMessage GetProductDetails()
        {
            string query = "SELECT ProductID, ProductName FROM Product";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }*/

        public string Post(Order order)
        {
            try
            {
                string query = @"INSERT INTO Order 
                                VALUES('" + order.ProductID + @"',
                                        '" + order.InvoiceNo + @"',
                                        '" + order.OrderDate + @"',
                                        '" + order.ShippedQuantity + @"',
                                        '" + order.TotalAmount + @"',
                                        '" + order.CustomerFirstName + @"',
                                        '" + order.CustomerLastName + @"')";

                var cmd = new SqlCommand(query, con);
                var data = new SqlDataAdapter(cmd);
                {
                    cmd.CommandType = CommandType.Text;
                    data.Fill(table);
                }
                return "Add Successfully!!";
            }

            catch
            {
                return "Failed to Add!!";
            }
        }
    }
}
