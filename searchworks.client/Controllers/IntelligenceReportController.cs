using MySql.Data.MySqlClient;
using searchworks.client.Models;
using searchworks.client.Report;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web.Mvc;

namespace searchworks.client.Controllers
{
    public class IntelligenceReportController : Controller
    {
        // GET: IntelligenceReport
        public ActionResult Report(int? id)
        {
            CheckReport checkReport = new CheckReport();
            byte[] abytes = checkReport.PrepareReport(GetHistory(id));
            return File(abytes, "application/pdf");

        }

        public check GetHistory(int? id)
        {

            check chec = new check();

            dbChecks bgDBModel = new dbChecks();


            List<check> checkList = new List<check>();
            using (dbChecks checkModel = new dbChecks())
            {

                var mail = "1";
                chec = checkModel.Checks.Find(id);

                string serverIp = "localhost";
                string username = "root";
                string password = "";
                string databaseName = "jcred";

                //string serverIp = "197.242.148.16";
                ////string username = "cykgxznt_user";
                //string username = "cykgxznt_admin";
                //string password = "jcred123";
                //string databaseName = "cykgxznt_jcred";
                //string port = "3306";

                string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
                string query = "SELECT * FROM checks WHERE id = '" + mail + "'";
                //string query = "SELECT * FROM checks, check_list WHERE checks.check_id = check_list.checks_id AND checks.check_id =  '" + TempData["check_id"] + "'";

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
                conn.Open();

                var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    chec = new check();

                    chec.first_name = reader["first_name"].ToString();
                    chec.surname = reader["surname"].ToString();
                    chec.check_id = Convert.ToInt32(reader["check_id"]);
                    chec.IDNum = reader["IDNum"].ToString();
                    chec.reason = reader["reason"].ToString();
                    chec.user_email = reader["user_email"].ToString();
                    chec.search_date = DateTime.Parse(reader["search_date"].ToString());









                }

                conn.Close();


                string query1 = "SELECT * FROM check_list WHERE checks_id = '" + chec.check_id + "'";
                conn.Open();

                var cmd1 = new MySql.Data.MySqlClient.MySqlCommand(query1, conn);
                var reader1 = cmd1.ExecuteReader();

                while (reader1.Read())
                {

                    chec.status = reader1["checks"].ToString();


                }

            }

            return chec;
        }
        public ActionResult IntelligenceReport()
        {
            IntelligenceReport checkSub = new IntelligenceReport
            {
                Check = new List<Check>()
            {
                new Check(){ },
                   new Check(){ }
            }
            };
            return View(checkSub);
        }

        public ActionResult AddCheck(Check check)
        {
            TempData["check"] = check;
            return View();
        }



        public ActionResult BlankEditorRow()
        {
            return PartialView("IntelligenceReportCheck/_IntelligenceReportCheckUpload", new Check());
        }

        public ActionResult PopulatedEditorRow(string id)
        {
            if (id == "" || id == null)
            {
                return null;
            }
            else
            {
                //check this code below

                var price1 = id.Split('|')[1];
                var price = price1.Split(' ')[1];


                return PartialView("IntelligenceReportCheck/_IntelligenceReportCheckUpload",
                                    new Check()
                                    {
                                        CheckType = id,

                                        CheckPrice = decimal.Parse(price, CultureInfo.InvariantCulture)
                                        //CheckPrice = Convert.ToDecimal(id.Split('|')[1])
                                    });
            }
        }

