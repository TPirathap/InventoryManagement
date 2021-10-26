using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Provider
{
    interface OrderProvider
    {
        List<Order> GetOrder();
        List<FindStock> GetAllOrders();
        string StoreOrder(Order order);
        string ModifyOrder(Order order);
    }
}
