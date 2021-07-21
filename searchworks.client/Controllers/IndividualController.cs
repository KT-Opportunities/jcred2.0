using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using searchworks.client.Individual;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Data;
using System.Configuration;
using ServiceStack.Text.Json;
using searchworks.client.Helpers;

namespace searchworks.client.Controllers
{
    [Authorize]
    public class IndividualController : Controller
    {
        public void saveSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic ResponseType, dynamic Name, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO searchhistory (SearchID,searchUserName,ResponseType,Name,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,typeOfSearch) VALUES('" + SearchID + "','" + searchUserName + "','" + ResponseType + "','" + Name + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public RedirectToRouteResult CheckLoginState()
        {
            try
            {
                string user_id = Session["ID"].ToString();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
            return (null);
        }

        public string GetLoginToken(string api_username, string api_password)
        {
            string loginToken = "";
            var userName = api_username;
            var password = api_password;
            var host = "https://uatrest.searchworks.co.za/auth/login/";
            var body_credentials = new
            {
                Username = api_username,
                Password = api_password
            };
            string authBody = "{  \"Username\": \"" + api_username + "\",  \"Password\": \"" + api_password + "\" }";
            var client = new RestClient(host);
            //client.Authenticator = new HttpBasicAuthenticator(userName, password);
            //var request = new RestRequest("login", Method.POST);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");
            //request.AddParameter("application/json", "{}", ParameterType.RequestBody);
            //request.AddParameter("application/json", body_credentials, ParameterType.RequestBody);
            //{  \"Username\": \"uatapi@ktopportunities.co.za\",  \"Password\": \"P@ssw0rd!\" }

            request.AddParameter("application/json", authBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            //return View(members);
            dynamic respContent = JObject.Parse(response.Content);
            loginToken = respContent.ResponseMessage;
            return loginToken;
        }

        public bool tokenValid(string token)
        {
            bool tokenIsValid = true;

            return tokenIsValid;
        }

        public ActionResult CSIPersonalRecords()
        {
            return View();
        }

        public ActionResult CSIPersonalRecordsResults(CSI csi)
        {
            string name = csi.FirstName;
            string sur = csi.Surname;
            string id = csi.IDNumber;
            string seaType = csi.seaType;
            string eqType = csi.eqType;
            string refe = csi.Reference;

            var url = "";
            var client = new RestClient();
            var request = new RestRequest();

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CSI Person " + eqType + "By " + seaType;
            string action = "Name:" + name + "; Surname:" + sur;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

            TempData["user"] = Session["Name"].ToString();
            TempData["date"] = DateTime.Today.ToShortDateString();
            TempData["ref"] = refe;
            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();
            conn.Close();

            JCredHelper jCredHelper = new JCredHelper();

            string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }
            //request headers
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response;
            dynamic rootObject;
            JObject o;
            JToken token;

            try
            {
                switch (seaType + "|" + eqType)
                {
                    case "idnumber|trace":
                        Debug.WriteLine("idnumber|trace");

                        url = jCredHelper.GetSWAPIHostUrl() + "/individual/csipersontrace/idnumber/"; //"https://uatrest.searchworks.co.za/individual/csipersontrace/idnumber/";
                        client = new RestClient(url);
                        request = new RestRequest(Method.POST);
                        var apiIdTrace = new
                        {
                            SessionToken = authtoken,
                            Reference = us,//search reference: probably store in logs
                            IDNumber = id,
                        };
                        request.Parameters.Clear();
                        request.AddParameter("application/json", JsonConvert.SerializeObject(apiIdTrace), ParameterType.RequestBody);
                        request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                        //ApiResponse is a class to model the data we want from the API response
                        //make the API request and get a response
                        response = client.Execute<RootObject>(request);
                        rootObject = JObject.Parse(response.Content);
                        //JObject o = JObject.Parse(response.Content);
                        o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
                        token = JToken.Parse(response.Content);
                        TempData["SearchType"] = seaType;
                        TempData["ResponseMessage"] = rootObject.ResponseMessage;
                        TempData["PDFCopyURL"] = rootObject.PDFCopyURL;
                        TempData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                        TempData["Title"] = rootObject.ResponseObject.PersonInformation.Title;
                        TempData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                        TempData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                        TempData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                        TempData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                        TempData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;
                        TempData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                        TempData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                        TempData["Quality"] = rootObject.ResponseObject.PersonInformation.Quality;
                        TempData.Keep();
                        try
                        {
                            int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                            string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                            string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                            string ResponseType = rootObject.ResponseMessage; ;
                            string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                            string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                            string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                            string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                            string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                            string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                            saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CSIPersonalRecords");
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);

                            ViewData["Message"] = "Error saving to database. ";
                        }
                        return View();

                    case "name|trace":

                        Debug.WriteLine("name|trace");

                        url = jCredHelper.GetSWAPIHostUrl() + "/individual/csipersonrecords/personverification/name/";// "https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/name/";

                        client = new RestClient(url);
                        request = new RestRequest(Method.POST);
                        var apinameTrace = new
                        {
                            sessionToken = authtoken,
                            reference = us,//search reference: probably store in logs
                            firstName = name,
                            surname = sur
                        };
                        //add parameters and token to request
                        request.Parameters.Clear();
                        request.AddParameter("application/json", JsonConvert.SerializeObject(apinameTrace), ParameterType.RequestBody);
                        request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                        //ApiResponse is a class to model the data we want from the API response
                        //make the API request and get a response
                        response = client.Execute<RootObject>(request);
                        rootObject = JObject.Parse(response.Content);
                        o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
                        token = JToken.Parse(response.Content);
                        System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
                        TempData["SearchType"] = seaType;
                        TempData["ResponseMessage"] = rootObject.ResponseMessage;
                        TempData["PDFCopyURL"] = rootObject.PDFCopyURL;
                        TempData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        TempData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                        TempData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        TempData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        TempData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        TempData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        TempData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                        TempData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        TempData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        TempData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                        TempData.Keep();
                        try
                        {
                            int SearchID = rootObject.ResponseObject[0].SearchInformation.SearchID;
                            string SearchUserName = rootObject.ResponseObject[0].SearchInformation.SearchUserName;
                            string ReportDate = rootObject.ResponseObject[0].SearchInformation.ReportDate;
                            string ResponseType = rootObject.ResponseMessage; ;
                            string Reference = rootObject.ResponseObject[0].SearchInformation.Reference;
                            string SearchToken = rootObject.ResponseObject[0].SearchInformation.SearchToken;
                            string CallerModule = rootObject.ResponseObject[0].SearchInformation.CallerModule;
                            string DataSupplier = rootObject.ResponseObject[0].SearchInformation.DataSupplier;
                            string SearchType = rootObject.ResponseObject[0].SearchInformation.SearchType;
                            string SearchDescription = rootObject.ResponseObject[0].SearchInformation.SearchDescription;
                            saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CSIPersonalRecords");
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);

                            ViewData["Message"] = "Error saving to database. ";
                        }
                        return View();

                    case "nameandidnumber|trace":
                        Debug.WriteLine("nameandidnumber|trace");
                        url = jCredHelper.GetSWAPIHostUrl() + "/individual/csipersonrecords/personverification/nameidnumber/"; //"https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/nameidnumber/";
                        client = new RestClient(url);
                        request = new RestRequest(Method.POST);

                        var apinameidTrace = new
                        {
                            sessionToken = authtoken,
                            reference = us,//search reference: probably store in logs
                            idNumber = id,
                            firstName = name,
                            surname = sur
                        };
                        //add parameters and token to request
                        request.Parameters.Clear();
                        request.AddParameter("application/json", JsonConvert.SerializeObject(apinameidTrace), ParameterType.RequestBody);
                        request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                        //ApiResponse is a class to model the data we want from the API response
                        //make the API request and get a response
                        response = client.Execute<RootObject>(request);
                        rootObject = JObject.Parse(response.Content);
                        o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
                        token = JToken.Parse(response.Content);
                        System.Diagnostics.Debug.WriteLine(response.Content);
                        TempData["SearchType"] = seaType;
                        TempData["ResponseMessage"] = rootObject.ResponseMessage;
                        TempData["PDFCopyURL"] = rootObject.PDFCopyURL;
                        TempData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        TempData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                        TempData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        TempData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        TempData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        TempData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        TempData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                        TempData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        TempData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        TempData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                        TempData.Keep();
                        try
                        {
                            int SearchID = rootObject.ResponseObject[0].SearchInformation.SearchID;
                            string SearchUserName = rootObject.ResponseObject[0].SearchInformation.SearchUserName;
                            string ReportDate = rootObject.ResponseObject[0].SearchInformation.ReportDate;
                            string ResponseType = rootObject.ResponseMessage; ;
                            string Reference = rootObject.ResponseObject[0].SearchInformation.Reference;
                            string SearchToken = rootObject.ResponseObject[0].SearchInformation.SearchToken;
                            string CallerModule = rootObject.ResponseObject[0].SearchInformation.CallerModule;
                            string DataSupplier = rootObject.ResponseObject[0].SearchInformation.DataSupplier;
                            string SearchType = rootObject.ResponseObject[0].SearchInformation.SearchType;
                            string SearchDescription = rootObject.ResponseObject[0].SearchInformation.SearchDescription;
                            saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CSIPersonalRecords");
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);

                            ViewData["Message"] = "Error saving to database. ";
                        }
                        return View();

                    case "idnumber|verification":
                        //company search API call
                        url = jCredHelper.GetSWAPIHostUrl() + "/individual/csipersonrecords/personverification/idnumber/"; //"https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/idnumber/";
                        //create RestSharp client and POST request object
                        client = new RestClient(url);
                        request = new RestRequest(Method.POST);
                        //object containing input parameter data for company() API method
                        var apiIdVeri = new
                        {
                            sessionToken = authtoken,
                            reference = us,//search reference: probably store in logs
                            idNumber = id,
                        };
                        //add parameters and token to request
                        request.Parameters.Clear();
                        request.AddParameter("application/json", JsonConvert.SerializeObject(apiIdVeri), ParameterType.RequestBody);
                        request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                        //ApiResponse is a class to model the data we want from the API response
                        //make the API request and get a response
                        response = client.Execute<RootObject>(request);
                        rootObject = JObject.Parse(response.Content);
                        //JObject o = JObject.Parse(response.Content);
                        o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
                        token = JToken.Parse(response.Content);
                        System.Diagnostics.Debug.WriteLine(response.Content);
                        TempData["SearchType"] = seaType;
                        TempData["ResponseMessage"] = rootObject.ResponseMessage;
                        TempData["PDFCopyURL"] = rootObject.PDFCopyURL;
                        TempData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        TempData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                        TempData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        TempData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        TempData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        TempData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        TempData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                        TempData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        TempData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        TempData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                        TempData.Keep();
                        try
                        {
                            int SearchID = rootObject.ResponseObject[0].SearchInformation.SearchID;
                            string SearchUserName = rootObject.ResponseObject[0].SearchInformation.SearchUserName;
                            string ReportDate = rootObject.ResponseObject[0].SearchInformation.ReportDate;
                            string ResponseType = rootObject.ResponseMessage; ;
                            string Reference = rootObject.ResponseObject[0].SearchInformation.Reference;
                            string SearchToken = rootObject.ResponseObject[0].SearchInformation.SearchToken;
                            string CallerModule = rootObject.ResponseObject[0].SearchInformation.CallerModule;
                            string DataSupplier = rootObject.ResponseObject[0].SearchInformation.DataSupplier;
                            string SearchType = rootObject.ResponseObject[0].SearchInformation.SearchType;
                            string SearchDescription = rootObject.ResponseObject[0].SearchInformation.SearchDescription;
                            saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CSIPersonalRecords");
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);

                            ViewData["Message"] = "Error saving to database. ";
                        }
                        return View();

                    case "name|verification":
                        Debug.WriteLine("name|verification");

                        url = jCredHelper.GetSWAPIHostUrl() + "/individual/csipersonrecords/personverification/name/";// "https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/name/";

                        client = new RestClient(url);
                        request = new RestRequest(Method.POST);
                        var apinameVeri = new
                        {
                            sessionToken = authtoken,
                            reference = us,//search reference: probably store in logs
                            firstName = name,
                            surname = sur
                        };
                        //add parameters and token to request
                        request.Parameters.Clear();
                        request.AddParameter("application/json", JsonConvert.SerializeObject(apinameVeri), ParameterType.RequestBody);
                        request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                        //ApiResponse is a class to model the data we want from the API response
                        //make the API request and get a response
                        response = client.Execute<RootObject>(request);
                        rootObject = JObject.Parse(response.Content);
                        o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
                        token = JToken.Parse(response.Content);
                        System.Diagnostics.Debug.WriteLine(response.Content);
                        TempData["SearchType"] = seaType;
                        TempData["ResponseMessage"] = rootObject.ResponseMessage;
                        TempData["PDFCopyURL"] = rootObject.PDFCopyURL;
                        TempData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        TempData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                        TempData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        TempData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        TempData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        TempData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        TempData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                        TempData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        TempData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        TempData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                        TempData.Keep();
                        try
                        {
                            int SearchID = rootObject.ResponseObject[0].SearchInformation.SearchID;
                            string SearchUserName = rootObject.ResponseObject[0].SearchInformation.SearchUserName;
                            string ReportDate = rootObject.ResponseObject[0].SearchInformation.ReportDate;
                            string ResponseType = rootObject.ResponseMessage; ;
                            string Reference = rootObject.ResponseObject[0].SearchInformation.Reference;
                            string SearchToken = rootObject.ResponseObject[0].SearchInformation.SearchToken;
                            string CallerModule = rootObject.ResponseObject[0].SearchInformation.CallerModule;
                            string DataSupplier = rootObject.ResponseObject[0].SearchInformation.DataSupplier;
                            string SearchType = rootObject.ResponseObject[0].SearchInformation.SearchType;
                            string SearchDescription = rootObject.ResponseObject[0].SearchInformation.SearchDescription;
                            saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CSIPersonalRecords");
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);

                            ViewData["Message"] = "Error saving to database. ";
                        }
                        return View();

