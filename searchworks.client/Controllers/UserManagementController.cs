using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using searchworks.client.Models;

namespace searchworks.client.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult UserManagementHome()
        {
            return View();
        }

        public ActionResult SearchHistory()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            string query_uid = "SELECT * FROM searchhistory";

            conn.Open();

            List<string> searchHistList = new List<string>();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            //if (reader2.Read())
            //{
            //    while (reader2.Read())
            //    {
            //        searchHistList.Add(reader2["searchID"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["searchID"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["searchUserName"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["reportDate"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["reference"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["searchToken"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["callerModule"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["dataSupplier"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["searchType"].ToString());
            //        System.Diagnostics.Debug.WriteLine(reader2["searchDescription"].ToString());
            //    }
            //    conn.Close();
            //    return View();
            //}
            //else
            //{
            //    TempData["Message"] = "Credentials did not match!";
            //    conn.Close();
            //    return View();
            //}
            return View();
        }
    }
}