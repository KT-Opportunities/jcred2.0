using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using searchworks.client.Company;
using searchworks.client.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;


namespace searchworks.client.Controllers
{
    public class HomeController : Controller
    {
        string serverIp = "localhost";
        string username = "root";
        string password = "";
        string databaseName = "jcred";

        //string serverIp = "197.242.148.16";
        //string username = "cykgxznt_admin";
        //string password = "Jcred123@";
        //string databaseName = "cykgxznt_jcred";


        // string serverIp = "jcred-azpoc.mysql.database.azure.com";
        // string username = "jcredadmin@jcred-azpoc";
        // string password = "vVHBF2XdhPfWsC";
        // string databaseName = "jcred";
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Login(Login log)
        {
            //string serverIp = "localhost";
            //string username = "root";
            //string password = "";
            //string databaseName = "jcred";

            //string serverIp = "197.242.148.16";
            ////string username = "cykgxznt_user";
            //string username = "cykgxznt_admin";
            //string password = "jcred123";
            //string databaseName = "cykgxznt_jcred";
            //string port = "3306";

            //string serverIp = "localhost";

            //string username = "familzkk_user";
            //string password = "familylaw1";
            //string databaseName = "familzkk_familylaw";
            //string port = "3306";




            string dbConnectionString = string.Format("server={0};database={1};uid={2};pwd={3};", serverIp, databaseName, username, password, databaseName);
            //string connsqlstring = "SERVER=" + serverIp + ";PORT=" + port + ";USER=" + username + ";PASSWORD=" + password + ";DATABASE=" + databaseName + "Persist Security Info= true;Charset=utf8";


            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);





            //System.Diagnostics.Debug.WriteLine(connsqlstring);
            System.Diagnostics.Debug.WriteLine(log.Password);
            System.Diagnostics.Debug.WriteLine(log.Email);




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
                    System.Diagnostics.Debug.WriteLine(DateTime.Today.ToShortDateString());

                    conn.Close();
                    DateTime time = DateTime.Now;


                    string date_add = DateTime.Today.ToShortDateString();
                    string time_add = time.ToString("T");
                    string page = "Login";
                    string action = "Email:" + log.Email;
                    string user_id = Session["ID"].ToString();
                    string us = Session["Name"].ToString();

                    System.Diagnostics.Debug.WriteLine(date_add);
                    System.Diagnostics.Debug.WriteLine(time_add);
                    System.Diagnostics.Debug.WriteLine(page);
                    System.Diagnostics.Debug.WriteLine(action);
                    System.Diagnostics.Debug.WriteLine(user_id);
                    System.Diagnostics.Debug.WriteLine(us);




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







        }

        public ActionResult Logs()
        {

            //string serverIp = "localhost";
            //string username = "root";
            //string password = "";
            //string databaseName = "jcred";

            //string serverIp = "197.242.148.16";
            //string username = "cykgxznt_admin";
            //string password = "jcred123";
            //string databaseName = "cykgxznt_jcred";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

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

                    foreach (string item in thatlist)
                    {
                        System.Diagnostics.Debug.WriteLine(item);
                    }
                }

                foreach (KeyValuePair<string, string> item in ArrayList)
                {
                    System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
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
            //string serverIp = "localhost";
            //string username = "root";
            //string password = "";
            //string databaseName = "jcred";

            //string serverIp = "197.242.148.16";
            ////string username = "cykgxznt_user";
            //string username = "cykgxznt_admin";
            //string password = "jcred123";
            //string databaseName = "cykgxznt_jcred";
            //string port = "3306";


            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            System.Diagnostics.Debug.WriteLine("Post:" + ad.email);
            System.Diagnostics.Debug.WriteLine(ad.password);

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

                    System.Diagnostics.Debug.WriteLine("Email: " + userEmail);
                    System.Diagnostics.Debug.WriteLine("Name: " + name);
                    System.Diagnostics.Debug.WriteLine("Num: " + ph);


                    thatlist.Add(name);
                    thatlist.Add(userEmail);
                    thatlist.Add(ph);
                    thatlist.Add(dateOfBirth);
                    thatlist.Add(gen);
                    thatlist.Add(ty);
                    thatlist.Add(or);

                    foreach (string item in thatlist)
                    {
                        System.Diagnostics.Debug.WriteLine(item);
                    }
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

        public ActionResult Landing()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //https://uatrest.searchworks.co.za/auth/login/

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
            System.Diagnostics.Debug.WriteLine(loginToken);
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
            string name = search.CompanyName;
            string pdf = search.PDF;
            System.Diagnostics.Debug.WriteLine(pdf);
            string strCompanyName = name;
            string refe = search.Reference;




            string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }

