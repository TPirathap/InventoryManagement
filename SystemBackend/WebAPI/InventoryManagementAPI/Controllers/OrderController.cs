using InventoryManagementAPI.DataAccess;
using InventoryManagementAPI.Logic;
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
        OrderData orderDataAccess;
        CalculateStock orderLogic;
        public OrderController()
        {
            this.orderDataAccess = new OrderData();
            this.orderLogic = new CalculateStock();
        }

        public HttpResponseMessage Get()
        {
            var orderDetails = orderDataAccess.GetOrder();
            return Request.CreateResponse(HttpStatusCode.OK, orderDetails);
        }

        //this api use to get order details and product in stock
        [HttpGet]
        [Route("api/Order/GetAllOrder")]
        public HttpResponseMessage GetOrder()
        {
            var orderDetails = orderLogic.CountStock();
            return Request.CreateResponse(HttpStatusCode.OK, orderDetails);
        }

        public string Post(Order order)
        {
            var orderDetails = orderDataAccess.StoreOrder(order);
            return orderDetails;
        }

        public string Put(Order order)
        {
            if (order.OrderID != null)
            {
                var orderDetails = orderDataAccess.ModifyOrder(order);
                return orderDetails;
            }
            else
            {
                return "Some data are missing!!";
            }
        }
    }
}
