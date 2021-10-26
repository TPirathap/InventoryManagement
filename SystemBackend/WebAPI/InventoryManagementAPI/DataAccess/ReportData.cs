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
    public class ReportData : ReportProvider
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();
        public List<Purchase> GetPurchaseReport(DateTime startDate)
        {
            List<Purchase> purchaseReport = new List<Purchase>();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DailyPurchaseReport";
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                cmd.Connection = con;
                con.Open();
                using (System.Data.IDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        Purchase purchase = new Purchase();
                        purchase.PurchaseID = data.GetInt32(0);
                        purchase.ProductName = data["ProductName"].ToString();
                        purchase.PurchaseDate = data["PurchaseDate"].ToString();
                        purchase.ReceiveQuantity = data["ReceiveQuantity"].ToString();
                        purchase.SupplierFirstName = data["SupplierFirstName"].ToString();
                        purchase.SupplierLastName = data["SupplierLastName"].ToString();
                        purchaseReport.Add(purchase);
                    }
                    return purchaseReport;
                }
                con.Close();
            }
            catch
            {
                return null;
            }
        }
        public List<Order> GetOrdereReport(DateTime startDate)
        {
            List<Order> orderReport = new List<Order>();
            try
            {
                var cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DailyOrderReport";
                cmd.Parameters.Add("@startDate", SqlDbType.Date).Value = startDate;
                cmd.Connection = con;
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
                        orderReport.Add(order);
                    }
                    return orderReport;
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