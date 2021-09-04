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
    public class PurchaseController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();

        public HttpResponseMessage Get()
        {
            string query = "SELECT * FROM Purchase";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        /*[HttpGet]
        [Route("api/Purchase/GetPurchaseProductDetails")]
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

        public string Post(Purchase purchase)
        {
            try
            {
                string query = @"INSERT INTO Purchase 
                                VALUES('" + purchase.ProductID + @"',
                                        '" + purchase.PurchaseDate + @"',
                                        '" + purchase.ReceiveQuantity + @"',
                                        '" + purchase.SupplierFirstName + @"',
                                        '" + purchase.SupplierLastName + @"')";

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
