using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementAPI.Models
{
    public class Purchase
    {
        public int PurchaseID { get; set; }
        public int ProductID { get; set; }
        public string PurchaseDate { get; set; }
        public string ReceiveQuantity { get; set; }
        public string SupplierFirstName { get; set; }
        public string SupplierLastName { get; set; }
    }
}