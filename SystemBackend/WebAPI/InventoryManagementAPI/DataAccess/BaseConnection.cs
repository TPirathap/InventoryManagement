using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InventoryManagementAPI.DataAccess
{
    public class BaseConnection
    {
        public static string connection;
        public BaseConnection()
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["InventoryManagement"].ConnectionString);
        }
    }
}