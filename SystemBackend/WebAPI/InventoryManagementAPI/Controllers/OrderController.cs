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
            string query = @"SELECT Orders.*, Product.ProductName
                            FROM Orders
                            INNER JOIN Product ON Product.ProductID=Orders.ProductID";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Order order)
        {
            var statusDetails = "Active";
            try
            {
                string query = @"INSERT INTO Orders 
                                VALUES('" + order.ProductID + @"',
                                        '" + order.InvoiceNo + @"',
                                        '" + order.OrderDate + @"',
                                        '" + order.ShippedQuantity + @"',
                                        '" + order.TotalAmount + @"',
                                        '" + order.CustomerFirstName + @"',
                                        '" + order.CustomerLastName + @"',
                                        '" + statusDetails + @"')";

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

        public string Put(Order order)
        {
            var statusDetails = "Deleted";
            try
            {
                string query = @"UPDATE Orders SET 
                                StatusDetail='" + statusDetails + @"'
                                WHERE OrderID='" + order.OrderID + @"'";

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
