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
using searchworks.client.Helpers;
using Microsoft.AspNet.Identity;
using searchworks.client.DAL;

namespace searchworks.client.Controllers

{
    [Authorize]
    public class UserManagementController : Controller
    {
        private JCredDBContextEntities db = new JCredDBContextEntities();
        private JCredDBContext vcontext;// = new JCredDBContext();
        private OrgUnitRepository orgUnitRep;// = new OrgUnitRepository(vcontext);

        public UserManagementController()
        {
            vcontext = new JCredDBContext();
            orgUnitRep = new OrgUnitRepository(vcontext);
        }
        public ActionResult UserManagementHome()
        {

            

            string strUserGUID =  User.Identity.GetUserId();
            int tenantID = -1;
            tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

            UserManagementViewModel userManagementViewModel = new UserManagementViewModel(tenantID);
        
            
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

        [HttpGet]
        public ActionResult AddOrgUnit()
        {
            string strUserGUID = User.Identity.GetUserId();
            int tenantID = -1;
            tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

            UserManagementViewModel userManagementViewModel = new UserManagementViewModel(tenantID);

            return View(userManagementViewModel.orgunit);
        }
            

            // POST: DAL/Orgunit    
            [HttpPost]
        public ActionResult AddOrgUnit(orgunit orgunit)
        {
            string strUserGUID = User.Identity.GetUserId();
            int tenantID = -1;
            tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

            try
            {
                if (ModelState.IsValid)
                {

                     
                 
                   orgUnitRep.InsertOrgUnit(orgunit, tenantID);

                  
                        ViewBag.Message = "Branch added successfully";
                    
                }

                return RedirectToAction("UserManagementHome"); ;
            }
            catch
            {
                return View("");
            }
        }

        [HttpGet]
        public ActionResult EditOrgUnit(int id)
        {
            
            string strUserGUID = User.Identity.GetUserId();
            int tenantID = -1;
            tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

            UserManagementViewModel userManagementViewModel = new UserManagementViewModel(tenantID);
            userManagementViewModel.orgunit = orgUnitRep.GetOrgUnitByID(id);
            return View(userManagementViewModel.orgunit);
        }


        // POST: DAL/Orgunit    
        [HttpPost]
        public ActionResult EditOrgUnit(orgunit vorgunit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orgUnitRep.UpdateOrgUnit(vorgunit);

                    ViewBag.Message = "Branch details updated successfully";
                }

                return RedirectToAction("UserManagementHome");
            }
            catch
            {
                return PartialView();
            }
        }


        [HttpGet]
        public ActionResult AddOrgUnitUser()
        {
            List<string> testlist = new List<string>();
            testlist.Add("test 1");
            testlist.Add("test 2");
            testlist.Add("test 3");

            OrgUnitUser orgunituser = new OrgUnitUser();

            string strUserGUID = User.Identity.GetUserId();
            int tenantID = -1;
            tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

            orgunituser.orgunits = testlist;

            //orgunituser.orgunits = (IEnumerable<string>)orgUnitRep.GetOrgUnits(tenantID);


            return View(orgunituser);
        }


        // POST: DAL/Orgunit    
        [HttpPost]
        public ActionResult AddOrgUnitUser(OrgUnitUser orgunituser)
        {
            string strUserGUID = User.Identity.GetUserId();
            int tenantID = -1;
            tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

            try
            {
                if (ModelState.IsValid)
                {

                    ViewBag.Message = "Org unit user  added successfully";

                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        [HttpGet]
        public ActionResult EditOrgUnitUser(int id)
        {
            List<string> testlist = new List<string>();
            testlist.Add("test 1");
            testlist.Add("test 2");
            testlist.Add("test 3");


            string strUserGUID = User.Identity.GetUserId();
            int tenantID = -1;
            tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

            UserManagementViewModel userManagementViewModel = new UserManagementViewModel(tenantID);
            // userManagementViewModel.Currentorgunituser = orgUnitRep.GetOrgUnitByID(id);

            userManagementViewModel.Currentorgunituser.orgunits = testlist;
            return View(userManagementViewModel.Currentorgunituser);
        }


        // POST: DAL/Orgunit    
        [HttpPost]
        public ActionResult EditOrgUnitUser(orgunit vorgunit)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    orgUnitRep.UpdateOrgUnit(vorgunit);

                    ViewBag.Message = "Branch details updated successfully";
                }

                return RedirectToAction("UserManagementHome");
            }
            catch
            {
                return PartialView();
            }
        }

    }
}