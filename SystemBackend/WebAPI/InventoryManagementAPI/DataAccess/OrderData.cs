using InventoryManagementAPI.Logic;
using InventoryManagementAPI.Models;
using InventoryManagementAPI.Models.Provider;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementAPI.DataAccess
{
    public class OrderData : OrderProvider
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();

        public List<Order> GetOrder() 
        {
            List<Order> orderList = new List<Order>();
            try
            {
                string query = @"SELECT Orders.*, Product.ProductName
                            FROM Orders
                            INNER JOIN Product ON Product.ProductID=Orders.ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (System.Data.IDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        Order order = new Order();
                        order.OrderID = data.GetInt32(0);
                        order.ProductName = data["ProductName"].ToString();
                        order.InvoiceNo = data["InvoiceNo"].ToString();
                        order.OrderDate = data["OrderDate"].ToString();
                        order.ShippedQuantity = data["ShippedQuantity"].ToString();
                        order.TotalAmount = data["TotalAmount"].ToString();
                        order.CustomerFirstName = data["CustomerFirstName"].ToString();
                        order.CustomerLastName = data["CustomerLastName"].ToString();
                        order.StatusDetail = data["StatusDetail"].ToString();
                        orderList.Add(order);
                    }
                    return orderList;
                }
                con.Close();
            }
            catch
            {
                return null;
            }
        }
        public string StoreOrder(Order order) 
        {
            var statusDetails = "Active";
            try
            {
                string query = @"INSERT INTO Orders 
                                VALUES('" + order.ProductID + @"',
                                        '" + order.InvoiceNo + @"',
                                        '" + order.OrderDate + @"',
                                        '" + order.ShippedQuantity + @"',
                                        '" + order.TotalAmount + @"',
                                        '" + order.CustomerFirstName + @"',
                                        '" + order.CustomerLastName + @"',
                                        '" + statusDetails + @"')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                var data = new SqlDataAdapter(cmd);
                {
                    data.Fill(table);
                    return "Add Successfully!!";
                }
            }

            catch
            {
                return "Failed to Add!!";
            }
        }
        public string ModifyOrder(Order order)
        {
            var statusDetails = "Deleted";
            try
            {
                string query = @"UPDATE Orders SET 
                            StatusDetail='" + statusDetails + @"'
                            WHERE OrderID='" + order.OrderID + @"'";

                var cmd = new SqlCommand(query, con);
                var data = new SqlDataAdapter(cmd);
                {
                    data.Fill(table);
                    return "Delete Successfully!!";
                }
            }
            catch
            {
                return "Failed to Delete!!";
            }
        }
        public List<FindStock> GetAllOrders()
        {
            List<FindStock> orderList = new List<FindStock>();
            try
            {
                string query = @"SELECT Orders.*, Product.ProductName, Product.StartInventory, Purchase.totalPurchaseProduct
                                FROM Orders
                                LEFT JOIN(
                                        SELECT ProductID,ProductName,StartInventory FROM Product
                                        ) Product ON Product.ProductID=Orders.ProductID
	                            LEFT JOIN(
                                        SELECT ProductID,SUM(CONVERT(int,ReceiveQuantity)) As totalPurchaseProduct FROM Purchase GROUP BY ProductID
                                        ) Purchase ON Purchase.ProductID=Orders.ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (System.Data.IDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        FindStock order = new FindStock();
                        order.OrderID = data.GetInt32(0);
                        order.ProductName = data["ProductName"].ToString();
                        order.InvoiceNo = data["InvoiceNo"].ToString();
                        order.OrderDate = data["OrderDate"].ToString();
                        order.ShippedQuantity = Int32.Parse(data["ShippedQuantity"].ToString());
                        order.TotalAmount = data["TotalAmount"].ToString();
                        order.orderShippedQuantity = Int32.Parse(data["ShippedQuantity"].ToString());
                        order.productsStartInventory = Int32.Parse(data["StartInventory"].ToString());
                        order.totalPurchaseProducts = Int32.Parse(data["totalPurchaseProduct"].ToString());
                   
                        orderList.Add(order);
                    }
                    return orderList;
                }
                con.Close();
            }
            catch
            {
                return null;
            }
        }
    }
}