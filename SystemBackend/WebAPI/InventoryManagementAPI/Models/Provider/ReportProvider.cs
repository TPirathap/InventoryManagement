using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Provider
{
    interface ReportProvider
    {
        List<Purchase> GetPurchaseReport(DateTime startDate);
        List<Order> GetOrdereReport(DateTime startDate);
    }
}
