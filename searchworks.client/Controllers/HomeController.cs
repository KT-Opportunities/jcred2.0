using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using searchworks.client.Company;
using ServiceStack.Text.Json;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using iTextSharp.text;
using iTextSharp.text.pdf;
using searchworks.client.Models;
using searchworks.client.Report;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Net.Mail;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Dapper;
using searchworks.client.Helpers;

namespace searchworks.client.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private IDbConnection db = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString);

        public HomeController()
        {
        }

        public string GetSWAPILoginToken()
        {
            string loginToken = "";

            //get config from settings
            string api_username = "";
            string api_password = "";
            string api_host = "";

            try
            {
                api_username = Convert.ToString(ConfigurationManager.AppSettings["SWAPIUID"]);
                api_password = Convert.ToString(ConfigurationManager.AppSettings["SWAPIPWD"]);
                api_host = Convert.ToString(ConfigurationManager.AppSettings["SWAPIHost"]);
            }
            catch (Exception err)
            {
                //throw;
            }

            var userName = api_username;
            var password = api_password;
            var host = api_host;
            var body_credentials = new
            {
                Username = api_username,
                Password = api_password
            };

            string authBody = "{  \"Username\": \"" + userName + "\",  \"Password\": \"" + password + "\" }";

            var client = new RestClient(host);

            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/json");

            request.AddParameter("application/json", authBody, ParameterType.RequestBody);

            try
            {
                IRestResponse response = client.Execute(request);

                if (response.IsSuccessful)
                {
                    dynamic respContent = JObject.Parse(response.Content);
                    loginToken = respContent.ResponseMessage;
                }
                else
                {//something went wrong: log the response
                }
            }
            catch (Exception err)
            {
                //error
                //throw;
            }

            return loginToken;
        }

        public bool IsValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return this.RedirectToAction("ForgotPassword", "Account");
        }

        //[AllowAnonymous]
        public ActionResult Login(Login log)
        {
            string dbConnectionString = "";
            dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            if (ModelState.IsValid)
            {
                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var authManager = HttpContext.GetOwinContext().Authentication;

                ApplicationUser user = userManager.Find(log.Email, log.Password);
                if (user != null)
                {
                    var ident = userManager.CreateIdentity(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    //use the instance that has been created.
                    authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);

                    //return Redirect(login.ReturnUrl ?? Url.Action("Index", "Home"));

                    Session["UserName"] = log.Email;
                    Session["ID"] = ident.GetUserId();// reader2["uid"].ToString();
                    Session["Name"] = log.Email;//reader2["fullname"].ToString();

                    //if (userEmail == log.Email && userPass == log.Password)
                    if (ident.IsAuthenticated)
                    {
                        //pull companyname
                        string strUserGUID = ident.GetUserId();
                        int tenantID = -1;
                        tenantID = new JCredHelper().GetUserTenantID(strUserGUID);

                        //var tenantusermap = db.Query<orgunitusermap>("Select * From orgunitusermap where strUserGUID='" + strUserGUID + "'").FirstOrDefault();
                        //tenantID = Convert.ToInt32(tenantusermap.orgtenantid);

                        //tenantID = new JCredHelper().GetUserTenantID(strUserGUID);
                        //tenantID = new JCredHelper.Instance.GetUserTenantID(strUserGUID);

                        //conn.Close();
                        DateTime time = DateTime.Now;

                        string date_add = DateTime.Today.ToShortDateString();
                        string time_add = time.ToString("T");
                        string page = "Login";
                        string action = "Email:" + log.Email;
                        string user_id = Session["ID"].ToString();
                        string us = Session["Name"].ToString();

                        try
                        {
                            string query_uidd = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";
                            conn.Open();
                            var cmd22 = new MySqlCommand(query_uidd, conn);
                            var reader22 = cmd22.ExecuteReader();
                            conn.Close();

                            return RedirectToAction("SearchHistory", "UserManagement");
                        }
                        catch (Exception err)
                        {
                            conn.Close();
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                    TempData["Message"] = "Invalid username or password";
                    //return View("Index");
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
            /*
            string query_uid = "SELECT * FROM users WHERE email = '" + log.Email + "' && password = '" + log.Password + "'";

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                string userEmail = reader2["email"].ToString();
                string userPass = reader2["password"].ToString();
                Session["UserName"] = userEmail;
                Session["ID"] = reader2["uid"].ToString();
                Session["Name"] = reader2["fullname"].ToString();

                if (userEmail == log.Email && userPass == log.Password)
                {
                    conn.Close();
                    DateTime time = DateTime.Now;

                    string date_add = DateTime.Today.ToShortDateString();
                    string time_add = time.ToString("T");
                    string page = "Login";
                    string action = "Email:" + log.Email;
                    string user_id = Session["ID"].ToString();
                    string us = Session["Name"].ToString();

                    string query_uidd = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";
                    conn.Open();
                    var cmd22 = new MySqlCommand(query_uidd, conn);
                    var reader22 = cmd22.ExecuteReader();
                    conn.Close();

                    return RedirectToAction("Landing", "Home");
                }
                else
                {
                    TempData["Message"] = "Credentials did not match!";
                    conn.Close();
                    return View("Index");
                }
            }
            else
            {
                TempData["Message"] = "Credentials did not match!";
                conn.Close();
                return View("Index");
            }
            */
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logs()
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            List<string> thatlist = new List<string>();
            Dictionary<string, string> ArrayList = new Dictionary<string, string>();

            string query_uid = "SELECT * FROM logs ORDER BY id DESC";

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            if (reader2.Read())
            {
                while (reader2.Read())
                {
                    thatlist.Add(reader2["user"].ToString());
                    thatlist.Add(reader2["page"].ToString());
                    thatlist.Add(reader2["action"].ToString());
                    thatlist.Add(reader2["date"].ToString());
                    thatlist.Add(reader2["time"].ToString());
                }

                ViewData["ArrayList"] = thatlist;

                conn.Close();
                return View();
            }
            else
            {
                TempData["Message"] = "Credentials did not match!";
                conn.Close();
                return View();
            }
        }

        public ActionResult Admin(Admin ad)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            List<string> thatlist = new List<string>();

            string email = ad.email;
            string fullname = ad.fullname;
            string dob = ad.dob;
            string phone = ad.phone;
            string gender = ad.gender;
            string org = ad.org;
            string type = ad.type;
            string date_add = DateTime.Today.ToShortDateString();

            if (ad.email != " ")
            {
                string query_uid = "INSERT INTO users (fullname,email,dob,phone,gender,org,type,date_added) VALUES('" + fullname + "','" + email + "','" + dob + "','" + phone + "','" + gender + "','" + org + "','" + type + "','" + date_add + "')";

                conn.Open();

                var cmd2 = new MySqlCommand(query_uid, conn);

                var reader2 = cmd2.ExecuteReader();
                conn.Close();
            }

            string users = "SELECT * FROM users ORDER BY uid DESC";
            conn.Open();

            var cmd = new MySqlCommand(users, conn);
            var reader3 = cmd.ExecuteReader();

            if (reader3.Read())
            {
                while (reader3.Read())
                {
                    string userEmail = reader3["email"].ToString();
                    string name = reader3["fullname"].ToString();
                    string ph = reader3["phone"].ToString();
                    string dateOfBirth = reader3["dob"].ToString();
                    string gen = reader3["gender"].ToString();
                    string ty = reader3["type"].ToString();
                    string or = reader3["org"].ToString();

                    thatlist.Add(name);
                    thatlist.Add(userEmail);
                    thatlist.Add(ph);
                    thatlist.Add(dateOfBirth);
                    thatlist.Add(gen);
                    thatlist.Add(ty);
                    thatlist.Add(or);

                    ViewData["ArrayList"] = thatlist;

                    conn.Close();
                    return View();
                }
            }
            else
            {
                TempData["Message"] = "Credentials did not match!";
                conn.Close();
                return View("Index");
            }

            return View();
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
            string authBody = "{  \"Username\": \"" + userName + "\",  \"Password\": \"" + password + "\" }";

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

        public ActionResult CIPCCompany()
        {
            return View();
        }

        public ActionResult CIPCCompanyResults(Search search)
        {
            string searchBy = search.CipcSearchBy;
            string name = search.CompanyName;
            string registrationNumber = search.RegistrationNumber;
            string pdf = search.PDF;
            string strCompanyName = name != null ? name.Trim() : null;
            string strRegistrationNumber = registrationNumber != null ? registrationNumber.Trim() : null;
            string strSearchBy = searchBy;

            string refe = search.Reference;

            JCredHelper jCredHelper = new JCredHelper();

            string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }
            try
            {
                //company search API call
                var url = jCredHelper.GetSWAPIHostUrl() + "/cipc/company/";//"https://uatrest.searchworks.co.za/cipc/company/";

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
                    CipcSearchBy = strSearchBy,//company name contains: See documentation
                    Reference = authtoken,//search reference: probably store in logs
                    CompanyName = strCompanyName,
                    RegistrationNumber = strRegistrationNumber
                };

                //add parameters and token to request
                request.Parameters.Clear();
                request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                //ApiResponse is a class to model the data we want from the API response

                //make the API request and get a response
                IRestResponse response = client.Execute<RootObject>(request);

                dynamic rootObject = JObject.Parse(response.Content);
                TempData["ResponseMessage"] = rootObject.ResponseMessage;
                ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;

                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CIPC Company Records";
                string action = "Company Name:" + name;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                TempData["user"] = Session["Name"].ToString();
                TempData["date"] = DateTime.Today.ToShortDateString();
                TempData["ref"] = refe;
                TempData["ComName"] = name;
                TempData.Keep();
                string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

                conn.Open();

                var cmd2 = new MySqlCommand(query_uid, conn);
                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
                var reader2 = cmd2.ExecuteReader();
                if (rootObject.ResponseMessage == "Invalid sessionToken")
                {
                    TempData["msg"] = "Invalid sessionToken.";
                    return View();
                }
                List<CompanyInformation> lst = new List<CompanyInformation>();
                dynamic respContent = JObject.Parse(response.Content);

                try
                {
                    List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();
                    foreach (ResponseObject responseObject in rawList)
                    {
                        //ResponseObject res = responseObject.ToObject<ResponseObject>;
                        //res.SearchInformation = responseObject.SearchInformation;
                        lst.Add(responseObject.CompanyInformation);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.ToString());

                    TempData["msg"] = "An error occured, please check the entered values.";
                }

                /* try
                 {
                     System.Collections.Generic.List<CompanyInformation> CompanyList = new System.Collections.Generic.List<CompanyInformation>();
                     foreach (CompanyInformation comp in rootObject.CompanyInformation)
                     {
                         CompanyList.Add(comp);
                     }
                     ViewData["CompanyList"] = CompanyList;
                     ViewData["CompanyListCount"] = CompanyList.Count;
                 }
                 catch (Exception e)
                 {
                     System.Diagnostics.Debug.WriteLine(e.ToString());
                     TempData["msg"] = "An error occured, please check the entered values.";
                 }
                 */
                conn.Close();
                return View(lst);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                return View();
            }
        }

        public ActionResult CIPCCompanyDetails(string comID)
        {
            try
            {
                JCredHelper jCredHelper = new JCredHelper();
                string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
                if (!tokenValid(authtoken))
                {
                    //exit with a warning
                }

                //company search API call
                var url = jCredHelper.GetSWAPIHostUrl() + "/cipc/company/companyid/";// "https://uatrest.searchworks.co.za/cipc/company/companyid/";

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
                    //CipcSearchBy = 2,company name contains: See documentation
                    Reference = authtoken,//search reference: probably store in logs
                    CompanyID = comID,
                    SearchDescription = ""
                };

                //add parameters and token to request
                request.Parameters.Clear();
                request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                //ApiResponse is a class to model the data we want from the API response

                //make the API request and get a response
                IRestResponse response = client.Execute<RootObject>(request);

                dynamic rootObject = JObject.Parse(response.Content);
                Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                Dictionary<string, string> arrayList = new Dictionary<string, string>();

                List<string> thatlist = new List<string>();
                Dictionary<int, Dictionary<string, string>> MianArrayList = new Dictionary<int, Dictionary<string, string>>();
                elements = rootObject.ResponseObject.Directors;
                ViewData["TheCount"] = elements.Count;

                List<Directors> DirecD;
                DirecD = new List<Directors>();
                for (int count = 0; count < (elements.Count); count++)
                {
                    string DirectorID = rootObject.ResponseObject.Directors[count].DirectorID;
                    string FirstName = rootObject.ResponseObject.Directors[count].FirstName;
                    string Surname = rootObject.ResponseObject.Directors[count].Surname;
                    string Fullname = rootObject.ResponseObject.Directors[count].Fullname;
                    string IdNumber = rootObject.ResponseObject.Directors[count].IdNumber;
                    string DateOfBirth = rootObject.ResponseObject.Directors[count].DateOfBirth;
                    string Age = rootObject.ResponseObject.Directors[count].Age;
                    string StatusCode = rootObject.ResponseObject.Directors[count].StatusCode;
                    string Status = rootObject.ResponseObject.Directors[count].Status;
                    string TypeCode = rootObject.ResponseObject.Directors[count].TypeCode;
                    string Type = rootObject.ResponseObject.Directors[count].Type;
                    string AppointmentDate = rootObject.ResponseObject.Directors[count].AppointmentDate;
                    string ResignationDate = rootObject.ResponseObject.Directors[count].ResignationDate;
                    string MemberContribution = rootObject.ResponseObject.Directors[count].MemberContribution;
                    string MemberSize = rootObject.ResponseObject.Directors[count].MemberSize;
                    string ResidentialAddress1 = rootObject.ResponseObject.Directors[count].ResidentialAddress1;
                    string ResidentialAddress2 = rootObject.ResponseObject.Directors[count].ResidentialAddress2;
                    string ResidentialAddress3 = rootObject.ResponseObject.Directors[count].ResidentialAddress3;
                    string ResidentialAddress4 = rootObject.ResponseObject.Directors[count].ResidentialAddress4;
                    string ResidentialPostCode = rootObject.ResponseObject.Directors[count].ResidentialPostCode;
                    string PostalAddress1 = rootObject.ResponseObject.Directors[count].PostalAddress1;
                    string PostalAddress2 = rootObject.ResponseObject.Directors[count].PostalAddress2;
                    string PostalAddress3 = rootObject.ResponseObject.Directors[count].PostalAddress3;
                    string PostalAddress4 = rootObject.ResponseObject.Directors[count].PostalAddress4;
                    string PostalPostCode = rootObject.ResponseObject.Directors[count].PostalPostCode;
                    string CountryCode = rootObject.ResponseObject.Directors[count].CountryCode;
                    string Country = rootObject.ResponseObject.Directors[count].Country;
                    string NationalityCode = rootObject.ResponseObject.Directors[count].NationalityCode;
                    string Gender = rootObject.ResponseObject.Directors[count].Gender;

                    thatlist.Add(FirstName);

                    ViewData["ArrayList"] = arrayList;
                    ViewData["thatlist"] = thatlist;

                    DirecD.Add(new Directors
                    {
                        DirectorID = DirectorID,
                        FirstName = FirstName,
                        Surname = Surname,
                        Gender = Gender,
                        IdNumber = IdNumber,
                        Age = Age,
                        Status = Status,
                        ResignationDate = ResignationDate,
                    });

                    MianArrayList.Add(count, arrayList);
                    ViewData[" MianArrayList"] = MianArrayList;
                    ViewData["DirectorsDetails"] = DirecD;
                }

                TempData["ResponseMessage"] = rootObject.ResponseMessage;
                ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                ViewData["CompanyName"] = rootObject.ResponseObject.CompanyInformation.CompanyName;
                ViewData["CompanyID"] = rootObject.ResponseObject.CompanyInformation.CompanyID;
                ViewData["CompanyRegistrationNumber"] = rootObject.ResponseObject.CompanyInformation.CompanyRegistrationNumber;
                ViewData["CompanyStatus"] = rootObject.ResponseObject.CompanyInformation.CompanyStatus;
                ViewData["CompanyType"] = rootObject.ResponseObject.CompanyInformation.CompanyType;
                ViewData["FinancialYearEnd"] = rootObject.ResponseObject.CompanyInformation.FinancialYearEnd;
                ViewData["RegistrationDate"] = rootObject.ResponseObject.CompanyInformation.RegistrationDate;
                ViewData["Region"] = rootObject.ResponseObject.CompanyInformation.Region;
                ViewData["Country"] = rootObject.ResponseObject.CompanyInformation.Country;

                ViewData["PhysicalAddressLine1"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine1;
                ViewData["PhysicalAddressLine2"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine2;
                ViewData["PhysicalAddressLine3"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine3;
                ViewData["PhysicalAddressLine4"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine4;
                ViewData["PhysicalPostCode"] = rootObject.ResponseObject.CompanyInformation.PhysicalPostCode;

                ViewData["PostalAddressLine1"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine1;
                ViewData["PostalAddressLine2"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine2;
                ViewData["PostalAddressLine3"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine3;
                ViewData["PostalAddressLine4"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine4;
                ViewData["PostalPostCode"] = rootObject.ResponseObject.CompanyInformation.PostalPostCode;
                TempData.Keep();
                return View();
            }
            catch (Exception e)
            {
                TempData["Msg"] = e.ToString();
                return View();
            }
        }

        public ActionResult CSICompanyRecords()
        {
            return View();
        }

        public ActionResult CSICompanyRecordsResults(Search search)
        {
            string name = search.CompanyName != null ? search.CompanyName.Trim() : null;
            string type = search.seaType;
            string comID = search.CompanyID;
            string regNum = search.RegistrationNumber;
            string refe = search.Reference;

            string strCompanyName = name;
            TempData["type"] = type;
            try
            {
                if (type == "name")
                {
                    string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                    var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                    DateTime time = DateTime.Now;

                    string date_add = DateTime.Today.ToShortDateString();
                    string time_add = time.ToString("T");
                    string page = "CSI Company Trace By Name";
                    string action = "Company Name:" + name;
                    string user_id = Session["ID"].ToString();
                    string us = Session["Name"].ToString();

                    TempData["user"] = Session["Name"].ToString();
                    TempData["date"] = DateTime.Today.ToShortDateString();
                    TempData["ref"] = refe;
                    TempData["ComName"] = name;

                    string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

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
                    var url = jCredHelper.GetSWAPIHostUrl() + "/company/csicompany/companytrace/companyname/";// "https://uatrest.searchworks.co.za/company/csicompany/companytrace/companyname/";

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
                        Reference = us,//search reference: probably store in logs
                        CompanyName = strCompanyName,
                    };

                    //add parameters and token to request
                    request.Parameters.Clear();
                    request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                    request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                    //ApiResponse is a class to model the data we want from the API response

                    //make the API request and get a response
                    IRestResponse response = client.Execute<RootObject>(request);

                    dynamic rootObject = JObject.Parse(response.Content);

                    ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                    var mes = ViewData["ResponseMessage"].ToString();
                    System.Diagnostics.Debug.WriteLine("Resp Message: " + mes);
                    System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
                    ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;

                    if (mes == "ServiceOffline")
                    {
                        ViewData["Message"] = "Service is offline";
                        return View();
                    }
                    else
                    {
                        //extract list of companies returned
                        ViewData["Message"] = "good";

                        ViewData["CompanyID"] = rootObject.ResponseObject.CompanyInformation.CompanyID;
                        ViewData["CompanyRegistrationNumber"] = rootObject.ResponseObject.CompanyInformation.CompanyRegistrationNumber;
                        ViewData["CompanyName"] = rootObject.ResponseObject.CompanyInformation.CompanyName;
                        ViewData["CompanyTranslatedName"] = rootObject.ResponseObject.CompanyInformation.CompanyTranslatedName;
                        ViewData["RegistrationDate"] = rootObject.ResponseObject.CompanyInformation.RegistrationDate;
                        ViewData["CompanyStatusCode"] = rootObject.ResponseObject.CompanyInformation.CompanyStatusCode;
                        ViewData["CompanyStatus"] = rootObject.ResponseObject.CompanyInformation.CompanyStatus;

                        return View();
                    }
                }
                else if (type == "comID")
                {
                    string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                    var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                    DateTime time = DateTime.Now;

                    string date_add = DateTime.Today.ToShortDateString();
                    string time_add = time.ToString("T");
                    string page = "CSI Company Trace By CompanyID";
                    string action = "Company ID:" + comID;
                    string user_id = Session["ID"].ToString();
                    string us = Session["Name"].ToString();

                    TempData["user"] = Session["Name"].ToString();
                    TempData["date"] = DateTime.Today.ToShortDateString();
                    TempData["ref"] = refe;
                    TempData["ComName"] = comID;

                    string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

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
                    var url = jCredHelper.GetSWAPIHostUrl() + "/company/csicompany/companytrace/companyid/";//"https://uatrest.searchworks.co.za/company/csicompany/companytrace/companyid/";

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
                        Reference = us,//search reference: probably store in logs
                        CompanyID = comID,
                    };

                    //add parameters and token to request
                    request.Parameters.Clear();
                    request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                    request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                    //ApiResponse is a class to model the data we want from the API response

                    //make the API request and get a response
                    IRestResponse response = client.Execute<RootObject>(request);

                    dynamic rootObject = JObject.Parse(response.Content);

                    TempData["ResponseMessage"] = rootObject.ResponseMessage;
                    var mes = TempData["ResponseMessage"].ToString();
                    ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                    TempData.Keep();
                    if (mes == "ServiceOffline")
                    {
                        ViewData["Message"] = "Service is offline";
                        return View();
                    }
                    else
                    {
                        //extract list of companies returned
                        ViewData["Message"] = "good";

                        ViewData["type"] = type;
                        ViewData["ComID"] = rootObject.ResponseObject.CompanyInformation.CompanyID;
                        ViewData["ComReg"] = rootObject.ResponseObject.CompanyInformation.CompanyRegistrationNumber;
                        ViewData["ComName"] = rootObject.ResponseObject.CompanyInformation.CompanyName;
                        ViewData["ComTransName"] = rootObject.ResponseObject.CompanyInformation.CompanyTranslatedName;
                        ViewData["ComRegDate"] = rootObject.ResponseObject.CompanyInformation.RegistrationDate;
                        ViewData["ComStatCode"] = rootObject.ResponseObject.CompanyInformation.CompanyStatusCode;
                        ViewData["ComStat"] = rootObject.ResponseObject.CompanyInformation.CompanyStatus;

                        return View();
                    }
                }
                else if (type == "regNum")
                {
                    string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                    var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                    DateTime time = DateTime.Now;

                    string date_add = DateTime.Today.ToShortDateString();
                    string time_add = time.ToString("T");
                    string page = "CSI Company Trace By Registration Number";
                    string action = "Registration Number:" + regNum;
                    string user_id = Session["ID"].ToString();
                    string us = Session["Name"].ToString();

                    TempData["user"] = Session["Name"].ToString();
                    TempData["date"] = DateTime.Today.ToShortDateString();
                    TempData["ref"] = refe;
                    TempData["ComName"] = regNum;

                    string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

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
                    var url = jCredHelper.GetSWAPIHostUrl() + "/company/csicompany/companytrace/registrationnumber/";//"https://uatrest.searchworks.co.za/company/csicompany/companytrace/registrationnumber/";

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
                        Reference = us,//search reference: probably store in logs
                        RegistrationNumber = regNum,
                    };

                    //add parameters and token to request
                    request.Parameters.Clear();
                    request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                    request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);
                    //ApiResponse is a class to model the data we want from the API response

                    //make the API request and get a response
                    IRestResponse response = client.Execute<RootObject>(request);

                    dynamic rootObject = JObject.Parse(response.Content);

                    TempData["ResponseMessage"] = rootObject.ResponseMessage;
                    var mes = TempData["ResponseMessage"].ToString();
                    ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                    TempData.Keep();

                    if (mes == "ServiceOffline")
                    {
                        ViewData["Message"] = "Service is offline";
                        return View();
                    }
                    else
                    {
                        //extract list of companies returned
                        ViewData["Message"] = "good";

                        ViewData["type"] = type;
                        ViewData["ComID"] = rootObject.ResponseObject.CompanyInformation.CompanyID;
                        ViewData["ComReg"] = rootObject.ResponseObject.CompanyInformation.CompanyRegistrationNumber;
                        ViewData["ComName"] = rootObject.ResponseObject.CompanyInformation.CompanyName;
                        ViewData["ComTransName"] = rootObject.ResponseObject.CompanyInformation.CompanyTranslatedName;
                        ViewData["ComRegDate"] = rootObject.ResponseObject.CompanyInformation.RegistrationDate;
                        ViewData["ComStatCode"] = rootObject.ResponseObject.CompanyInformation.CompanyStatusCode;
                        ViewData["ComStat"] = rootObject.ResponseObject.CompanyInformation.CompanyStatus;

                        return View();
                    }
                }
            }
            catch (Exception e)

            {
                TempData["msg"] = "An error occured, please check the entered values.";
            }

            return View();
        }

        public ActionResult CSICompanyDetails(string comID)
        {
            JCredHelper jCredHelper = new JCredHelper();
            string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }
            var url = jCredHelper.GetSWAPIHostUrl() + "/company/csicompany/companytrace/companyid/";//"https://uatrest.searchworks.co.za/company/csicompany/companytrace/companyid/";

            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);

            //request headers
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            //object containing input parameter data for company() API method

            var apiInput = new
            {
                SessionToken = authtoken,
                Reference = authtoken,
                CompanyID = comID,
                SearchDescription = "CSI CompanyID Search",
            };

            //add parameters and token to request
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);

            //make the API request and get a response
            IRestResponse response = client.Execute<RootObject>(request);
            dynamic rootObject = JObject.Parse(response.Content);

            string CapitalType = "";
            string CompanyCapitalID = "";
            string CompanyID = "";
            string CompanyRegistrationNumber = "";
            string NoShares = "";
            string ParriValue = "";
            string Premium = "";
            string ShareAmount = "";

            TempData["ResponseMessage"] = rootObject.ResponseMessage;
            ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
            ViewData["CompanyName"] = rootObject.ResponseObject.CompanyInformation.CompanyName;
            ViewData["CompanyID"] = rootObject.ResponseObject.CompanyInformation.CompanyID;
            ViewData["CompanyRegistrationNumber"] = rootObject.ResponseObject.CompanyInformation.CompanyRegistrationNumber;
            ViewData["CompanyStatus"] = rootObject.ResponseObject.CompanyInformation.CompanyStatus;
            ViewData["CompanyType"] = rootObject.ResponseObject.CompanyInformation.CompanyType;
            ViewData["FinancialYearEnd"] = rootObject.ResponseObject.CompanyInformation.FinancialYearEnd;
            ViewData["RegistrationDate"] = rootObject.ResponseObject.CompanyInformation.RegistrationDate;
            ViewData["Region"] = rootObject.ResponseObject.CompanyInformation.Region;
            ViewData["Country"] = rootObject.ResponseObject.CompanyInformation.Country;

            ViewData["PhysicalAddressLine1"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine1;
            ViewData["PhysicalAddressLine2"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine2;
            ViewData["PhysicalAddressLine3"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine3;
            ViewData["PhysicalAddressLine4"] = rootObject.ResponseObject.CompanyInformation.PhysicalAddressLine4;
            ViewData["PhysicalPostCode"] = rootObject.ResponseObject.CompanyInformation.PhysicalPostCode;

            ViewData["PostalAddressLine1"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine1;
            ViewData["PostalAddressLine2"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine2;
            ViewData["PostalAddressLine3"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine3;
            ViewData["PostalAddressLine4"] = rootObject.ResponseObject.CompanyInformation.PostalAddressLine4;
            ViewData["PostalPostCode"] = rootObject.ResponseObject.CompanyInformation.PostalPostCode;
            TempData.Keep();
            ViewData["DirectorsDetails"] = null;

            if (rootObject.ResponseObject["Directors"] != null)
            {
                List<Directors> DirecD;

                Newtonsoft.Json.Linq.JArray elements2 = new Newtonsoft.Json.Linq.JArray();
                elements2 = rootObject.ResponseObject.Directors;

                DirecD = new List<Directors>();
                for (int count = 0; count < (elements2.Count); count++)
                {
                    string DirectorID = rootObject.ResponseObject.Directors[count].DirectorID;
                    string FirstName = rootObject.ResponseObject.Directors[count].FirstName;
                    string Surname = rootObject.ResponseObject.Directors[count].Surname;
                    string Fullname = rootObject.ResponseObject.Directors[count].Fullname;
                    string IdNumber = rootObject.ResponseObject.Directors[count].IdNumber;
                    string DateOfBirth = rootObject.ResponseObject.Directors[count].DateOfBirth;
                    string Age = rootObject.ResponseObject.Directors[count].Age;
                    string StatusCode = rootObject.ResponseObject.Directors[count].StatusCode;
                    string Status = rootObject.ResponseObject.Directors[count].Status;
                    string TypeCode = rootObject.ResponseObject.Directors[count].TypeCode;
                    string Type = rootObject.ResponseObject.Directors[count].Type;
                    string AppointmentDate = rootObject.ResponseObject.Directors[count].AppointmentDate;
                    string ResignationDate = rootObject.ResponseObject.Directors[count].ResignationDate;
                    string MemberContribution = rootObject.ResponseObject.Directors[count].MemberContribution;
                    string MemberSize = rootObject.ResponseObject.Directors[count].MemberSize;
                    string ResidentialAddress1 = rootObject.ResponseObject.Directors[count].ResidentialAddress1;
                    string ResidentialAddress2 = rootObject.ResponseObject.Directors[count].ResidentialAddress2;
                    string ResidentialAddress3 = rootObject.ResponseObject.Directors[count].ResidentialAddress3;
                    string ResidentialAddress4 = rootObject.ResponseObject.Directors[count].ResidentialAddress4;
                    string ResidentialPostCode = rootObject.ResponseObject.Directors[count].ResidentialPostCode;
                    string PostalAddress1 = rootObject.ResponseObject.Directors[count].PostalAddress1;
                    string PostalAddress2 = rootObject.ResponseObject.Directors[count].PostalAddress2;
                    string PostalAddress3 = rootObject.ResponseObject.Directors[count].PostalAddress3;
                    string PostalAddress4 = rootObject.ResponseObject.Directors[count].PostalAddress4;
                    string PostalPostCode = rootObject.ResponseObject.Directors[count].PostalPostCode;
                    string CountryCode = rootObject.ResponseObject.Directors[count].CountryCode;
                    string Country = rootObject.ResponseObject.Directors[count].Country;
                    string NationalityCode = rootObject.ResponseObject.Directors[count].NationalityCode;
                    string Gender = rootObject.ResponseObject.Directors[count].Gender;

                    DirecD.Add(new Directors
                    {
                        DirectorID = DirectorID,
                        FirstName = FirstName,
                        Surname = Surname,
                        Gender = Gender,
                        IdNumber = IdNumber,
                        Age = Age,
                        Status = Status,
                        ResignationDate = ResignationDate,
                    });

                    ViewData["DirectorsDetails"] = DirecD;
                }
            }
            ViewData["CapInfo"] = null;
            if (rootObject.ResponseObject["CapitalInformation "] != null)
            {
                List<CapitalInformation> CapInfo;

                Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();

                elements1 = rootObject.ResponseObject.CapitalInformation;

                CapInfo = new List<CapitalInformation>();

                for (int count = 0; count < (elements1.Count); count++)
                {
                    CapitalType = rootObject.ResponseObject.CapitalInformation[count].CapitalType;
                    CompanyCapitalID = rootObject.ResponseObject.CapitalInformation[count].CompanyCapitalID;
                    CompanyID = rootObject.ResponseObject.CapitalInformation[count].CompanyID;
                    CompanyRegistrationNumber = rootObject.ResponseObject.CapitalInformation[count].CompanyRegistrationNumber;
                    NoShares = rootObject.ResponseObject.CapitalInformation[count].NoShares;
                    ParriValue = rootObject.ResponseObject.CapitalInformation[count].ParriValue;
                    Premium = rootObject.ResponseObject.CapitalInformation[count].Premium;
                    ShareAmount = rootObject.ResponseObject.CapitalInformation[count].ShareAmount;

                    CapInfo.Add(new CapitalInformation
                    {
                        CapitalType = CapitalType,
                        CompanyCapitalID = CompanyCapitalID,
                        CompanyID = CompanyID,
                        CompanyRegistrationNumber = CompanyRegistrationNumber,
                        NoShares = NoShares,
                        ParriValue = ParriValue,
                        Premium = Premium,
                        ShareAmount = ShareAmount,
                    });

                    ViewData["CapInfo"] = CapInfo;
                }
            }

            {
                return View();
            }
        }

        private List<CompanyInformation> getCSICompanyList(IRestResponse response)
        {
            List<CompanyInformation> lst = new List<CompanyInformation>();

            dynamic respContent = JObject.Parse(response.Content);

            //List<ResponseObject> rawList = respContent.ResponseObject.CompanyInformation.ToObject<List<ResponseObject>>();

            //foreach (ResponseObject responseObject in rawList)
            //{
            //    //ResponseObject res = responseObject.ToObject<ResponseObject>;
            //    //res.SearchInformation = responseObject.SearchInformation;
            //    lst.Add(responseObject.CompanyInformation);
            //}

            return lst;
        }

        public ActionResult DatabasePropertyCompany()
        {
            return View();
        }

        public ActionResult DatabasePropertyCompanyResults(CompanyDeeds comDeeds)
        {
            /* string Reference = deed.Reference != null ? deed.Reference.Trim() : null;*/
            string Reference = " ";
            string deedsOffice = comDeeds.DeedsOffice != null ? comDeeds.DeedsOffice.Trim() : " ";
            string companyName = comDeeds.CompanyName != null ? comDeeds.CompanyName.Trim() : " ";
            string companyRegistrationNumber = comDeeds.CompanyRegistrationNumber != null ? comDeeds.CompanyRegistrationNumber.Trim() : " ";

            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();
            DateTime time = DateTime.Now;
            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Database Property Company";
            string action = "Company Name:" + companyName + "; Company Registration Number:" + companyRegistrationNumber;

            TempData["user"] = Session["Name"].ToString();
            TempData["date"] = DateTime.Today.ToShortDateString();
            TempData["ref"] = Reference;
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

                var url = jCredHelper.GetSWAPIHostUrl() + "/databaseproperty/company/";//"https://uatrest.searchworks.co.za/databaseproperty/company/";

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
                    DeedsOffice = deedsOffice,
                    CompanyName = companyName,
                    RegistrationNumber = companyRegistrationNumber,
                };
                //add parameters and token to request
                request.Parameters.Clear();
                request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);

                IRestResponse response = client.Execute<RootObject>(request);

                dynamic rootObject = JObject.Parse(response.Content);
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                /*ViewData["ComName"] = rootObject.ResponseObject.SearchInformation.SearchDescription;*/

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

                List<ResponseObject> Resp = new List<ResponseObject>();
                Newtonsoft.Json.Linq.JArray ResponseElement = new Newtonsoft.Json.Linq.JArray();

                ResponseElement = rootObject.ResponseObject;
                System.Diagnostics.Debug.WriteLine(ResponseElement);
                ViewData["ResponseElement"] = ResponseElement;

                return View();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                TempData["msg"] = "Error Occured, Please verify the details that have been entered. ";
                return View();
            }
        }

        public ActionResult DeedsOfficeRecordsCompany()
        {
            return View();
        }

        public ActionResult DeedsOfficeRecordsCompanyResult(CompanyDeeds CompanyDeed)
        {
            /*string Reference = CompanyDeed.Reference != null ? CompanyDeed.Reference.Trim() : " ";*/
            string Reference = " ";
            string deedsOffice = CompanyDeed.DeedsOffice != null ? CompanyDeed.DeedsOffice.Trim() : null;
            string companyName = CompanyDeed.CompanyName != null ? CompanyDeed.CompanyName.Trim() : null;
            string companyRegistrationNumber = CompanyDeed.CompanyRegistrationNumber != null ? CompanyDeed.CompanyRegistrationNumber.Trim() : null;
            string sequestration = CompanyDeed.Sequestration;
            System.Diagnostics.Debug.WriteLine(deedsOffice, Reference, companyName, companyRegistrationNumber, sequestration);
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();
            DateTime time = DateTime.Now;
            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Database Property Individual";
            string action = "Company Name:" + companyName + "; Company Registration Number:" + companyRegistrationNumber;

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

            /*string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");*/
            JCredHelper jCredHelper = new JCredHelper();
            string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }

            //company search API call
            var url = jCredHelper.GetSWAPIHostUrl() + "/deedsoffice/company/"; //"https://uatrest.searchworks.co.za/deedsoffice/company/";

            //create RestSharp client and POST request object
            var client = new RestClient(url);
            var request = new RestRequest(Method.POST);
            //request headers
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            try
            {
                var apiInput = new
                {
                    SessionToken = authtoken,
                    Reference = Reference,
                    DeedsOffice = deedsOffice,
                    CompanyName = companyName,
                    CompanyRegistrationNumber = companyRegistrationNumber,
                    Sequestration = sequestration
                };

                //add parameters and token to request
                request.Parameters.Clear();
                request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
                request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);

                IRestResponse response = client.Execute<RootObject>(request);

                dynamic rootObject = JObject.Parse(response.Content);
                JObject responseObject = JObject.Parse(response.Content);

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));

                /* var url = "http://localhost:8000/root";
                 var client = new RestClient(url);
                 var request = new RestRequest(Method.GET);*/
                /* IRestResponse response = client.Execute<RootObject>(request);
                 dynamic rootObject = JObject.Parse(response.Content);*/
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                TempData["ResponseMessage"] = rootObject.ResponseMessage;

                if (rootObject.ResponseMessage == "ServiceOffline")
                {
                    TempData["msg"] = "Sorry Service Is Currently Offline, Please try again later ";
                    return View();
                }

                if (rootObject.ResponseMessage == "NotFound")
                {
                    TempData["msg"] = "No Results Returned. ";
                    return View();
                }
                if (rootObject.ResponseMessage == "DeedsOfficeCompany, Error occurred. Please try again.")
                {
                    TempData["msg"] = "DeedsOfficeCompany, Error occurred. Please try again. ";
                    return View();
                }

                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));

                Newtonsoft.Json.Linq.JArray ResponseElement = new Newtonsoft.Json.Linq.JArray();
                ResponseElement = rootObject.ResponseObject;
                System.Diagnostics.Debug.WriteLine(ResponseElement);
                ViewData["ResponseElement"] = ResponseElement;
                ViewData["DeedsOfficeID"] = rootObject.ResponseObject[0].CompanyInformation.DeedsOfficeID;
                ViewData["CompanyID"] = rootObject.ResponseObject[0].CompanyInformation.CompanyID;
                ViewData["SearchDescription"] = rootObject.ResponseObject[0].SearchInformation.SearchDescription;

                return View();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                TempData["msg"] = "Error Occured, Please verify the details that have been entered. ";
                return View();
            }
        }

        public ActionResult DeedsOfficeRecordsCompanyDetails(CompanyDeeds CompanyDeed)
        {
            /*string Reference = CompanyDeed.Reference != null ? CompanyDeed.Reference.Trim() : " ";*/
            string Reference = " ";
            string dbKey = CompanyDeed.DBKey;
            string deedsOffice = CompanyDeed.DeedsOffice != null ? CompanyDeed.DeedsOffice.Trim() : null;
            string companyName = CompanyDeed.CompanyName != null ? CompanyDeed.CompanyName.Trim() : null;
            string SearchDescription = CompanyDeed.SearchDescription;

            System.Diagnostics.Debug.WriteLine(CompanyDeed.DBKey);
            System.Diagnostics.Debug.WriteLine(CompanyDeed.DeedsOffice);
            System.Diagnostics.Debug.WriteLine(CompanyDeed.Reference);
            System.Diagnostics.Debug.WriteLine(CompanyDeed.SearchDescription);

            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();
            DateTime time = DateTime.Now;
            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Deeds Office Records Company Details";
            string action = "Company Name:" + companyName;

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

            JCredHelper jCredHelper = new JCredHelper();
            string authtoken = jCredHelper.GetSWAPILoginToken(); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); //GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }

            //company search API call
            var url = jCredHelper.GetSWAPIHostUrl() + "/deedsoffice/company/dbkey/";

            /*var url = "https://uatrest.searchworks.co.za/deedsoffice/company/dbkey/";*/

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
                DeedsOffice = deedsOffice,
                DBKey = dbKey,
                SearchDescription = SearchDescription
            };

            //add parameters and token to request
            request.Parameters.Clear();
            request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput), ParameterType.RequestBody);
            request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);

            IRestResponse response = client.Execute<RootObject>(request);

            dynamic rootObject = JObject.Parse(response.Content);
            JObject responseObject = JObject.Parse(response.Content);

            /*  var url = "http://localhost:3000/root";
              var client = new RestClient(url);
              var request = new RestRequest(Method.GET);
              IRestResponse response = client.Execute<RootObject>(request);
              System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
              dynamic rootObject = JObject.Parse(response.Content);*/
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
            /* Newtonsoft.Json.Linq.JArray ResponseElement = new Newtonsoft.Json.Linq.JArray();*/

            ResponseElement = rootObject.ResponseObject;
            System.Diagnostics.Debug.WriteLine(ResponseElement);
            ViewData["ResponseElement"] = ResponseElement;
            ViewData["CompanyInformation"] = rootObject.ResponseObject.CompanyInformation;
            List<Property> PropInfo;
            PropInfo = new List<Property>();
            List<TransferInformation> TransferList;
            TransferList = new List<TransferInformation>();
            List<GeneralInformation> GeneralList;
            GeneralList = new List<GeneralInformation>();
            List<FarmInformation> FarmList;
            FarmList = new List<FarmInformation>();
            List<ErfInformation> ErfList;
            ErfList = new List<ErfInformation>();

            Newtonsoft.Json.Linq.JArray PropertyInfoElement = new Newtonsoft.Json.Linq.JArray();
            PropertyInfoElement = rootObject.ResponseObject.PropertyInformation.Properties;
            int PropertyCount;
            for (PropertyCount = 0; PropertyCount < (PropertyInfoElement.Count); PropertyCount++)
            {
                {
                    JToken TransferInfoExists = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount]["TransferInformation"];
                    TransferInformation TransferInfo = new TransferInformation();

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
                    GeneralInformation GeneralInfo = new GeneralInformation();
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
                    FarmInformation FarmInfo = new FarmInformation();
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
                    ErfInformation ErfInfo = new ErfInformation();
                    JToken ErfInfoExists = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount]["ErfInformation"];
                    if (ErfInfoExists != null)
                    {
                        ErfInfo.Number = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].ErfInformation.Number;
                        ErfInfo.PortionNumber = rootObject.ResponseObject.PropertyInformation.Properties[PropertyCount].ErfInformation.PortionNumber;

                        ErfList.Add(ErfInfo);
                    }
                }
                ViewData["ErfList"] = ErfList;
            }

            return View();
        }

        public ActionResult LightStoneBusiness()
        {
            return View();
        }

        [HttpPost]
        [ActionName("PDF")]
        public ActionResult Index_Post(CompanyInformation information)
        {
            Document pdfDoc = new Document(PageSize.A4, 25, 25, 25, 15);
            PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();

            //Top Heading
            Chunk chunk = new Chunk(information.CompanyName, FontFactory.GetFont("Arial", 20, Font.BOLDITALIC, BaseColor.MAGENTA));
            pdfDoc.Add(chunk);

            //Horizontal Line
            Paragraph line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            //Table
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;
            //0=Left, 1=Centre, 2=Right
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell no 1
            PdfPCell cell = new PdfPCell();
            cell.Border = 0;
            Image image = Image.GetInstance(Server.MapPath("~/Content/img/jcred_logo.png"));
            image.ScaleAbsolute(200, 150);
            cell.AddElement(image);
            table.AddCell(cell);

            //Cell no 2
            chunk = new Chunk("Name: Mrs. Salma Mukherji,\nAddress: Latham Village, Latham, New York, US, \nOccupation: Nurse, \nAge: 35 years", FontFactory.GetFont("Arial", 15, Font.NORMAL, BaseColor.PINK));
            cell = new PdfPCell();
            cell.Border = 0;
            cell.AddElement(chunk);
            table.AddCell(cell);

            //Add table to document
            pdfDoc.Add(table);

            //Horizontal Line
            line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            //Table
            table = new PdfPTable(5);
            table.WidthPercentage = 100;
            table.HorizontalAlignment = 0;
            table.SpacingBefore = 20f;
            table.SpacingAfter = 30f;

            //Cell
            cell = new PdfPCell();
            chunk = new Chunk("This Month's Transactions of your Credit Card");
            cell.AddElement(chunk);
            cell.Colspan = 5;
            cell.BackgroundColor = BaseColor.PINK;
            table.AddCell(cell);

            table.AddCell("S.No");
            table.AddCell("NYC Junction");
            table.AddCell("Item");
            table.AddCell("Cost");
            table.AddCell("Date");

            table.AddCell("1");
            table.AddCell("David Food Store");
            table.AddCell("Fruits & Vegetables");
            table.AddCell("$100.00");
            table.AddCell("June 1");

            table.AddCell("2");
            table.AddCell("Child Store");
            table.AddCell("Diaper Pack");
            table.AddCell("$6.00");
            table.AddCell("June 9");

            table.AddCell("3");
            table.AddCell("Punjabi Restaurant");
            table.AddCell("Dinner");
            table.AddCell("$29.00");
            table.AddCell("June 15");

            table.AddCell("4");
            table.AddCell("Wallmart Albany");
            table.AddCell("Grocery");
            table.AddCell("$299.50");
            table.AddCell("June 25");

            table.AddCell("5");
            table.AddCell("Singh Drugs");
            table.AddCell("Back Pain Tablets");
            table.AddCell("$14.99");
            table.AddCell("June 28");

            pdfDoc.Add(table);

            Paragraph para = new Paragraph();
            para.Add("Hello Salma,\n\nThank you for being our valuable customer. We hope our letter finds you in the best of health and wealth.\n\nYours Sincerely, \nBank of America");
            pdfDoc.Add(para);

            //Horizontal Line
            line = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            pdfDoc.Add(line);

            para = new Paragraph();
            para.Add("This PDF is generated using iTextSharp. You can read the turorial:");
            para.SpacingBefore = 20f;
            para.SpacingAfter = 20f;
            pdfDoc.Add(para);

            //Creating link
            chunk = new Chunk("How to Create a Pdf File");
            chunk.Font = FontFactory.GetFont("Arial", 25, Font.BOLD, BaseColor.RED);
            chunk.SetAnchor("http://www.yogihosting.com/create-pdf-asp-net-mvc/");
            pdfDoc.Add(chunk);

            pdfWriter.CloseStream = false;
            pdfDoc.Close();
            Response.Buffer = true;
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Credit-Card-Report.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

            return View();
        }

        private List<CompanyInformation> getCompanyList(IRestResponse response)
        {
            List<CompanyInformation> lst = new List<CompanyInformation>();

            dynamic respContent = JObject.Parse(response.Content);
            List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();

            foreach (ResponseObject responseObject in rawList)
            {
                lst.Add(responseObject.CompanyInformation);
            }

            return lst;
        }

        private List<Directors> getCompanyDetails(IRestResponse response)
        {
            List<Directors> lst = new List<Directors>();

            dynamic respContent = JsonConvert.DeserializeObject(response.Content);
            List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();
            ViewData["Directors"] = rawList;
            //foreach (JObject responseObject in rawList)
            //foreach (ResponseObject responseObject in rawList)
            //{
            //    lst.Add(responseObject.Directors);
            //}

            return lst;
        }
    }
}