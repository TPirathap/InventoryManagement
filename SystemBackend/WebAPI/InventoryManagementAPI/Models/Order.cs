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
        public string InvoiceNo { get; set; }
        public string OrderDate { get; set; }
        public string ShippedQuantity { get; set; }
        public string TotalAmount { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
    }
}