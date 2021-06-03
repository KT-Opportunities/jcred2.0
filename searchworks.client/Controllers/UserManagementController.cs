using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;
using searchworks.client.Models;
using searchworks.client.Credit;

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

            List<string> thatlist = new List<string>();
            var cmd2 = new MySqlCommand(query_uid, conn);
            var reader2 = cmd2.ExecuteReader();

            System.Collections.Generic.List<SearchHistoryModel> arrObjects = new System.Collections.Generic.List<SearchHistoryModel>();
            int searchID = reader2.GetOrdinal("searchID");
            int searchUserName = reader2.GetOrdinal("searchUserName");
            int searchType = reader2.GetOrdinal("searchType");
            int searchDescription = reader2.GetOrdinal("searchDescription");
            int ResponseType = reader2.GetOrdinal("ResponseType");
            int Reference = reader2.GetOrdinal("Reference");
            int Name = reader2.GetOrdinal("Name");
            int reportDate = reader2.GetOrdinal("reportDate");
            int callerMOdule = reader2.GetOrdinal("callerMOdule");
            if (reader2.Read())
            {
                while (reader2.Read())
                {
                    SearchHistoryModel obj = new SearchHistoryModel();

                    obj.searchType = (reader2[searchType] != Convert.DBNull) ? reader2[searchType].ToString() : null;
                    obj.searchDescription = (reader2[searchDescription] != Convert.DBNull) ? reader2[searchDescription].ToString() : null;
                    obj.ResponseType = (reader2[ResponseType] != Convert.DBNull) ? reader2[ResponseType].ToString() : null;
                    obj.reference = (reader2[Reference] != Convert.DBNull) ? reader2[Reference].ToString() : null;
                    obj.Name = (reader2[Name] != Convert.DBNull) ? reader2[Name].ToString() : null;
                    obj.reportDate = (reader2[reportDate] != Convert.DBNull) ? reader2[reportDate].ToString() : null;
                    obj.callerModule = (reader2[callerMOdule] != Convert.DBNull) ? reader2[callerMOdule].ToString() : null;
                    arrObjects.Add(obj);
                }

                ViewData["ArrayList"] = arrObjects;

                conn.Close();
                return View();
            }
            else
            {
                TempData["Message"] = "Error Occured!";
                conn.Close();
                return View();
            }
        }
    }
}