            //company search API call
            var url = "https://uatrest.searchworks.co.za/cipc/company/";

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
                CipcSearchBy = 2,//company name contains: See documentation
                Reference = authtoken,//search reference: probably store in logs
                CompanyName = strCompanyName,
                RegistrationNumber = ""
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
            ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;

            //extract list of companies returned
            List<CompanyInformation> lst = getCompanyList(response);


            //string serverIp = "localhost";
            //string username = "root";
            //string password = "";
            //string databaseName = "jcred";

            //string serverIp = "197.242.148.16";
            //string username = "cykgxznt_admin";
            //string password = "jcred123";
            //string databaseName = "cykgxznt_jcred";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            //System.Diagnostics.Debug.WriteLine(log.Email);
            //System.Diagnostics.Debug.WriteLine(log.Password);

            DateTime time = DateTime.Now;


            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CIPC Company Records";
            string action = "Company Name:" + name;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            //System.Diagnostics.Debug.WriteLine(date_add);
            //System.Diagnostics.Debug.WriteLine(time_add);
            //System.Diagnostics.Debug.WriteLine(page);
            //System.Diagnostics.Debug.WriteLine(action);
            //System.Diagnostics.Debug.WriteLine(user_id);
            //System.Diagnostics.Debug.WriteLine(us);

            ViewData["user"] = Session["Name"].ToString();
            ViewData["date"] = DateTime.Today.ToShortDateString();
            ViewData["ref"] = refe;
            System.Diagnostics.Debug.WriteLine(refe);
            ViewData["ComName"] = name;




