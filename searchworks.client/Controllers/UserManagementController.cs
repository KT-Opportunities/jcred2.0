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
using Dapper;
using System.Data;

namespace searchworks.client.Controllers

{
    public class UserManagementController : Controller
    {
        JCredDBContextEntities db = new JCredDBContextEntities();
        public ActionResult UserManagementHome()
        {
            UserManagementViewModel userManagementViewModel = new UserManagementViewModel(2);
            /*
            userManagementViewModel.Company = db.orgtenants.Where(a => a.orgtenantid == 2).Single();
            var companyOrgUnits   = from s in db.orgunits
                                    where s.orgtenantid == userManagementViewModel.Company.orgtenantid
                                    select s;
            userManagementViewModel.orgunits = companyOrgUnits.ToList<orgunit>();
            */

            /*
            using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString))
            {
                userManagementViewModel.Company  = db.Query<orgtenant>("Select * From orgtenant where orgtenantid=2").FirstOrDefault();
                userManagementViewModel.orgunits = db.Query<orgunit>("Select * From orgunit where orgtenantid="+ userManagementViewModel.Company.orgtenantid).ToList();
            }
            */

                return View(userManagementViewModel);
        }

        public ActionResult SearchHistory()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            string query_uid = "SELECT * FROM searchhistory";

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);
            var reader2 = cmd2.ExecuteReader();

            System.Collections.Generic.List<SearchHistoryModel> arrObjects = new System.Collections.Generic.List<SearchHistoryModel>();
            int SearchToken = reader2.GetOrdinal("SearchToken");
            int Reference = reader2.GetOrdinal("Reference");
            int SearchID = reader2.GetOrdinal("SearchID");
            int SearchUserName = reader2.GetOrdinal("SearchUserName");
            int SearchType = reader2.GetOrdinal("SearchType");
            int SearchDescription = reader2.GetOrdinal("SearchDescription");
            int ResponseType = reader2.GetOrdinal("ResponseType");
            int Name = reader2.GetOrdinal("Name");
            int ReportDate = reader2.GetOrdinal("ReportDate");
            int CallerModule = reader2.GetOrdinal("CallerModule");
            int typeOfSearch = reader2.GetOrdinal("typeOfSearch");
            if (reader2.Read())
            {
                while (reader2.Read())
                {
                    SearchHistoryModel obj = new SearchHistoryModel();

                    obj.SearchToken = (reader2[SearchToken] != Convert.DBNull) ? reader2[SearchToken].ToString() : null;
                    obj.SearchID = (reader2[SearchID] != Convert.DBNull) ? reader2[SearchID].ToString() : null;
                    obj.SearchType = (reader2[SearchType] != Convert.DBNull) ? reader2[SearchType].ToString() : null;
                    obj.SearchDescription = (reader2[SearchDescription] != Convert.DBNull) ? reader2[SearchDescription].ToString() : null;
                    obj.ResponseType = (reader2[ResponseType] != Convert.DBNull) ? reader2[ResponseType].ToString() : null;
                    obj.Reference = (reader2[Reference] != Convert.DBNull) ? reader2[Reference].ToString() : null;
                    obj.Name = (reader2[Name] != Convert.DBNull) ? reader2[Name].ToString() : null;
                    obj.ReportDate = (reader2[ReportDate] != Convert.DBNull) ? reader2[ReportDate].ToString() : null;
                    obj.CallerModule = (reader2[CallerModule] != Convert.DBNull) ? reader2[CallerModule].ToString() : null;
                    obj.typeOfSearch = (reader2[typeOfSearch] != Convert.DBNull) ? reader2[typeOfSearch].ToString() : null;

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