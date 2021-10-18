using InventoryManagementAPI.DataAccess;
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
        PurchaseData purchaseDataAccess;
        public PurchaseController()
        {
            this.purchaseDataAccess = new PurchaseData();
        }
        public HttpResponseMessage Get()
        {
            var purchaseDetails = purchaseDataAccess.GetPurchase();
            return Request.CreateResponse(HttpStatusCode.OK, purchaseDetails);
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
            var purchaseDetails = purchaseDataAccess.StorePurchase(purchase);
            return purchaseDetails;
        }

        public string Put(Purchase purchase)
        {
            if (purchase.PurchaseID != null)
            {
                var purchaseDetails = purchaseDataAccess.ModifyPurchase(purchase);
                return purchaseDetails;
            }
            else
            {
                return "Some data are missing!!";
            }
            
        }
    }
}