        public ActionResult SubmitCheck(IntelligenceReport checksSubmission)
        {
            //TempData["ExistingClient"] = TempData["mEmail"];

            //ExistingClient existingClient = new ExistingClient();

            //existingClient.Email = "raymond@gmail.com";

            if (TempData.Peek("ExistingClient") != null && TempData.Peek("NewClient") != null)
            {
                return RedirectToAction("SubmissionStep1");
            }

            if (ModelState.IsValid)
            {
                // Validate CheckDocument and ConsentForm

                //================================== Email =========================================================

                // Validate CheckDocument and ConsentForm

                //using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["EmailFrom"], ConfigurationManager.AppSettings["EmailTo"]))
                //using (MailMessage mmm = new MailMessage("raymondmortu@outlook.com", checksSubmission.Email))
                //{
                //    mmm.Subject = "Background Checks - New Application Submitted";
                //    mmm.Body = $"Dear {TempData["name"]}" + $"{TempData["surname"]}" + "<br/><br/>";

                //    //if (TempData["ExistingClient"] != null)
                //    //{
                //    //mm.Body += $"Existing Client Email :{((ExistingClient)TempData["ExistingClient"]).Email}<br><br>";

                //    var url = "http://www.google.com";

                //    mmm.Body += $"Thank you for your application regarding {checksSubmission.FullFirstName}" + " " + $"{checksSubmission.Surname}.<br/>" +
                //        "The results thereof shall be emailed to you upon completion of the relevant verification procedures, <br>" +
                //        "provided the relevant information and forms have been provided and uploaded on Background Checks. <br/><br/>" +
                //        "Please use the ID number as reference in any queries regarding your application <br/><br/>" +
                //        "For any enquiries send us an e-mail at support@backgroundchecks.co.za or contact us on the numbers below.<br/><br/>";
                //    //$"<a target='_blank' href='www.google.com'><button>Activate Account</button></a> <br/><br/>";

                //    //}

                //    mmm.Body += "Regards<br/>" +
                //        "Background Checks Support Team<br/>" +
                //        "011 051 6147";

                //    mmm.IsBodyHtml = true;

                //    SmtpClient smtp = new SmtpClient
                //    {
                //        Host = "smtp-mail.outlook.com",
                //        EnableSsl = true
                //    };

                //    NetworkCredential NetworkCred = new NetworkCredential("raymondmortu@outlook.com", "raymonddoe13");
                //    smtp.UseDefaultCredentials = true;
                //    smtp.Credentials = NetworkCred;
                //    smtp.Port = 587;
                //    smtp.Send(mmm);

                //    TempData["SuccessResult"] = "Form Successfully submitted.";
                //}

                TempData["SuccessResult"] = "Form Successfully submitted.";
                //SmtpClient smtp = new SmtpClient
                //{
                //    Host = "mail.backgroundchecks.co.za",
                //    EnableSsl = false
                //};

                //NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["HostEmail"], ConfigurationManager.AppSettings["HostEmailPassword"]);

                //=================================================================================================

                //using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["EmailFrom"], ConfigurationManager.AppSettings["EmailTo"]))
                using (MailMessage mm = new MailMessage("raymondmortu@outlook.com", "raymond.mortu@gmail.com"))
                {
                    //string fileList = "";
                    //mm.Subject = "Checks Submission";
                    //mm.Body = "<b>Checks Submission</b><br/><br/>";

                    ////if (TempData["ExistingClient"] != null)
                    ////{
                    ////mm.Body += $"Existing Client Email :{((ExistingClient)TempData["ExistingClient"]).Email}<br><br>";

                    //var email = TempData["email"];
                    //var uid = TempData["uid"];

                    //mm.Body += $"Existing Client Email :{checksSubmission.Email}<br><br>";

                    ////}

                    //mm.Body += "<b>Application details</b><br>" +
                    //           $"Full First Name : {checksSubmission.FullFirstName} <br/>" +
                    //           $"Surname : {checksSubmission.Surname} <br/>" +
                    //           $"Passport Number : {checksSubmission.MaidenName} <br/>" +
                    //           $"ID Number : {checksSubmission.IDNumber} <br/>" +
                    //           $"Passport Number : {checksSubmission.PassportNumber} <br/>" +
                    //           $"Passport Number : {checksSubmission.Mobile} <br/>" +
                    //           $"Passport Number : {checksSubmission.Country} <br/>" +
                    //           $"Date of Birth : {checksSubmission.DateOfBirth} <br/><br>" +
                    //           $"Passport Number : {checksSubmission.Reason} <br/>";

                    //===================================================================================================================

                    string serverIp = "localhost";
                    string username = "root";
                    string password = "";
                    string databaseName = "jcred";

                    //string serverIp = "197.242.148.16";
                    ////string username = "cykgxznt_user";
                    //string username = "cykgxznt_admin";
                    //string password = "jcred123";
                    //string databaseName = "cykgxznt_jcred";
                    //string port = "3306";

                    string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                    var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                    string query_uid = "SELECT * FROM members WHERE email = '" + checksSubmission.Email + "'";

                    conn.Open();

                    var cmd2 = new MySql.Data.MySqlClient.MySqlCommand(query_uid, conn);

                    var reader2 = cmd2.ExecuteReader();

                    reader2.Read();

                    var userID = reader2.GetInt32("id");

                    conn.Close();

                    //=================================== GENERATE CHECK ID =========================

                    ArrayList lstNumbers = new ArrayList();
                    Random rndNumber = new Random();

                    ArrayList ar = RandomNumbers(11111, 999999999, 0);

                    for (int iLoop = 0; iLoop < ar.Count; iLoop++)
                    {
                        //var ticks = DateTime.Now.Ticks;
                        //var guid = Guid.NewGuid().ToString();
                        //var uniqueSessionId = ticks.ToString() + '-' + guid;

                        //string tickss = DateTime.Now.Ticks.ToString();
                        //tickss = tickss.Substring(tickss.Length - 15);
                        //=============================================================================

                        Random rand = new Random();
                        int ccc = rand.Next(000000000, 999999999);

                        check check = new check();

                        var DOB = Convert.ToDateTime(checksSubmission.DateOfBirth);

                        string fileNames = Path.GetFileName(checksSubmission.ConsentForm.FileName);
                        string checks = checksSubmission.Check.Count.ToString();

                        string query = "INSERT INTO checks (check_id, first_name,surname, maiden_name, IDNum, passportNum, country, DOB, mobile ,Num_search, reason ,consent_Form, user_id, user_email) VALUES('" + ar[iLoop] + "','" + checksSubmission.FullFirstName + "', '" + checksSubmission.Surname + "', '" + checksSubmission.MaidenName + "', '" + checksSubmission.IDNumber + "', '" + checksSubmission.PassportNumber + "', '" + checksSubmission.Country + "', '" + DOB + "', '" + checksSubmission.Mobile + "', '" + checks + "', '" + checksSubmission.Reason + "', '" + fileNames + "','" + userID + "','" + checksSubmission.Email + "' )";

                        //string query_checklist = "INSERT INTO checks_list (checks_id, checks, detail_attached_file_name)";

                        conn.Open();

                        var cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
                        var reader = cmd.ExecuteReader();

                        conn.Close();

                        //===================================================================================================================

                        //mm.IsBodyHtml = true;

                        if (checksSubmission.Check != null)
                        {
                            foreach (Check attachment in checksSubmission.Check)
                            {
                                string query_checklist = "INSERT INTO check_list (checks_id, checks, detail_attached_file_name) " +
                                    "VALUES('" + ar[iLoop] + "', '" + attachment.CheckType + "', '" + attachment.CheckInfo + "' )";




                                conn.Open();



                                var cmd3 = new MySql.Data.MySqlClient.MySqlCommand(query_checklist, conn);
                                var reader3 = cmd3.ExecuteReader();

                                conn.Close();
                            }
                        }

                        //if (checksSubmission.Check != null)
                        //{
                        //    foreach (Check attachment in checksSubmission.Check)
                        //    {
                        //        string query_checklist = "INSERT INTO check_list (checks_id, checks, detail_attached_file_name) " +
                        //            "VALUES('" + ar[iLoop] + "', '" + attachment.CheckType + "', '" + attachment.CheckInfo + "' )";

                        //        conn.Open();

                        //        var cmd3 = new MySql.Data.MySqlClient.MySqlCommand(query_checklist, conn);
                        //        var reader3 = cmd3.ExecuteReader();

                        //        conn.Close();

                        //        if (attachment.CheckDocument != null)
                        //        {
                        //            fileList += attachment.CheckType.Split('|')[0] + " : " + Path.GetFileName(attachment.CheckDocument.FileName) + "<br>";

                        //            if (attachment != null)
                        //            {
                        //                string fileName = Path.GetFileName(attachment.CheckDocument.FileName);
                        //                mm.Attachments.Add(new Attachment(attachment.CheckDocument.InputStream, fileName));
                        //            }
                        //        }
                        //        else
                        //            fileList += attachment.CheckType.Split('|')[0] + " : " + attachment.CheckInfo + "<br>";
                        //    }
                        //}

                        //{
                        //    fileList += "Consent Form : " + Path.GetFileName(checksSubmission.ConsentForm.FileName) + "<br>";
                        //    string fileName = Path.GetFileName(checksSubmission.ConsentForm.FileName);
                        //    mm.Attachments.Add(new Attachment(checksSubmission.ConsentForm.InputStream, fileName));
                        //}

                        //mm.Body += fileList;
                        //mm.IsBodyHtml = true;
                    }
                    //SmtpClient smtp = new SmtpClient
                    //{
                    //    Host = "mail.backgroundchecks.co.za",
                    //    EnableSsl = false
                    //};

                    //NetworkCredential NetworkCred = new NetworkCredential(ConfigurationManager.AppSettings["HostEmail"], ConfigurationManager.AppSettings["HostEmailPassword"]);

                    //SmtpClient smtp = new SmtpClient
                    //{
                    //    Host = "smtp-mail.outlook.com",
                    //    EnableSsl = true
                    //};

                    //NetworkCredential NetworkCred = new NetworkCredential("raymondmortu@outlook.com", "raymonddoe13");
                    //smtp.UseDefaultCredentials = true;
                    //smtp.Credentials = NetworkCred;
                    //smtp.Port = 587;
                    //smtp.Send(mm);

                    TempData["SuccessResult"] = "Form Successfully submitted.";
                    //return View("SubmissionStep1");
                    return View("IntelligenceReport", checksSubmission);
                }
            }
            else
            {
                TempData["ErrorResult"] = "Invalid fields entered.";
                return View("IntelligenceReport", checksSubmission);
            }
        }