            string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);



            var reader2 = cmd2.ExecuteReader();

            conn.Close();



            return View(lst);
        }

        private List<CompanyInformation> getCompanyList(IRestResponse response)
        {
            List<CompanyInformation> lst = new List<CompanyInformation>();

            dynamic respContent = JObject.Parse(response.Content);

            List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();
            System.Diagnostics.Debug.WriteLine("YList: " + rawList);
            //var rawList = respContent.ResponseObject;

            //foreach (JObject responseObject in rawList)
            foreach (ResponseObject responseObject in rawList)
            {
                //ResponseObject res = responseObject.ToObject<ResponseObject>;
                //res.SearchInformation = responseObject.SearchInformation;
                lst.Add(responseObject.CompanyInformation);
            }


            System.Diagnostics.Debug.WriteLine("List: " + lst);
            return lst;

        }


        public ActionResult CIPCCompanyDetails(string comID)
        {

            System.Diagnostics.Debug.WriteLine(comID);



            string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }

            //company search API call
            var url = "https://uatrest.searchworks.co.za/cipc/company/companyid/";

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
            System.Diagnostics.Debug.WriteLine("elements Length: " + elements.Count);
            foreach (object element in elements)
            {
                //ViewData["DirectorName"] = rootObject.ResponseObject.Directors[0].DirectorID;
                //System.Diagnostics.Debug.WriteLine("element: "+element);

                // JObject.Parse(element);
                //System.Diagnostics.Debug.WriteLine("element: " + element["Gender"]);
                //System.Diagnostics.Debug.WriteLine(JsonConvert.DeserializeObject<System.Collections.ArrayList>(element));

                //ViewData["DirectorName"] = element.DirectorID;
                //System.Diagnostics.Debug.WriteLine(ViewData["DirectorName"]);
            }
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
                arrayList.Add(count + "_DirectorID", DirectorID);
                arrayList.Add(count + "_FirstName", FirstName);
                arrayList.Add(count + "_Surname", Surname);
                arrayList.Add(count + "_Gender", Gender);
                arrayList.Add(count + "_IdNumber", IdNumber);
                arrayList.Add(count + "_Age", Age);
                arrayList.Add(count + "_Status", Status);
                arrayList.Add(count + "_ResignationDate", ResignationDate);
                ViewData["ArrayList"] = arrayList;
                ViewData["thatlist"] = thatlist;

                System.Diagnostics.Debug.WriteLine(count + " arrayList: " + arrayList);
                MianArrayList.Add(count, arrayList);
                ViewData[" MianArrayList"] = MianArrayList;
                System.Diagnostics.Debug.WriteLine(count + " MianArrayList: " + MianArrayList);
                //ViewData["MianArrayList"] = MianArrayList;
                //ViewData["elements"] = elements;

                //ViewData["elementsType"] = elements;
                // ViewData["DirectorID"] = DirectorID;
                //ViewData["FirstName"] = FirstName;
                //ViewData["Surname"] = Surname;


                //System.Diagnostics.Debug.WriteLine(" Director ID "+count+" : "+ DirectorID);
            }
            foreach (KeyValuePair<string, string> item in arrayList)
            {
                System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
            }

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
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



            //ViewData["Director"] = rootObject.ResponseObject.Directors[1].FirstName[1];


            //extract list of companies returned
            //List<Directors> lst = getCompanyDetails(response);



            return View();
        }

        private List<Directors> getCompanyDetails(IRestResponse response)
        {
            List<Directors> lst = new List<Directors>();

            dynamic respContent = JsonConvert.DeserializeObject(response.Content);
            List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();
            //var rawList = respContent.ResponseObject;

            //foreach (JObject responseObject in rawList)
            //foreach (ResponseObject responseObject in rawList)
            //{
            //    //ResponseObject res = responseObject.ToObject<ResponseObject>;
            //    //res.SearchInformation = responseObject.SearchInformation;
            //    lst.Add(responseObject.Directors);
            //}

            return lst;
        }

        public ActionResult CSICompanyRecords()
        {
            return View();
        }

        public ActionResult CSICompanyRecordsResults(Search search)
        {
            string name = search.CompanyName;
            string type = search.seaType;
            string comID = search.CompanyID;
            string regNum = search.RegistrationNumber;
            string refe = search.Reference;

            string strCompanyName = name;
            ViewData["type"] = type;


            if (type == "name")
            {

                //string serverIp = "localhost";
                //string username = "root";
                //string password = "";
                //string databaseName = "jcred";

                //string serverIp = "197.242.148.16";
                //string username = "cykgxznt_admin";
                //string password = "jcred123";
                //string databaseName = "cykgxznt_jcred";

                string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                //System.Diagnostics.Debug.WriteLine(log.Email);
                //System.Diagnostics.Debug.WriteLine(log.Password);

                DateTime time = DateTime.Now;


                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CSI Company Trace By Name";
                string action = "Company Name:" + name;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);

                ViewData["user"] = Session["Name"].ToString();
                ViewData["date"] = DateTime.Today.ToShortDateString();
                ViewData["ref"] = refe;
                ViewData["ComName"] = name;



                string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

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
                var url = "https://uatrest.searchworks.co.za/company/csicompany/companytrace/companyname/";

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

                    //extract list of companies returned
                    List<CompanyInformation> lst = getCSICompanyList(response);
                    return View(lst);
                }




            }

            else if (type == "comID")
            {

                //string serverIp = "localhost";
                //string username = "root";
                //string password = "";
                //string databaseName = "jcred";

                //string serverIp = "197.242.148.16";
                //string username = "cykgxznt_admin";
                //string password = "jcred123";
                //string databaseName = "cykgxznt_jcred";

                string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                //System.Diagnostics.Debug.WriteLine(log.Email);
                //System.Diagnostics.Debug.WriteLine(log.Password);

                DateTime time = DateTime.Now;


                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CSI Company Trace By CompanyID";
                string action = "Company ID:" + comID;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);

                ViewData["user"] = Session["Name"].ToString();
                ViewData["date"] = DateTime.Today.ToShortDateString();
                ViewData["ref"] = refe;
                ViewData["ComName"] = comID;



                string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

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
                var url = "https://uatrest.searchworks.co.za/company/csicompany/companytrace/companyid/";

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

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                var mes = ViewData["ResponseMessage"].ToString();
                System.Diagnostics.Debug.WriteLine("Resp Message: " + mes);
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

                    ViewData["type"] = type;
                    ViewData["ComID"] = rootObject.ResponseObject["CompanyInformation"].CompanyID;
                    ViewData["ComReg"] = rootObject.ResponseObject["CompanyInformation"].CompanyRegistrationNumber;
                    ViewData["ComName"] = rootObject.ResponseObject["CompanyInformation"].CompanyName;
                    ViewData["ComTransName"] = rootObject.ResponseObject["CompanyInformation"].CompanyTranslatedName;
                    ViewData["ComRegDate"] = rootObject.ResponseObject["CompanyInformation"].RegistrationDate;
                    ViewData["ComStatCode"] = rootObject.ResponseObject["CompanyInformation"].CompanyStatusCode;
                    ViewData["ComStat"] = rootObject.ResponseObject["CompanyInformation"].CompanyStatus;



                    return View();
                }
            }

            else if (type == "regNum")
            {

                //string serverIp = "localhost";
                //string username = "root";
                //string password = "";
                //string databaseName = "jcred";

                //string serverIp = "197.242.148.16";
                //string username = "cykgxznt_admin";
                //string password = "jcred123";
                //string databaseName = "cykgxznt_jcred";

                string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                //System.Diagnostics.Debug.WriteLine(log.Email);
                //System.Diagnostics.Debug.WriteLine(log.Password);

                DateTime time = DateTime.Now;


                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CSI Company Trace By Registration Number";
                string action = "Registration Number:" + regNum;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);

                ViewData["user"] = Session["Name"].ToString();
                ViewData["date"] = DateTime.Today.ToShortDateString();
                ViewData["ref"] = refe;
                ViewData["ComName"] = regNum;




                string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

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
                var url = "https://uatrest.searchworks.co.za/company/csicompany/companytrace/registrationnumber/";

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

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                var mes = ViewData["ResponseMessage"].ToString();
                System.Diagnostics.Debug.WriteLine("Resp Message: " + mes);
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

                    ViewData["type"] = type;
                    ViewData["ComID"] = rootObject.ResponseObject["CompanyInformation"].CompanyID;
                    ViewData["ComID2"] = rootObject.ResponseObject["CompanyInformation"];
                    System.Diagnostics.Debug.WriteLine("Com Message: " + ViewData["ComID"]);
                    System.Diagnostics.Debug.WriteLine("Com2 Message: " + ViewData["ComID2"]);
                    ViewData["ComReg"] = rootObject.ResponseObject["CompanyInformation"].CompanyRegistrationNumber;
                    ViewData["ComName"] = rootObject.ResponseObject["CompanyInformation"].CompanyName;
                    ViewData["ComTransName"] = rootObject.ResponseObject["CompanyInformation"].CompanyTranslatedName;
                    ViewData["ComRegDate"] = rootObject.ResponseObject["CompanyInformation"].RegistrationDate;
                    ViewData["ComStatCode"] = rootObject.ResponseObject["CompanyInformation"].CompanyStatusCode;
                    ViewData["ComStat"] = rootObject.ResponseObject["CompanyInformation"].CompanyStatus;



                    return View();
                }
            }

            return View();

        }

        private List<CompanyInformation> getCSICompanyList(IRestResponse response)
        {
            List<CompanyInformation> lst = new List<CompanyInformation>();

            dynamic respContent = JObject.Parse(response.Content);

            List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();
            //var rawList = respContent.ResponseObject;

            //foreach (JObject responseObject in rawList)
            foreach (ResponseObject responseObject in rawList)
            {
                //ResponseObject res = responseObject.ToObject<ResponseObject>;
                //res.SearchInformation = responseObject.SearchInformation;
                lst.Add(responseObject.CompanyInformation);
            }



            return lst;
        }

        public ActionResult DatabasePropertyCompany()
        {
            return View();
        }

        public ActionResult DeedsOfficeRecordsCompany()
        {
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



    }

}