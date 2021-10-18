using InventoryManagementAPI.Models;
using InventoryManagementAPI.DataAccess;
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
    public class ProductController : ApiController
    {
        ProductData productDataAccess;
        public ProductController()
        {
            this.productDataAccess = new ProductData();
        }

        public HttpResponseMessage Get()
        {
            var productDetails = productDataAccess.GetProduct();
            return Request.CreateResponse(HttpStatusCode.OK, productDetails);
        }

        //this api use to product edit page
        [HttpGet]
        [Route("api/Product/GetProductDetails/{productId}")]
        public HttpResponseMessage GetProductDetails(int productId)
        {
            var getProductDetails = productDataAccess.GetProductById(productId);
            return Request.CreateResponse(HttpStatusCode.OK, getProductDetails);
        }

        //this api use to purchase and order page
        /*[HttpGet]
        [Route("api/Product/GetProduct")]
        public HttpResponseMessage GetProduct()
        {
            string query = "SELECT ProductID, ProductName FROM Product";
            var cmd = new SqlCommand(query, con);
            var data = new SqlDataAdapter(cmd);
            {
                cmd.CommandType = CommandType.Text;
                data.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }*/

        public string Post(Product product)
        {
            var productDetails = productDataAccess.StoreProduct(product);
            return productDetails;
        }

        public string Put(Product product)
        {
            if (product.ProductID != null)
            {
                var productDetails = productDataAccess.ModifyProduct(product);
                return productDetails;
            }
            else
            {
                return "Some data are missing!!";
            }
        }

        public string Delete(int id)
        {
            if (id != null)
            {
                var productDetails = productDataAccess.DeleteProduct(id);
                return productDetails;
            }
            else
            {
                return "Some data are missing!!";
            }
        }
    }
}
