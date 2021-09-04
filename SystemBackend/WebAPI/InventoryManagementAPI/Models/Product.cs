using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementAPI.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public string Label { get; set; }
        public string StartInventory { get; set; }
        public string MinimumInventory { get; set; }
        public string UnitPrice { get; set; }
        public string SellPrice { get; set; }
    }
}