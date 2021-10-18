using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementAPI.Models.Provider
{
     interface ProductsProvider
    {
        List<Product> GetProduct();
        List<Product> GetProductById(int productId);
        string StoreProduct(Product product);
        string ModifyProduct(Product product);
        string DeleteProduct(int id);
    }
}
