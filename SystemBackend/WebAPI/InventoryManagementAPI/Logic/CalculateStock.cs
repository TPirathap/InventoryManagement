using InventoryManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InventoryManagementAPI.DataAccess;
using InventoryManagementAPI.Models.Provider;

namespace InventoryManagementAPI.Logic
{
    public class CalculateStock
    {
        OrderData orderDataAccess;
        public CalculateStock()
        {
            this.orderDataAccess = new OrderData();
        }
        public List<FindStock> CountStock()
        {
            var getOrderDetails = orderDataAccess.GetAllOrders();

            try
            {
                List<FindStock> orderDetails = new List<FindStock>();
                foreach (var values in getOrderDetails)
                {
                    FindStock order = new FindStock();
                    order.OrderID = values.OrderID;
                    order.ProductName = values.ProductName;
                    order.InvoiceNo = values.InvoiceNo;
                    order.OrderDate = values.OrderDate;
                    order.ShippedQuantity = values.ShippedQuantity;
                    order.TotalAmount = values.TotalAmount;
                    int totalPurchaseProduct = values.productsStartInventory + values.totalPurchaseProducts;
                    int countCurrentStocks = totalPurchaseProduct - values.orderShippedQuantity;
                    order.InStock = countCurrentStocks;

                    orderDetails.Add(order);
                }
                return orderDetails;
            }
            catch
            {
                return null;
            }
            
        }
    }
}