        public ArrayList RandomNumbers(int iFromNum, int iToNum, int iNumOfItem)
        {
            ArrayList lstNumbers = new ArrayList();
            Random rndNumber = new Random();

            int number = rndNumber.Next(iFromNum, iToNum);
            lstNumbers.Add(number); int count = 0;

            do
            {
                number = rndNumber.Next(iFromNum, iToNum);

                if (!lstNumbers.Contains(number))
                {
                    lstNumbers.Add(number);
                }

                count++;
            } while (count <= iNumOfItem);

            return lstNumbers;
        }

        public ActionResult SubmitNewClient(NewClient newClient)
        {
            if (ModelState.IsValid)
            {
                TempData["NewClient"] = newClient;
                TempData["ExistingClient"] = null;
                IntelligenceReport checkSubmission = new IntelligenceReport
                {
                    Check = new List<Check>()
                    {
                      new Check(){ },
                      new Check(){ }
                    }
                };
                return View("SubmissionStep2", checkSubmission);
            }
            else
            {
                TempData["ErrorResult"] = "Fill in all fields on form before submitting";
                return View("SubmissionStep1", newClient);
            }
        }

        public ActionResult SubmitExistingClient(ExistingClient existingClient)
        {
            if (ModelState.IsValid)
            {
                TempData["NewClient"] = null;
                TempData["ExistingClient"] = existingClient;
                IntelligenceReport checkSubmission = new IntelligenceReport
                {
                    Check = new List<Check>()
                    {
                      new Check(){ },
                      new Check(){ }
                    }
                };
                return View("SubmissionStep2", checkSubmission);
            }
            else
            {
                TempData["ErrorResult"] = "Fill in all fields on form before submitting";
                return View("SubmissionStep1", existingClient);
            }
        }