                    case "nameandidnumber|verification":
                        Debug.WriteLine("nameandidnumber|verification");
                        url = jCredHelper.GetSWAPIHostUrl() + "/individual/csipersonrecords/personverification/nameidnumber/"; //"https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/nameidnumber/";
                        client = new RestClient(url);
                        request = new RestRequest(Method.POST);

                        var apinameidVeri = new
                        {
                            sessionToken = authtoken,
                            reference = us,//search reference: probably store in logs
                            idNumber = id,
                            firstName = name,
                            surname = sur
                        };
                        //add parameters and token to request
                        request.Parameters.Clear();
                        request.AddParameter("application/json", JsonConvert.SerializeObject(apinameidVeri), ParameterType.RequestBody);
                        request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                        //ApiResponse is a class to model the data we want from the API response
                        //make the API request and get a response
                        response = client.Execute<RootObject>(request);
                        rootObject = JObject.Parse(response.Content);
                        o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
                        token = JToken.Parse(response.Content);
                        System.Diagnostics.Debug.WriteLine(response.Content);
                        TempData["SearchType"] = seaType;
                        TempData["ResponseMessage"] = rootObject.ResponseMessage;
                        TempData["PDFCopyURL"] = rootObject.PDFCopyURL;
                        TempData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        TempData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                        TempData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        TempData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        TempData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        TempData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        TempData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                        TempData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        TempData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        TempData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                        TempData.Keep();
                        try
                        {
                            int SearchID = rootObject.ResponseObject[0].SearchInformation.SearchID;
                            string SearchUserName = rootObject.ResponseObject[0].SearchInformation.SearchUserName;
                            string ReportDate = rootObject.ResponseObject[0].SearchInformation.ReportDate;
                            string ResponseType = rootObject.ResponseMessage; ;
                            string Reference = rootObject.ResponseObject[0].SearchInformation.Reference;
                            string SearchToken = rootObject.ResponseObject[0].SearchInformation.SearchToken;
                            string CallerModule = rootObject.ResponseObject[0].SearchInformation.CallerModule;
                            string DataSupplier = rootObject.ResponseObject[0].SearchInformation.DataSupplier;
                            string SearchType = rootObject.ResponseObject[0].SearchInformation.SearchType;
                            string SearchDescription = rootObject.ResponseObject[0].SearchInformation.SearchDescription;
                            saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CSIPersonalRecords");
                        }
                        catch (Exception e)
                        {
                            System.Diagnostics.Debug.WriteLine(e);

                            ViewData["Message"] = "Error saving to database. ";
                        }
                        return View();
                }
            }
            catch (Exception e)
            {
                TempData["msg"] = "An error occured, please check the entered values.";
            }

            return View();
        }

        public ActionResult CSIPersonalRecordsDetails(string indiID)
        {
            JCredHelper jCredHelper = new JCredHelper();
            string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }

            //company search API call
            var url = jCredHelper.GetSWAPIHostUrl() + "/individual/csipersontrace/idnumber/"; //"https://uatrest.searchworks.co.za/individual/csipersontrace/idnumber/";

            //create RestSharp client and POST request object
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            //request headers
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            //object containing input parameter data for company() API method
            var apiInput = new
            {
                SessionToken = authtoken,
                Reference = authtoken,//search reference: probably store in logs
                IDNumber = indiID,
            };

            //add parameters and token to request
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
            //ApiResponse is a class to model the data we want from the API response

            //make the API request and get a response
            IRestResponse response = client.Execute<RootObject>(request);

            dynamic rootObject = JObject.Parse(response.Content);
            //JObject o = JObject.Parse(response.Content);
            Debug.WriteLine(JObject.Parse(response.Content).Count);
            JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

            JToken token = JToken.Parse(response.Content);

            Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JArray totalElements = new Newtonsoft.Json.Linq.JArray();
            Dictionary<string, string> arrayList = new Dictionary<string, string>();
            Dictionary<string, string> arrayList1 = new Dictionary<string, string>();
            List<string> thatlist = new List<string>();
            List<string> thatlist1 = new List<string>();
            Dictionary<int, Dictionary<string, string>> MianArrayList = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<int, Dictionary<string, string>> MianArrayList1 = new Dictionary<int, Dictionary<string, string>>();

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
            ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
            ViewData["Title"] = rootObject.ResponseObject.PersonInformation.Title;
            ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
            ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
            ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
            ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
            ViewData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;
            ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
            ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
            ViewData["Quality"] = rootObject.ResponseObject.PersonInformation.Quality;
            try
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CSIPersonalRecords");
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            JToken HistoricalDataExists = rootObject.ResponseObject["HistoricalInformation"];
            if (HistoricalDataExists != null)
            {
                JToken TelephoneHistoryExists = rootObject.ResponseObject.HistoricalInformation["TelephoneHistory"];
                JToken AddressHistoryExists = rootObject.ResponseObject.HistoricalInformation["AddressHistory"];
                JToken EmploymentHistoryExists = rootObject.ResponseObject.HistoricalInformation["EmploymentHistory"];
                List<TelephoneHistory> telH;
                telH = new List<TelephoneHistory>();
                if (TelephoneHistoryExists != null)

                {
                    elements = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;
                    string TypeDescription = "";
                    string TypeCode = "";
                    string Number = "";
                    string LastUpdatedDate = "";

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        TypeDescription = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        TypeCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeCode;
                        Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number;
                        LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;
                        //string FirstName = rootObject.ResponseObject.Directors[count].FirstName;
                        //string Surname = rootObject.ResponseObject.Directors[count].Surname;
                        //string Fullname = rootObject.ResponseObject.Directors[count].Fullname;
                        //string IdNumber = rootObject.ResponseObject.Directors[count].IdNumber;
                        //string DateOfBirth = rootObject.ResponseObject.Directors[count].DateOfBirth;
                        //string Age = rootObject.ResponseObject.Directors[count].Age;
                        //string StatusCode = rootObject.ResponseObject.Directors[count].StatusCode;
                        //string Status = rootObject.ResponseObject.Directors[count].Status;
                        //string TypeCode = rootObject.ResponseObject.Directors[count].TypeCode;
                        //string Type = rootObject.ResponseObject.Directors[count].Type;
                        //string AppointmentDate = rootObject.ResponseObject.Directors[count].AppointmentDate;
                        //string ResignationDate = rootObject.ResponseObject.Directors[count].ResignationDate;
                        //string MemberContribution = rootObject.ResponseObject.Directors[count].MemberContribution;
                        //string MemberSize = rootObject.ResponseObject.Directors[count].MemberSize;
                        //string ResidentialAddress1 = rootObject.ResponseObject.Directors[count].ResidentialAddress1;
                        //string ResidentialAddress2 = rootObject.ResponseObject.Directors[count].ResidentialAddress2;
                        //string ResidentialAddress3 = rootObject.ResponseObject.Directors[count].ResidentialAddress3;
                        //string ResidentialAddress4 = rootObject.ResponseObject.Directors[count].ResidentialAddress4;
                        //string ResidentialPostCode = rootObject.ResponseObject.Directors[count].ResidentialPostCode;
                        //string PostalAddress1 = rootObject.ResponseObject.Directors[count].PostalAddress1;
                        //string PostalAddress2 = rootObject.ResponseObject.Directors[count].PostalAddress2;
                        //string PostalAddress3 = rootObject.ResponseObject.Directors[count].PostalAddress3;
                        //string PostalAddress4 = rootObject.ResponseObject.Directors[count].PostalAddress4;
                        //string PostalPostCode = rootObject.ResponseObject.Directors[count].PostalPostCode;
                        //string CountryCode = rootObject.ResponseObject.Directors[count].CountryCode;
                        //string Country = rootObject.ResponseObject.Directors[count].Country;
                        //string NationalityCode = rootObject.ResponseObject.Directors[count].NationalityCode;
                        //string Gender = rootObject.ResponseObject.Directors[count].Gender;

                        arrayList.Add(count + "_TypeDescription", TypeDescription);
                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Number", Number);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);

                        telH.Add(new TelephoneHistory
                        {
                            TypeDescription = TypeDescription,
                            TypeCode = TypeCode,
                            Number = Number
                        });

                        //arrayList.Add(count + "_IdNumber", IdNumber);
                        //arrayList.Add(count + "_Age", Age);
                        //arrayList.Add(count + "_Status", Status);
                        //arrayList.Add(count + "_ResignationDate", ResignationDate);
                        ViewData["ArrayList"] = arrayList;
                        ViewData["thatlist"] = thatlist;

                        //System.Diagnostics.Debug.WriteLine(count + " arrayList: " + arrayList);
                        MianArrayList.Add(count, arrayList);
                        //Debug.WriteLine(MianArrayList);
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        ViewData["MianArrayList"] = serializer.Serialize(MianArrayList[0]);
                        //ViewData["MianArrayList"] = MianArrayList;
                        //ViewData["elements"] = elements;

                        //ViewData["elementsType"] = elements;
                        // ViewData["DirectorID"] = DirectorID;
                        //ViewData["FirstName"] = FirstName;
                        //ViewData["Surname"] = Surname;

                        ViewData["telH"] = telH;
                        //System.Diagnostics.Debug.WriteLine(" Director ID "+count+" : "+ DirectorID);
                    }
                    //foreach (KeyValuePair<string, string> item in arrayList)
                    //{
                    //    System.Diagnostics.Debug.WriteLine( item.Key, item.Value);
                    //}
                }
                else
                {
                    telH.Add(new TelephoneHistory
                    {
                        TypeDescription = "None",
                        TypeCode = "None",
                        Number = "None",
                    });
                    ViewData["empH"] = telH;
                }

                List<EmploymentHistory> empH;
                empH = new List<EmploymentHistory>();
                if (EmploymentHistoryExists != null)
                {
                    string EmployerName = "";
                    string Designation = "";
                    string LastUpdatedDate1 = "";

                    elements1 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;

                    for (int count = 0; count < (elements1.Count); count++)
                    {
                        EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation;
                        LastUpdatedDate1 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;
                        //string FirstName = rootObject.ResponseObject.Directors[count].FirstName;
                        //string Surname = rootObject.ResponseObject.Directors[count].Surname;
                        //string Fullname = rootObject.ResponseObject.Directors[count].Fullname;
                        //string IdNumber = rootObject.ResponseObject.Directors[count].IdNumber;
                        //string DateOfBirth = rootObject.ResponseObject.Directors[count].DateOfBirth;
                        //string Age = rootObject.ResponseObject.Directors[count].Age;
                        //string StatusCode = rootObject.ResponseObject.Directors[count].StatusCode;
                        //string Status = rootObject.ResponseObject.Directors[count].Status;
                        //string TypeCode = rootObject.ResponseObject.Directors[count].TypeCode;
                        //string Type = rootObject.ResponseObject.Directors[count].Type;
                        //string AppointmentDate = rootObject.ResponseObject.Directors[count].AppointmentDate;
                        //string ResignationDate = rootObject.ResponseObject.Directors[count].ResignationDate;
                        //string MemberContribution = rootObject.ResponseObject.Directors[count].MemberContribution;
                        //string MemberSize = rootObject.ResponseObject.Directors[count].MemberSize;
                        //string ResidentialAddress1 = rootObject.ResponseObject.Directors[count].ResidentialAddress1;
                        //string ResidentialAddress2 = rootObject.ResponseObject.Directors[count].ResidentialAddress2;
                        //string ResidentialAddress3 = rootObject.ResponseObject.Directors[count].ResidentialAddress3;
                        //string ResidentialAddress4 = rootObject.ResponseObject.Directors[count].ResidentialAddress4;
                        //string ResidentialPostCode = rootObject.ResponseObject.Directors[count].ResidentialPostCode;
                        //string PostalAddress1 = rootObject.ResponseObject.Directors[count].PostalAddress1;
                        //string PostalAddress2 = rootObject.ResponseObject.Directors[count].PostalAddress2;
                        //string PostalAddress3 = rootObject.ResponseObject.Directors[count].PostalAddress3;
                        //string PostalAddress4 = rootObject.ResponseObject.Directors[count].PostalAddress4;
                        //string PostalPostCode = rootObject.ResponseObject.Directors[count].PostalPostCode;
                        //string CountryCode = rootObject.ResponseObject.Directors[count].CountryCode;
                        //string Country = rootObject.ResponseObject.Directors[count].Country;
                        //string NationalityCode = rootObject.ResponseObject.Directors[count].NationalityCode;
                        //string Gender = rootObject.ResponseObject.Directors[count].Gender;

                        arrayList1.Add(count + "_EmployerName", EmployerName);
                        arrayList1.Add(count + "_Designation", Designation);
                        arrayList1.Add(count + "_LastUpdatedDate", LastUpdatedDate1);
                        //arrayList.Add(count + "_IdNumber", IdNumber);
                        //arrayList.Add(count + "_Age", Age);
                        //arrayList.Add(count + "_Status", Status);
                        //arrayList.Add(count + "_ResignationDate", ResignationDate);

                        empH.Add(new EmploymentHistory
                        {
                            EmployerName = EmployerName,
                            Designation = Designation,
                            LastUpdatedDate = LastUpdatedDate1
                        });

                        ViewData["ArrayList1"] = arrayList1;
                        ViewData["thatlist1"] = thatlist1;
                        ViewData["MianArrayList"] = MianArrayList;
                        MianArrayList1.Add(count, arrayList1);
                        //ViewData["MianArrayList"] = MianArrayList;
                        //ViewData["elements"] = elements;
                        //ViewData["elementsType"] = elements;
                        // ViewData["DirectorID"] = DirectorID;
                        //ViewData["FirstName"] = FirstName;
                        //ViewData["Surname"] = Surname;

                        //System.Diagnostics.Debug.WriteLine(" Director ID "+count+" : "+ DirectorID);
                    }

                    //empH = new List<EmploymentHistory>();

                    //foreach (var item in arrayList1)
                    //{
                    //    empH.Add(new EmploymentHistory
                    //    {
                    //        EmployerName = EmployerName,
                    //        Designation = Designation,
                    //        LastUpdatedDate = LastUpdatedDate1
                    //    });
                    //}
                    ViewData["empH"] = empH;

                    //foreach (KeyValuePair<string, string> item in arrayList1)
                    //{
                    //    System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    //}
                }
                else
                {
                    empH.Add(new EmploymentHistory
                    {
                        EmployerName = "None",
                        Designation = "None",
                        LastUpdatedDate = "None",
                    });
                    ViewData["empH"] = empH;
                }
            }
            JToken HomeAffairsInfoExists = rootObject.ResponseObject["HomeAffairsInformation"];
            if (HomeAffairsInfoExists != null)
            {
                ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                ViewData["CauseOfDeath"] = rootObject.ResponseObject.HomeAffairsInformation.CauseOfDeath;
                ViewData["VerifiedDate"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedDate;
                ViewData["VerifiedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus;
            }

            return View();
        }

        public ActionResult DatabasePropertyIndividual()
        {
            return View();
        }

        public ActionResult DatabasePropertyIndividualResults(Deeds deed)
        {
            /*string Reference = deed.Reference != null ? deed.Reference.Trim() : " ";*/
            string Reference = " ";
            string DeedsOffice = deed.DeedsOffice != null ? deed.DeedsOffice.Trim() : null;
            string Surname = deed.Surname != null ? deed.Surname.Trim() : null;
            string FirstName = deed.FirstName != null ? deed.FirstName.Trim() : null;
            string IDNumber = deed.IDNumber != null ? deed.IDNumber.Trim() : null;

            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();
            DateTime time = DateTime.Now;
            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Database Property Individual";
            string action = "Name:" + FirstName + "; Surname:" + Surname;

            ViewData["user"] = Session["Name"].ToString();
            ViewData["date"] = DateTime.Today.ToShortDateString();
            ViewData["ref"] = Reference;
            List<PropertiesInformation> PropInfo;
            PropInfo = new List<PropertiesInformation>();
            try
            {
                string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                conn.Open();

                var cmd2 = new MySqlCommand(query_uid, conn);

                var reader2 = cmd2.ExecuteReader();

                conn.Close();


                JCredHelper jCredHelper = new JCredHelper();
                string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
                if (!tokenValid(authtoken))
                {
                    //exit with a warning
                }

                //company search API call
                var url = jCredHelper.GetSWAPIHostUrl() + "/databaseproperty/person/"; //"https://uatrest.searchworks.co.za/databaseproperty/person/";

                /*var url = " http://localhost:3000/root";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);*/
                //create RestSharp client and POST request object
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);
                //request headers
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");

                var apiInput = new
                {
                    SessionToken = authtoken,
                    Reference = Reference,
                    DeedsOffice = DeedsOffice,
                    Surname = Surname,
                    Firstname = FirstName,
                    IDNumber = IDNumber
                };
                //add parameters and token to request
                request.Parameters.Clear();
                request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);

                IRestResponse response = client.Execute<RootObject>(request);

                dynamic rootObject = JObject.Parse(response.Content);
                JObject responseObject = JObject.Parse(response.Content);
                System.Diagnostics.Debug.WriteLine(responseObject);

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                if (ViewData["ResponseMessage"].ToString() == "NotFound")
                {
                    TempData["msg"] = "Result Not Found ";
                    return View();
                }

                //PersonInformation
                PersonInformation personInformation = new PersonInformation();

                personInformation.PersonID = rootObject.ResponseObject.PersonInformation.PersonID;
                personInformation.PersonType = rootObject.ResponseObject.PersonInformation.PersonType;
                personInformation.PersonTypeCode = rootObject.ResponseObject.PersonInformation.PersonTypeCode;
                personInformation.DateOfBirth = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                personInformation.FirstName = rootObject.ResponseObject.PersonInformation.FirstName;
                personInformation.Surname = rootObject.ResponseObject.PersonInformation.Surname;
                personInformation.Fullname = rootObject.ResponseObject.PersonInformation.Fullname;
                personInformation.IDNumber = rootObject.ResponseObject.PersonInformation.IDNumber;
                personInformation.MaritalStatus = rootObject.ResponseObject.PersonInformation.MaritalStatus;
                personInformation.Gender = rootObject.ResponseObject.PersonInformation.Gender;
                personInformation.Age = rootObject.ResponseObject.PersonInformation.Age;
                personInformation.MiddleName1 = rootObject.ResponseObject.PersonInformation.MiddleName1;
                personInformation.DeedsOfficeID = rootObject.ResponseObject.PersonInformation.DeedsOfficeID;
                personInformation.DeedsOfficeName = rootObject.ResponseObject.PersonInformation.DeedsOfficeName;
                personInformation.HasProperties = rootObject.ResponseObject.PersonInformation.HasProperties;

                ViewData["personInformationList"] = personInformation;

                //DeedsOfficeBonds
                {
                    List<DeedsOfficeBonds> DeedsOfficeBondsList;
                    DeedsOfficeBondsList = new List<DeedsOfficeBonds>();

                    Newtonsoft.Json.Linq.JArray DeedsElement = new Newtonsoft.Json.Linq.JArray();
                    DeedsElement = rootObject.ResponseObject.DeedsOfficeBonds;

                    for (int count = 0; count < (DeedsElement.Count); count++)
                    {
                        DeedsOfficeBonds deedOffice = new DeedsOfficeBonds();

                        deedOffice.DocumentNumber = rootObject.ResponseObject.DeedsOfficeBonds[count].DocumentNumber;
                        deedOffice.Value = rootObject.ResponseObject.DeedsOfficeBonds[count].Value;
                        deedOffice.Type = rootObject.ResponseObject.DeedsOfficeBonds[count].Type;
                        deedOffice.Description = rootObject.ResponseObject.DeedsOfficeBonds[count].Description;

                        DeedsOfficeBondsList.Add(deedOffice);
                    }
                    ViewData["DeedsOfficeBondsList"] = DeedsOfficeBondsList;
                }

                Newtonsoft.Json.Linq.JArray PropertyInfoElement = new Newtonsoft.Json.Linq.JArray();
                PropertyInfoElement = rootObject.ResponseObject.PropertyInformation.Properties;
                int PropertyCount;

                for (PropertyCount = 0; PropertyCount < (PropertyInfoElement.Count); PropertyCount++)
                {
                    //TransferInformation
                    List<PropertiesTransferInformation> TransferList;
                    TransferList = new List<PropertiesTransferInformation>();
                    {
                        PropertiesTransferInformation TransferIn = new PropertiesTransferInformation();

                        TransferIn.PurchaseDate = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].TransferInformation.PurchaseDate;
                        TransferIn.PurchasePrice = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].TransferInformation.PurchasePrice;
                        TransferIn.TitleDeedNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].TransferInformation.TitleDeedNumber;

                        TransferList.Add(TransferIn);

                        ViewData["TransferList"] = TransferList;
                    }
                    //GeneralInformation
                    List<PropertiesGeneralInformation> GeneralList;
                    GeneralList = new List<PropertiesGeneralInformation>();
                    {
                        PropertiesGeneralInformation GeneralIn = new PropertiesGeneralInformation();

                        GeneralIn.PropertyType = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.PropertyType;
                        GeneralIn.PropertyID = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.PropertyID;
                        GeneralIn.RawPropertyType = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.RawPropertyType;
                        GeneralIn.ShortPropertyDescription = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.ShortPropertyDescription;
                        GeneralIn.DeedsOfficeID = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.DeedsOfficeID;
                        GeneralIn.DeedsOfficeName = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.DeedsOfficeName;
                        GeneralIn.RegistrationDate = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.RegistrationDate;
                        GeneralIn.Share = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.Share;
                        GeneralIn.MultiOwner = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.MultiOwner;
                        GeneralIn.MultiProperty = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.MultiProperty;

                        GeneralList.Add(GeneralIn);

                        ViewData["GeneralList"] = GeneralList;
                    }
                    //SchemeInformation
                    List<PropertiesSchemeInformation> SchemeList;
                    SchemeList = new List<PropertiesSchemeInformation>();
                    {
                        PropertiesSchemeInformation SchemeIn = new PropertiesSchemeInformation();

                        SchemeIn.Name = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].SchemeInformation.Name;
                        SchemeIn.Number = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].SchemeInformation.Number;
                        SchemeIn.UnitNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].SchemeInformation.UnitNumber;

                        SchemeList.Add(SchemeIn);
                        ViewData["SchemeList"] = SchemeList;
                    }
                    PropInfo.Add(new PropertiesInformation
                    {
                        TransferInformation = TransferList,
                        GeneralInformation = GeneralList,
                        SchemeInformation = SchemeList,
                    });
                }
                ViewData["PropInfo"] = PropInfo;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                TempData["msg"] = "Error Occured, Please check the values entered.";
            }

            return View(PropInfo);
        }

        public ActionResult DeedsOfficeRecordsIndividual()
        {
            return View();
        }

        public ActionResult DeedsOfficeRecordsIndividualResults(Deeds deed)
        {
            /* string name = deed.FirstName != null ? deed.FirstName.Trim() : null;
             string deeds = deed.DeedsOffice != null ? deed.DeedsOffice.Trim() : null;
             string sur = deed.Surname != null ? deed.Surname.Trim() : null;
             string id = deed.IDNumber != null ? deed.IDNumber.Trim() : null;
             string refe = deed.Reference != null ? deed.Reference.Trim() : null;
             bool Sequestration = deed.Sequestration;

             string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
             if (!tokenValid(authtoken))
             {
                 //exit with a warning
             }

             //company search API call
             var url = "https://uatrest.searchworks.co.za/deedsoffice/person/";
             //create RestSharp client and POST request object
             var client = new RestClient(url);
             var request = new RestRequest(Method.POST);

             //request headers
             request.RequestFormat = DataFormat.Json;
             request.AddHeader("Content-Type", "application/json");*/

            try
            {
                /* var apiInput = new
                 {
                     SessionToken = authtoken,
                     DeedsOfficeIDs = deeds,
                     Reference = refe,
                     Surname = sur,
                     Firstname = name,
                     IDNumber = id,
                     Sequestration = Sequestration
                 };

                 //add parameters and token to request
                 request.Parameters.Clear();
                 request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                 request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                 //ApiResponse is a class to model the data we want from the API response

                 //make the API request and get a response
                 IRestResponse response = client.Execute<RootObject>(request);

                 //dynamic rootObject = JObject.Parse(response.Content);
                 //ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                 //ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                 string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                 var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                 DateTime time = DateTime.Now;

                 string date_add = DateTime.Today.ToShortDateString();
                 string time_add = time.ToString("T");
                 string page = "Deeds Office Records Individual ";
                 string action = "Deeds Office:" + name;
                 string user_id = Session["ID"].ToString();
                 string us = Session["Name"].ToString();

                 ViewData["user"] = Session["Name"].ToString();
                 ViewData["date"] = DateTime.Today.ToShortDateString();
                 ViewData["ref"] = refe;
                 ViewData["ComName"] = name;

                 string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

                 conn.Open();

                 var cmd2 = new MySqlCommand(query_uid, conn);

                 var reader2 = cmd2.ExecuteReader();

                 conn.Close();*/
                string refe = deed.Reference != null ? deed.Reference.Trim() : null;
                ViewData["user"] = Session["Name"].ToString();
                ViewData["date"] = DateTime.Today.ToShortDateString();
                ViewData["ref"] = refe;
                var url = " http://localhost:7000/root";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute<RootObject>(request);
                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));

                dynamic rootObject = JObject.Parse(response.Content);
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                TempData["ResponseMessage"] = rootObject.ResponseMessage;

                if (ViewData["ResponseMessage"].ToString() == "ServiceOffline")
                {
                    TempData["msg"] = "Sorry Service Is Currently Offline, Please try again later ";
                    return View();
                }

                if (rootObject.ResponseMessage == "NotFound")
                {
                    TempData["msg"] = "No Results Returned. ";
                    return View();
                }

                List<DeedsResponseObject> Resp = new List<DeedsResponseObject>();
                List<PersonInformation> perInfoList = new List<PersonInformation>();
                List<SearchInformation> searchInfoList = new List<SearchInformation>();

                Newtonsoft.Json.Linq.JArray responseElement = new Newtonsoft.Json.Linq.JArray();
                responseElement = rootObject.ResponseObject;
                System.Diagnostics.Debug.WriteLine(responseElement.Count);
                int count;
                for (count = 0; count < (responseElement.Count); count++)
                {
                    SearchInformation searchInfo = new SearchInformation();

                    searchInfo.SearchUserName = rootObject.ResponseObject[count].SearchInformation.SearchUserName;
                    searchInfo.ReportDate = rootObject.ResponseObject[count].SearchInformation.ReportDate;
                    searchInfo.Reference = rootObject.ResponseObject[count].SearchInformation.Reference;
                    searchInfo.SearchToken = rootObject.ResponseObject[count].SearchInformation.SearchToken;
                    searchInfo.SearchDescription = rootObject.ResponseObject[count].SearchInformation.SearchDescription;
                    searchInfo.CallerModule = rootObject.ResponseObject[count].SearchInformation.CallerModule;
                    searchInfo.SearchID = rootObject.ResponseObject[count].SearchInformation.SearchID;
                    searchInfo.DataSupplier = rootObject.ResponseObject[count].SearchInformation.DataSupplier;
                    searchInfo.SearchType = rootObject.ResponseObject[count].SearchInformation.SearchType;

                    searchInfoList.Add(searchInfo);

                    PersonInformation PersonInfo = new PersonInformation();

                    PersonInfo.PersonID = rootObject.ResponseObject[count].PersonInformation.PersonID;
                    PersonInfo.PersonType = rootObject.ResponseObject[count].PersonInformation.PersonType;
                    PersonInfo.PersonTypeCode = rootObject.ResponseObject[count].PersonInformation.PersonTypeCode;
                    PersonInfo.Sequestration = rootObject.ResponseObject[count].PersonInformation.Sequestration;
                    PersonInfo.DateOfBirth = rootObject.ResponseObject[count].PersonInformation.DateOfBirth;
                    PersonInfo.FirstName = rootObject.ResponseObject[count].PersonInformation.FirstName;
                    PersonInfo.Surname = rootObject.ResponseObject[count].PersonInformation.Surname;
                    PersonInfo.Fullname = rootObject.ResponseObject[count].PersonInformation.Fullname;
                    PersonInfo.Description = rootObject.ResponseObject[count].PersonInformation.Description;
                    PersonInfo.IDNumber = rootObject.ResponseObject[count].PersonInformation.IDNumber;
                    PersonInfo.MaritalStatus = rootObject.ResponseObject[count].PersonInformation.MaritalStatus;
                    PersonInfo.Gender = rootObject.ResponseObject[count].PersonInformation.Gender;
                    PersonInfo.Age = rootObject.ResponseObject[count].PersonInformation.Age;
                    PersonInfo.DeedsOfficeID = rootObject.ResponseObject[count].PersonInformation.DeedsOfficeID;
                    PersonInfo.DeedsOfficeName = rootObject.ResponseObject[count].PersonInformation.DeedsOfficeName;

                    perInfoList.Add(PersonInfo);

                    Resp.Add(new DeedsResponseObject
                    {
                        PersonInformation = perInfoList,
                        SearchInformation = searchInfoList,
                    });
                }
                ViewData["Resp"] = Resp;
                ViewData["PersonID"] = rootObject.ResponseObject[0].PersonInformation.PersonID;
                ViewData["DeedsOffice"] = rootObject.ResponseObject[0].PersonInformation.DeedsOfficeID;
                ViewData["SearchDescription"] = rootObject.ResponseObject[0].PersonInformation.Description;
                ViewData["Sequestration"] = rootObject.ResponseObject[0].PersonInformation.Sequestration;
                return View();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                TempData["msg"] = "Error Occured, Please verify the details that have been entered. ";
                return View();
            }
        }

        public ActionResult DeedsOfficeRecordsIndividualDetail(string DeedsOffice, string PersonID, string SearchDescription, string Sequestration)
        {
            System.Diagnostics.Debug.WriteLine(DeedsOffice);
            System.Diagnostics.Debug.WriteLine(PersonID);
            System.Diagnostics.Debug.WriteLine(SearchDescription);
            System.Diagnostics.Debug.WriteLine(Sequestration);

            /*string Reference = CompanyDeed.Reference != null ? CompanyDeed.Reference.Trim() : " ";*/
            /*string Reference = " ";
            string deedsOffice = DeedsOffice != null ? DeedsOffice.Trim() : null;
            string personID = PersonID != null ? PersonID.Trim() : null;
            string searchDescription = SearchDescription != null ? SearchDescription.Trim() : null;
            string sequestration = Sequestration != null ? Sequestration.Trim() : null;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();
            DateTime time = DateTime.Now;
            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Deeds Office Records Individual";
            string action = "Company Name:" + searchDescription + "; Company Registration Number:" + searchDescription;

            ViewData["user"] = Session["Name"].ToString();
            ViewData["date"] = DateTime.Today.ToShortDateString();
            ViewData["ref"] = Reference;

            string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();

            string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }

            //company search API call
            var url = "https://uatrest.searchworks.co.za/deedsoffice/person/dbkey/";

            //create RestSharp client and POST request object
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            //request headers
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");*/

            try
            {
                /* var apiInput = new
                 {
                     SessionToken = authtoken,
                     Reference = Reference,
                     DeedsOffice = deedsOffice,
                     SearchDescription = searchDescription,
                     DBKey = personID,
                     IsSequastration = sequestration,
                 };

                 //add parameters and token to request
                 request.Parameters.Clear();
                 request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                 request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);

                 IRestResponse response = client.Execute<RootObject>(request);

                 dynamic rootObject = JObject.Parse(response.Content);
                 JObject responseObject = JObject.Parse(response.Content);*/

                var url = "http://localhost:7001/root";
                var client = new RestClient(url);
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute<RootObject>(request);
                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
                dynamic rootObject = JObject.Parse(response.Content);

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                TempData["ResponseMessage"] = rootObject.ResponseMessage;

                if (ViewData["ResponseMessage"].ToString() == "ServiceOffline")
                {
                    TempData["msg"] = "Sorry Service Is Currently Offline, Please try again later ";
                    return View();
                }

                if (rootObject.ResponseMessage == "NotFound")
                {
                    TempData["msg"] = "No Results Returned. ";
                    return View();
                }

                Newtonsoft.Json.Linq.JObject ResponseElement = new Newtonsoft.Json.Linq.JObject();
                ResponseElement = rootObject.ResponseObject;
                System.Diagnostics.Debug.WriteLine(ResponseElement);

                //PersonInformation
                PersonInformation personInformation = new PersonInformation();

                personInformation.PersonID = rootObject.ResponseObject.PersonInformation.PersonID;
                personInformation.PersonType = rootObject.ResponseObject.PersonInformation.PersonType;
                personInformation.PersonTypeCode = rootObject.ResponseObject.PersonInformation.PersonTypeCode;
                personInformation.Sequestration = rootObject.ResponseObject.PersonInformation.Sequestration;
                personInformation.DateOfBirth = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                personInformation.FirstName = rootObject.ResponseObject.PersonInformation.FirstName;
                personInformation.MaidenName = rootObject.ResponseObject.PersonInformation.MaidenName;
                personInformation.Surname = rootObject.ResponseObject.PersonInformation.Surname;
                personInformation.Fullname = rootObject.ResponseObject.PersonInformation.Fullname;
                personInformation.IDNumber = rootObject.ResponseObject.PersonInformation.IDNumber;
                personInformation.MaritalStatus = rootObject.ResponseObject.PersonInformation.MaritalStatus;
                personInformation.Gender = rootObject.ResponseObject.PersonInformation.Gender;
                personInformation.Age = rootObject.ResponseObject.PersonInformation.Age;
                personInformation.DeedsOfficeID = rootObject.ResponseObject.PersonInformation.DeedsOfficeID;
                personInformation.DeedsOfficeName = rootObject.ResponseObject.PersonInformation.DeedsOfficeName;

                ViewData["personInformationList"] = personInformation;

                //SearchInformation
                SearchInformation searchInformation = new SearchInformation();

                searchInformation.SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                searchInformation.ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                searchInformation.Reference = rootObject.ResponseObject.SearchInformation.Reference;
                searchInformation.SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                searchInformation.SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                searchInformation.CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                searchInformation.SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                searchInformation.DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                searchInformation.SearchType = rootObject.ResponseObject.SearchInformation.SearchType;

                ViewData["searchInformationList"] = searchInformation;

                //DeedsOfficeContracts
                List<DeedsOfficeContracts> DeedOffContractsList = new List<DeedsOfficeContracts>();
                Newtonsoft.Json.Linq.JArray DeedOffContractsElement = new Newtonsoft.Json.Linq.JArray();

                DeedOffContractsElement = rootObject.ResponseObject.DeedsOfficeContracts;
                System.Diagnostics.Debug.WriteLine(DeedOffContractsElement.Count);
                int count;
                for (count = 0; count < (DeedOffContractsElement.Count); count++)
                {
                    DeedsOfficeContracts DeedsOfficeContractsInfo = new DeedsOfficeContracts();

                    DeedsOfficeContractsInfo.DeedsOfficeID = rootObject.ResponseObject.DeedsOfficeContracts[count].DeedsOfficeID;
                    DeedsOfficeContractsInfo.DocumentNumber = rootObject.ResponseObject.DeedsOfficeContracts[count].DocumentNumber;
                    DeedsOfficeContractsInfo.OtherParty = rootObject.ResponseObject.DeedsOfficeContracts[count].OtherParty;
                    DeedsOfficeContractsInfo.Value = rootObject.ResponseObject.DeedsOfficeContracts[count].Value;
                    DeedsOfficeContractsInfo.MicroFilmReferenceNumber = rootObject.ResponseObject.DeedsOfficeContracts[count].MicroFilmReferenceNumber;
                    DeedsOfficeContractsInfo.Type = rootObject.ResponseObject.DeedsOfficeContracts[count].Type;
                    DeedsOfficeContractsInfo.Description = rootObject.ResponseObject.DeedsOfficeContracts[count].Description;

                    DeedOffContractsList.Add(DeedsOfficeContractsInfo);
                }
                ViewData["DeedOffContractsList"] = DeedOffContractsList;

                List<PropertiesInformation> PropInfo;
                PropInfo = new List<PropertiesInformation>();
                List<PropertiesTransferInformation> TransferList;
                TransferList = new List<PropertiesTransferInformation>();
                List<PropertiesGeneralInformation> GeneralList;
                GeneralList = new List<PropertiesGeneralInformation>();
                List<PropertiesFarmInformation> FarmList;
                FarmList = new List<PropertiesFarmInformation>();
                List<PropertiesErfInformation> ErfList;
                ErfList = new List<PropertiesErfInformation>();
                List<PropertiesSchemeInformation> SchemeList;
                SchemeList = new List<PropertiesSchemeInformation>();

                Newtonsoft.Json.Linq.JArray PropertyInfoElement = new Newtonsoft.Json.Linq.JArray();
                PropertyInfoElement = rootObject.ResponseObject.PropertyInformation.Properties;
                int PropertyCount;

                for (PropertyCount = 0; PropertyCount < (PropertyInfoElement.Count); PropertyCount++)
                {
                    for (PropertyCount = 0; PropertyCount < (PropertyInfoElement.Count); PropertyCount++)
                    {
                        {
                            JToken TransferInfoExists = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount]["TransferInformation"];
                            PropertiesTransferInformation TransferInfo = new PropertiesTransferInformation();

                            if (TransferInfoExists != null)
                            {
                                TransferInfo.PurchaseDate = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].TransferInformation.PurchaseDate;
                                TransferInfo.RegistrationDate = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].TransferInformation.RegistrationDate;
                                TransferInfo.PurchasePrice = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].TransferInformation.PurchasePrice;
                                TransferInfo.TitleDeedNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].TransferInformation.TitleDeedNumber;

                                TransferList.Add(TransferInfo);
                            }
                            ViewData["TransferList"] = TransferList;
                        }

                        {
                            PropertiesGeneralInformation GeneralInfo = new PropertiesGeneralInformation();
                            JToken GeneralInfoExists = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount]["GeneralInformation"];
                            if (GeneralInfoExists != null)
                            {
                                GeneralInfo.PropertyType = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.PropertyType;
                                GeneralInfo.PropertyID = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.PropertyID;
                                GeneralInfo.RawPropertyType = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.RawPropertyType;
                                GeneralInfo.ShortPropertyDescription = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.ShortPropertyDescription;
                                GeneralInfo.Township = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.Township;
                                GeneralInfo.SGCode = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.SGCode;
                                GeneralInfo.DeedsOfficeID = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.DeedsOfficeID;
                                GeneralInfo.DeedsOfficeName = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.DeedsOfficeName;
                                GeneralInfo.RegistrationDate = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.RegistrationDate;
                                GeneralInfo.MicrofilmReferenceNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.MicrofilmReferenceNumber;
                                GeneralInfo.Share = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.Share;
                                GeneralInfo.MultiOwner = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.MultiOwner;
                                GeneralInfo.MultiProperty = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].GeneralInformation.MultiProperty;

                                GeneralList.Add(GeneralInfo);
                            }
                            ViewData["GeneralList"] = GeneralList;
                        }

                        {
                            PropertiesFarmInformation FarmInfo = new PropertiesFarmInformation();
                            JToken FarmInfoExists = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount]["FarmInformation"];
                            if (FarmInfoExists != null)
                            {
                                FarmInfo.Number = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].FarmInformation.Number;
                                FarmInfo.RegistrationDivision = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].FarmInformation.RegistrationDivision;
                                FarmInfo.PortionNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].FarmInformation.PortionNumber;

                                FarmList.Add(FarmInfo);
                            }
                            ViewData["FarmList"] = FarmList;
                        }

                        {
                            PropertiesErfInformation ErfInfo = new PropertiesErfInformation();
                            JToken ErfInfoExists = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount]["ErfInformation"];
                            if (ErfInfoExists != null)
                            {
                                ErfInfo.Number = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].ErfInformation.Number;
                                ErfInfo.PortionNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].ErfInformation.PortionNumber;

                                ErfList.Add(ErfInfo);
                            }
                            ViewData["ErfList"] = ErfList;
                        }

                        {
                            PropertiesSchemeInformation SchemeInfo = new PropertiesSchemeInformation();
                            JToken SchemeInfoExists = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount]["SchemeInformation"];
                            if (SchemeInfoExists != null)
                            {
                                SchemeInfo.Name = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].SchemeInformation.Name;
                                SchemeInfo.Number = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].SchemeInformation.Number;
                                SchemeInfo.UnitNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].SchemeInformation.UnitNumber;

                                SchemeList.Add(SchemeInfo);
                            }
                            ViewData["ErfList"] = ErfList;
                        }
                    }
                    PropInfo.Add(new PropertiesInformation
                    {
                        TransferInformation = TransferList,
                        GeneralInformation = GeneralList,
                        SchemeInformation = SchemeList,
                        ErfInformation = ErfList,
                    });
                }
                ViewData["PropInfo"] = PropInfo;
                return View(PropInfo);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                TempData["msg"] = "Error Occured, Please verify the details that have been entered. ";
                return View();
            }
        }

        private List<DeedsInformation> getCompanyList(IRestResponse response)
        {
            List<DeedsInformation> lst = new List<DeedsInformation>();

            dynamic respContent = JObject.Parse(response.Content);
            List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();

            foreach (ResponseObject responseObject in rawList)
            {
                lst.Add(responseObject.DeedsInformation);
            }

            return lst;
        }
    }
}