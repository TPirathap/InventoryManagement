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
    public class ReportController : ApiController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();

        //this api use to get purchase details specific date
        [HttpGet]
        [Route("api/Report/GetPurchaseDetails/{startDate}")]
        public HttpResponseMessage GetPurchaseReport(DateTime startDate)
        {
            /*string query = @"SELECT Purchase.*, Product.ProductName
                            FROM Purchase
                            INNER JOIN Product ON Product.ProductID=Purchase.ProductID
                            WHERE PurchaseDate='" + startDate + "'";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }*/

            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DailyPurchaseReport";
            cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
            cmd.Connection = con;
            var data = new SqlDataAdapter(cmd);
            data.Fill(table);

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        //this api use to get Order details specific date
        [HttpGet]
        [Route("api/Report/GetOrderDetails/{startDate}")]
        public HttpResponseMessage GetOrdereReport(DateTime startDate)
        {
            var cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DailyOrderReport";
            cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
            cmd.Connection = con;
            var data = new SqlDataAdapter(cmd);
            data.Fill(table);

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}
