using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using searchworks.client.Credit;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace searchworks.client.Controllers
{
    public class CreditController : Controller
    {

        string serverIp = "localhost";
        string username = "root";
        string password = "";
        string databaseName = "jcred";

        //string serverIp = "197.242.148.16";
        //string username = "cykgxznt_admin";
        //string password = "Jcred123@";
        //string databaseName = "cykgxznt_jcred";

        //string serverIp = "jcred-azpoc.mysql.database.azure.com";
        //string username = "jcredadmin@jcred-azpoc";
        //string password = "vVHBF2XdhPfWsC";
        //string databaseName = "jcred";

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
            System.Diagnostics.Debug.WriteLine("Login Token: " + loginToken);

            return loginToken;
        }

        public bool tokenValid(string token)
        {
            bool tokenIsValid = true;

            return tokenIsValid;
        }
        public ActionResult CombinedCreditReport()
        {
            return View();
        }

        public ActionResult CombinedCreditReportResults(Search search)
        {
            string id = search.IDNumber;
            string name = search.FirstName;
            string sur = search.Surname;
            int er = search.EnquiryReason;

            string refe = search.Reference;
            ViewData["refe"] = name + " " + sur;

            System.Diagnostics.Debug.WriteLine(id);
            System.Diagnostics.Debug.WriteLine(er);


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
            string page = "Combined Credit Report";
            string action = "Name:" + name + "; Surname: " + sur + "; Equiry Reason:" + er + "; ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/combinedreport/consumer/";

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
                EnquiryReason = er,
                IDNumber = id,
                FirstName = name,
                Surname = sur





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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            //ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;


            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["CompuScanMessage"] = rootObject.ResponseObject.CombinedCreditInformation["CompuScan"];
                System.Diagnostics.Debug.WriteLine(ViewData["CompuScanMessage"]);
                ViewData["ExperianMessage"] = rootObject.ResponseObject.CombinedCreditInformation.Experian;
                ViewData["TransUnion"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnion;
                ViewData["XDSMessage"] = rootObject.ResponseObject.CombinedCreditInformation.XDS;

                //
                if (ViewData["CompuScanMessage"].ToString() == "CONSUMER MATCH")
                {
                    //personaInformantion
                    ViewData["ComDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.DateOfBirth;
                    ViewData["ComFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.FirstName;
                    ViewData["ComSurname"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Surname;
                    ViewData["ComIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.IDNumber;
                    ViewData["ComGender"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Gender;
                    ViewData["ComAge"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Age;
                    ViewData["ComVerificationStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.VerificationStatus;


                    //CreditInformation
                    ViewData["ComDelphiScore"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScore;
                    ViewData["ComRisk"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.Risk;
                    ViewData["ComDelphiScoreChartURL"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScoreChartURL;

                    ViewData["ComAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Accounts;
                    ViewData["ComEnquiries"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Enquiries;
                    ViewData["ComJudgments"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Judgments;
                    ViewData["ComNotices"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Notices;
                    ViewData["ComBankDefaults"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.BankDefaults;
                    ViewData["ComDefaults"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Defaults;
                    ViewData["ComCollections"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Collections;
                    ViewData["ComDirectors"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Directors;
                    ViewData["ComAddresses"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Addresses;
                    ViewData["ComTelephones"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Telephones;
                    ViewData["ComOccupants"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Occupants;
                    ViewData["ComEmployers"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Employers;
                    ViewData["ComTraceAlerts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.TraceAlerts;
                    ViewData["ComPaymentProfiles"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.PaymentProfiles;
                    ViewData["ComOwnEnquiries"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.OwnEnquiries;

                    ViewData["ComAdminOrders"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.AdminOrders;
                    ViewData["ComPossibleMatches"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.PossibleMatches;
                    ViewData["ComDefiniteMatches"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.DefiniteMatches;
                    ViewData["ComLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Loans;
                    ViewData["ComFraudAlerts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.FraudAlerts;
                    ViewData["ComCompanies"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Companies;
                    ViewData["ComProperties"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Properties;
                    ViewData["ComDocuments"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Documents;
                    ViewData["ComDemandLetters"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.DemandLetters;
                    ViewData["ComTrusts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Trusts;
                    ViewData["ComBondsBonds"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.BondsBonds;
                    ViewData["ComDeeds"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Deeds;
                    ViewData["ComPublicDefaults"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.PublicDefaults;
                    ViewData["ComNLRAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.NLRAccounts;
                    ViewData["ComApplicationDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DebtReviewStatus.ApplicationDate;


                    //ConsumerStatistics
                    ViewData["ComHighestJudgment"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.HighestJudgment;
                    ViewData["ComRevolvingAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                    ViewData["ComInstalmentAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                    ViewData["ComOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.OpenAccounts;
                    ViewData["ComAdverseAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.AdverseAccounts;


                    //NLRStats
                    ViewData["ComNLRActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                    ViewData["ComNLRClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                    ViewData["ComNLRWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                    ViewData["ComNLRBalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                    ViewData["ComNLRCumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;


                    //CCAStats
                    ViewData["ComCCAActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                    ViewData["ComCCAClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                    ViewData["ComCCAWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                    ViewData["ComCCABalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                    ViewData["ComCCACumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;


                    //NLR12Months
                    ViewData["ComNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                    ViewData["ComNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                    ViewData["ComNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                    ViewData["ComNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;


                    //NLR24Months
                    ViewData["ComNLR24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                    ViewData["ComNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                    ViewData["ComNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                    ViewData["ComNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;


                    //NLR36Months
                    ViewData["ComNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                    ViewData["ComNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                    ViewData["ComNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                    ViewData["ComNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;


                    //CCA12Months
                    ViewData["ComCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                    ViewData["ComCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                    ViewData["ComCCA12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                    ViewData["ComCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;


                    //CCA24Months
                    ViewData["ComCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                    ViewData["ComCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                    ViewData["ComCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                    ViewData["ComCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;


                    //CCA36Months
                    ViewData["ComCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                    ViewData["ComCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                    ViewData["ComCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                    ViewData["ComCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;

                }
                else
                {
                    ViewData["CompuScanMessage"] = "No Match";
                }



                if (ViewData["ExperianMessage"].ToString() == "CONSUMER MATCH")
                {
                    //PersonInformation
                    ViewData["ExDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.DateOfBirth;
                    ViewData["ExFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.FirstName;
                    ViewData["ExSurname"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Surname;
                    ViewData["ExIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.IDNumber;
                    ViewData["ExGender"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Gender;
                    ViewData["ExAge"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Age;
                    ViewData["ExMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.MaritalStatus;
                    ViewData["ExMiddleName1"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.MiddleName1;
                    ViewData["ExReference"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Reference;
                    //ViewData["ExPhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.PhysicalAddress;


                    //HomeAffairsInformation
                    ViewData["ExIDVerified"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.IDVerified;
                    ViewData["ExSurnameVerified"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.SurnameVerified;
                    ViewData["ExInitialsVerified"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.InitialsVerified;



                    //CreditInformation
                    ViewData["ExDelphiScoreChartURL"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DelphiScoreChartURL;
                    ViewData["ExDelphiScore"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DelphiScore;
                    ViewData["ExFlagCount"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.FlagCount;
                    ViewData["ExFlagDetails"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.FlagDetails;





                    ViewData["ExAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Accounts;
                    ViewData["ExEnquiries"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Enquiries;
                    ViewData["ExJudgments"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Judgments;
                    ViewData["ExNotices"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Notices;
                    ViewData["ExBankDefaults"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.BankDefaults;
                    ViewData["ExDefaults"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Defaults;
                    ViewData["ExCollections"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Collections;
                    ViewData["ExDirectors"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Directors;
                    ViewData["ExAddresses"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Addresses;
                    ViewData["ExTelephones"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Telephones;
                    ViewData["ExOccupants"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Occupants;
                    ViewData["ExEmployers"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Employers;
                    ViewData["ExTraceAlerts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.TraceAlerts;
                    ViewData["ExPaymentProfiles"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.PaymentProfiles;
                    ViewData["ExOwnEnquiries"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.OwnEnquiries;

                    ViewData["ExAdminOrders"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.AdminOrders;
                    ViewData["ExPossibleMatches"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.PossibleMatches;
                    ViewData["ExDefiniteMatches"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.DefiniteMatches;
                    ViewData["ExLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Loans;
                    ViewData["ExFraudAlerts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.FraudAlerts;
                    ViewData["ExCompanies"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Companies;
                    ViewData["ExProperties"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Properties;
                    ViewData["ExDocuments"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Documents;
                    ViewData["ExDemandLetters"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.DemandLetters;
                    ViewData["ExTrusts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Trusts;
                    ViewData["ExBondsBonds"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.BondsBonds;
                    ViewData["ExDeeds"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Deeds;
                    ViewData["ExPublicDefaults"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.PublicDefaults;
                    ViewData["ExNLRAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.NLRAccounts;
                    ViewData["ExApplicationDate"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DebtReviewStatus.ApplicationDate;


                    //ConsumerStatistics
                    ViewData["ExHighestJudgment"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.HighestJudgment;
                    ViewData["ExRevolvingAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                    ViewData["ExInstalmentAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                    ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.OpenAccounts;
                    ViewData["ExAdverseAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.AdverseAccounts;
                    ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.OpenAccounts;


                    //NLRStats
                    ViewData["ExNLRActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                    ViewData["ExNLRClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                    ViewData["ExNLRWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                    ViewData["ExNLRBalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                    ViewData["ExNLRCumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;


                    //CCAStats
                    ViewData["ExCCAActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                    ViewData["ExCCAClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                    ViewData["ExCCAWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                    ViewData["ExCCABalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                    ViewData["ExCCACumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;


                    //NLR12Months
                    ViewData["ExNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                    ViewData["ExNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                    ViewData["ExNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                    ViewData["ExNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;


                    //NLR24Months
                    ViewData["ExNLR24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                    ViewData["ExNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                    ViewData["ExNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                    ViewData["ExNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;


                    //NLR36Months
                    ViewData["ExNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                    ViewData["ExNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                    ViewData["ExNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                    ViewData["ExNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;


                    //CCA12Months
                    ViewData["ExCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                    ViewData["ExCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                    ViewData["ExCCA12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                    ViewData["ExCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;


                    //CCA24Months
                    ViewData["ExCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                    ViewData["ExCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                    ViewData["ExCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                    ViewData["ExCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;


                    //CCA36Months
                    ViewData["ExCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                    ViewData["ExCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                    ViewData["ExCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                    ViewData["ExCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;



                }
                else
                {
                    ViewData["Experian"] = "No Match";
                }


                if (rootObject.ResponseObject.CombinedCreditInformation.TransUnion == "CONSUMER MATCH")
                {

                }
                else
                {
                    ViewData["TransUnion"] = "No Match";
                }




                if (ViewData["XDSMessage"].ToString() == "CONSUMER MATCH")
                {

                    System.Diagnostics.Debug.WriteLine(ViewData["CompuScan"]);
                    System.Diagnostics.Debug.WriteLine(ViewData["Experian"]);
                    System.Diagnostics.Debug.WriteLine(ViewData["TransUnion"]);

                    System.Diagnostics.Debug.WriteLine(ViewData["BuyerName"]);



                    //Person Information:
                    ViewData["PersonID"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.PersonID;
                    ViewData["Title"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Title;
                    ViewData["DateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.DateOfBirth;
                    ViewData["Initials"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Initials;
                    ViewData["IDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.IDNumber;
                    ViewData["MaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MaritalStatus;
                    ViewData["Gender"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Gender;
                    ViewData["MiddleName1"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MiddleName1;
                    ViewData["Fullname"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Fullname;

                    System.Diagnostics.Debug.WriteLine(ViewData["PersonID"]);


                    //COntact Information:
                    //ViewData["EmailAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.EmailAddress;
                    //ViewData["MobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.MobileNumber;
                    ViewData["PhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PhysicalAddress;
                    ViewData["PostalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PostalAddress;

                    //HomeAffairs Information:
                    ViewData["DeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.DeceasedStatus;
                    ViewData["DeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.DeceasedDate;
                    ViewData["VerifiedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.VerifiedStatus;


                    //FraudIndicatorSummary:
                    ViewData["SAFPSListing"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.SAFPSListing;
                    ViewData["EmployerFraudVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.EmployerFraudVerification;
                    ViewData["ProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.ProtectiveVerification;

                    if (rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].CompanyName != null)
                    {
                        //DirectorshipInformation242px;
                        ViewData["CompanyName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].CompanyName;
                        ViewData["CompanyRegistrationNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].CompanyRegistrationNumber;
                        ViewData["AppointmentDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].AppointmentDate;
                        ViewData["PhysicalAddressD"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].PhysicalAddress;

                        System.Diagnostics.Debug.WriteLine(ViewData["CompanyName"]);

                        //PropertyInformation
                        ViewData["BuyerName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].BuyerInformation.Fullname;
                        ViewData["BuyerIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].BuyerInformation.IDNumber;
                        ViewData["BuyerMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].BuyerInformation.MaritalStatus;
                        ViewData["BuyerPropertySharePercentage"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].BuyerInformation.PropertySharePercentage;


                        ViewData["SellerName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].SellerInformation.Fullname;
                        ViewData["SellerIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].SellerInformation.IDNumber;
                        ViewData["SellerMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].SellerInformation.MaritalStatus;


                        ViewData["Institution"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].BondInformation.Institution;
                        ViewData["BondNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].BondInformation.BondNumber;
                        ViewData["BondAmount"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].BondInformation.BondAmount;


                        //TransferInformation
                        ViewData["AttorneyFirmNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].TransferInformation.AttorneyFirmNumber;
                        ViewData["AttorneyFileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].TransferInformation.AttorneyFileNumber;
                        ViewData["TitleDeedFeeAmount"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].TransferInformation.TitleDeedFeeAmount;
                        ViewData["TransferDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].TransferInformation.TransferDate;
                        ViewData["PurchaseDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].TransferInformation.PurchaseDate;
                        ViewData["PurchasePrice"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].TransferInformation.PurchasePrice;
                        ViewData["TitleDeedNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].TransferInformation.TitleDeedNumber;


                        //GeneralInformation
                        ViewData["Municipality"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.Municipality;
                        ViewData["Township"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.Township;
                        ViewData["CityName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.CityName;
                        ViewData["StreetName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.StreetName;
                        ViewData["StreetNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.StreetNumber;
                        ViewData["RegisteredSize"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.RegisteredSize;
                        ViewData["DeedsOfficeName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.DeedsOfficeName;
                        ViewData["OldTitleDeedNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.OldTitleDeedNumber;
                        ViewData["PhysicalAddressG"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.PhysicalAddress;
                        ViewData["StandNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[0].GeneralInformation.StandNumber;
                    }
                }
                else
                {
                    ViewData["XDS"] = "No Match";
                }
            }

            return View();
        }

        public ActionResult CompuScan()
        {
            return View();
        }

        public ActionResult CombinedConsumerTrace()
        {
            return View();
        }

        public ActionResult CombinedConsumerTraceResults(Search comp)
        {
            string id = comp.IDNumber;
            string refe = comp.Reference;
            System.Diagnostics.Debug.WriteLine(id);

            ViewData["refe"] = id;

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
            string page = "Combined Consumer Trace";
            string action = "ID: " + id;
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
            //ViewData["ComName"] = comID;




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
            var url = "https://uatrest.searchworks.co.za/credit/combinedreport/trace/";

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
                IDNumber = id
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {

                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                System.Diagnostics.Debug.WriteLine(ViewData["ResponseMessage"]);

                ViewData["CompuScanMessage"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScan;
                ViewData["TransUnionMessage"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnion;
                ViewData["XDSMessage"] = rootObject.ResponseObject.CombinedCreditInformation.XDS;
                ViewData["VeriCredMessage"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCred;


                if (ViewData["CompuScanMessage"].ToString() == "Found")
                {
                    //Personal Information
                    ViewData["CompuScanDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].DateOfBirth;
                    ViewData["CompuScanFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].FirstName;
                    ViewData["CompuScanSurname"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].Surname;
                    ViewData["CompuScanFullname"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].Fullname;
                    ViewData["CompuScanIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].IDNumber;
                    ViewData["CompuScanGender"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].Gender;
                    ViewData["CompuScanAge"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].Age;
                    ViewData["CompuScanMiddleName1"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].MiddleName1;
                    ViewData["CompuScanMiddleName2"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].MiddleName2;
                    ViewData["CompuScanHasProperties"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["PersonInformation"].HasProperties;

                    //Home Affairs Information
                    ViewData["CompuScanDeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].DeceasedStatus;
                    ViewData["CompuScanDeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].DeceasedDate;
                    ViewData["CompuScanCauseOfDeath"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].CauseOfDeath;
                    ViewData["CompuScanVerifiedDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].VerifiedDate;
                    ViewData["CompuScanVerifiedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].VerifiedStatus;


                    //Credit Information
                    ViewData["CompuScanProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["FraudIndicatorSummary"].ProtectiveVerification;

                    //Historical Information

                    // Address
                    Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory;
                    List<string> thatlist = new List<string>();
                    Dictionary<string, string> arrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                        string Line1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1;
                        string Line2 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2;
                        string Line3 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3;
                        string Line4 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4;
                        string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Line1", Line1);
                        arrayList.Add(count + "_Line2", Line2);
                        arrayList.Add(count + "_Line3", Line3);
                        arrayList.Add(count + "_Line4", Line4);
                        arrayList.Add(count + "_PostalCode", PostalCode);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["ArrayList"] = arrayList;
                        System.Diagnostics.Debug.WriteLine(count + " arrayList: " + arrayList);

                    }

                    foreach (KeyValuePair<string, string> item in arrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }


                    // Telephone
                    Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                    Telelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory;
                    List<string> Telthatlist = new List<string>();
                    Dictionary<string, string> TelarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (Telelements.Count); count++)
                    {
                        string Type = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        string Number = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                        TelarrayList.Add(count + "_Type", Type);
                        TelarrayList.Add(count + "_Numnber", Number);
                        TelarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["TelArrayList"] = TelarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " TelarrayList: " + TelarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in TelarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                    EMelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory;
                    List<string> EMthatlist = new List<string>();
                    Dictionary<string, string> EMarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (EMelements.Count); count++)
                    {
                        string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        string Designation = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                        EMarrayList.Add(count + "_EmployerName", EmployerName);
                        EMarrayList.Add(count + "_Designation", Designation);
                        EMarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["EMArrayList"] = EMarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " EMarrayList: " + EMarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in EMarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("EMKey = {0}, EMValue = {1}", item.Key, item.Value);
                    }

                }

                if (ViewData["TransUnionMessage"].ToString() == "Found")
                {
                    //Personal Information
                    ViewData["TransUnionInfoInformationDate"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].InformationDate;
                    ViewData["TransUnionInfoPersonID"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].PersonID;
                    ViewData["TransUnionInfoTitle"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].Title;
                    ViewData["TransUnionInfoDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].DateOfBirth;
                    ViewData["TransUnionInfoFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].FirstName;
                    ViewData["TransUnionInfoSurname"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].Surname;
                    ViewData["TransUnionInfoFullname"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].Fullname;
                    ViewData["TransUnionInfoIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].IDNumber;
                    ViewData["TransUnionInfoMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].MaritalStatus;
                    ViewData["TransUnionInfoGender"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].Gender;
                    ViewData["TransUnionInfoAge"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].Age;
                    ViewData["TransUnionInfoMiddleName1"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].MiddleName1;
                    ViewData["TransUnionInfoMiddleName2"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].MiddleName2;
                    ViewData["TransUnionInfoDeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].DeceasedDate;
                    ViewData["TransUnionInfoDeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].DeceasedStatus;
                    ViewData["TransUnionInfoSpouseFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].SpouseFirstName;
                    ViewData["TransUnionInfoSpouseSurname"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].SpouseSurname;
                    ViewData["TransUnionInfoNumberOfDependants"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].NumberOfDependants;
                    ViewData["TransUnionInfoHasProperties"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["PersonInformation"].HasProperties;

                    //Contact Information
                    ViewData["TransUnionInfoEmailAddress"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].EmailAddress;
                    ViewData["TransUnionInfoMobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].MobileNumber;
                    ViewData["TransUnionInfoHomeTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].HomeTelephoneNumber;
                    ViewData["TransUnionInfoWorkTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].WorkTelephoneNumber;


                    //Historical Information

                    // Address
                    Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory;
                    List<string> thatlist = new List<string>();
                    Dictionary<string, string> arrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                        string Line1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1;
                        string Line2 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2;
                        string Line3 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3;
                        string Line4 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4;
                        string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Line1", Line1);
                        arrayList.Add(count + "_Line2", Line2);
                        arrayList.Add(count + "_Line3", Line3);
                        arrayList.Add(count + "_Line4", Line4);
                        arrayList.Add(count + "_PostalCode", PostalCode);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["ArrayList"] = arrayList;
                        System.Diagnostics.Debug.WriteLine(count + " arrayList: " + arrayList);

                    }

                    foreach (KeyValuePair<string, string> item in arrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }


                    // Telephone
                    Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                    Telelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory;
                    List<string> Telthatlist = new List<string>();
                    Dictionary<string, string> TelarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (Telelements.Count); count++)
                    {
                        string Type = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        string Number = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                        TelarrayList.Add(count + "_Type", Type);
                        TelarrayList.Add(count + "_Numnber", Number);
                        TelarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["TelArrayList"] = TelarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " TelarrayList: " + TelarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in TelarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                    EMelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory;
                    List<string> EMthatlist = new List<string>();
                    Dictionary<string, string> EMarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (EMelements.Count); count++)
                    {
                        string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        string Designation = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                        EMarrayList.Add(count + "_EmployerName", EmployerName);
                        EMarrayList.Add(count + "_Designation", Designation);
                        EMarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["EMArrayList"] = EMarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " EMarrayList: " + EMarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in EMarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("EMKey = {0}, EMValue = {1}", item.Key, item.Value);
                    }

                }

                if (ViewData["XDSMessage"].ToString() == "Found")
                {
                    //Personal Information

                    ViewData["XDSInfoPersonID"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].PersonID;
                    ViewData["XDSInfoTitle"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Title;
                    ViewData["XDSInfoDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].DateOfBirth;
                    ViewData["XDSInfoInitials"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Initials;
                    ViewData["XDSInfoFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].FirstName;
                    ViewData["XDSInfoSurname"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Surname;
                    ViewData["XDSInfoFullname"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Fullname;
                    ViewData["XDSInfoIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].IDNumber;
                    ViewData["XDSInfoPassportNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].PassportNumber;
                    ViewData["XDSInfoMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].MaritalStatus;
                    ViewData["XDSInfoGender"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Gender;
                    ViewData["XDSInfoAge"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Age;
                    ViewData["XDSInfoMiddleName1"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].MiddleName1;
                    ViewData["XDSInfoMiddleName2"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].MiddleName2;
                    ViewData["TransUnionInfoReference"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Reference;
                    ViewData["XDSInfoHasProperties"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].HasProperties;

                    //Home Affairs Information
                    ViewData["XDSInfoDeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HomeAffairsInformation"].DeceasedStatus;
                    ViewData["XDSInfoDeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HomeAffairsInformation"].DeceasedDate;
                    ViewData["XDSInfoVerifiedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HomeAffairsInformation"].VerifiedStatus;


                    //Credit Information
                    ViewData["XDSInfoProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].ProtectiveVerification;
                    ViewData["XDSInfoSAFPSListing"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].SAFPSListing;
                    ViewData["XDSInfoEmployerFraudVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].EmployerFraudVerification;

                    //Historical Information

                    // Address
                    Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory;
                    List<string> thatlist = new List<string>();
                    Dictionary<string, string> arrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                        string Line1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1;
                        string Line2 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2;
                        string Line3 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3;
                        string Line4 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4;
                        string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Line1", Line1);
                        arrayList.Add(count + "_Line2", Line2);
                        arrayList.Add(count + "_Line3", Line3);
                        arrayList.Add(count + "_Line4", Line4);
                        arrayList.Add(count + "_PostalCode", PostalCode);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["ArrayList"] = arrayList;
                        System.Diagnostics.Debug.WriteLine(count + " arrayList: " + arrayList);

                    }

                    foreach (KeyValuePair<string, string> item in arrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }


                    // Telephone
                    Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                    Telelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory;
                    List<string> Telthatlist = new List<string>();
                    Dictionary<string, string> TelarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (Telelements.Count); count++)
                    {
                        string Type = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        string Number = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                        TelarrayList.Add(count + "_Type", Type);
                        TelarrayList.Add(count + "_Numnber", Number);
                        TelarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["TelArrayList"] = TelarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " TelarrayList: " + TelarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in TelarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                    EMelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory;
                    List<string> EMthatlist = new List<string>();
                    Dictionary<string, string> EMarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (EMelements.Count); count++)
                    {
                        string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        string Designation = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                        EMarrayList.Add(count + "_EmployerName", EmployerName);
                        EMarrayList.Add(count + "_Designation", Designation);
                        EMarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["EMArrayList"] = EMarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " EMarrayList: " + EMarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in EMarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("EMKey = {0}, EMValue = {1}", item.Key, item.Value);
                    }

                }

                if (ViewData["VeriCredMessage"].ToString() == "Found")
                {
                    //Personal Information

                    ViewData["VeriCredInfoDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].DateOfBirth;
                    ViewData["VeriCredInfoFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].FirstName;
                    ViewData["VeriCredInfoSurname"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Surname;
                    ViewData["VeriCredInfoFullname"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Fullname;
                    ViewData["VeriCredInfoIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].IDNumber;

                    ViewData["VeriCredInfoGender"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Gender;
                    ViewData["VeriCredInfoAge"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Age;
                    ViewData["VeriCredInfoCurrentEmployer"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].CurrentEmployer;


                    //Contact Information
                    ViewData["VeriCredInfoPhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].PhysicalAddress;
                    ViewData["VeriCredInfoMobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].MobileNumber;
                    ViewData["VeriCredInfoHomeTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].HomeTelephoneNumber;
                    ViewData["VeriCredInfoWorkTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].WorkTelephoneNumber;


                    //Historical Information

                    // Address
                    Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory;
                    List<string> thatlist = new List<string>();
                    Dictionary<string, string> arrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                        string Line1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1;
                        string Line2 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2;
                        string Line3 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3;
                        string Line4 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4;
                        string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Line1", Line1);
                        arrayList.Add(count + "_Line2", Line2);
                        arrayList.Add(count + "_Line3", Line3);
                        arrayList.Add(count + "_Line4", Line4);
                        arrayList.Add(count + "_PostalCode", PostalCode);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["ArrayList"] = arrayList;
                        System.Diagnostics.Debug.WriteLine(count + " arrayList: " + arrayList);

                    }

                    foreach (KeyValuePair<string, string> item in arrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }


                    // Telephone
                    Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                    Telelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory;
                    List<string> Telthatlist = new List<string>();
                    Dictionary<string, string> TelarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (Telelements.Count); count++)
                    {
                        string Type = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        string Number = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                        TelarrayList.Add(count + "_Type", Type);
                        TelarrayList.Add(count + "_Numnber", Number);
                        TelarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["TelArrayList"] = TelarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " TelarrayList: " + TelarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in TelarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", item.Key, item.Value);
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                    EMelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory;
                    List<string> EMthatlist = new List<string>();
                    Dictionary<string, string> EMarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (EMelements.Count); count++)
                    {
                        string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        string Designation = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                        EMarrayList.Add(count + "_EmployerName", EmployerName);
                        EMarrayList.Add(count + "_Designation", Designation);
                        EMarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["EMArrayList"] = EMarrayList;
                        System.Diagnostics.Debug.WriteLine(count + " EMarrayList: " + EMarrayList);

                    }

                    foreach (KeyValuePair<string, string> item in EMarrayList)
                    {
                        System.Diagnostics.Debug.WriteLine("EMKey = {0}, EMValue = {1}", item.Key, item.Value);
                    }

                }
                else
                {

                }
            }

            return View();
        }

        public ActionResult CompuScanBankCodesDocument()
        {
            return View();
        }

        public ActionResult CompuScanBankCodesDocumentResults(CompuScan comp)
        {
            string id = comp.IDNumber;
            string clientName = comp.clientName;
            string bankName = comp.bankName;
            string branchCode = comp.branchCode;
            string branchName = comp.branchName;
            string accountNumber = comp.accountNumber;
            int amount = comp.amount;
            string terms = comp.terms;
            int reportType = comp.ReportType;

            System.Diagnostics.Debug.WriteLine(id);



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
            string page = "Combined Consumer Trace";
            string action = "Client Name:" + clientName + "; Bank Name: " + bankName + "; Branch Code:" + branchCode + "; Branch Name: " + branchName + "; Account Number:" + accountNumber + "; Amount:" + amount + "; Terms:" + terms + "; Report Type" + reportType;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            System.Diagnostics.Debug.WriteLine(date_add);
            System.Diagnostics.Debug.WriteLine(time_add);
            System.Diagnostics.Debug.WriteLine(page);
            System.Diagnostics.Debug.WriteLine(action);
            System.Diagnostics.Debug.WriteLine(user_id);
            System.Diagnostics.Debug.WriteLine(us);




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
            var url = "https://uatrest.searchworks.co.za/documents/compuscan/bankcodes/";

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
                clientName = clientName,
                bankName = bankName,
                branchCode = branchCode,
                branchName = branchName,
                accountNumber = accountNumber,
                amount = amount,
                terms = terms,
                ReportType = reportType,
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            return View();
        }

        public ActionResult CompuScanBankOnFile()
        {
            return View();
        }

        public ActionResult CompuScanBankOnFileResults(CompuScan comp)
        {
            string id = comp.IDNumber;


            System.Diagnostics.Debug.WriteLine(id);



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
            string page = "CompuScan Bank On File";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            System.Diagnostics.Debug.WriteLine(date_add);
            System.Diagnostics.Debug.WriteLine(time_add);
            System.Diagnostics.Debug.WriteLine(page);
            System.Diagnostics.Debug.WriteLine(action);
            System.Diagnostics.Debug.WriteLine(user_id);
            System.Diagnostics.Debug.WriteLine(us);




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
            var url = "https://uatrest.searchworks.co.za/compuscan/bankcodes/idnumber/";

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
                iDNumber = id
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {

            }
            return View();
        }

        public ActionResult CompuScanConsumerProfile()
        {
            return View();
        }

        public ActionResult CompuScanConsumerProfileResults(CompuScan comp)
        {
            string id = comp.IDNumber;
            int enquiryReason = comp.EnquiryReason;
            string surname = comp.Surname;
            string firstname = comp.FirstName;
            string refe = comp.Reference;




            System.Diagnostics.Debug.WriteLine(id);



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
            string page = "CompuScan Consumer Profile";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; Enquiry Reason: " + enquiryReason + "; ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            System.Diagnostics.Debug.WriteLine(date_add);
            System.Diagnostics.Debug.WriteLine(time_add);
            System.Diagnostics.Debug.WriteLine(page);
            System.Diagnostics.Debug.WriteLine(action);
            System.Diagnostics.Debug.WriteLine(user_id);
            System.Diagnostics.Debug.WriteLine(us);




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
            var url = "https://uatrest.searchworks.co.za/credit/compuscan/consumerprofile/";

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
                enquiryReason = enquiryReason,
                surname = surname,
                firstname = firstname,
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();

            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation["DateOfBirth"];
                ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation["DelphiScore"];
                ViewData["DirectorshipInformationMessage"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DesignationCode;
                ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;


                if (ViewData["PersonInformationMessage"].ToString() != "")
                {
                    //personaInformantion
                    ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                    ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                    ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                    ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                    ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                    ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                    ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                    ViewData["Country"] = rootObject.ResponseObject.PersonInformation.Country;
                    ViewData["VerificationStatus"] = rootObject.ResponseObject.PersonInformation.VerificationStatus;
                    ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                }
                else
                {
                    ViewData["PersonInformationMessage"] = "No Match";
                }

                if (ViewData["CreditInformationMessage"].ToString() != "")
                {
                    //CreditInformation
                    ViewData["DelphiScore"] = rootObject.ResponseObject.CreditInformation.DelphiScore;
                    ViewData["Risk"] = rootObject.ResponseObject.CreditInformation.Risk;
                    ViewData["RiskColour"] = rootObject.ResponseObject.CreditInformation.RiskColour;
                    ViewData["DelphiScoreChartURL"] = rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL;
                    ViewData["TotalInstallmentAmountCPAAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalInstallmentAmountCPAAccounts_CompuScan;
                    ViewData["TotalInstallmentAmountNLRAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalInstallmentAmountNLRAccounts_CompuScan;
                    ViewData["TotalNumberCPAAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalNumberCPAAccounts_CompuScan;
                    ViewData["TotalNumberNLRAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalNumberNLRAccounts_CompuScan;
                    ViewData["TotalNumberActiveCPAAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalNumberActiveCPAAccounts_CompuScan;
                    ViewData["TotalNumberActiveNLRAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalNumberActiveNLRAccounts_CompuScan;
                    ViewData["TotalNumberClosedCPAAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalNumberClosedCPAAccounts_CompuScan;
                    ViewData["TotalNumberClosedNLRAccounts_CompuScan"] = rootObject.ResponseObject.CreditInformation.TotalNumberClosedNLRAccounts_CompuScan;

                    //DeclineReason
                    ViewData["ReasonDescription"] = rootObject.ResponseObject.CreditInformation.DeclineReason[0].ReasonDescription;

                    //DataCounts
                    ViewData["Accounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.Accounts;
                    ViewData["Enquiries"] = rootObject.ResponseObject.CreditInformation.DataCounts.Enquiries;
                    ViewData["Judgments"] = rootObject.ResponseObject.CreditInformation.DataCounts.Judgments;
                    ViewData["Notices"] = rootObject.ResponseObject.CreditInformation.DataCounts.Notices;
                    ViewData["BankDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.BankDefaults;
                    ViewData["Defaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.Defaults;
                    ViewData["Collections"] = rootObject.ResponseObject.CreditInformation.DataCounts.Collections;
                    ViewData["Directors"] = rootObject.ResponseObject.CreditInformation.DataCounts.Directors;
                    ViewData["Addresses"] = rootObject.ResponseObject.CreditInformation.DataCounts.Addresses;
                    ViewData["Telephones"] = rootObject.ResponseObject.CreditInformation.DataCounts.Telephones;
                    ViewData["Occupants"] = rootObject.ResponseObject.CreditInformation.DataCounts.Occupants;
                    ViewData["Employers"] = rootObject.ResponseObject.CreditInformation.DataCounts.Employers;
                    ViewData["TraceAlerts"] = rootObject.ResponseObject.CreditInformation.DataCounts.TraceAlerts;
                    ViewData["PaymentProfiles"] = rootObject.ResponseObject.CreditInformation.DataCounts.PaymentProfiles;
                    ViewData["OwnEnquiries"] = rootObject.ResponseObject.CreditInformation.DataCounts.OwnEnquiries;
                    ViewData["AdminOrders"] = rootObject.ResponseObject.CreditInformation.DataCounts.AdminOrders;
                    ViewData["PossibleMatches"] = rootObject.ResponseObject.CreditInformation.DataCounts.PossibleMatches;
                    ViewData["DefiniteMatches"] = rootObject.ResponseObject.CreditInformation.DataCounts.DefiniteMatches;
                    ViewData["Loans"] = rootObject.ResponseObject.CreditInformation.DataCounts.Loans;
                    ViewData["FraudAlerts"] = rootObject.ResponseObject.CreditInformation.DataCounts.FraudAlerts;
                    ViewData["Companies"] = rootObject.ResponseObject.CreditInformation.DataCounts.Companies;
                    ViewData["Properties"] = rootObject.ResponseObject.CreditInformation.DataCounts.Properties;
                    ViewData["Documents"] = rootObject.ResponseObject.CreditInformation.DataCounts.Documents;
                    ViewData["DemandLetters"] = rootObject.ResponseObject.CreditInformation.DataCounts.DemandLetters;
                    ViewData["Trusts"] = rootObject.ResponseObject.CreditInformation.DataCounts.Trusts;
                    ViewData["Bonds"] = rootObject.ResponseObject.CreditInformation.DataCounts.Bonds;
                    ViewData["Deeds"] = rootObject.ResponseObject.CreditInformation.DataCounts.Deeds;
                    ViewData["PublicDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults;
                    ViewData["NLRAccounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts;

                    //DebtReviewStatus
                    ViewData["ApplicationDate"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.ApplicationDate;

                    //ConsumerStatistics
                    ViewData["HighestJudgment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.HighestJudgment;
                    ViewData["RevolvingAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                    ViewData["InstalmentAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                    ViewData["OpenAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.OpenAccounts;
                    ViewData["AdverseAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.AdverseAccounts;
                    //NLRStats
                    ViewData["NLRStats_ActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                    ViewData["NLRStats_ClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                    ViewData["NLRStats_WorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                    ViewData["NLRStats_BalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                    ViewData["NLRStats_MonthlyInstalment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
                    ViewData["NLRStats_CumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.CumulativeArrears;
                    //CCAStats
                    ViewData["CCAStats_ActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                    ViewData["CCAStats_ClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                    ViewData["CCAStats_WorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                    ViewData["CCAStats_BalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                    ViewData["CCAStats_MonthlyInstalment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                    ViewData["CCAStats_CumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.CumulativeArrears;
                    //NLR12Months
                    ViewData["NLR12Months_EnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                    ViewData["NLR12Months_EnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                    ViewData["NLR12Months_PositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                    ViewData["NLR12Months_HighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
                    //NLR36Months
                    ViewData["NLR36Months_EnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                    ViewData["NLR36Months_EnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                    ViewData["NLR36Months_PositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                    ViewData["NLR36Months_HighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
                    //NLR24Months
                    ViewData["NLR24Months_EnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                    ViewData["NLR24Months_EnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                    ViewData["NLR24Months_PositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                    ViewData["NLR24Months_HighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
                    //CCA12Months
                    ViewData["CCA12Months_EnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                    ViewData["CCA12Months_EnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                    ViewData["CCA12Months_PositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                    ViewData["CCA12Months_HighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
                    //CCA24Months
                    ViewData["CCA24Months_EnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                    ViewData["CCA24Months_EnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                    ViewData["CCA24Months_PositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                    ViewData["CCA24Months_HighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
                    //CCA36Months
                    ViewData["CCA36Months_EnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                    ViewData["CCA36Months_EnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                    ViewData["CCA36Months_PositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                    ViewData["CCA36Months_HighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;

                    //EnquiryHistory
                    ViewData["EnquiryHistory_EnquiryDate"] = rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiryDate;
                    ViewData["EnquiryHistory_EnquiredBy"] = rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiredBy;
                    ViewData["EnquiryHistory_EnquiredByContact"] = rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiredByContact;
                    ViewData["EnquiryHistory_EnquiredByContactNumber"] = rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiredByContactNumber;

                    //CPA_Accounts
                    ViewData["SubscriberCode"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].SubscriberCode;
                    ViewData["SubscriberName"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].SubscriberName;
                    ViewData["BranchCode"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].BranchCode;
                    ViewData["AccountNO"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].AccountNO;
                    ViewData["SubAccountNO"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].SubAccountNO;
                    ViewData["OwnershipType"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OwnershipType;
                    ViewData["OwnershipTypeDescription"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OwnershipTypeDescription;
                    ViewData["Reason"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].Reason;
                    ViewData["ReasonDescription"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ReasonDescription;
                    ViewData["PaymentType"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentType;
                    ViewData["PaymentTypeDescription"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentTypeDescription;
                    ViewData["AccountType"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].AccountType;
                    ViewData["AccountTypeDescription"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].AccountTypeDescription;
                    ViewData["OpenDate"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OpenDate;
                    ViewData["DeferredPaymentDate"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].DeferredPaymentDate;
                    ViewData["LastPaymentDate"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].LastPaymentDate;
                    ViewData["OpenBalance"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OpenBalance;
                    ViewData["OpenBalanceIND"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OpenBalanceIND;
                    ViewData["CurrentBalance"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].CurrentBalance;
                    ViewData["CurrentBalanceIND"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].CurrentBalanceIND;
                    ViewData["OverdueAmount"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OverdueAmount;
                    ViewData["OverdueAmountIND"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OverdueAmountIND;
                    ViewData["InstalmentAmount"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].InstalmentAmount;
                    ViewData["ArrearsPeriod"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ArrearsPeriod;
                    ViewData["RepaymentFrequency"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].RepaymentFrequency;
                    ViewData["RepaymentFrequencyDescription"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].RepaymentFrequencyDescription;
                    ViewData["Terms"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].Terms;
                    ViewData["StatusCode"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].StatusCode;
                    ViewData["StatusCodeDesc"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].StatusCodeDesc;
                    ViewData["StatusDate"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].StatusDate;
                    ViewData["ThirdPartyName"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ThirdPartyName;
                    ViewData["ThirdPartySold"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ThirdPartySold;
                    ViewData["ThirdPartySoldDescription"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ThirdPartySoldDescription;
                    ViewData["JointLoanParticipants"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].JointLoanParticipants;
                    ViewData["PaymentHistory"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentHistory;
                    ViewData["PaymentHistoryStatus"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentHistoryStatus;
                    ViewData["PaymentHistoryChart"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentHistoryChart;
                    ViewData["MonthEndDate"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].MonthEndDate;
                    ViewData["DateCreated"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].DateCreated;

                    //NLR_Accounts
                    ViewData["NLR_SubscriberCode"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubscriberCode;
                    ViewData["NLR_SubscriberName"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubscriberName;
                    ViewData["NLR_BranchCode"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].BranchCode;
                    ViewData["NLR_AccountNO"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].AccountNO;
                    ViewData["NLR_SubAccountNO"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubAccountNO;
                    ViewData["NLR_OwnershipType"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OwnershipType;
                    ViewData["NLR_OwnershipTypeDescription"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OwnershipTypeDescription;
                    ViewData["NLR_Reason"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].Reason;
                    ViewData["NLR_ReasonDescription"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ReasonDescription;
                    ViewData["NLR_PaymentType"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentType;
                    ViewData["NLR_PaymentTypeDescription"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentTypeDescription;
                    ViewData["NLR_AccountType"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].AccountType;
                    ViewData["NLR_AccountTypeDescription"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].AccountTypeDescription;
                    ViewData["NLR_OpenDate"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OpenDate;
                    ViewData["NLR_DeferredPaymentDate"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].DeferredPaymentDate;
                    ViewData["NLR_LastPaymentDate"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].LastPaymentDate;
                    ViewData["NLR_OpenBalance"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OpenBalance;
                    ViewData["NLR_OpenBalanceIND"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OpenBalanceIND;
                    ViewData["NLR_CurrentBalance"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].CurrentBalance;
                    ViewData["NLR_CurrentBalanceIND"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].CurrentBalanceIND;
                    ViewData["NLR_OverdueAmount"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OverdueAmount;
                    ViewData["NLR_OverdueAmountIND"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OverdueAmountIND;
                    ViewData["NLR_InstalmentAmount"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].InstalmentAmount;
                    ViewData["NLR_ArrearsPeriod"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ArrearsPeriod;
                    ViewData["NLR_RepaymentFrequency"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubscriberCodeRepaymentFrequency;
                    ViewData["NLR_RepaymentFrequencyDescription"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].RepaymentFrequencyDescription;
                    ViewData["NLR_Terms"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].Terms;
                    ViewData["NLR_StatusCode"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].StatusCode;
                    ViewData["NLR_StatusCodeDesc"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].StatusCodeDesc;
                    ViewData["NLR_StatusDate"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].StatusDate;
                    ViewData["NLR_ThirdPartyName"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ThirdPartyName;
                    ViewData["NLR_ThirdPartySold"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ThirdPartySold;
                    ViewData["NLR_ThirdPartySoldDescription"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ThirdPartySoldDescription;
                    ViewData["NLR_JointLoanParticipants"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].JointLoanParticipants;
                    ViewData["NLR_PaymentHistory"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentHistory;
                    ViewData["NLR_PaymentHistoryStatus"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentHistoryStatus;
                    ViewData["NLR_PaymentHistoryChart"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentHistoryChart;
                    ViewData["NLR_MonthEndDate"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].MonthEndDate;
                    ViewData["NLR_DateCreated"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].DateCreated;


                }
                else
                {

                    ViewData["CreditInformationMessage"] = "No Match";
                }

                if (ViewData["DirectorshipInformationMessage"].ToString() != "")
                {
                    //Directorships
                    ViewData["D_DesignationCode"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DesignationCode;
                    ViewData["D_AppointmentDate"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].AppointmentDate;
                    ViewData["D_DirectorStatus"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorStatus;
                    ViewData["D_DirectorStatusDate"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorStatusDate;
                    ViewData["D_CompanyName"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyName;
                    ViewData["D_CompanyType"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyType;
                    ViewData["D_CompanyStatus"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyStatus;
                    ViewData["D_CompanyStatusCode"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyStatusCode;
                    ViewData["D_CompanyRegistrationNumber"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyRegistrationNumber;
                    ViewData["D_CompanyRegistrationDate"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyRegistrationDate;
                    ViewData["D_CompanyStartDate"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyStartDate;
                    ViewData["D_CompanyTaxNumber"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyTaxNumber;
                    ViewData["D_DirectorTypeCode"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorTypeCode;
                    ViewData["D_DirectorType"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorType;
                    ViewData["D_MemberSize"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].MemberSize;
                    ViewData["D_MemberContribution"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].MemberContribution;
                    ViewData["D_MemberContributionType"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].MemberContributionType;
                    ViewData["D_ResignationDate"] = rootObject.ResponseObject.DirectorshipInformation.Directorships[0].ResignationDate;
                }
                else
                {
                    ViewData["DirectorshipInformationMessage"] = "No Match";
                }

                if (ViewData["HistoricalInformationMessage"].ToString() != "")
                {
                    //AddressHistory
                    ViewData["AH_TypeDescription"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;
                    ViewData["AH_Line1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line1;
                    ViewData["AH_Line2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line2;
                    ViewData["AH_Line3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line3;
                    ViewData["AH_Line4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line4;
                    ViewData["AH_PostalCode"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].PostalCode;
                    ViewData["AH_FullAddress"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
                    ViewData["AH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;

                    //TelephoneHistory
                    ViewData["TH_TypeDescription"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeDescription;
                    ViewData["TH_FullNumber"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].FullNumber;
                    ViewData["TH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].LastUpdatedDate;

                    //EmploymentHistory
                    ViewData["EH_TypeDescription"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].TypeDescription;
                    ViewData["EH_Designation"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
                    ViewData["EH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate;
                    ViewData["EH_EmployeeType"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployeeType;
                    ViewData["EH_SalaryFrequency"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].SalaryFrequency;
                    ViewData["EH_PayslipReference"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].PayslipReference;
                    ViewData["EH_EmployeeNumber"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployeeNumber;

                }
                else
                {
                    ViewData["HistoricalInformationMessage"] = "No Match";
                }
                return View();
            }
        }

        public ActionResult CompuScanConsumerTrace()
        {
            return View();
        }

        public ActionResult CompuScanConsumerTraceResults(CompuScan comp)
        {
            string id = comp.IDNumber;
            string tele = comp.TelephoneNumber;
            string teleID = comp.TelephoneID;
            string traceType = comp.TraceType;
            string refe = comp.Reference;



            System.Diagnostics.Debug.WriteLine(id);


            if (traceType == "ID")
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
                string page = "CompuScan Consumer Trace By IDNumber";
                string action = "ID: " + id;
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
                var url = "https://uatrest.searchworks.co.za/credit/compuscan/consumertrace/idnumber/";

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
                    IDNumber = id
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;



                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation["DateOfBirth"];
                    ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                    ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                    ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeCode;


                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                        ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                        ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                        ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                        ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                        ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                        ViewData["MiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
                        ViewData["MiddleName2"] = rootObject.ResponseObject.PersonInformation.MiddleName2;
                        ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }

                    if (ViewData["CreditInformationMessage"].ToString() != "")
                    {
                        //FraudIndicatorSummary
                        ViewData["ProtectiveVerification"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];

                    }
                    else
                    {
                        ViewData["CreditInformationMessage"] = "No Match";
                    }

                    if (ViewData["HomeAffairsInformationMessage"].ToString() != "")
                    {
                        //HomeAffairsInformation
                        ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                        ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                        ViewData["CauseOfDeath"] = rootObject.ResponseObject.HomeAffairsInformation.CauseOfDeath;
                        ViewData["VerifiedDate"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedDate;
                        ViewData["VerifiedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus;

                    }
                    else
                    {
                        ViewData["HomeAffairsInformationMessage"] = "No Match";
                    }

                    if (ViewData["HistoricalInformationMessage"].ToString() != "")
                    {
                        //AddressHistory
                        ViewData["TypeCode"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeCode;
                        ViewData["AH_Line1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line1;
                        ViewData["AH_Line2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line2;
                        ViewData["AH_Line3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line3;
                        ViewData["AH_Line4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line4;
                        ViewData["AH_PostalCode"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].PostalCode;
                        ViewData["AH_FullAddress"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
                        ViewData["AH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;

                        //TelephoneHistory
                        ViewData["TH_TypeDescription"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeDescription;
                        ViewData["TH_TypeCode"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeCode;
                        ViewData["TH_FullNumber"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].Number;
                        ViewData["TH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].LastUpdatedDate;

                        //EmploymentHistory
                        ViewData["EH_EmployerName"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;
                        ViewData["EH_Designation"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
                        ViewData["EH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate;

                    }
                    else
                    {
                        ViewData["HistoricalInformationMessage"] = "No Match";
                    }
                    return View();
                }

            }

            else if (traceType == "tele")
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
                string page = "CompuScan Consumer Trace By Telephone Number";
                string action = "Telephone Number: " + tele;
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
                var url = "https://uatrest.searchworks.co.za/credit/compuscan/consumertrace/telephonenumber/";

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
                    TelephoneNumber = tele
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject[0].PersonInformation.FirstName;


                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        ViewData["MiddleName1"] = rootObject.ResponseObject[0].PersonInformation.MiddleName1;
                        ViewData["HasProperties"] = rootObject.ResponseObject[0].PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }
                    return View();
                }

            }

            else if (traceType == "teleID")
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
                string page = "CompuScan Consumer Trace By TelephoneID";
                string action = "TelephoneID: " + tele;
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
                var url = "https://uatrest.searchworks.co.za/credit/compuscan/consumertrace/telephoneid/";

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
                    TelephoneID = id
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }
            return View();
        }

        public ActionResult CompuScanContactInformation()
        {
            return View();

        }

        public ActionResult CompuScanContactInformationResults(CompuScan comp)
        {
            string id = comp.IDNumber;
            string passport = comp.passport;
            string surname = comp.Surname;
            string firstname = comp.FirstName;
            string refe = comp.Reference;

            System.Diagnostics.Debug.WriteLine(id);



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
            string page = "CompuScan Contact Information";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; Passport: " + passport + "; ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/compuscan/contactinformation/";

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
                passport = passport,
                surname = surname,
                firstname = firstname,
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation["DateOfBirth"];
                //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                if (ViewData["PersonInformationMessage"].ToString() != "")
                {
                    //personaInformantion
                    ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                    ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                    ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                    ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                    ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                    ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                    ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                    ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                }
                else
                {
                    ViewData["PersonInformationMessage"] = "No Match";
                }

                if (ViewData["HistoricalInformationMessage"].ToString() != "")
                {
                    //AddressHistory
                    ViewData["AH_TypeDescription"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;
                    ViewData["AH_Line1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line1;
                    ViewData["AH_Line2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line2;
                    ViewData["AH_Line3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line3;
                    ViewData["AH_Line4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line4;
                    ViewData["AH_PostalCode"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].PostalCode;
                    ViewData["AH_FullAddress"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
                    ViewData["AH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;

                    //TelephoneHistory
                    ViewData["TH_TypeDescription"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeDescription;
                    ViewData["TH_FullNumber"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].Number;
                    ViewData["TH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].LastUpdatedDate;

                    //EmploymentHistory
                    ViewData["EH_EmployerName"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;
                    ViewData["EH_Designation"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
                    ViewData["EH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate;

                }
                else
                {
                    ViewData["HistoricalInformationMessage"] = "No Match";
                }
            }
            return View();
        }

        public ActionResult CompuScanEmploymentConfidenceIndex()
        {
            return View();

        }

        public ActionResult CompuScanEmploymentConfidenceIndexResults(CompuScan comp)
        {
            string id = comp.IDNumber;
            string firstname = comp.FirstName;
            string surname = comp.Surname;
            string refe = comp.Reference;

            System.Diagnostics.Debug.WriteLine(id);



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
            string page = "CompuScan Employment Confidence Index";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/compuscan/EmploymentConfidenceIndex/";

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
                IDNumber = id,
                Surname = surname,
                Firstname = firstname
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation["DateOfBirth"];
                //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;

                if (ViewData["PersonInformationMessage"].ToString() != "")
                {
                    //personaInformantion
                    ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                    ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                    ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                    ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                    ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                    ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                    ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                    ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                }
                else
                {
                    ViewData["PersonInformationMessage"] = "No Match";
                }

                if (ViewData["HistoricalInformationMessage"].ToString() != "")
                {
                    //EmploymentHistory
                    ViewData["EH_EmployerName"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;
                    ViewData["EH_Designation"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
                    ViewData["EH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate;
                    ViewData["EH_FirstReportedDate"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].FirstReportedDate;
                    ViewData["EH_NumberOfAccounts"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].NumberOfAccounts;
                    ViewData["EH_ConfidenceIndex"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].ConfidenceIndex;
                    ViewData["EH_HighestConfidence"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].HighestConfidence;

                }
                else
                {
                    ViewData["HistoricalInformationMessage"] = "No Match";
                }

            }
            return View();
        }

        public ActionResult CompuScanGrossMonthlyIncomeByIDNumber()
        {
            return View();
        }

        public ActionResult CompuScanGrossMonthlyIncomeByIDNumberResults(CompuScan comp)
        {
            string id = comp.IDNumber;
            string refe = comp.Reference;


            System.Diagnostics.Debug.WriteLine(id);



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
            string page = "CompuScan Employment Confidence Index";
            string action = "ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/compuscan/grossmonthlyincome/idnumber/";

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
                IDNumber = id,

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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline" || mes == "NotFound")
            {
                ViewData["Message"] = "Service is offline";

                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";

                ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                System.Diagnostics.Debug.WriteLine("PersonalMessage: " + ViewData["PersonInformationMessage"].ToString());
                //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;

                if (ViewData["PersonInformationMessage"].ToString() != "")
                {
                    //personaInformantion
                    ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                    ViewData["IncomeBracket"] = rootObject.ResponseObject.PersonInformation.IncomeBracket;
                    ViewData["IncomeGrossEstimate"] = rootObject.ResponseObject.PersonInformation.IncomeGrossEstimate;
                    ViewData["IncomeConfidence"] = rootObject.ResponseObject.PersonInformation.IncomeConfidence;
                    ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                    ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                    ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                    ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                }
                else
                {
                    ViewData["PersonInformationMessage"] = "No Match";
                }
            }
            return View();
        }

        public ActionResult CompuScanIDPhotoVerification()
        {
            return View();
        }

        public ActionResult CompuScanIDPhotoVerificationResults(CompuScan comp)
        {
            string id = comp.IDNumber;
            string refe = comp.Reference;


            System.Diagnostics.Debug.WriteLine(id);



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
            string page = "CompuScan ID Photo Verification";
            string action = "ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/compuscan/idphotoverification/";

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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation["DateOfBirth"];
                //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                if (ViewData["PersonInformationMessage"].ToString() != "")
                {
                    //personaInformantion
                    ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                    ViewData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;
                    ViewData["MarriageDate"] = rootObject.ResponseObject.PersonInformation.MarriageDate;
                    ViewData["CountryOfBirth"] = rootObject.ResponseObject.PersonInformation.CountryOfBirth;
                    ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                    ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                    ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                }
                else
                {
                    ViewData["PersonInformationMessage"] = "No Match";
                }

                if (ViewData["HomeAffairsInformationMessage"].ToString() != "")
                {
                    //personaInformantion
                    ViewData["IDNumber"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                    ViewData["IDPhotoURL"] = rootObject.ResponseObject.HomeAffairsInformation.IDPhotoURL;
                    ViewData["FirstName"] = rootObject.ResponseObject.HomeAffairsInformation.FirstName;
                    ViewData["Surname"] = rootObject.ResponseObject.HomeAffairsInformation.Surname;
                    ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                    ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                    ViewData["IDIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDIssuedDate;
                    ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                    ViewData["IDNumberBlocked"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumberBlocked;
                    ViewData["IDSequenceNumber"] = rootObject.ResponseObject.HomeAffairsInformation.IDSequenceNumber;
                    ViewData["OnHANIS"] = rootObject.ResponseObject.HomeAffairsInformation.OnHANIS;
                    ViewData["OnNPR"] = rootObject.ResponseObject.HomeAffairsInformation.OnNPR;
                }
                else
                {
                    ViewData["HomeAffairsInformationMessage"] = "No Match";
                }
            }
            return View();
        }


        public ActionResult ExperianConsumerProfile()
        {
            return View();
        }

        public ActionResult ExperianConsumerProfileResults(Experian exp)
        {
            string id = exp.iDNumber;
            string enquiryReason = exp.enquiryReason;
            string surname = exp.surname;
            string firstname = exp.firstName;
            string passport = exp.passportNumber;
            string refe = exp.reference;




            System.Diagnostics.Debug.WriteLine("exp ID: " + id);
            System.Diagnostics.Debug.WriteLine("exp reason: " + enquiryReason);
            System.Diagnostics.Debug.WriteLine("exp ref: " + refe);



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
            string page = "Experian Consumer Profile";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; Enquiry Reason: " + enquiryReason + "; Passport: " + passport + "; ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/experian/consumerprofile/";

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
                iDNumber = id,
                enquiryReason = enquiryReason,
                surname = surname,
                firstName = firstname,
                passporNumber = passport
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";


                if (ViewData["ResponseMessage"].ToString() == "ExperianConsumerProfile")
                {
                    //PersonInformation
                    ViewData["ExDateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;

                    System.Diagnostics.Debug.WriteLine("DATEofBiRTH: " + ViewData["ExDateOfBirth"]);

                    ViewData["ExFirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                    ViewData["ExSurname"] = rootObject.ResponseObject.PersonInformation.Surname;
                    ViewData["ExIDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                    ViewData["ExGender"] = rootObject.ResponseObject.PersonInformation.Gender;
                    ViewData["ExAge"] = rootObject.ResponseObject.PersonInformation.Age;
                    ViewData["ExMaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;
                    ViewData["ExMiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
                    ViewData["ExReference"] = rootObject.ResponseObject.PersonInformation.Reference;
                    //ViewData["ExPhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.PhysicalAddress;


                    //HomeAffairsInformation
                    ViewData["ExIDVerified"] = rootObject.ResponseObject.HomeAffairsInformation.IDVerified;
                    ViewData["ExSurnameVerified"] = rootObject.ResponseObject.HomeAffairsInformation.SurnameVerified;
                    ViewData["ExInitialsVerified"] = rootObject.ResponseObject.HomeAffairsInformation.InitialsVerified;



                    //CreditInformation
                    ViewData["ExDelphiScoreChartURL"] = rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL;
                    ViewData["ExDelphiScore"] = rootObject.ResponseObject.CreditInformation.DelphiScore;
                    ViewData["ExFlagCount"] = rootObject.ResponseObject.CreditInformation.FlagCount;
                    ViewData["ExFlagDetails"] = rootObject.ResponseObject.CreditInformation.FlagDetails;





                    ViewData["ExAccounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.Accounts;
                    ViewData["ExEnquiries"] = rootObject.ResponseObject.CreditInformation.DataCounts.Enquiries;
                    ViewData["ExJudgments"] = rootObject.ResponseObject.CreditInformation.DataCounts.Judgments;
                    ViewData["ExNotices"] = rootObject.ResponseObject.CreditInformation.DataCounts.Notices;
                    ViewData["ExBankDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.BankDefaults;
                    ViewData["ExDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.Defaults;
                    ViewData["ExCollections"] = rootObject.ResponseObject.CreditInformation.DataCounts.Collections;
                    ViewData["ExDirectors"] = rootObject.ResponseObject.CreditInformation.DataCounts.Directors;
                    ViewData["ExAddresses"] = rootObject.ResponseObject.CreditInformation.DataCounts.Addresses;
                    ViewData["ExTelephones"] = rootObject.ResponseObject.CreditInformation.DataCounts.Telephones;
                    ViewData["ExOccupants"] = rootObject.ResponseObject.CreditInformation.DataCounts.Occupants;
                    ViewData["ExEmployers"] = rootObject.ResponseObject.CreditInformation.DataCounts.Employers;
                    ViewData["ExTraceAlerts"] = rootObject.ResponseObject.CreditInformation.DataCounts.TraceAlerts;
                    ViewData["ExPaymentProfiles"] = rootObject.ResponseObject.CreditInformation.DataCounts.PaymentProfiles;
                    ViewData["ExOwnEnquiries"] = rootObject.ResponseObject.CreditInformation.DataCounts.OwnEnquiries;

                    ViewData["ExAdminOrders"] = rootObject.ResponseObject.CreditInformation.DataCounts.AdminOrders;
                    ViewData["ExPossibleMatches"] = rootObject.ResponseObject.CreditInformation.DataCounts.PossibleMatches;
                    ViewData["ExDefiniteMatches"] = rootObject.ResponseObject.CreditInformation.DataCounts.DefiniteMatches;
                    ViewData["ExLoans"] = rootObject.ResponseObject.CreditInformation.DataCounts.Loans;
                    ViewData["ExFraudAlerts"] = rootObject.ResponseObject.CreditInformation.DataCounts.FraudAlerts;
                    ViewData["ExCompanies"] = rootObject.ResponseObject.CreditInformation.DataCounts.Companies;
                    ViewData["ExProperties"] = rootObject.ResponseObject.CreditInformation.DataCounts.Properties;
                    ViewData["ExDocuments"] = rootObject.ResponseObject.CreditInformation.DataCounts.Documents;
                    ViewData["ExDemandLetters"] = rootObject.ResponseObject.CreditInformation.DataCounts.DemandLetters;
                    ViewData["ExTrusts"] = rootObject.ResponseObject.CreditInformation.DataCounts.Trusts;
                    ViewData["ExBondsBonds"] = rootObject.ResponseObject.CreditInformation.DataCounts.BondsBonds;
                    ViewData["ExDeeds"] = rootObject.ResponseObject.CreditInformation.DataCounts.Deeds;
                    ViewData["ExPublicDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults;
                    ViewData["ExNLRAccounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts;
                    ViewData["ExApplicationDate"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.ApplicationDate;


                    //ConsumerStatistics
                    ViewData["ExHighestJudgment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.HighestJudgment;
                    ViewData["ExRevolvingAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                    ViewData["ExInstalmentAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                    ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.OpenAccounts;
                    ViewData["ExAdverseAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.AdverseAccounts;
                    ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.OpenAccounts;


                    //NLRStats
                    ViewData["ExNLRActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                    ViewData["ExNLRClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                    ViewData["ExNLRWorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                    ViewData["ExNLRBalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                    ViewData["ExNLRCumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;


                    //CCAStats
                    ViewData["ExCCAActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                    ViewData["ExCCAClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                    ViewData["ExCCAWorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                    ViewData["ExCCABalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                    ViewData["ExCCACumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;


                    //NLR12Months
                    ViewData["ExNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                    ViewData["ExNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                    ViewData["ExNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                    ViewData["ExNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;


                    //NLR24Months
                    ViewData["ExNLR24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                    ViewData["ExNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                    ViewData["ExNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                    ViewData["ExNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;


                    //NLR36Months
                    ViewData["ExNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                    ViewData["ExNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                    ViewData["ExNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                    ViewData["ExNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;


                    //CCA12Months
                    ViewData["ExCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                    ViewData["ExCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                    ViewData["ExCCA12MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                    ViewData["ExCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;


                    //CCA24Months
                    ViewData["ExCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                    ViewData["ExCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                    ViewData["ExCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                    ViewData["ExCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;


                    //CCA36Months
                    ViewData["ExCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                    ViewData["ExCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                    ViewData["ExCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                    ViewData["ExCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;



                }
                else
                {
                    ViewData["Experian"] = "No Match";
                    return View();
                }

                return View();
            }

        }


        public ActionResult LetterOfDemand()
        {
            return View();
        }

        public ActionResult TransUnionCompanyProfileByCompanyID()
        {
            return View();
        }

        public ActionResult TransUnionCompanyProfileByCompanyIDResults(TransUnion trans)
        {

            string enquiryReason = trans.EnquiryReason;
            string searchDesc = trans.SearchDescription;
            string companyID = trans.CompanyID;
            Array moduleCodes = trans.ModuleCodes;




            System.Diagnostics.Debug.WriteLine(companyID);



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
            string page = "TransUnion Company Profile By CompanyID";
            string action = "Company ID: " + companyID + "; Search Description: " + searchDesc + "; Enquiry Reason: " + enquiryReason + "; Module Codes: " + moduleCodes;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            System.Diagnostics.Debug.WriteLine(date_add);
            System.Diagnostics.Debug.WriteLine(time_add);
            System.Diagnostics.Debug.WriteLine(page);
            System.Diagnostics.Debug.WriteLine(action);
            System.Diagnostics.Debug.WriteLine(user_id);
            System.Diagnostics.Debug.WriteLine(us);




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
            var url = "https://uatrest.searchworks.co.za/credit/transunion/companyprofile/bycompanyid/";

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
                EnquiryReason = enquiryReason,
                SearchDescription = searchDesc,
                CompanyID = companyID,
                ModuleCodes = moduleCodes,

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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            return View();
        }

        public ActionResult TransUnionCompanyProfile()
        {
            return View();
        }

        public ActionResult TransUnionCompanyProfileResults(TransUnion trans)
        {

            string enquiryReason = trans.EnquiryReason;
            string enquiryType = trans.EnquiryType;
            string entityNumber = trans.EntityNumber;
            string entityName = trans.EntityName;
            Array moduleCodes = trans.ModuleCodes;




            System.Diagnostics.Debug.WriteLine(entityName);



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
            string page = "TransUnion Company Profile";
            string action = "Entity Name: " + entityName + "; Entity Number: " + entityNumber + "; Enquiry Reason: " + enquiryReason + "; Enquiry Type: " + enquiryType + "; Module Codes: " + moduleCodes;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            System.Diagnostics.Debug.WriteLine(date_add);
            System.Diagnostics.Debug.WriteLine(time_add);
            System.Diagnostics.Debug.WriteLine(page);
            System.Diagnostics.Debug.WriteLine(action);
            System.Diagnostics.Debug.WriteLine(user_id);
            System.Diagnostics.Debug.WriteLine(us);




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
            var url = "https://uatrest.searchworks.co.za/credit/transunion/companyprofile/bycompanyid/";

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
                EnquiryReason = enquiryReason,
                EnquiryType = enquiryType,
                EntityNumber = entityNumber,
                EntityName = entityName,
                ModuleCodes = moduleCodes,

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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            return View();
        }

        public ActionResult TransUnionConsumerContactInformation()
        {
            return View();
        }

        public ActionResult TransUnionConsumerContactInformationResults(TransUnion trans)
        {

            string enquiryReason = trans.EnquiryReason;
            string idNumber = trans.IDNumber;
            string surname = trans.Surname;
            string refe = trans.Reference;


            System.Diagnostics.Debug.WriteLine("ID: " + idNumber);



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
            string page = "TransUnion Consumer Contact Information";
            string action = "Surname: " + surname + "; ID Number: " + idNumber + "; Enquiry Reason: " + enquiryReason;
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
            var url = "https://uatrest.searchworks.co.za/credit/transunion/contactinfo/";

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
                EnquiryReason = enquiryReason,
                IDNumber = idNumber,
                Surname = surname


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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "NotFound")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                return View();
            }
        }


        public ActionResult TransUnionConsumerIDVerification()
        {
            return View();
        }

        public ActionResult TransUnionConsumerIDVerificationResults(TransUnion search)
        {

            string id = search.IDNumber;
            string refe = search.Reference;

            System.Diagnostics.Debug.WriteLine(id);

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
            string page = "TransUnion Consumer ID Verification";
            string action = "ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/transunion/idverification/";

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
                IDNumber = id,




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

            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "NotFound")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                //ViewData["Message2"] = "No recent searches available. Please modify criteria above.";



                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                System.Diagnostics.Debug.WriteLine(ViewData["FirstName"]);

                ViewData["MiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
                ViewData["PassportNumber"] = rootObject.ResponseObject.PersonInformation.PassportNumber;
                ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["VerificationStatus"] = rootObject.ResponseObject.PersonInformation.VerificationStatus;
                ViewData["EnquiryResultID"] = rootObject.ResponseObject.PersonInformation.EnquiryResultID;
                ViewData["Reference"] = rootObject.ResponseObject.PersonInformation.Reference;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["DeceasedDate"] = rootObject.ResponseObject.PersonInformation.DeceasedDate;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                ViewData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;


                ViewData["AddressLine1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
                ViewData["AddressDate1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;
                System.Diagnostics.Debug.WriteLine(ViewData["IDNumber"]);
                System.Diagnostics.Debug.WriteLine(ViewData["IDNumber"]);

                //if (rootObject.ResponseObject.HistoricalInformation.AddressHistory !=null)
                //{
                //    ViewData["AddressLine2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].FullAddress;
                //    ViewData["AddressDate2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].LastUpdatedDate;

                //    ViewData["AddressLine3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
                //    ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

                //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
                //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
                //}






                //for (int i = 0; i < 5; i++)
                //{
                //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
                //}
                //    System.Diagnostics.Debug.WriteLine(ViewData["Address"]);
                //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                //extract list of companies returned

                //PersonInformation lst = getIndividualList(response);

                return View();
            }





            return View();
        }

        public ActionResult TransUnionConsumerProfile()
        {
            return View();
        }

        public ActionResult TransUnionConsumerProfileResults(TransUnion trans)
        {

            string id = trans.IDNumber;
            string conName = trans.ContactName;
            string conNumber = trans.ContactNumber;
            string enquiryReason = trans.EnquiryReason;
            string surname = trans.Surname;
            string firstName = trans.FirstName;
            string passport = trans.PassportNumber;
            string dob = trans.DateOfBirth;
            string refe = trans.Reference;

            System.Diagnostics.Debug.WriteLine(id);

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
            string page = "TransUnion Consumer ID Verification";
            string action = "ID: " + id + "; First Name: " + firstName + "; Surname: " + surname + "; Contact Name: " + conName + "; Contact Number: " + conNumber + "; Passport Number: " + passport + "; Date Of Birth: " + dob;
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
            var url = "https://uatrest.searchworks.co.za/credit/transunion/consumerprofile/";

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
                ContactName = conName,
                ContactNumber = conNumber,
                EnquiryReason = enquiryReason,
                IDNumber = id,
                Surname = surname,
                FirstName = firstName,
                PassportNumber = passport,
                DateOfBirth = dob,


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
            ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
            System.Diagnostics.Debug.WriteLine(ViewData["FirstName"]);
            ViewData["MiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
            ViewData["PassportNumber"] = rootObject.ResponseObject.PersonInformation.PassportNumber;
            ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
            ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
            ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
            ViewData["VerificationStatus"] = rootObject.ResponseObject.PersonInformation.VerificationStatus;
            ViewData["EnquiryResultID"] = rootObject.ResponseObject.PersonInformation.EnquiryResultID;
            ViewData["Reference"] = rootObject.ResponseObject.PersonInformation.Reference;
            ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
            ViewData["DeceasedDate"] = rootObject.ResponseObject.PersonInformation.DeceasedDate;
            ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
            ViewData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;


            ViewData["AddressLine1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
            ViewData["AddressDate1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;
            System.Diagnostics.Debug.WriteLine(ViewData["IDNumber"]);
            System.Diagnostics.Debug.WriteLine(ViewData["IDNumber"]);

            //if (rootObject.ResponseObject.HistoricalInformation.AddressHistory !=null)
            //{
            //    ViewData["AddressLine2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].FullAddress;
            //    ViewData["AddressDate2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].LastUpdatedDate;

            //    ViewData["AddressLine3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
            //    ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

            //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
            //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
            //}






            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
            //}
            //    System.Diagnostics.Debug.WriteLine(ViewData["Address"]);
            //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
            //extract list of companies returned

            //PersonInformation lst = getIndividualList(response);





            return View();
        }

        public ActionResult TransUnionConsumerTrace()
        {
            return View();
        }

        public ActionResult TransUnionConsumerTraceResults(TransUnion trans)
        {
            string enquiryID = trans.enquiryID;
            string enquiryResultID = trans.enquiryResultID;
            string seaDesc = trans.SearchDescription;
            string id = trans.IDNumber;
            string mobile = trans.mobileNumber;
            string surname = trans.Surname;
            string dob = trans.DateOfBirth;
            string tele = trans.telephoneNumber;
            string traceType = trans.TraceType;
            string refe = trans.Reference;

            traceType = "ID";

            System.Diagnostics.Debug.WriteLine(id);


            if (traceType == "enquiryID")
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
                string page = "TransUnion Consumer Trace By EnquiryID";
                string action = "Equiry ID: " + enquiryID + "; Equiry Result ID: " + enquiryResultID + "; Search Description: " + seaDesc;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);




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
                var url = "https://uatrest.searchworks.co.za/credit/transunion/consumertrace/enquiryid/";

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
                    enquiryID = enquiryID,
                    enquiryResultID = enquiryResultID,
                    searchDescription = seaDesc,
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }

            else if (traceType == "ID")
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
                string page = "TransUnion Consumer Trace By ID Number";
                string action = "ID: " + id;
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
                var url = "https://uatrest.searchworks.co.za/credit/transunion/consumertrace/idnumber/";

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
                    idNumber = id
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "NotFound")
                {
                    ViewData["Message"] = "Not Found";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    //ViewData["Message2"] = "No recent searches available. Please modify criteria above.";



                    ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                    var name = ViewData["FirstName"].ToString();
                    System.Diagnostics.Debug.WriteLine(name);



                    ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                    System.Diagnostics.Debug.WriteLine(ViewData["DateOfBirth"].ToString());

                    ViewData["MiddleName1"] = rootObject.ResponseObject[0].PersonInformation.MiddleName1;
                    ViewData["PassportNumber"] = rootObject.ResponseObject[0].PersonInformation.PassportNumber;
                    ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                    ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                    ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                    ViewData["VerificationStatus"] = rootObject.ResponseObject[0].PersonInformation.VerificationStatus;
                    ViewData["EnquiryResultID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryResultID;
                    ViewData["Reference"] = rootObject.ResponseObject[0].PersonInformation.Reference;
                    ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                    ViewData["DeceasedDate"] = rootObject.ResponseObject[0].PersonInformation.DeceasedDate;
                    ViewData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                    ViewData["EnquiryID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryID;




                    //if (rootObject.ResponseObject.HistoricalInformation.AddressHistory !=null)
                    //{
                    //    ViewData["AddressLine2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].FullAddress;
                    //    ViewData["AddressDate2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].LastUpdatedDate;

                    //    ViewData["AddressLine3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
                    //    ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

                    //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
                    //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
                    //}






                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
                    //}
                    //    System.Diagnostics.Debug.WriteLine(ViewData["Address"]);
                    //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                    //extract list of companies returned

                    //PersonInformation lst = getIndividualList(response);

                    return View();
                }
            }

            else if (traceType == "mobile")
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
                string page = "TransUnion Consumer Trace By Mobile Number";
                string action = "Mobile Number: " + mobile;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);




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
                var url = "https://uatrest.searchworks.co.za/credit/transunion/consumertrace/mobilenumber/";

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
                    mobileNumber = mobile
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }

            else if (traceType == "surname")
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
                string page = "TransUnion Consumer Trace By Surname and Date of Birth";
                string action = "Surname: " + surname + "; Date Of Birth: " + dob;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);




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
                var url = "https://uatrest.searchworks.co.za/credit/transunion/consumertrace/dateofbirthsurname/";

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
                    surname = surname,
                    DateOfBirth = dob,
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }

            else if (traceType == "tele")
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
                string page = "TransUnion Consumer Trace By Telephone Number";
                string action = "Telephone Number: " + tele;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

                System.Diagnostics.Debug.WriteLine(date_add);
                System.Diagnostics.Debug.WriteLine(time_add);
                System.Diagnostics.Debug.WriteLine(page);
                System.Diagnostics.Debug.WriteLine(action);
                System.Diagnostics.Debug.WriteLine(user_id);
                System.Diagnostics.Debug.WriteLine(us);




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
                var url = "https://uatrest.searchworks.co.za/credit/transunion/consumertrace/telephonenumber/";

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
                    surname = surname,
                    DateOfBirth = dob,
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }

            return View();
        }

        public ActionResult VeriCredAccountVerification()
        {
            return View();
        }

        public ActionResult VeriCredAccountVerificationResults(VeriCred veri)
        {

            string id = veri.idNumber;
            string accType = veri.accountType;
            string surname = veri.surname;
            string initials = veri.initials;
            string branchCode = veri.branchCode;
            string accNumber = veri.accountNumber;
            string refe = veri.Reference;

            System.Diagnostics.Debug.WriteLine(id);

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
            string page = "VeriCred Account Verification";
            string action = "ID: " + id + "; Surname: " + surname + "; Initials: " + initials + "; Account Type: " + accType + "; Account Number: " + accNumber + "; Branch Code: " + branchCode;
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
            var url = "https://uatrest.searchworks.co.za/credit/vericred/AccountVerification/";

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
                reference = authtoken,//search reference: probably store in logs
                idNumber = id,
                accountType = accType,
                surname = surname,
                initials = initials,
                branchCode = branchCode,
                accountNumber = accNumber,


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
            ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
            System.Diagnostics.Debug.WriteLine(ViewData["FirstName"]);
            ViewData["MiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
            ViewData["PassportNumber"] = rootObject.ResponseObject.PersonInformation.PassportNumber;
            ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
            ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
            ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
            ViewData["VerificationStatus"] = rootObject.ResponseObject.PersonInformation.VerificationStatus;
            ViewData["EnquiryResultID"] = rootObject.ResponseObject.PersonInformation.EnquiryResultID;
            ViewData["Reference"] = rootObject.ResponseObject.PersonInformation.Reference;
            ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
            ViewData["DeceasedDate"] = rootObject.ResponseObject.PersonInformation.DeceasedDate;
            ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
            ViewData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;


            ViewData["AddressLine1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
            ViewData["AddressDate1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;
            System.Diagnostics.Debug.WriteLine(ViewData["IDNumber"]);
            System.Diagnostics.Debug.WriteLine(ViewData["IDNumber"]);

            //if (rootObject.ResponseObject.HistoricalInformation.AddressHistory !=null)
            //{
            //    ViewData["AddressLine2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].FullAddress;
            //    ViewData["AddressDate2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].LastUpdatedDate;

            //    ViewData["AddressLine3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
            //    ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

            //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
            //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
            //}






            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
            //}
            //    System.Diagnostics.Debug.WriteLine(ViewData["Address"]);
            //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
            //extract list of companies returned

            //PersonInformation lst = getIndividualList(response);





            return View();
        }

        public ActionResult VeriCredConsumerProfile()
        {
            return View();
        }

        public ActionResult VeriCredConsumerProfileResults(VeriCred veri)
        {

            string id = veri.idNumber;
            string enquiryReason = veri.EnquiryReason;
            string refe = veri.Reference;


            System.Diagnostics.Debug.WriteLine(id);

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
            string page = "VeriCred Consumer Profile";
            string action = "ID: " + id + "; Enquiry Reason: " + enquiryReason;
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
            var url = "https://uatrest.searchworks.co.za/credit/vericred/consumerprofile/";

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
                IDNumber = id,
                EnquiryReason = enquiryReason,



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

            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "NotFound")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";

                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;


                ViewData["DelphiScore"] = rootObject.ResponseObject.CreditInformation.DelphiScore;
                ViewData["RiskColour"] = rootObject.ResponseObject.CreditInformation.RiskColour;
                ViewData["MonthlyInstalment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;


                ViewData["MonthlyInstalment"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].Account_ID;
                ViewData["MonthlyInstalment"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].Account_ID;





                //if (rootObject.ResponseObject.HistoricalInformation.AddressHistory !=null)
                //{
                //    ViewData["AddressLine2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].FullAddress;
                //    ViewData["AddressDate2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].LastUpdatedDate;

                //    ViewData["AddressLine3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
                //    ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

                //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
                //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
                //}






                //for (int i = 0; i < 5; i++)
                //{
                //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
                //}
                //    System.Diagnostics.Debug.WriteLine(ViewData["Address"]);
                //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                //extract list of companies returned

                //PersonInformation lst = getIndividualList(response);
                return View();


            }


            return View();
        }

        public ActionResult VeriCredContactInfoByIDNumber()
        {
            return View();
        }

        public ActionResult VeriCredContactInfoByIDNumberResults(VeriCred veri)
        {

            string id = veri.idNumber;
            string refe = veri.Reference;

            System.Diagnostics.Debug.WriteLine(id);


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
            string page = "VeriCred Contact Info By IDNumber";
            string action = "ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/vericred/contactinfo/";

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
                IDNumber = id,



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
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "NotFound")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";

                //PersonInformation
                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                System.Diagnostics.Debug.WriteLine(ViewData["FirstName"]);
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["CurrentEmployer"] = rootObject.ResponseObject.PersonInformation.CurrentEmployer;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;



                //ContactInformation
                ViewData["MobileNumber"] = rootObject.ResponseObject.ContactInformation.MobileNumber;
                ViewData["HomeTelephoneNumber"] = rootObject.ResponseObject.ContactInformation.HomeTelephoneNumber;
                ViewData["WorkTelephoneNumber"] = rootObject.ResponseObject.ContactInformation.WorkTelephoneNumber;
                ViewData["PhysicalAddress"] = rootObject.ResponseObject.ContactInformation.PhysicalAddress;


                return View();
            }









            return View();
        }

        public ActionResult VeriCredIDPhotoVerification()
        {
            return View();
        }

        public ActionResult VeriCredIDPhotoVerificationResults(VeriCred veri)
        {

            string id = veri.idNumber;
            string refe = veri.Reference;

            System.Diagnostics.Debug.WriteLine(id);


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
            string page = "VeriCred ID Photo Verification";
            string action = "ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/vericred/idphotoverification/";

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
                reference = authtoken,//search reference: probably store in logs
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
            var mes = ViewData["ResponseMessage"].ToString();

            System.Diagnostics.Debug.WriteLine("Message " + mes);
            if (mes == "NotFound")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";

                //PersonInformation
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;
                ViewData["MarriageDate"] = rootObject.ResponseObject.PersonInformation.MarriageDate;
                ViewData["CountryOfBirth"] = rootObject.ResponseObject.PersonInformation.Reference;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;


                //HomeAffairsInformation
                ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                ViewData["PlaceOfDeath"] = rootObject.ResponseObject.HomeAffairsInformation.PlaceOfDeath;
                ViewData["PlaceOfMarriage"] = rootObject.ResponseObject.HomeAffairsInformation.PlaceOfMarriage;
                ViewData["IDIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDIssuedDate;
                ViewData["IDCardIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssuedDate;
                ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                ViewData["VerifiedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus;
                ViewData["HomeIDNumber"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                ViewData["IDPhotoURL"] = rootObject.ResponseObject.HomeAffairsInformation.IDPhotoURL;
                ViewData["HomeFirstName"] = rootObject.ResponseObject.HomeAffairsInformation.FirstName;
                ViewData["HomeSurname"] = rootObject.ResponseObject.HomeAffairsInformation.Surname;

                return View();
            }
            return View();
        }

        public ActionResult VeriCredIncomeEstimateByIDNumber()
        {
            return View();
        }

        public ActionResult VeriCredIncomeEstimateByIDNumberResults(VeriCred veri)
        {

            string id = veri.idNumber;
            string refe = veri.Reference;

            System.Diagnostics.Debug.WriteLine(id);


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
            string page = "VeriCred Income Estimate By IDNumber";
            string action = "ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/vericred/incomeestimate/";

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
                reference = authtoken,//search reference: probably store in logs
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

            //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            System.Diagnostics.Debug.WriteLine("Reponse Message:" + ViewData["ResponseMessage"]);

            ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;

            var mes = ViewData["ResponseMessage"].ToString();

            System.Diagnostics.Debug.WriteLine("Message " + mes);
            if (mes == "NotFound" || mes == "Invalid sessionToken")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";


                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                System.Diagnostics.Debug.WriteLine(ViewData["FirstName"]);
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["Initials"] = rootObject.ResponseObject.PersonInformation.Initials;
                ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["EnquiryID"] = rootObject.ResponseObject.PersonInformation.EnquiryID;
                ViewData["EnquiryResultID"] = rootObject.ResponseObject.PersonInformation.EnquiryResultID;
                ViewData["IncomeGrossEstimate"] = rootObject.ResponseObject.PersonInformation.IncomeGrossEstimate;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;

                ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                ViewData["PlaceOfDeath"] = rootObject.ResponseObject.HomeAffairsInformation.PlaceOfDeath;
                ViewData["PlaceOfMarriage"] = rootObject.ResponseObject.HomeAffairsInformation.PlaceOfMarriage;
                ViewData["IDIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDIssuedDate;
                ViewData["IDCardIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssuedDate;
                ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                ViewData["VerifiedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus;

                return View();

            }









            return View();
        }

        public ActionResult VeriCredPersonVerificationByIDNumber()
        {
            return View();
        }

        public ActionResult VeriCredPersonVerificationByIDNumberResults(VeriCred search)
        {

            string id = search.idNumber;
            string refe = search.Reference;

            System.Diagnostics.Debug.WriteLine(id);


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
            string page = "VeriCred Person Verification By IDNumber";
            string action = "ID: " + id;
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
            var url = "https://uatrest.searchworks.co.za/credit/vericred/personverification/";

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

            var mes = ViewData["ResponseMessage"].ToString();

            System.Diagnostics.Debug.WriteLine("Message " + mes);
            if (mes == "NotFound")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";


                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                System.Diagnostics.Debug.WriteLine(ViewData["FirstName"]);
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["Initials"] = rootObject.ResponseObject.PersonInformation.Initials;
                ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["EnquiryID"] = rootObject.ResponseObject.PersonInformation.EnquiryID;
                ViewData["EnquiryResultID"] = rootObject.ResponseObject.PersonInformation.EnquiryResultID;
                ViewData["Reference"] = rootObject.ResponseObject.PersonInformation.Reference;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;

                ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                ViewData["PlaceOfDeath"] = rootObject.ResponseObject.HomeAffairsInformation.PlaceOfDeath;
                ViewData["PlaceOfMarriage"] = rootObject.ResponseObject.HomeAffairsInformation.PlaceOfMarriage;
                ViewData["IDIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDIssuedDate;
                ViewData["IDCardIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssuedDate;
                ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                ViewData["VerifiedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus;

                return View();

            }









            return View();
        }

        public ActionResult XDSConsumerIDVerification()
        {
            return View();
        }

        public ActionResult XDSConsumerIDVerificationResults(XDS xds)
        {
            string refe = xds.Reference;
            string id = xds.IDNumber;
            string type = xds.Type;
            string enquiryID = xds.enquiryID;
            string enquiryResultID = xds.enquiryResultID;
            string seaDesc = xds.searchDescription;
            string name = xds.FirstName;
            string sur = xds.Surname;


            System.Diagnostics.Debug.WriteLine(id);

            if (type == "photo")
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
                string page = "XDS ID Photo Verification";
                string action = "ID: " + id;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/xds/idphotoverification/";

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
                    Reference = authtoken,//search reference: probably store in logs
                    IDNumber = id,



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

                // System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation["DateOfBirth"];
                    //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                    ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                    //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                        ViewData["MarriageDate"] = rootObject.ResponseObject.PersonInformation.MarriageDate;
                        ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                        ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                        ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }

                    if (ViewData["HomeAffairsInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["IDNumber"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                        ViewData["IDPhoto"] = rootObject.ResponseObject.HomeAffairsInformation.IDPhoto;
                        ViewData["FirstName"] = rootObject.ResponseObject.HomeAffairsInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject.HomeAffairsInformation.Surname;
                        ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                        ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                        ViewData["IDIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDIssuedDate;
                        ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                        ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                        ViewData["HanisReference"] = rootObject.ResponseObject.HomeAffairsInformation.HanisReference;
                        ViewData["DiaReference"] = rootObject.ResponseObject.HomeAffairsInformation.DiaReference;
                        ViewData["IDPhotoURL"] = rootObject.ResponseObject.HomeAffairsInformation.IDPhotoURL;
                    }
                    else
                    {
                        ViewData["HomeAffairsInformationMessage"] = "No Match";
                    }
                    return View();
                }






            }

            else if (type == "enquiryID")
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
                string page = "XDS Consumer ID Verification By EnquiryID";
                string action = "Equiry ID: " + enquiryID + "; Equiry Result ID: " + enquiryResultID + "; Search Description: " + seaDesc;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/idverification/enquiryid/";

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
                    enquiryID = enquiryID,
                    enquiryResultID = enquiryResultID,
                    searchDescription = seaDesc,
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }
            else
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
                string page = "XDS Consumer ID Verification";
                string action = "Name: " + name + "; Surname: " + sur + "; ID: " + id;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/idverification/";

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

                JToken token = JToken.Parse(response.Content);

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                var mes = ViewData["ResponseMessage"].ToString();

                System.Diagnostics.Debug.WriteLine("message: " + mes);

                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject[0].PersonInformation["FirstName"];
                    //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                    //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                    //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["PersonID"] = rootObject.ResponseObject[0].PersonInformation.PersonID;
                        ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        ViewData["Description"] = rootObject.ResponseObject[0].PersonInformation.Description;
                        ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        ViewData["PassportNumber"] = rootObject.ResponseObject[0].PersonInformation.PassportNumber;
                        ViewData["EnquiryID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryID;
                        ViewData["EnquiryResultID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryResultID;
                        ViewData["Reference"] = rootObject.ResponseObject[0].PersonInformation.Reference;
                        ViewData["HasProperties"] = rootObject.ResponseObject[0].PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }

                    return View();
                }
            }


            return View();
        }

        public ActionResult XDS()
        {
            return View();
        }

        public ActionResult XDSConsumerTrace()
        {
            return View();
        }

        public ActionResult XDSConsumerTraceResults(XDS xds)
        {
            string refe = xds.Reference;
            string suburb = xds.Suburb;
            string streetNumber = xds.StreetNumber;
            string streetName = xds.StreetName;
            string city = xds.City;
            string province = xds.Province;
            string type = xds.Type;
            string enquiryID = xds.enquiryID;
            string enquiryResultID = xds.enquiryResultID;
            string seaDesc = xds.searchDescription;
            string name = xds.FirstName;
            string surname = xds.Surname;
            string dob = xds.DateOfBirth;
            string passport = xds.PassportNumber;
            string teleCode = xds.TelephoneCode;
            string teleNumber = xds.TelephoneNumber;

            string id = xds.IDNumber;

            System.Diagnostics.Debug.WriteLine(name);
            System.Diagnostics.Debug.WriteLine(surname);
            System.Diagnostics.Debug.WriteLine(id);

            if (type == "address")
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
                string page = "XDS Consumer Trace By Address";
                string action = "Suburb: " + suburb + "; Street Number: " + streetNumber + "; Street Name: " + streetName + "; City: " + city + "; Province: " + province;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/consumertrace/address/";

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
                    Reference = authtoken,//search reference: probably store in logs
                    Suburb = suburb,
                    StreetNumber = streetNumber,
                    StreetName = streetName,
                    City = city,
                    Province = province,



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
                ViewData["PersonID"] = rootObject.ResponseObject[0].PersonInformation.PersonID;
                ViewData["PassportNumber"] = rootObject.ResponseObject[0].PersonInformation.PassportNumber;
                ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                ViewData["EnquiryID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryID;
                ViewData["EnquiryResultID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryResultID;
                ViewData["Reference"] = rootObject.ResponseObject[0].PersonInformation.Reference;
                ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                ViewData["Quality"] = rootObject.ResponseObject[0].PersonInformation.Quality;
                System.Diagnostics.Debug.WriteLine(ViewData["MaritalStatus"]);
                //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                //extract list of companies returned

                //PersonInformation lst = getIndividualList(response);
            }

            else if (type == "enquiryID")
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
                string page = "XDS Consumer Trace By EnquiryID";
                string action = "Equiry ID: " + enquiryID + "; Equiry Result ID: " + enquiryResultID + "; Search Description: " + seaDesc;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/consumertrace/enquiryid/";

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
                    EnquiryID = enquiryID,
                    EnquiryResultID = enquiryResultID,
                    SearchDescription = seaDesc,
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }

            else if (type == "ID")
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
                string page = "XDS Consumer Trace By ID Number";
                string action = "ID: " + id;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/consumertrace/idnumber/";

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
                    IDNumber = id
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject[0].PersonInformation["DateOfBirth"];
                    //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                    //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                    //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["PersonID"] = rootObject.ResponseObject[0].PersonInformation.PersonID;
                        ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        ViewData["Description"] = rootObject.ResponseObject[0].PersonInformation.Description;
                        ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        ViewData["PassportNumber"] = rootObject.ResponseObject[0].PersonInformation.PassportNumber;
                        ViewData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        ViewData["EnquiryID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryID;
                        ViewData["EnquiryResultID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryResultID;
                        ViewData["Reference"] = rootObject.ResponseObject[0].PersonInformation.Reference;
                        ViewData["HasProperties"] = rootObject.ResponseObject[0].PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }

                    return View();
                }


            }

            else if (type == "name")
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
                string page = "XDS Consumer Trace by Name";
                string action = "First Name: " + name + "; Surname: " + surname + "; Date Of Birth: " + dob;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/consumertrace/name/";

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
                    Surname = surname,
                    Firstname = name,
                    DateOfBirth = dob,
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                System.Diagnostics.Debug.WriteLine("Message: " + mes);
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject[0].PersonInformation["DateOfBirth"];
                    //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                    //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                    //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["PersonID"] = rootObject.ResponseObject[0].PersonInformation.PersonID;
                        ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        ViewData["Description"] = rootObject.ResponseObject[0].PersonInformation.Description;
                        ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        ViewData["PassportNumber"] = rootObject.ResponseObject[0].PersonInformation.PassportNumber;
                        ViewData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        ViewData["EnquiryID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryID;
                        ViewData["EnquiryResultID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryResultID;
                        ViewData["Reference"] = rootObject.ResponseObject[0].PersonInformation.Reference;
                        ViewData["HasProperties"] = rootObject.ResponseObject[0].PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }

                    return View();
                }
            }

            else if (type == "passport")
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
                string page = "XDS Consumer Trace By PassportNumber";
                string action = "Passport Number: " + passport;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/consumertrace/passportnumber/";

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
                    PassportNumber = passport,

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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else if (mes == "NotFound")
                {
                    ViewData["Message"] = "No Results Found";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation["DateOfBirth"];
                    //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                    ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                    //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                        ViewData["MarriageDate"] = rootObject.ResponseObject.PersonInformation.MarriageDate;
                        ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                        ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                        ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }

                    if (ViewData["HomeAffairsInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["IDNumber"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                        ViewData["IDPhoto"] = rootObject.ResponseObject.HomeAffairsInformation.IDPhoto;
                        ViewData["FirstName"] = rootObject.ResponseObject.HomeAffairsInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject.HomeAffairsInformation.Surname;
                        ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
                        ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                        ViewData["IDIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDIssuedDate;
                        ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                        ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
                        ViewData["HanisReference"] = rootObject.ResponseObject.HomeAffairsInformation.HanisReference;
                        ViewData["DiaReference"] = rootObject.ResponseObject.HomeAffairsInformation.DiaReference;
                        ViewData["IDPhotoURL"] = rootObject.ResponseObject.HomeAffairsInformation.IDPhotoURL;
                    }
                    else
                    {
                        ViewData["HomeAffairsInformationMessage"] = "No Match";
                    }
                    return View();
                }
            }

            else if (type == "tele")
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
                string page = "XDS Consumer Trace by TelephoneNumber";
                string action = "Surname: " + surname + "; Telephone Code: " + teleCode + "; Telephone Number: " + teleNumber;
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
                ViewData["type"] = type;

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
                var url = "https://uatrest.searchworks.co.za/credit/xds/consumertrace/telephonenumber/";

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
                    Surname = surname,
                    TelephoneCode = teleCode,
                    TelephoneNumber = teleNumber
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

                //System.Diagnostics.Debug.WriteLine(o["ResponseObject"].ToString());
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    ViewData["Message"] = "good";
                    ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["PersonInformationMessage"] = rootObject.ResponseObject[0].PersonInformation["DateOfBirth"];
                    //ViewData["CreditInformationMessage"] = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
                    //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
                    //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

                    if (ViewData["PersonInformationMessage"].ToString() != "")
                    {
                        //personaInformantion
                        ViewData["PersonID"] = rootObject.ResponseObject[0].PersonInformation.PersonID;
                        ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;
                        ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                        ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
                        ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
                        ViewData["Description"] = rootObject.ResponseObject[0].PersonInformation.Description;
                        ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
                        ViewData["PassportNumber"] = rootObject.ResponseObject[0].PersonInformation.PassportNumber;
                        ViewData["Gender"] = rootObject.ResponseObject[0].PersonInformation.Gender;
                        ViewData["Age"] = rootObject.ResponseObject[0].PersonInformation.Age;
                        ViewData["EnquiryID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryID;
                        ViewData["EnquiryResultID"] = rootObject.ResponseObject[0].PersonInformation.EnquiryResultID;
                        ViewData["Reference"] = rootObject.ResponseObject[0].PersonInformation.Reference;
                        ViewData["HasProperties"] = rootObject.ResponseObject[0].PersonInformation.HasProperties;
                    }
                    else
                    {
                        ViewData["PersonInformationMessage"] = "No Match";
                    }

                    return View();
                }
            }


            return View();
        }
    }
}