        //========================================

        //public ActionResult Dashboard()
        //{
        //    return View();
        //}

        //==========================================

        public ActionResult ExistingClient()
        {
            return PartialView("ChecksSubmission/_PartialExistingClient");
        }

        public ActionResult NewClient()
        {
            return PartialView("ChecksSubmission/_PartialNewClient");
        }

        public ActionResult IntelligenceReportHistory()
        {
            List<check> checkList = new List<check>();
            using (dbChecks checkModel = new dbChecks())
            {
                checkList = checkModel.Checks.ToList<check>();
            }

            return View(checkList);
        }
        public ActionResult ReportAdmin(int? id)
        {
            dbChecks checkModel = new dbChecks();
            checkList checkList = new checkList();

            check_list _List = checkList.check_list.Find(id);
            check edit = checkModel.Checks.Find(id);

            string serverIp = "localhost";
            string username = "root";
            string password = "";
            string databaseName = "bgcheck";

            string dbConnectionString = string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
            string query = "SELECT * FROM checks WHERE id = '" + id + "'";

            var conn = new MySqlConnection(dbConnectionString);
            conn.Open();

            TempData["checkID"] = id;

            var cmd = new MySqlCommand(query, conn);
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                var u_id = reader["check_id"];

                TempData["checkID"] = u_id;
            }

            conn.Close();

            string query1 = "SELECT * FROM check_list WHERE checks_id = '" + TempData["checkID"] + "'";
            conn.Open();

            var cmd1 = new MySqlCommand(query1, conn);
            var reader1 = cmd1.ExecuteReader();

            while (reader1.Read())
            {
                var checks = reader1["checks"];

                TempData["checks"] = checks;
            }

            return View(edit);
        }
    }
}