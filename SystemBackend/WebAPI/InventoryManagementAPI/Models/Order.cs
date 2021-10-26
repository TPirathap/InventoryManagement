using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementAPI.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderDate { get; set; }
        public string ShippedQuantity { get; set; }
        public string TotalAmount { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string StatusDetail { get; set; }
        public int InStock { get; set; }
    }

    public class FindStock
    {
        public int OrderID { get; set; }
        public string ProductName { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderDate { get; set; }
        public int ShippedQuantity { get; set; }
        public string TotalAmount { get; set; }
        public int orderShippedQuantity { get; set; }
        public int productsStartInventory { get; set; }
        public int totalPurchaseProducts { get; set; }
        public int InStock { get; set; }
    }
}