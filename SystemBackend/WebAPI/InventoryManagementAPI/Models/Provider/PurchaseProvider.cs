using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Provider
{
    interface PurchaseProvider
    {
        List<Purchase> GetPurchase();
        string StorePurchase(Purchase purchase);
        string ModifyPurchase(Purchase purchase);
    }
}
