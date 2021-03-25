using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using searchworks.client.Individual;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace searchworks.client.Controllers
{
    public class IndividualController : Controller
    {
        //string serverIp = "localhost";
        //string username = "root";
        //string password = "";
        //string databaseName = "jcred";

        //string serverIp = "197.242.148.16";
        //string username = "cykgxznt_admin";
        //string password = "Jcred123@";
        //string databaseName = "cykgxznt_jcred";

        string serverIp = "jcred-azpoc.mysql.database.azure.com";
        string username = "jcredadmin@jcred-azpoc";
        string password = "vVHBF2XdhPfWsC";
        string databaseName = "jcred";
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

            System.Diagnostics.Debug.WriteLine("EQ: " + eqType);
            System.Diagnostics.Debug.WriteLine("SE: " + seaType);


            if (seaType == "nameandidnumber" && eqType == "verification")
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

                //System.Diagnostics.Debug.WriteLine(log.Email);
                //System.Diagnostics.Debug.WriteLine(log.Password);

                DateTime time = DateTime.Now;


                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CSI Person Verification By Name and ID Number";
                string action = "Name:" + name + "; Surname:" + sur + "; ID:" + id;
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
                var url = "https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/nameidnumber/";

                //create RestSharp client and POST request object
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                //request headers
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                //object containing input parameter data for company() API method
                var apiInput = new
                {
                    sessionToken = authtoken,
                    reference = us,//search reference: probably store in logs
                    idNumber = id,
                    firstName = name,
                    surname = sur



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

                JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
                Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                JToken token = JToken.Parse(response.Content);




                System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                ViewData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                ViewData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                ViewData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                ViewData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;

                //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                //extract list of companies returned

                //PersonInformation lst = getIndividualList(response);
                return View();

            }

            if (seaType == "name" && eqType == "verification" || eqType == "trace")
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

                //System.Diagnostics.Debug.WriteLine(log.Email);
                //System.Diagnostics.Debug.WriteLine(log.Password);

                DateTime time = DateTime.Now;


                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CSI Person Verification By Name";
                string action = "Name:" + name + "; Surname:" + sur;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();
                System.Diagnostics.Debug.WriteLine(Session["ID"].ToString());

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);


                ViewData["user"] = Session["Name"].ToString();
                ViewData["date"] = DateTime.Today.ToShortDateString();
                ViewData["ref"] = refe;




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
                var url = "https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/name/";

                //create RestSharp client and POST request object
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                //request headers
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                //object containing input parameter data for company() API method
                var apiInput = new
                {
                    sessionToken = authtoken,
                    reference = us,//search reference: probably store in logs

                    firstName = name,
                    surname = sur



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

                JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

                JToken token = JToken.Parse(response.Content);

                System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                ViewData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                ViewData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                ViewData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                ViewData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                System.Diagnostics.Debug.WriteLine(ViewData["MaritalStatus"]);
                //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                //extract list of companies returned

                //PersonInformation lst = getIndividualList(response);
                return View();

            }

            if (seaType == "idnumber" && eqType == "verification" || eqType == "trace")
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

                //System.Diagnostics.Debug.WriteLine(log.Email);
                //System.Diagnostics.Debug.WriteLine(log.Password);

                DateTime time = DateTime.Now;


                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CSI Person Verification By Name";
                string action = "Name:" + name + "; Surname:" + sur;
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
                var url = "https://uatrest.searchworks.co.za/individual/csipersonrecords/personverification/idnumber/";

                //create RestSharp client and POST request object
                var client = new RestClient(url);
                var request = new RestRequest(Method.POST);

                //request headers
                request.RequestFormat = DataFormat.Json;
                request.AddHeader("Content-Type", "application/json");
                //object containing input parameter data for company() API method
                var apiInput = new
                {
                    sessionToken = authtoken,
                    reference = us,//search reference: probably store in logs
                    idNumber = id,

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

                JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

                JToken token = JToken.Parse(response.Content);

                System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                ViewData["Title"] = rootObject.ResponseObject[0].PersonInformation.Title;
                ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                ViewData["MaritalStatus"] = rootObject.ResponseObject[0].PersonInformation.MaritalStatus;
                ViewData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                ViewData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                System.Diagnostics.Debug.WriteLine(ViewData["MaritalStatus"]);
                //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                //extract list of companies returned

                //PersonInformation lst = getIndividualList(response);
                return View();

            }

            return View();

        }


        public ActionResult CSIPersonalRecordsDetails(string indiID)
        {

            System.Diagnostics.Debug.WriteLine(indiID);

            return View();

            string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                //exit with a warning
            }

            //company search API call
            var url = "https://uatrest.searchworks.co.za/individual/csipersontrace/idnumber/";

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
                idNumber = indiID,




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

            JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

            JToken token = JToken.Parse(response.Content);


            Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
            Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
            Dictionary<string, string> arrayList = new Dictionary<string, string>();
            Dictionary<string, string> arrayList1 = new Dictionary<string, string>();
            List<string> thatlist = new List<string>();
            List<string> thatlist1 = new List<string>();
            Dictionary<int, Dictionary<string, string>> MianArrayList = new Dictionary<int, Dictionary<string, string>>();
            Dictionary<int, Dictionary<string, string>> MianArrayList1 = new Dictionary<int, Dictionary<string, string>>();
            elements = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;
            ViewData["TheCount"] = elements.Count;

            elements1 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;
            ViewData["TheCount"] = elements1.Count;
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
            if (rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeDescription != null)
            {
                for (int count = 0; count < (elements.Count); count++)
                {
                    string TypeDescription = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                    string TypeCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeCode;
                    string Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number;
                    string LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;
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
                    //arrayList.Add(count + "_IdNumber", IdNumber);
                    //arrayList.Add(count + "_Age", Age);
                    //arrayList.Add(count + "_Status", Status);
                    //arrayList.Add(count + "_ResignationDate", ResignationDate);
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
            }

            if (rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName != null)
            {
                for (int count = 0; count < (elements1.Count); count++)
                {
                    string EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName;
                    string Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation;

                    string LastUpdatedDate1 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;
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
                    ViewData["ArrayList1"] = arrayList1;
                    ViewData["thatlist1"] = thatlist1;
                    System.Diagnostics.Debug.WriteLine(count + " arrayList: " + arrayList1);
                    MianArrayList1.Add(count, arrayList1);
                    ViewData[" MianArrayList"] = MianArrayList1;
                    System.Diagnostics.Debug.WriteLine(count + " MianArrayList: " + MianArrayList1);
                    //ViewData["MianArrayList"] = MianArrayList;
                    //ViewData["elements"] = elements;

                    //ViewData["elementsType"] = elements;
                    // ViewData["DirectorID"] = DirectorID;
                    //ViewData["FirstName"] = FirstName;
                    //ViewData["Surname"] = Surname;


                    //System.Diagnostics.Debug.WriteLine(" Director ID "+count+" : "+ DirectorID);
                }
                foreach (KeyValuePair<string, string> item in arrayList1)
                {
                    System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                }
            }

            System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
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

            if (rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus != null)
            {
                ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                ViewData["CauseOfDeath"] = rootObject.ResponseObject.HomeAffairsInformation.CauseOfDeath;
                ViewData["VerifiedDate"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedDate;
                ViewData["VerifiedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus;
            }




            System.Diagnostics.Debug.WriteLine(ViewData["DeceasedStatus"]);
            //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
            //extract list of companies returned

            //PersonInformation lst = getIndividualList(response);




        }

        public ActionResult DatabasePropertyIndividual()
        {
            return View();
        }

        public ActionResult DeedsOfficeRecordsIndividual()
        {
            return View();
        }



        public ActionResult DeedsOfficeRecordsIndividualResults(Deeds deed)
        {
            string name = deed.Firstname;
            string deeds = deed.DeedsOffice;
            string sur = deed.Surname;
            string id = deed.IDNumber;
            string refe = deed.Reference;




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
            request.AddHeader("Content-Type", "application/json");
            //object containing input parameter data for company() API method
            var apiInput = new
            {
                SessionToken = authtoken,
                DeedsOffice = deed,//company name contains: See documentation
                Reference = authtoken,//search reference: probably store in logs
                Surname = sur,
                Firstname = name,
                IDNumber = id,
                Sequestration = "false",

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
            List<DeedsInformation> lst = getCompanyList(response);


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

        private List<DeedsInformation> getCompanyList(IRestResponse response)
        {
            List<DeedsInformation> lst = new List<DeedsInformation>();

            dynamic respContent = JObject.Parse(response.Content);

            List<ResponseObject> rawList = respContent.ResponseObject.ToObject<List<ResponseObject>>();
            System.Diagnostics.Debug.WriteLine("YList: " + rawList);
            //var rawList = respContent.ResponseObject;

            //foreach (JObject responseObject in rawList)
            foreach (ResponseObject responseObject in rawList)
            {
                //ResponseObject res = responseObject.ToObject<ResponseObject>;
                //res.SearchInformation = responseObject.SearchInformation;
                lst.Add(responseObject.DeedsInformation);
            }


            System.Diagnostics.Debug.WriteLine("List: " + lst);
            return lst;

        }

        public ActionResult DOTSRecords()
        {
            return View();
        }
    }
}