using InventoryManagementAPI.DataAccess;
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
        ReportData reportDataAccess;
        public ReportController()
        {
            this.reportDataAccess = new ReportData();
        }

        //this api use to get purchase details specific date
        [HttpGet]
        [Route("api/Report/GetPurchaseDetails/{startDate}")]
        public HttpResponseMessage GetPurchaseReport(DateTime startDate)
        {
            var purchaseReport = reportDataAccess.GetPurchaseReport(startDate);
            return Request.CreateResponse(HttpStatusCode.OK, purchaseReport);
        }

        //this api use to get Order details specific date
        [HttpGet]
        [Route("api/Report/GetOrderDetails/{startDate}")]
        public HttpResponseMessage GetOrdereReport(DateTime startDate)
        {
            var orderReport = reportDataAccess.GetOrdereReport(startDate);
            return Request.CreateResponse(HttpStatusCode.OK, orderReport);
        }
    }
}
