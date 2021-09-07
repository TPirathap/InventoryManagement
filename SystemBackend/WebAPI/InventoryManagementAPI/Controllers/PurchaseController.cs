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
            string query = @"SELECT Purchase.*, Product.ProductName
                            FROM Purchase
                            INNER JOIN Product ON Product.ProductID=Purchase.ProductID";
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
            var statusDetails = "Active";
            try
            {
                string query = @"INSERT INTO Purchase 
                                VALUES('" + purchase.ProductID + @"',
                                        '" + purchase.PurchaseDate + @"',
                                        '" + purchase.ReceiveQuantity + @"',
                                        '" + purchase.SupplierFirstName + @"',
                                        '" + purchase.SupplierLastName + @"',
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

        public string Put(Purchase purchase)
        {
            var statusDetails = "Deleted";
            try
            {
                string query = @"UPDATE Purchase SET 
                                StatusDetail='" + statusDetails + @"'
                                WHERE PurchaseID='" + purchase.PurchaseID + @"'";

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
