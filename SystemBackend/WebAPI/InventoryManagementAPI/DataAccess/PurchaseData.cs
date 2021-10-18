using InventoryManagementAPI.Models;
using InventoryManagementAPI.Models.Provider;
using System.Data.SqlClient;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace InventoryManagementAPI.DataAccess
{
    public class PurchaseData : PurchaseProvider
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        DataTable table = new DataTable();

        public List<Purchase> GetPurchase()
        {
            List<Purchase> purchaseList = new List<Purchase>();
            try
            {
                string query = @"SELECT Purchase.*, Product.ProductName
                            FROM Purchase
                            INNER JOIN Product ON Product.ProductID=Purchase.ProductID";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (System.Data.IDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        Purchase purchase = new Purchase();
                        purchase.ProductID = data.GetInt32(0);
                        purchase.PurchaseID = data.GetInt32(1);
                        purchase.PurchaseDate = data["PurchaseDate"].ToString();
                        purchase.ReceiveQuantity = data["ReceiveQuantity"].ToString();
                        purchase.SupplierFirstName = data["SupplierFirstName"].ToString();
                        purchase.SupplierLastName = data["SupplierLastName"].ToString();
                        purchaseList.Add(purchase);
                    }
                    return purchaseList;
                }
                con.Close();
            }
            catch
            {
                return null;
            }
        }
        public string StorePurchase(Purchase purchase)
        {
            var statusDetails = "Active";
            try
            {
                string query = @"INSERT INTO Purchase 
                                VALUES('" + purchase.ProductID + @"',
                                        '" + purchase.PurchaseDate + @"',
                                        '" + purchase.ReceiveQuantity + @"',
                                        '" + purchase.SupplierFirstName + @"',
                                        '" + purchase.SupplierLastName + @"',
                                        '" + statusDetails + @"')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                IDataReader data = cmd.ExecuteReader();
                {
                    return "Add Successfully!!";
                }

            }
            catch
            {
                return "Failed to Add!!";
            }
        }
        public string ModifyPurchase(Purchase purchase)
        {
            var statusDetails = "Deleted";
            try
            {
                string query = @"UPDATE Purchase SET 
                                StatusDetail='" + statusDetails + @"'
                                WHERE PurchaseID='" + purchase.PurchaseID + @"'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                IDataReader data = cmd.ExecuteReader();
                return "Delete Successfully!!";
            }
            catch
            {
                return "Failed to Delete!!";
            }
        }
    }
}