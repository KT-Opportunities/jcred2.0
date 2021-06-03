using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using searchworks.client.Credit;
using searchworks.client.Models;
using ServiceStack.Text.Json;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace searchworks.client.Controllers
{
    public class CreditController : Controller
    {
        public void MakeConnection(string query_uid)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic ResponseType, dynamic Name, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription)
        {
            string query_uid = "INSERT INTO searchhistory (SearchID,searchUserName,ResponseType,Name,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription) VALUES('" + SearchID + "','" + searchUserName + "','" + ResponseType + "','" + Name + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCompuScanSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic created_at)
        {
            string query_uid = "INSERT INTO compuscansearchhist (SearchID,searchUserName,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,created_at) VALUES('" + SearchID + "','" + searchUserName + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveTransUnionSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic created_at)
        {
            string query_uid = "INSERT INTO transunionsearchHistory (SearchID,searchUserName,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,created_at) VALUES('" + SearchID + "','" + searchUserName + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveXDSSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic created_at)
        {
            string query_uid = "INSERT INTO xdssearchHistory (SearchID,searchUserName,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,created_at) VALUES('" + SearchID + "','" + searchUserName + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void savePersonInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic InformationDate, dynamic PersonID, dynamic Title, dynamic DateOfBirth, dynamic FirstName, dynamic Surname, dynamic Fullname, dynamic IDNumber, dynamic IDNumber_Alternate, dynamic PassportNumber, dynamic Ref, dynamic MaritalStatus, dynamic Gender, dynamic Age, dynamic MiddleName1, dynamic MiddleName2, dynamic SpouseFirstName, dynamic SpouseSurname, dynamic NumberOfDependants, dynamic Remarks, dynamic CurrentEmployer, dynamic VerificationStatus, dynamic HasProperties, dynamic created_at)
        {
            string query_uid = "INSERT INTO personinformation (SearchToken,Reference,SearchID,InformationDate,PersonID,Title,DateOfBirth,FirstName,Surname,Fullname,IDNumber,IDNumber_Alternate,PassportNumber,Ref,MaritalStatus,Gender,Age,MiddleName1,MiddleName2,SpouseFirstName,SpouseSurname,NumberOfDependants,Remarks,CurrentEmployer,VerificationStatus,HasProperties,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + InformationDate + "','" + PersonID + "','" + Title + "','" + DateOfBirth + "','" + FirstName + "','" + Surname + "','" + Fullname + "','" + IDNumber + "','" + IDNumber_Alternate + "','" + PassportNumber + "','" + Ref + "','" + MaritalStatus + "','" + Gender + "','" + Age + "','" + MiddleName1 + "','" + MiddleName2 + "','" + SpouseFirstName + "','" + SpouseSurname + "','" + NumberOfDependants + "','" + Remarks + "','" + CurrentEmployer + "','" + VerificationStatus + "','" + HasProperties + "','" + created_at + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveContactInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EmailAddress, dynamic MobileNumber, dynamic HomeTelephoneNumber, dynamic WorkTelephoneNumber, dynamic PhysicalAddress, dynamic PostalAddress, dynamic created_at)
        {
            string query_uid = "INSERT INTO contactinformation (SearchToken,Reference,SearchID,EmailAddress,MobileNumber,HomeTelephoneNumber,WorkTelephoneNumber,PhysicalAddress,PostalAddress,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EmailAddress + "','" + MobileNumber + "','" + HomeTelephoneNumber + "','" + WorkTelephoneNumber + "','" + PhysicalAddress + "','" + PostalAddress + "','" + created_at + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveHomeAffairsInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic FirstName, dynamic DeceasedDate, dynamic IDVerified, dynamic SurnameVerified, dynamic Warnings, dynamic DeceasedStatus, dynamic VerifiedStatus, dynamic InitialsVerified, dynamic CauseOfDeath, dynamic VerifiedDate, dynamic created_at)
        {
            string query_uid = "INSERT INTO homeaffairsinformation (SearchToken,Reference,SearchID,FirstName,DeceasedDate,IDVerified,SurnameVerified,Warnings,DeceasedStatus,VerifiedStatus,InitialsVerified,CauseOfDeath,VerifiedDate,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + FirstName + "','" + DeceasedDate + "','" + IDVerified + "','" + SurnameVerified + "','" + Warnings + "','" + DeceasedStatus + "','" + VerifiedStatus + "','" + InitialsVerified + "','" + CauseOfDeath + "','" + VerifiedDate + "','" + created_at + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCreditInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic CreditSummaryChartURL, dynamic DelphiScore, dynamic DelphiScoreChartURL, dynamic RiskColour, dynamic FlagCount, dynamic FlagDetails, dynamic TotalInstallmentAmountCPAAccounts_CompuScan, dynamic TotalInstallmentAmountNLRAccounts_CompuScan, dynamic TotalNumberCPAAccounts_CompuScan, dynamic TotalNumberNLRAccounts_CompuScan, dynamic TotalNumberActiveCPAAccounts_CompuScan, dynamic TotalNumberActiveNLRAccounts_CompuScan, dynamic TotalNumberClosedCPAAccounts_CompuScan, dynamic TotalNumberClosedNLRAccounts_CompuScan, dynamic created_at)
        {
            string query_uid = "INSERT INTO creditinformation (SearchToken,Reference,SearchID,CreditSummaryChartURL,DelphiScore,DelphiScoreChartURL,RiskColour,FlagCount,FlagDetails,TotalInstallmentAmountCPAAccounts_CompuScan,TotalInstallmentAmountNLRAccounts_CompuScan,TotalNumberCPAAccounts_CompuScan,TotalNumberNLRAccounts_CompuScan,TotalNumberActiveCPAAccounts_CompuScan,TotalNumberActiveNLRAccounts_CompuScan,TotalNumberClosedCPAAccounts_CompuScan,TotalNumberClosedNLRAccounts_CompuScan,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + CreditSummaryChartURL + "','" + DelphiScore + "','" + DelphiScoreChartURL + "','" + RiskColour + "','" + FlagCount + "','" + FlagDetails + "','" + TotalInstallmentAmountCPAAccounts_CompuScan + "','" + TotalInstallmentAmountNLRAccounts_CompuScan + "','" + TotalNumberCPAAccounts_CompuScan + "','" + TotalNumberNLRAccounts_CompuScan + "','" + TotalNumberActiveCPAAccounts_CompuScan + "','" + TotalNumberActiveNLRAccounts_CompuScan + "','" + TotalNumberClosedCPAAccounts_CompuScan + "','" + TotalNumberClosedNLRAccounts_CompuScan + "','" + created_at + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveFraudIndicatorSummary(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic SAFPSListing, dynamic EmployerFraudVerification, dynamic ProtectiveVerification, dynamic created_at)
        {
            string query_uid = "INSERT INTO fraudindicatorsummary (SearchToken,Reference,SearchID,SAFPSListing, EmployerFraudVerification,ProtectiveVerification,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + SAFPSListing + "','" + ProtectiveVerification + "','" + ProtectiveVerification + "','" + created_at + "')";

            MakeConnection(query_uid);
        }

        public void saveCreditDeclineReason(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic ReasonCode, dynamic ReasonDescription, dynamic created_at)
        {
            string query_uid = "INSERT INTO creditdeclinereason (SearchToken,Reference,SearchID,ReasonCode, ReasonDescription,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + ReasonCode + "','" + ReasonDescription + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveDataCounts(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic Accounts, dynamic Enquiries /*dynamic Judgments, dynamic Notices, dynamic BankDefaults, dynamic Defaults, dynamic Collections, dynamic Directors, dynamic Addresses, dynamic Telephones, dynamic Occupants, dynamic Employers, dynamic TraceAlerts, dynamic PaymentProfiles, dynamic OwnEnquiries, dynamic AdminOrders, dynamic PossibleMatches, dynamic DefiniteMatches, dynamic Loans, dynamic FraudAlerts, dynamic Companies, dynamic Properties, dynamic Documents, dynamic DemandLetters, dynamic Trusts, dynamic Bonds, dynamic Deeds, dynamic PublicDefaults, dynamic NLRAccounts, dynamic created_at*/)
        {
            string query_uid = "INSERT INTO datacounts (SearchToken,Reference,SearchID,Accounts,Enquiries) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + Accounts + "','" + Enquiries + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveDebtReviewStatus(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic StatusCode, dynamic StatusDate, dynamic StatusDescription, dynamic ApplicationDate, dynamic created_at)
        {
            string query_uid = "INSERT INTO debtreviewstatus (SearchToken,Reference,SearchID,StatusCode,StatusDate, StatusDescription,ApplicationDate,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + StatusCode + "','" + StatusDate + "','" + StatusDescription + "','" + ApplicationDate + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveConsumerStatistics(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic HighestJudgment, dynamic RevolvingAccounts, dynamic InstalmentAccounts, dynamic OpenAccounts, dynamic AdverseAccounts, dynamic Percent0ArrearsLast12Histories, dynamic MonthsOldestOpenedPPSEver, dynamic NumberPPSLast12Months, dynamic NLRMicroloansPast12Months, dynamic created_at)
        {
            string query_uid = "INSERT INTO consumerstatistics (SearchToken,Reference,SearchID,HighestJudgment,RevolvingAccounts,InstalmentAccounts,OpenAccounts,AdverseAccounts,Percent0ArrearsLast12Histories,MonthsOldestOpenedPPSEver,NumberPPSLast12Months,NLRMicroloansPast12Months,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + HighestJudgment + "','" + RevolvingAccounts + "','" + InstalmentAccounts + "','" + OpenAccounts + "','" + AdverseAccounts + "','" + Percent0ArrearsLast12Histories + "','" + MonthsOldestOpenedPPSEver + "','" + NumberPPSLast12Months + "','" + NLRMicroloansPast12Months + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLRStats(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic ActiveAccounts, dynamic ClosedAccounts, dynamic WorstMonthArrears, dynamic WorstArrearsStatus, dynamic BalanceExposure, dynamic MonthlyInstalment, dynamic CumulativeArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO nlrstats (SearchToken,Reference,SearchID,ActiveAccounts, ClosedAccounts,WorstMonthArrears,WorstArrearsStatus,BalanceExposure,MonthlyInstalment,CumulativeArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + ActiveAccounts + "','" + ClosedAccounts + "','" + WorstMonthArrears + "','" + WorstArrearsStatus + "','" + BalanceExposure + "','" + MonthlyInstalment + "','" + CumulativeArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCAStats(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic ActiveAccounts, dynamic ClosedAccounts, dynamic WorstMonthArrears, dynamic WorstArrearsStatus, dynamic BalanceExposure, dynamic MonthlyInstalment, dynamic CumulativeArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO ccastats (SearchToken,Reference,SearchID,ActiveAccounts, ClosedAccounts,WorstMonthArrears,WorstArrearsStatus,BalanceExposure,MonthlyInstalment,CumulativeArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + ActiveAccounts + "','" + ClosedAccounts + "','" + WorstMonthArrears + "','" + WorstArrearsStatus + "','" + BalanceExposure + "','" + MonthlyInstalment + "','" + CumulativeArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLRStats12(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO nlr12months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLRStats24(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO nlr24months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLRStats36(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO nlr36months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCA12Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO cca12months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCA24Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO cca24months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCA36Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic created_at)
        {
            string query_uid = "INSERT INTO cca36months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveEnquiryHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiryDate, dynamic EnquiredBy, dynamic EnquiredByContact, dynamic EnquiredByType, dynamic ReasonForEnquiry, dynamic created_at)
        {
            string query_uid = "INSERT INTO enquiryhistory (SearchToken,Reference,SearchID,EnquiryDate, EnquiredBy,EnquiredByContact,EnquiredByType,ReasonForEnquiry,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiryDate + "','" + EnquiredBy + "','" + EnquiredByContact + "','" + EnquiredByType + "','" + ReasonForEnquiry + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCPA_Accounts(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic Account_ID, dynamic SubscriberCode, dynamic SubscriberName, dynamic AccountNO, dynamic SubAccountNO, dynamic OwnershipTypeDescription, dynamic Reason, dynamic ReasonDescription, dynamic PaymentType, dynamic PaymentTypeDescription, dynamic AccountType, dynamic AccountTypeDescription, dynamic OpenDate, dynamic DeferredPaymentDate, dynamic LastPaymentDate, dynamic OpenBalance, dynamic OpenBalanceIND, dynamic CurrentBalance, dynamic CurrentBalanceIND, dynamic OverdueAmount, dynamic InstalmentAmount, dynamic ArrearsPeriod, dynamic RepaymentFrequencyDescription, dynamic Terms, dynamic StatusCode, dynamic StatusCodeDesc, dynamic IndustryType, dynamic PaymentHistoryChartURL, dynamic StatusDate, dynamic ThirdPartyName, dynamic ThirdPartySold, dynamic JointLoanParticipants, dynamic PaymentHistory, dynamic PaymentHistoryStatus, dynamic PaymentHistoryChart, dynamic MonthEndDate, dynamic DateCreated, dynamic created_at)
        {
            string query_uid = "INSERT INTO cpa_accounts (SearchToken,Reference,SearchID,Account_ID,SubscriberCode,SubscriberName,AccountNO,SubAccountNO,OwnershipTypeDescription,Reason,ReasonDescription,PaymentType,PaymentTypeDescription,AccountType,AccountTypeDescription,OpenDate,DeferredPaymentDate,LastPaymentDate,OpenBalance,OpenBalanceIND,CurrentBalance,CurrentBalanceIND,OverdueAmount,InstalmentAmount,ArrearsPeriod,RepaymentFrequencyDescription,Terms,StatusCode,StatusCodeDesc,IndustryType,PaymentHistoryChartURL,StatusDate,ThirdPartyName,ThirdPartySold,JointLoanParticipants,PaymentHistory,PaymentHistoryStatus,PaymentHistoryChart,MonthEndDate,DateCreated,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + Account_ID + "','" + SubscriberCode + "','" + SubscriberName + "','" + AccountNO + "','" + SubAccountNO + "','" + OwnershipTypeDescription + "','" + Reason + "','" + ReasonDescription + "','" + PaymentType + "','" + PaymentTypeDescription + "','" + AccountType + "','" + AccountTypeDescription + "','" + OpenDate + "','" + DeferredPaymentDate + "','" + LastPaymentDate + "','" + OpenBalance + "','" + OpenBalanceIND + "','" + CurrentBalance + "','" + CurrentBalanceIND + "','" + OverdueAmount + "','" + InstalmentAmount + "','" + ArrearsPeriod + "','" + RepaymentFrequencyDescription + "','" + Terms + "','" + StatusCode + "','" + StatusCodeDesc + "','" + IndustryType + "','" + PaymentHistoryChartURL + "','" + StatusDate + "','" + ThirdPartyName + "','" + ThirdPartySold + "','" + JointLoanParticipants + "','" + PaymentHistory + "','" + PaymentHistoryStatus + "','" + PaymentHistoryChart + "','" + MonthEndDate + "','" + DateCreated + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLR_Accounts(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic Account_ID, dynamic SubscriberCode, dynamic SubscriberName, dynamic AccountNO, dynamic SubAccountNO, dynamic OwnershipTypeDescription, dynamic Reason, dynamic ReasonDescription, dynamic PaymentType, dynamic PaymentTypeDescription, dynamic AccountType, dynamic AccountTypeDescription, dynamic OpenDate, dynamic DeferredPaymentDate, dynamic LastPaymentDate, dynamic OpenBalance, dynamic OpenBalanceIND, dynamic CurrentBalance, dynamic CurrentBalanceIND, dynamic OverdueAmount, dynamic InstalmentAmount, dynamic ArrearsPeriod, dynamic RepaymentFrequencyDescription, dynamic Terms, dynamic StatusCode, dynamic StatusCodeDesc, dynamic IndustryType, dynamic PaymentHistoryChartURL, dynamic StatusDate, dynamic ThirdPartyName, dynamic ThirdPartySold, dynamic JointLoanParticipants, dynamic PaymentHistory, dynamic PaymentHistoryStatus, dynamic PaymentHistoryChart, dynamic MonthEndDate, dynamic DateCreated, dynamic created_at)
        {
            string query_uid = "INSERT INTO nlr_accounts (SearchToken,Reference,SearchID,Account_ID,SubscriberCode,SubscriberName,AccountNO,SubAccountNO,OwnershipTypeDescription,Reason,ReasonDescription,PaymentType,PaymentTypeDescription,AccountType,AccountTypeDescription,OpenDate,DeferredPaymentDate,LastPaymentDate,OpenBalance,OpenBalanceIND,CurrentBalance,CurrentBalanceIND,OverdueAmount,InstalmentAmount,ArrearsPeriod,RepaymentFrequencyDescription,Terms,StatusCode,StatusCodeDesc,IndustryType,PaymentHistoryChartURL,StatusDate,ThirdPartyName,ThirdPartySold,JointLoanParticipants,PaymentHistory,PaymentHistoryStatus,PaymentHistoryChart,MonthEndDate,DateCreated,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + Account_ID + "','" + SubscriberCode + "','" + SubscriberName + "','" + AccountNO + "','" + SubAccountNO + "','" + OwnershipTypeDescription + "','" + Reason + "','" + ReasonDescription + "','" + PaymentType + "','" + PaymentTypeDescription + "','" + AccountType + "','" + AccountTypeDescription + "','" + OpenDate + "','" + DeferredPaymentDate + "','" + LastPaymentDate + "','" + OpenBalance + "','" + OpenBalanceIND + "','" + CurrentBalance + "','" + CurrentBalanceIND + "','" + OverdueAmount + "','" + InstalmentAmount + "','" + ArrearsPeriod + "','" + RepaymentFrequencyDescription + "','" + Terms + "','" + StatusCode + "','" + StatusCodeDesc + "','" + IndustryType + "','" + PaymentHistoryChartURL + "','" + StatusDate + "','" + ThirdPartyName + "','" + ThirdPartySold + "','" + JointLoanParticipants + "','" + PaymentHistory + "','" + PaymentHistoryStatus + "','" + PaymentHistoryChart + "','" + MonthEndDate + "','" + DateCreated + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveAddressHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic AddressID, dynamic TypeDescription, dynamic Line1, dynamic Line2, dynamic Line3, dynamic Line4, dynamic PostalCode, dynamic FullAddress, dynamic LastUpdatedDate, dynamic created_at)
        {
            string query_uid = "INSERT INTO addresshistory (SearchToken,Reference,SearchID,AddressID,TypeDescription,Line1,Line2,Line3,Line4,PostalCode,FullAddress,LastUpdatedDate,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + AddressID + "','" + TypeDescription + "','" + Line1 + "','" + Line2 + "','" + Line3 + "','" + Line4 + "','" + PostalCode + "','" + FullAddress + "','" + LastUpdatedDate + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveTelephoneHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic TelephoneID, dynamic TypeDescription, dynamic TypeCode, dynamic Number, dynamic FullNumber, dynamic LastUpdatedDate, dynamic created_at)
        {
            string query_uid = "INSERT INTO telephonehistory (SearchToken,Reference,SearchID,TelephoneID,TypeDescription,TypeCode,Number,FullNumber,LastUpdatedDate,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + TelephoneID + "','" + TypeDescription + "','" + TypeCode + "','" + Number + "','" + FullNumber + "','" + LastUpdatedDate + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveEmploymentHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EmployerName, dynamic Designation, dynamic LastUpdatedDate, dynamic created_at)
        {
            string query_uid = "INSERT INTO employmenthistory (SearchToken,Reference,SearchID,EmployerName,Designation,LastUpdatedDate,created_at) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EmployerName + "','" + Designation + "','" + LastUpdatedDate + "','" + created_at + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public string GetLoginToken(string api_username, string api_password)

        {
            string user_id = Session["ID"].ToString();
            string loginToken = "";
            var userName = api_username;
            var password = api_password;
            var host = "https://rest.searchworks.co.za/auth/login/";
            var body_credentials = new
            {
                Username = api_username,
                Password = api_password
            };
            /* string authBody = "{  \"Username\": \"" + api_username + "\",  \"Password\": \"" + api_password + "\" }"; *///Change Back
            string authBody = "{  \"Username\": \"" + "api@ktopportunities.co.za" + "\",  \"Password\": \"" + "P@ssw0rd!" + "\" }";
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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Combined Credit Report";
            string action = "Name:" + name + "; Surname: " + sur + "; Equiry Reason:" + er + "; ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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
            var url = "https://rest.searchworks.co.za/credit/combinedreport/consumer/";

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
            System.Diagnostics.Debug.WriteLine(o);

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            var mes = ViewData["ResponseMessage"].ToString();
            System.Diagnostics.Debug.WriteLine(mes);

            if (rootObject.ResponseMessage != "CombinedConsumerCreditReport")
            {
                System.Diagnostics.Debug.WriteLine("Mama I made it");

                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["CompuScanMessage"] = rootObject.ResponseObject.CombinedCreditInformation["CompuScan"];
                ViewData["ExperianMessage"] = rootObject.ResponseObject.CombinedCreditInformation.Experian;
                ViewData["TransUnion"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnion;
                ViewData["XDSMessage"] = rootObject.ResponseObject.CombinedCreditInformation.XDS;
                System.Diagnostics.Debug.WriteLine("Yoooo", ViewData["CompuScanMessage"].ToString());
                try
                {
                    int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                    string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                    string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                    string ResponseType = rootObject.ResponseMessage; ;
                    string Name = ViewData["user"].ToString();
                    string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                    string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                    string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                    string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                    string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                    string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                    saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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
                        //Personal Information
                        savePersonInformation(SearchToken, Reference, SearchID, null, null, null, ViewData["ComDateOfBirth"].ToString(), ViewData["ComFirstName"].ToString(), ViewData["ComSurname"].ToString(), null, ViewData["ComIDNumber"].ToString(), null, null, null, null, ViewData["ComGender"].ToString(), ViewData["ComAge"].ToString(), null, null, null, null, null, null, null, ViewData["ComVerificationStatus"].ToString(), null, time.ToString());
                        //CreditInformation
                        ViewData["ComDelphiScore"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScore;
                        ViewData["ComRisk"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.Risk;
                        ViewData["ComDelphiScoreChartURL"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScoreChartURL;
                        saveCreditInformation(SearchToken, Reference, SearchID, " ", rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScore, rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScoreChartURL, rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.Risk, null, " ", " ", " ", " ", " ", " ", " ", " ", " ", time.ToString());

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
                        ViewData["ComBonds"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Bonds;
                        ViewData["ComDeeds"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Deeds;
                        ViewData["ComPublicDefaults"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.PublicDefaults;
                        ViewData["ComNLRAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.NLRAccounts;
                        ViewData["ComApplicationDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DebtReviewStatus.ApplicationDate;
                        //saveDataCounts()

                        //ConsumerStatistics
                        ViewData["ComHighestJudgment"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.HighestJudgment;
                        ViewData["ComRevolvingAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                        ViewData["ComInstalmentAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                        ViewData["ComOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.OpenAccounts;
                        ViewData["ComAdverseAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.AdverseAccounts;
                        saveConsumerStatistics(SearchToken, Reference, SearchID, ViewData["ComHighestJudgment"].ToString(), ViewData["ComRevolvingAccounts"].ToString(), ViewData["ComInstalmentAccounts"].ToString(), ViewData["ComOpenAccounts"].ToString(), ViewData["ComAdverseAccounts"].ToString(), " ", " ", " ", " ", time.ToString());
                        //NLRStats
                        ViewData["ComNLRActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                        ViewData["ComNLRClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                        ViewData["ComNLRWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                        ViewData["ComNLRBalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                        ViewData["ComNLRCumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
                        saveNLRStats(SearchToken, Reference, SearchID, ViewData["ComNLRActiveAccounts"].ToString(), ViewData["ComNLRClosedAccounts"].ToString(), ViewData["ComNLRWorstMonthArrears"].ToString(), " ", ViewData["ComNLRBalanceExposure"].ToString(), " ", ViewData["ComNLRCumulativeArrears"].ToString(), time.ToString());

                        //CCAStats
                        ViewData["ComCCAActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                        ViewData["ComCCAClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                        ViewData["ComCCAWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                        ViewData["ComCCABalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                        ViewData["ComCCACumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                        saveCCAStats(SearchToken, Reference, SearchID, ViewData["ComCCAActiveAccounts"].ToString(), ViewData["ComCCAClosedAccounts"].ToString(), ViewData["ComCCAWorstMonthArrears"].ToString(), " ", ViewData["ComCCABalanceExposure"].ToString(), " ", ViewData["ComCCACumulativeArrears"].ToString(), time.ToString());

                        //NLR12Months
                        ViewData["ComNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                        ViewData["ComNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                        ViewData["ComNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                        ViewData["ComNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
                        saveNLRStats12(SearchToken, Reference, SearchID, ViewData["ComNLR12MonthsEnquiriesByClient"].ToString(), ViewData["ComNLR12MonthsEnquiriesByOther"].ToString(), ViewData["ComNLR12MonthsPositiveLoans"].ToString(), ViewData["ComNLR12MonthsHighestMonthsInArrears"].ToString(), time.ToString());
                        //NLR24Months
                        ViewData["ComNLR24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                        ViewData["ComNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                        ViewData["ComNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                        ViewData["ComNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
                        saveNLRStats24(SearchToken, Reference, SearchID, ViewData["ComNLR24MonthsEnquiriesByClient"].ToString(), ViewData["ComNLR24MonthsEnquiriesByOther"].ToString(), ViewData["ComNLR24MonthsPositiveLoans"].ToString(), ViewData["ComNLR24MonthsHighestMonthsInArrears"].ToString(), time.ToString());

                        //NLR36Months
                        ViewData["ComNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                        ViewData["ComNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                        ViewData["ComNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                        ViewData["ComNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
                        saveNLRStats36(SearchToken, Reference, SearchID, ViewData["ComNLR36MonthsEnquiriesByClient"].ToString(), ViewData["ComNLR36MonthsEnquiriesByOther"].ToString(), ViewData["ComNLR36MonthsPositiveLoans"].ToString(), ViewData["ComNLR36MonthsHighestMonthsInArrears"].ToString(), time.ToString());

                        //CCA12Months
                        ViewData["ComCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                        ViewData["ComCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                        ViewData["ComCCA12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                        ViewData["ComCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
                        saveCCA12Months(SearchToken, Reference, SearchID, ViewData["ComCCA12MonthsEnquiriesByClient"].ToString(), ViewData["ComCCA12MonthsEnquiriesByOther"].ToString(), ViewData["ComCCA12MonthsPositiveLoans"].ToString(), ViewData["ComCCA12MonthsHighestMonthsInArrears"].ToString(), time.ToString());

                        //CCA24Months
                        ViewData["ComCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                        ViewData["ComCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                        ViewData["ComCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                        ViewData["ComCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
                        saveCCA24Months(SearchToken, Reference, SearchID, ViewData["ComCCA24MonthsEnquiriesByClient"].ToString(), ViewData["ComCCA24MonthsEnquiriesByOther"].ToString(), ViewData["ComCCA24MonthsPositiveLoans"].ToString(), ViewData["ComCCA24MonthsHighestMonthsInArrears"].ToString(), time.ToString());

                        //CCA36Months
                        ViewData["ComCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                        ViewData["ComCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                        ViewData["ComCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                        ViewData["ComCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;
                        saveCCA36Months(SearchToken, Reference, SearchID, ViewData["ComCCA36MonthsEnquiriesByClient"].ToString(), ViewData["ComCCA36MonthsEnquiriesByOther"].ToString(), ViewData["ComCCA36MonthsPositiveLoans"].ToString(), ViewData["ComCCA36MonthsHighestMonthsInArrears"].ToString(), time.ToString());
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
                        savePersonInformation(SearchToken, Reference, SearchID, null, null, null, ViewData["ExDateOfBirth"].ToString(), ViewData["ExFirstName"].ToString(), ViewData["ExSurname"].ToString(),
                           null, ViewData["ExIDNumber"].ToString(), null, null, ViewData["ExReference"].ToString(), ViewData["ExMaritalStatus"].ToString(), ViewData["ExGender"].ToString(), ViewData["ExAge"].ToString(), ViewData["ExMiddleName1"].ToString(), null, null, null, null, null, null, null, ViewData["ExHasProperties"], time);
                        //HomeAffairsInformation
                        ViewData["ExIDVerified"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.IDVerified;
                        ViewData["ExSurnameVerified"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.SurnameVerified;
                        ViewData["ExInitialsVerified"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.InitialsVerified;
                        saveHomeAffairsInformation(SearchToken, Reference, SearchID,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.FirstName,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.DeceasedDate,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.IDVerified,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.SurnameVerified,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.Warnings,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.DeceasedStatus,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.VerifiedStatus,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.InitialsVerified,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.CauseOfDeath,
                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.VerifiedDate, time
                       );
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
                        saveCreditInformation(SearchToken, Reference, SearchID, " ", ViewData["ExDelphiScore"].ToString(), ViewData["ExDelphiScoreChartURL"].ToString(), " ", ViewData["ExFlagCount"].ToString(), ViewData["ExFlagDetails"].ToString(), " ", " ", " ", " ", " ", " ", " ", " ", time);
                        //saveDataCounts()
                        //ConsumerStatistics
                        ViewData["ExHighestJudgment"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.HighestJudgment;
                        ViewData["ExRevolvingAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                        ViewData["ExInstalmentAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                        ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.OpenAccounts;
                        ViewData["ExAdverseAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.AdverseAccounts;
                        ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.OpenAccounts;
                        saveConsumerStatistics(SearchToken, Reference, SearchID, ViewData["ExHighestJudgment"].ToString(), ViewData["ExRevolvingAccounts"].ToString(), ViewData["ExInstalmentAccounts"].ToString(), ViewData["ExOpenAccounts"].ToString(), ViewData["ExAdverseAccounts"].ToString(), ViewData["ExOpenAccounts"].ToString(), " ", " ", " ", time);
                        //NLRStats
                        ViewData["ExNLRActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                        ViewData["ExNLRClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                        ViewData["ExNLRWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                        ViewData["ExNLRBalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                        ViewData["ExNLRCumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
                        saveNLRStats(SearchToken, Reference, SearchID, ViewData["ExNLRActiveAccounts"].ToString(), ViewData["ExNLRClosedAccounts"].ToString(), ViewData["ExNLRWorstMonthArrears"].ToString(), " ", ViewData["ExNLRBalanceExposure"].ToString(), " ", ViewData["ExNLRCumulativeArrears"].ToString(), time);
                        //CCAStats
                        ViewData["ExCCAActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                        ViewData["ExCCAClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                        ViewData["ExCCAWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                        ViewData["ExCCABalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                        ViewData["ExCCACumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                        saveCCAStats(SearchToken, Reference, SearchID, ViewData["ExCCAActiveAccounts"].ToString(), ViewData["ExCCAClosedAccounts"].ToString(), ViewData["ExCCAWorstMonthArrears"].ToString(), " ", ViewData["ExCCABalanceExposure"].ToString(), " ", ViewData["ExCCACumulativeArrears"].ToString(), time);
                        //NLR12Months
                        ViewData["ExNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                        ViewData["ExNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                        ViewData["ExNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                        ViewData["ExNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
                        saveNLRStats12(SearchToken, Reference, SearchID, ViewData["ExNLR12MonthsEnquiriesByClient"].ToString(), ViewData["ExNLR12MonthsEnquiriesByOther"].ToString(), ViewData["ExNLR12MonthsPositiveLoans"].ToString(), ViewData["ExNLR12MonthsHighestMonthsInArrears"].ToString(), time);

                        //NLR24Months
                        ViewData["ExNLR24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                        ViewData["ExNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                        ViewData["ExNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                        ViewData["ExNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
                        saveNLRStats24(SearchToken, Reference, SearchID, ViewData["ExNLR24MonthsEnquiriesByClient"].ToString(), ViewData["ExNLR24MonthsEnquiriesByOther"].ToString(), ViewData["ExNLR24MonthsPositiveLoans"].ToString(), ViewData["ExNLR24MonthsHighestMonthsInArrears"].ToString(), time);

                        //NLR36Months
                        ViewData["ExNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                        ViewData["ExNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                        ViewData["ExNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                        ViewData["ExNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
                        saveNLRStats36(SearchToken, Reference, SearchID, ViewData["ExNLR36MonthsEnquiriesByClient"].ToString(), ViewData["ExNLR36MonthsEnquiriesByOther"].ToString(), ViewData["ExNLR36MonthsPositiveLoans"].ToString(), ViewData["ExNLR36MonthsHighestMonthsInArrears"].ToString(), time);

                        //CCA12Months
                        ViewData["ExCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                        ViewData["ExCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                        ViewData["ExCCA12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                        ViewData["ExCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
                        saveCCA12Months(SearchToken, Reference, SearchID, ViewData["ExCCA12MonthsEnquiriesByClient"].ToString(), ViewData["ExCCA12MonthsEnquiriesByOther"].ToString(), ViewData["ExCCA12MonthsPositiveLoans"].ToString(), ViewData["ExCCA12MonthsHighestMonthsInArrears"].ToString(), time);

                        //CCA24Months
                        ViewData["ExCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                        ViewData["ExCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                        ViewData["ExCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                        ViewData["ExCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
                        saveCCA24Months(SearchToken, Reference, SearchID, ViewData["ExCCA24MonthsEnquiriesByClient"].ToString(), ViewData["ExCCA24MonthsEnquiriesByOther"].ToString(), ViewData["ExCCA24MonthsPositiveLoans"].ToString(), ViewData["ExCCA24MonthsHighestMonthsInArrears"].ToString(), time);

                        //CCA36Months
                        ViewData["ExCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                        ViewData["ExCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                        ViewData["ExCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                        ViewData["ExCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;
                        saveCCA36Months(SearchToken, Reference, SearchID, ViewData["ExCCA36MonthsEnquiriesByClient"].ToString(), ViewData["ExCCA36MonthsEnquiriesByOther"].ToString(), ViewData["ExCCA36MonthsPositiveLoans"], ViewData["ExCCA36MonthsHighestMonthsInArrears"], time);
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
                        savePersonInformation(SearchToken, Reference, SearchID, null, ViewData["PersonID"].ToString(), ViewData["Title"].ToString(), ViewData["DateOfBirth"].ToString(),
                            null, null, ViewData["Fullname"].ToString(), ViewData["IDNumber"].ToString(),
                           null, null, null, ViewData["MaritalStatus"].ToString(), ViewData["Gender"].ToString(), null,
                            ViewData["MiddleName1"].ToString(), null, null, null, null, null
                            , null, null, null, DateTime.Now);

                        //COntact Information:
                        ViewData["EmailAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.EmailAddress;
                        ViewData["MobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.MobileNumber;
                        ViewData["PhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PhysicalAddress;
                        ViewData["PostalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PostalAddress;
                        //HomeAffairs Information:
                        ViewData["DeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.DeceasedStatus;
                        ViewData["DeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.DeceasedDate;
                        ViewData["VerifiedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.VerifiedStatus;
                        saveHomeAffairsInformation(SearchToken, Reference, SearchID,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.FirstName,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.DeceasedDate,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.IDVerified,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.SurnameVerified,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.Warnings,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.DeceasedStatus,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.VerifiedStatus,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.InitialsVerified,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.CauseOfDeath,
                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.VerifiedDate, time
                       );
                        //FraudIndicatorSummary:
                        ViewData["SAFPSListing"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.SAFPSListing;
                        ViewData["EmployerFraudVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.EmployerFraudVerification;
                        ViewData["ProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.ProtectiveVerification;
                        saveFraudIndicatorSummary(SearchToken, Reference, SearchID, ViewData["SAFPSListing"].ToString(), ViewData["EmployerFraudVerification"].ToString(), ViewData["ProtectiveVerification"].ToString(), DateTime.Now);
                        if (rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].CompanyName != null)
                        {
                            //DirectorshipInformation242px;
                            ViewData["CompanyName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].CompanyName;
                            ViewData["CompanyRegistrationNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].CompanyRegistrationNumber;
                            ViewData["AppointmentDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].AppointmentDate;
                            ViewData["PhysicalAddressD"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[0].PhysicalAddress;
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
                catch (Exception e)
                {
                    TempData["msg"] = "An error occured, please check the entered values.";
                }
                return View();
            }
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

            ViewData["refe"] = id;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Combined Consumer Trace";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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
            var url = "https://rest.searchworks.co.za/credit/combinedreport/trace/";
            //var url = "https://uatrest.searchworks.co.za/credit/combinedreport/trace/";

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
            JObject o = JObject.Parse(response.Content);

            System.Diagnostics.Debug.WriteLine(o);
            JToken token = JToken.Parse(response.Content);
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            var mes = ViewData["ResponseMessage"].ToString();
            if (rootObject.ResponseMessage == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";

                return View();
            }

            if (rootObject.ResponseMessage == "Error updating search request.")
            {
                ViewData["Message"] = "Error updating search request.";

                return View();
            }
            else
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["CompuScanMessage"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScan;
                ViewData["TransUnionMessage"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnion;
                ViewData["XDSMessage"] = rootObject.ResponseObject.CombinedCreditInformation.XDS;
                ViewData["VeriCredMessage"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCred;

                if (ViewData["CompuScanMessage"].ToString() == "Found")
                {
                    int CSSearchID = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.SearchID;
                    string CSSearchUserName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.SearchUserName;
                    string CSReportDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.ReportDate;
                    string CSReference = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.Reference;
                    string CSSearchToken = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.SearchToken;
                    string CSCallerModule = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.CallerModule;
                    string CSDataSupplier = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.DataSupplier;
                    string CSSearchType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.SearchType;
                    string CSSearchDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.SearchInformation.SearchDescription;
                    saveCompuScanSearchHistory(CSSearchID, CSSearchUserName, CSReportDate, CSReference, CSSearchToken, CSCallerModule, CSDataSupplier, CSSearchType, CSSearchDescription, time);

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
                    //savePersonInformation(SearchToken, Reference, SearchID, null, null, null, ViewData["CompuScanDateOfBirth"].ToString(), ViewData["CompuScanFirstName"].ToString(), ViewData["CompuScanSurname"].ToString(),
                    //     ViewData["CompuScanFullname"].ToString(), ViewData["CompuScanIDNumber"].ToString(), null, null, null, null, ViewData["CompuScanGender"].ToString(), ViewData["CompuScanAge"].ToString(), ViewData["CompuScanMiddleName1"].ToString(), ViewData["CompuScanMiddleName2"].ToString(), null, null, null, null, null, null,
                    //     ViewData["CompuScanHasProperties"].ToString(), time.ToString());

                    //Home Affairs Information
                    saveHomeAffairsInformation(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.FirstName,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.DeceasedDate,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.IDVerified,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.SurnameVerified,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.Warnings,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.DeceasedStatus,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.VerifiedStatus,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.InitialsVerified,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.CauseOfDeath,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.VerifiedDate, time
                        );
                    ViewData["CompuScanDeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].DeceasedStatus;
                    ViewData["CompuScanDeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].DeceasedDate;
                    ViewData["CompuScanCauseOfDeath"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].CauseOfDeath;
                    ViewData["CompuScanVerifiedDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].VerifiedDate;
                    ViewData["CompuScanVerifiedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].VerifiedStatus;

                    //Credit Information
                    saveFraudIndicatorSummary(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.SAFPSListing,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EmployerFraudVerification,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ProtectiveVerification, time
                        );
                    ViewData["CompuScanProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["FraudIndicatorSummary"].ProtectiveVerification;

                    //Historical Information
                    // Address
                    Newtonsoft.Json.Linq.JArray addressElement = new Newtonsoft.Json.Linq.JArray();
                    addressElement = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory;
                    for (int count = 0; count < (addressElement.Count); count++)
                    {
                        saveAddressHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].AddressID,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, time
                        );
                    }
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
                    }

                    // Telephone
                    Newtonsoft.Json.Linq.JArray telephoneElement = new Newtonsoft.Json.Linq.JArray();
                    telephoneElement = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory;
                    for (int count = 0; count < (telephoneElement.Count); count++)
                    {
                        saveTelephoneHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, time

                        );
                    }
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
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray Employmentelements = new Newtonsoft.Json.Linq.JArray();
                    Employmentelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory;
                    for (int count = 0; count < (Employmentelements.Count); count++)
                    {
                        saveEmploymentHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, time
                        );
                    }
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
                    }
                }
                else
                {
                    ViewData["CompuScanMessage"] = "No Match";
                }

                if (ViewData["TransUnionMessage"].ToString() == "Found")
                {
                    int TUSearchID = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.SearchID;
                    string TUSearchUserName = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.SearchUserName;
                    string TUReportDate = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.ReportDate;
                    string TUReference = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.Reference;
                    string TUSearchToken = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.SearchToken;
                    string TUCallerModule = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.CallerModule;
                    string TUDataSupplier = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.DataSupplier;
                    string TUSearchType = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.SearchType;
                    string TUSearchDescription = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.SearchInformation.SearchDescription;
                    saveTransUnionSearchHistory(TUSearchID, TUSearchUserName, TUReportDate, TUReference, TUSearchToken, TUCallerModule, TUDataSupplier, TUSearchType, TUSearchDescription, time);
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
                    //savePersonInformation(SearchToken, Reference, SearchID, ViewData["TransUnionInfoInformationDate"].ToString(), ViewData["TransUnionInfoPersonID"].ToString(), ViewData["TransUnionInfoTitle"].ToString(),
                    //    ViewData["TransUnionInfoDateOfBirth"].ToString(), ViewData["TransUnionInfoFirstName"].ToString(), ViewData["TransUnionInfoSurname"].ToString(),
                    //    ViewData["TransUnionInfoFullname"].ToString(), ViewData["TransUnionInfoIDNumber"].ToString(), null, null, null, ViewData["TransUnionInfoMaritalStatus"].ToString(),
                    //    ViewData["TransUnionInfoGender"].ToString(), ViewData["TransUnionInfoAge"].ToString(), ViewData["TransUnionInfoMiddleName1"].ToString(), ViewData["TransUnionInfoMiddleName2"].ToString(),
                    //      ViewData["TransUnionInfoSpouseFirstName"].ToString(),
                    //     ViewData["TransUnionInfoSpouseSurname"].ToString(), ViewData["TransUnionInfoNumberOfDependants"].ToString(), null, null, ViewData["ComVerificationStatus"].ToString(),
                    //    ViewData["TransUnionInfoHasProperties"].ToString(), time.ToString());
                    //Contact Information
                    ViewData["TransUnionInfoEmailAddress"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].EmailAddress;
                    ViewData["TransUnionInfoMobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].MobileNumber;
                    ViewData["TransUnionInfoHomeTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].HomeTelephoneNumber;
                    ViewData["TransUnionInfoWorkTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].WorkTelephoneNumber;
                    saveContactInformation(SearchToken, Reference, SearchID,
                        ViewData["TransUnionInfoEmailAddress"],
                        ViewData["TransUnionInfoMobileNumber"],
                        ViewData["TransUnionInfoHomeTelephoneNumber"],
                        ViewData["TransUnionInfoWorkTelephoneNumber"],
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].PhysicalAddress,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].PostalAddress, time);

                    //Historical Information

                    // Address

                    Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory;
                    List<string> thatlist = new List<string>();
                    Dictionary<string, string> arrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        saveAddressHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].AddressID,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line1,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line2,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line3,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line4,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, time
                            );

                        string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                        string Line1 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line1;
                        string Line2 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line2;
                        string Line3 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line3;
                        string Line4 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line4;
                        string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Line1", Line1);
                        arrayList.Add(count + "_Line2", Line2);
                        arrayList.Add(count + "_Line3", Line3);
                        arrayList.Add(count + "_Line4", Line4);
                        arrayList.Add(count + "_PostalCode", PostalCode);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["ArrayList"] = arrayList;
                    }
                    // Telephone
                    Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                    Telelements = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory;
                    List<string> Telthatlist = new List<string>();
                    Dictionary<string, string> TelarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (Telelements.Count); count++)
                    {
                        saveTelephoneHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].Number,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, time

                        );

                        string Type = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        string Number = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].Number;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                        TelarrayList.Add(count + "_Type", Type);
                        TelarrayList.Add(count + "_Numnber", Number);
                        TelarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["TelArrayList"] = TelarrayList;
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                    EMelements = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory;
                    List<string> EMthatlist = new List<string>();
                    Dictionary<string, string> EMarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (EMelements.Count); count++)
                    {
                        saveEmploymentHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                        rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, time
                        );

                        string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        string Designation = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                        EMarrayList.Add(count + "_EmployerName", EmployerName);
                        EMarrayList.Add(count + "_Designation", Designation);
                        EMarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["EMArrayList"] = EMarrayList;
                    }
                }
                else
                {
                    ViewData["TransUnion"] = "No Match";
                }
                if (ViewData["XDSMessage"].ToString() == "Found")
                {
                    int XDSSearchID = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.SearchID;
                    string XDSSearchUserName = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.SearchUserName;
                    string XDSReportDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.ReportDate;
                    string XDSReference = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.Reference;
                    string XDSSearchToken = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.SearchToken;
                    string XDSCallerModule = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.CallerModule;
                    string XDSDataSupplier = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.DataSupplier;
                    string XDSSearchType = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.SearchType;
                    string XDSSearchDescription = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.SearchInformation.SearchDescription;
                    saveXDSSearchHistory(XDSSearchID, XDSSearchUserName, XDSReportDate, XDSReference, XDSSearchToken, XDSCallerModule, XDSDataSupplier, XDSSearchType, XDSSearchDescription, time);
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
                    ViewData["XDSInfoReference"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].Reference;
                    ViewData["XDSInfoHasProperties"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PersonInformation"].HasProperties;
                    //savePersonInformation(SearchToken, Reference, SearchID, null, ViewData["XDSInfoPersonID"].ToString(), ViewData["XDSInfoTitle"].ToString(),
                    //    ViewData["XDSInfoDateOfBirth"].ToString(), ViewData["XDSInfoFirstName"].ToString(), ViewData["XDSInfoSurname"].ToString(),
                    //    ViewData["XDSInfoFullname"].ToString(), ViewData["XDSInfoIDNumber"].ToString(), null, ViewData["XDSInfoPassportNumber"].ToString(), ViewData["XDSInfoReference"].ToString(), ViewData["XDSInfoMaritalStatus"].ToString(),
                    //    ViewData["XDSInfoGender"].ToString(), ViewData["XDSInfoAge"].ToString(), ViewData["XDSInfoMiddleName1"].ToString(), ViewData["XDSInfoMiddleName2"].ToString(),
                    //      null,
                    //     null, null, null, null, null,
                    //    ViewData["XDSInfoHasProperties"].ToString(), time.ToString());
                    //Home Affairs Information
                    ViewData["XDSInfoDeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HomeAffairsInformation"].DeceasedStatus;
                    ViewData["XDSInfoDeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HomeAffairsInformation"].DeceasedDate;
                    ViewData["XDSInfoVerifiedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HomeAffairsInformation"].VerifiedStatus;
                    saveHomeAffairsInformation(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.FirstName,
                        ViewData["XDSInfoDeceasedDate"],
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.IDVerified,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.SurnameVerified,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.Warnings,
                        ViewData["XDSInfoDeceasedStatus"],
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.VerifiedStatus,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.InitialsVerified,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.CauseOfDeath,
                        ViewData["XDSInfoVerifiedStatus"], time
                        );
                    //Credit Information

                    ViewData["XDSInfoProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].ProtectiveVerification;
                    ViewData["XDSInfoSAFPSListing"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].SAFPSListing;
                    ViewData["XDSInfoEmployerFraudVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].EmployerFraudVerification;
                    saveFraudIndicatorSummary(SearchToken, Reference, SearchID, ViewData["XDSInfoSAFPSListing"].ToString(), ViewData["XDSInfoEmployerFraudVerification"].ToString(), ViewData["XDSInfoProtectiveVerification"].ToString(), time.ToString());

                    // Address
                    Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory;
                    List<string> thatlist = new List<string>();
                    Dictionary<string, string> arrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                        string Line1 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line1;
                        string Line2 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line2;
                        string Line3 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line3;
                        string Line4 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line4;
                        string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Line1", Line1);
                        arrayList.Add(count + "_Line2", Line2);
                        arrayList.Add(count + "_Line3", Line3);
                        arrayList.Add(count + "_Line4", Line4);
                        arrayList.Add(count + "_PostalCode", PostalCode);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["ArrayList"] = arrayList;

                        saveAddressHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].AddressID,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line1,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line2,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line3,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line4,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, time
                        );
                    }

                    // Telephone
                    Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                    Telelements = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory;
                    List<string> Telthatlist = new List<string>();
                    Dictionary<string, string> TelarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (Telelements.Count); count++)
                    {
                        string Type = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        string Number = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].Number;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                        TelarrayList.Add(count + "_Type", Type);
                        TelarrayList.Add(count + "_Numnber", Number);
                        TelarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["TelArrayList"] = TelarrayList;

                        saveTelephoneHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].Number,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, time
                        );
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                    EMelements = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory;
                    List<string> EMthatlist = new List<string>();
                    Dictionary<string, string> EMarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (EMelements.Count); count++)
                    {
                        string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        string Designation = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                        EMarrayList.Add(count + "_EmployerName", EmployerName);
                        EMarrayList.Add(count + "_Designation", Designation);
                        EMarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["EMArrayList"] = EMarrayList;

                        saveEmploymentHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, time
                        );
                    }
                }
                else
                {
                    ViewData["XDS"] = "No Match";
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
                    //savePersonInformation()

                    //Contact Information
                    ViewData["VeriCredInfoPhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].PhysicalAddress;
                    ViewData["VeriCredInfoMobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].MobileNumber;
                    ViewData["VeriCredInfoHomeTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].HomeTelephoneNumber;
                    ViewData["VeriCredInfoWorkTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].WorkTelephoneNumber;

                    saveContactInformation(SearchToken, Reference, SearchID,
                       rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].EmailAddress,
                        ViewData["VeriCredInfoMobileNumber"],
                        ViewData["VeriCredInfoHomeTelephoneNumber"],
                        ViewData["VeriCredInfoWorkTelephoneNumber"],
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].PhysicalAddress,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].PostalAddress, time);

                    //Historical Information

                    // Address
                    Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory;
                    List<string> thatlist = new List<string>();
                    Dictionary<string, string> arrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (elements.Count); count++)
                    {
                        string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                        string Line1 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line1;
                        string Line2 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line2;
                        string Line3 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line3;
                        string Line4 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line4;
                        string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                        arrayList.Add(count + "_TypeCode", TypeCode);
                        arrayList.Add(count + "_Line1", Line1);
                        arrayList.Add(count + "_Line2", Line2);
                        arrayList.Add(count + "_Line3", Line3);
                        arrayList.Add(count + "_Line4", Line4);
                        arrayList.Add(count + "_PostalCode", PostalCode);
                        arrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["ArrayList"] = arrayList;

                        saveAddressHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].AddressID,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line1,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line2,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line3,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line4,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, time
                        );
                    }

                    // Telephone
                    Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                    Telelements = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory;
                    List<string> Telthatlist = new List<string>();
                    Dictionary<string, string> TelarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (Telelements.Count); count++)
                    {
                        string Type = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                        string Number = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].Number;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                        TelarrayList.Add(count + "_Type", Type);
                        TelarrayList.Add(count + "_Numnber", Number);
                        TelarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["TelArrayList"] = TelarrayList;
                        saveTelephoneHistory(SearchToken, Reference, SearchID,
                       rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                       rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                       rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                       rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].Number,
                       rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                       rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, time
                       );
                    }

                    // Employment
                    Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                    EMelements = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory;
                    List<string> EMthatlist = new List<string>();
                    Dictionary<string, string> EMarrayList = new Dictionary<string, string>();

                    for (int count = 0; count < (EMelements.Count); count++)
                    {
                        string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                        string Designation = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                        string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                        EMarrayList.Add(count + "_EmployerName", EmployerName);
                        EMarrayList.Add(count + "_Designation", Designation);
                        EMarrayList.Add(count + "_LastUpdatedDate", LastUpdatedDate);
                        ViewData["EMArrayList"] = EMarrayList;
                        saveEmploymentHistory(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                        rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, time
                        );
                    }
                }
                else
                {
                    ViewData["VeriCred"] = "No Match";
                }
                return View();
            }
        }

        public ActionResult CombinedConsumerTraceDbResults()
        {
            ViewData["Message"] = "Good";
            ViewData["CompuScanMessage"] = "Found";
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            string query_uid = "SELECT * FROM searchhistory";

            conn.Open();
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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Combined Consumer Trace";
            string action = "Client Name:" + clientName + "; Bank Name: " + bankName + "; Branch Code:" + branchCode + "; Branch Name: " + branchName + "; Account Number:" + accountNumber + "; Amount:" + amount + "; Terms:" + terms + "; Report Type" + reportType;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
            string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
            string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
            string ResponseType = rootObject.ResponseMessage; ;
            string Name = ViewData["user"].ToString();
            string Reference = rootObject.ResponseObject.SearchInformation.Reference;
            string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
            string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
            string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
            string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
            string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
            saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

            return View();
        }

        public ActionResult CompuScanBankOnFile()
        {
            return View();
        }

        public ActionResult CompuScanBankOnFileResults(CompuScan comp)
        {
            string id = comp.IDNumber;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CompuScan Bank On File";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                return View();
            }
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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CompuScan Consumer Profile";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; Enquiry Reason: " + enquiryReason + "; ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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
                    ViewData["DRStatusCode"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusCode;
                    ViewData["DRStatusDescription"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription;

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

            if (traceType == "ID")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CompuScan Consumer Trace By IDNumber";
                string action = "ID: " + id;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                    string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                    string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                    string ResponseType = rootObject.ResponseMessage; ;
                    string Name = ViewData["user"].ToString();
                    string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                    string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                    string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                    string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                    string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                    string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                    saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CompuScan Consumer Trace By Telephone Number";
                string action = "Telephone Number: " + tele;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                var mes = ViewData["ResponseMessage"].ToString();
                if (mes == "ServiceOffline")
                {
                    ViewData["Message"] = "Service is offline";
                    return View();
                }
                else
                {
                    int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                    string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                    string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                    string ResponseType = rootObject.ResponseMessage; ;
                    string Name = ViewData["user"].ToString();
                    string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                    string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                    string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                    string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                    string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                    string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                    saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "CompuScan Consumer Trace By TelephoneID";
                string action = "TelephoneID: " + tele;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CompuScan Contact Information";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; Passport: " + passport + "; ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CompuScan Employment Confidence Index";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();
            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CompuScan Employment Confidence Index";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["Message"] = "good";

                ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation.IDNumber;
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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "CompuScan ID Photo Verification";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "Experian Consumer Profile";
            string action = "First Name: " + firstname + "; Surname: " + surname + "; Enquiry Reason: " + enquiryReason + "; Passport: " + passport + "; ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();
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
            var url = "https://rest.searchworks.co.za/credit/experian/consumerprofile/";

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
            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));

            ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            var mes = ViewData["ResponseMessage"].ToString();

            if (mes == "ServiceOffline")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                if (ViewData["ResponseMessage"].ToString() == "ExperianConsumerProfile")
                {
                    //PersonInformation
                    ViewData["ExDateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                    ViewData["ExTitle"] = rootObject.ResponseObject.PersonInformation.Title;
                    ViewData["ExFirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                    ViewData["ExSurname"] = rootObject.ResponseObject.PersonInformation.Surname;
                    ViewData["ExFullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                    ViewData["ExIDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                    ViewData["ExGender"] = rootObject.ResponseObject.PersonInformation.Gender;
                    ViewData["ExAge"] = rootObject.ResponseObject.PersonInformation.Age;
                    ViewData["ExMaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;
                    ViewData["ExMiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
                    ViewData["ExReference"] = rootObject.ResponseObject.PersonInformation.Reference;
                    ViewData["ExHasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                    ViewData["ExPhysicalAddress"] = rootObject.ResponseObject.ContactInformation.PhysicalAddress;
                    saveContactInformation(SearchToken, Reference, SearchID, null, null, null, null, ViewData["ExPhysicalAddress"].ToString(), null, time);
                    savePersonInformation(SearchToken, Reference, SearchID, null, null, ViewData["ExTitle"].ToString(), ViewData["ExDateOfBirth"].ToString(), ViewData["ExFirstName"].ToString(), ViewData["ExSurname"].ToString(),
                         ViewData["ExFullname"].ToString(), ViewData["ExIDNumber"].ToString(), null, null, ViewData["ExReference"].ToString(), ViewData["ExMaritalStatus"].ToString(), ViewData["ExGender"].ToString(), ViewData["ExAge"].ToString(), ViewData["ExMiddleName1"].ToString(), null, null, null, null, null, null, null, ViewData["ExHasProperties"], time);
                    //HomeAffairsInformation
                    ViewData["ExIDVerified"] = rootObject.ResponseObject.HomeAffairsInformation.IDVerified;
                    ViewData["ExSurnameVerified"] = rootObject.ResponseObject.HomeAffairsInformation.SurnameVerified;
                    ViewData["ExInitialsVerified"] = rootObject.ResponseObject.HomeAffairsInformation.InitialsVerified;
                    saveHomeAffairsInformation(SearchToken, Reference, SearchID,
                       rootObject.ResponseObject.HomeAffairsInformation.FirstName,
                       rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate,
                       rootObject.ResponseObject.HomeAffairsInformation.IDVerified,
                       rootObject.ResponseObject.HomeAffairsInformation.SurnameVerified,
                       rootObject.ResponseObject.HomeAffairsInformation.Warnings,
                       rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus,
                       rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus,
                       rootObject.ResponseObject.HomeAffairsInformation.InitialsVerified,
                       rootObject.ResponseObject.HomeAffairsInformation.CauseOfDeath,
                       rootObject.ResponseObject.HomeAffairsInformation.VerifiedDate, time
                       );
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
                    saveCreditInformation(SearchToken, Reference, SearchID, null, rootObject.ResponseObject.CreditInformation.DelphiScore, rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL,
                        null,
                        rootObject.ResponseObject.CreditInformation.FlagCount,
                        rootObject.ResponseObject.CreditInformation.FlagDetails,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null, null, null, time.ToString());

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
                    //ViewData["ExApplicationDate"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.ApplicationDate;
                    saveDataCounts(SearchToken, Reference, SearchID, null, null);
                    //ConsumerStatistics
                    ViewData["ExHighestJudgment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.HighestJudgment;
                    ViewData["ExRevolvingAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                    ViewData["ExInstalmentAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                    ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.OpenAccounts;
                    ViewData["ExAdverseAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.AdverseAccounts;
                    ViewData["ExPercent0ArrearsLast12Histories"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.Percent0ArrearsLast12Histories;
                    ViewData["ExMonthsOldestOpenedPPSEver"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.MonthsOldestOpenedPPSEver;
                    ViewData["ExNumberPPSLast12Months"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NumberPPSLast12Months;
                    ViewData["ExNLRMicroloansPast12Months"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRMicroloansPast12Months;
                    saveConsumerStatistics(SearchToken, Reference, SearchID, ViewData["ExHighestJudgment"].ToString(), ViewData["ExRevolvingAccounts"].ToString(), ViewData["ExInstalmentAccounts"].ToString(),
                        ViewData["ExOpenAccounts"].ToString(), ViewData["ExAdverseAccounts"].ToString(), ViewData["ExPercent0ArrearsLast12Histories"].ToString(),
                        ViewData["ExMonthsOldestOpenedPPSEver"].ToString(), ViewData["ExNumberPPSLast12Months"].ToString(), ViewData["ExNLRMicroloansPast12Months"].ToString(), time);
                    //DebtReviewStatus
                    ViewData["DRStatusCode"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusCode;
                    ViewData["DRStatusDescription"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription;
                    saveDebtReviewStatus(SearchToken, Reference, SearchID, ViewData["DRStatusCode"].ToString(), null, ViewData["DRStatusDescription"].ToString(), null, time);
                    List<EnquiryHistory> EnqHIst;
                    List<AddressHistory> AddressHist;
                    List<TelephoneHistory> TelHist;
                    List<EmploymentHistory> EmpHist;
                    Newtonsoft.Json.Linq.JArray elements, elements1, elements2, elements3 = new Newtonsoft.Json.Linq.JArray();
                    elements = rootObject.ResponseObject.CreditInformation.EnquiryHistory;
                    elements1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory;
                    elements2 = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;
                    elements3 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;

                    String EnquiryDate = "";
                    String EnquiredBy = "";
                    String EnquiredByContact = "";
                    //AddressHIstoryValues
                    String TypeDescription = "";
                    String Line1 = "";
                    String Line2 = "";
                    String Line3 = "";
                    String PostalCode = "";
                    String FullAddress = "";
                    String LastUpdatedDate = "";
                    //TelephoneHIstory
                    String TypeDescriptionTel = "";
                    String DialCode = "";
                    String Number = "";
                    String FullNumber = "";
                    String LastUpdatedDateTel = "";
                    //EmploymentHistory
                    String EmployerName = "";
                    String Designation = "";
                    EnqHIst = new List<EnquiryHistory>();
                    AddressHist = new List<AddressHistory>();
                    TelHist = new List<TelephoneHistory>();
                    EmpHist = new List<EmploymentHistory>();
                    if (rootObject.ResponseObject.CreditInformation.EnquiryHistory != null)
                    {
                        for (int count = 0; count < (elements.Count); count++)
                        {
                            EnquiryDate = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate;
                            EnquiredBy = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy;
                            EnquiredByContact = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact;
                            saveEnquiryHistory(SearchToken, Reference, SearchID, EnquiryDate, EnquiredBy, EnquiredByContact, null, null, null);
                            EnqHIst.Add(new EnquiryHistory
                            {
                                EnquiryDate = EnquiryDate,
                                EnquiredBy = EnquiredBy,
                                EnquiredByContact = EnquiredByContact
                            });
                        }
                    }
                    if (rootObject.ResponseObject.CreditInformation.AddressHistory != null)
                    {
                        for (int count = 0; count < (elements1.Count); count++)
                        {
                            TypeDescription = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription;
                            Line1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1;
                            Line2 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2;
                            Line3 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3;
                            PostalCode = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode;
                            FullAddress = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress;
                            LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate;
                            saveAddressHistory(SearchToken, Reference, SearchID, null, TypeDescription, Line1, Line2, Line3, null, PostalCode, FullAddress, LastUpdatedDate, time);

                            AddressHist.Add(new AddressHistory
                            {
                                TypeDescription = TypeDescription,
                                Line1 = Line1,
                                Line2 = Line2,
                                Line3 = Line3,
                                PostalCode = PostalCode,
                                FullAddress = FullAddress,
                                LastUpdatedDate = LastUpdatedDate,
                            });
                        }
                    }

                    if (rootObject.ResponseObject.HistoricalInformation.TelephoneHistory != null)
                    {
                        for (int count = 0; count < (elements2.Count); count++)
                        {
                            TypeDescriptionTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                            DialCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode;
                            Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number;
                            FullNumber = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber;
                            LastUpdatedDateTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDateTel;
                            saveTelephoneHistory(SearchToken, Reference, SearchID, null, TypeDescription, DialCode, Number, FullNumber, LastUpdatedDate, time);

                            TelHist.Add(new TelephoneHistory
                            {
                                TypeDescriptionTel = TypeDescriptionTel,
                                DialCode = DialCode,
                                Number = Number,
                                FullNumber = FullNumber,
                                LastUpdatedDateTel = LastUpdatedDate,
                            });
                        }
                    }
                    if (rootObject.ResponseObject.HistoricalInformation.EmploymentHistory != null)
                    {
                        for (int count = 0; count < (elements3.Count); count++)
                        {
                            EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName;
                            Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation; ;
                            saveEmploymentHistory(SearchToken, Reference, SearchID, EmployerName, Designation, LastUpdatedDate, time);

                            EmpHist.Add(new EmploymentHistory
                            {
                                EmployerName = EmployerName,
                                Designation = Designation,
                            });
                        }
                    }

                    ViewData["EnqHIst"] = EnqHIst;
                    ViewData["AddressHist"] = AddressHist;
                    ViewData["TelHist"] = TelHist;
                    ViewData["EmpHist"] = EmpHist;
                    //NLRStats
                    ViewData["ExNLRActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                    ViewData["ExNLRClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                    ViewData["ExNLRWorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                    ViewData["ExNLRBalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                    ViewData["ExNLRCumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
                    saveNLRStats(SearchToken, Reference, SearchID, ViewData["ExNLRActiveAccounts"].ToString(), ViewData["ExNLRClosedAccounts"].ToString(), ViewData["ExNLRWorstMonthArrears"].ToString(), " ", ViewData["ExNLRBalanceExposure"].ToString(), " ", ViewData["ExNLRCumulativeArrears"].ToString(), time);

                    //CCAStats
                    ViewData["ExCCAActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                    ViewData["ExCCAClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                    ViewData["ExCCAWorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                    ViewData["ExCCABalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                    ViewData["ExCCACumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                    saveCCAStats(SearchToken, Reference, SearchID, ViewData["ExCCAActiveAccounts"].ToString(), ViewData["ExCCAClosedAccounts"].ToString(), ViewData["ExCCAWorstMonthArrears"].ToString(), " ", ViewData["ExCCABalanceExposure"].ToString(), " ", ViewData["ExCCACumulativeArrears"].ToString(), time);

                    //NLR12Months
                    ViewData["ExNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                    ViewData["ExNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                    ViewData["ExNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                    ViewData["ExNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
                    saveNLRStats12(SearchToken, Reference, SearchID, ViewData["ExNLR12MonthsEnquiriesByClient"].ToString(), ViewData["ExNLR12MonthsEnquiriesByOther"].ToString(), ViewData["ExNLR12MonthsPositiveLoans"].ToString(), ViewData["ExNLR12MonthsHighestMonthsInArrears"].ToString(), time);

                    //NLR24Months
                    ViewData["ExNLR24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                    ViewData["ExNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                    ViewData["ExNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                    ViewData["ExNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
                    saveNLRStats24(SearchToken, Reference, SearchID, ViewData["ExNLR24MonthsEnquiriesByClient"].ToString(), ViewData["ExNLR24MonthsEnquiriesByOther"].ToString(), ViewData["ExNLR24MonthsPositiveLoans"].ToString(), ViewData["ExNLR24MonthsHighestMonthsInArrears"].ToString(), time);

                    //NLR36Months
                    ViewData["ExNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                    ViewData["ExNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                    ViewData["ExNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                    ViewData["ExNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
                    saveNLRStats36(SearchToken, Reference, SearchID, ViewData["ExNLR36MonthsEnquiriesByClient"].ToString(), ViewData["ExNLR36MonthsEnquiriesByOther"].ToString(), ViewData["ExNLR36MonthsPositiveLoans"].ToString(), ViewData["ExNLR36MonthsHighestMonthsInArrears"].ToString(), time);

                    //CCA12Months
                    ViewData["ExCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                    ViewData["ExCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                    ViewData["ExCCA12MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                    ViewData["ExCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
                    saveCCA12Months(SearchToken, Reference, SearchID, ViewData["ExCCA12MonthsEnquiriesByClient"].ToString(), ViewData["ExCCA12MonthsEnquiriesByOther"].ToString(), ViewData["ExCCA12MonthsPositiveLoans"].ToString(), ViewData["ExCCA12MonthsHighestMonthsInArrears"].ToString(), time);

                    //CCA24Months
                    ViewData["ExCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                    ViewData["ExCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                    ViewData["ExCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                    ViewData["ExCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
                    saveCCA24Months(SearchToken, Reference, SearchID, ViewData["ExCCA24MonthsEnquiriesByClient"].ToString(), ViewData["ExCCA24MonthsEnquiriesByOther"].ToString(), ViewData["ExCCA24MonthsPositiveLoans"].ToString(), ViewData["ExCCA24MonthsHighestMonthsInArrears"].ToString(), time);

                    //CCA36Months
                    ViewData["ExCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                    ViewData["ExCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                    ViewData["ExCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                    ViewData["ExCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;
                    saveCCA36Months(SearchToken, Reference, SearchID, ViewData["ExCCA36MonthsEnquiriesByClient"].ToString(), ViewData["ExCCA36MonthsEnquiriesByOther"].ToString(), ViewData["ExCCA36MonthsPositiveLoans"], ViewData["ExCCA36MonthsHighestMonthsInArrears"], time);
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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "TransUnion Company Profile By CompanyID";
            string action = "Company ID: " + companyID + "; Search Description: " + searchDesc + "; Enquiry Reason: " + enquiryReason + "; Module Codes: " + moduleCodes;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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
            int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
            string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
            string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
            string ResponseType = rootObject.ResponseMessage; ;
            string Name = ViewData["user"].ToString();
            string Reference = rootObject.ResponseObject.SearchInformation.Reference;
            string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
            string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
            string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
            string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
            string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
            saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "TransUnion Company Profile";
            string action = "Entity Name: " + entityName + "; Entity Number: " + entityNumber + "; Enquiry Reason: " + enquiryReason + "; Enquiry Type: " + enquiryType + "; Module Codes: " + moduleCodes;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add + "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();

            string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!");
            if (!tokenValid(authtoken))
            {
                System.Diagnostics.Debug.WriteLine("User needs to be logged out");
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
            int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
            string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
            string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
            string ResponseType = rootObject.ResponseMessage; ;
            string Name = ViewData["user"].ToString();
            string Reference = rootObject.ResponseObject.SearchInformation.Reference;
            string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
            string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
            string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
            string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
            string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
            saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "TransUnion Consumer Contact Information";
            string action = "Surname: " + surname + "; ID Number: " + idNumber + "; Enquiry Reason: " + enquiryReason;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "TransUnion Consumer ID Verification";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["Message"] = "good";
                //ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;

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

                //if (rootObject.ResponseObject.HistoricalInformation.AddressHistory !=null)
                //{
                //    ViewData["AddressLine2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].FullAddress;
                //    ViewData["AddressDate2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].LastUpdatedDate;

                // ViewData["AddressLine3"] =
                // rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
                // ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

                //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
                //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
                //}

                //for (int i = 0; i < 5; i++)
                //{
                //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
                //}
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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "TransUnion Consumer ID Verification";
            string action = "ID: " + id + "; First Name: " + firstName + "; Surname: " + surname + "; Contact Name: " + conName + "; Contact Number: " + conNumber + "; Passport Number: " + passport + "; Date Of Birth: " + dob;
            System.Diagnostics.Debug.WriteLine(Session["ID"].ToString());
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

            TempData["user"] = Session["Name"].ToString();
            TempData["date"] = DateTime.Today.ToShortDateString();
            TempData["ref"] = refe;

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
            var url = "https://rest.searchworks.co.za/credit/transunion/consumerprofile/";

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
            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content), "hereee");
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            JToken token = JToken.Parse(response.Content);
            try
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = TempData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                //PersonalInfroamtion
                ViewData["AkaName"] = rootObject.ResponseObject.PersonInformation.AlsoKnownAs[0].AkaName;
                ViewData["ConsumerID"] = rootObject.ResponseObject.PersonInformation.AlsoKnownAs[0].ConsumerID;
                ViewData["InformationDate"] = rootObject.ResponseObject.PersonInformation.InformationDate;
                ViewData["PersonID"] = rootObject.ResponseObject.PersonInformation.PersonID;
                ViewData["PersonTitle"] = rootObject.ResponseObject.PersonInformation.Title;
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["IDNumber_Alternate"] = rootObject.ResponseObject.PersonInformation.IDNumber_Alternate;
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                ViewData["MiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
                ViewData["MiddleName2"] = rootObject.ResponseObject.PersonInformation.MiddleName2;
                ViewData["NumberOfDependants"] = rootObject.ResponseObject.PersonInformation.NumberOfDependants;
                ViewData["Remarks"] = rootObject.ResponseObject.PersonInformation.Remarks;
                ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                ViewData["SpouseFirstName"] = rootObject.ResponseObject.PersonInformation.SpouseFirstName;
                ViewData["SpouseSurname"] = rootObject.ResponseObject.PersonInformation.SpouseFirstName;
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
                //savePersonInformation(SearchToken, Reference, SearchID, ViewData["InformationDate"].ToString(), ViewData["PersonID"].ToString(), null, ViewData["DateOfBirth"].ToString(), ViewData["FirstName"].ToString(), ViewData["Surname"].ToString(), ViewData["Fullname"].ToString(), ViewData["IDNumber"].ToString(),
                //    ViewData["IDNumber_Alternate"].ToString(), ViewData["PassportNumber"].ToString(), ViewData["Reference"].ToString(), ViewData["MaritalStatus"].ToString(), ViewData["Gender"].ToString(), ViewData["Age"].ToString(),
                //   ViewData["MiddleName1"].ToString(), ViewData["MiddleName2"].ToString(), ViewData["SpouseFirstName"].ToString(), ViewData["SpouseSurname"].ToString(), ViewData["NumberOfDependants"].ToString(), ViewData["Remarks"].ToString()
                //   , null, ViewData["VerificationStatus"].ToString(), ViewData["HasProperties"], time);

                //HomeAffairsInformation
                ViewData["FirstName"] = rootObject.ResponseObject.HomeAffairsInformation.FirstName;
                ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                ViewData["IDVerified"] = rootObject.ResponseObject.HomeAffairsInformation.IDVerified;
                ViewData["SurnameVerified"] = rootObject.ResponseObject.HomeAffairsInformation.SurnameVerified;
                ViewData["Warnings"] = rootObject.ResponseObject.HomeAffairsInformation.Warnings;
                saveHomeAffairsInformation(SearchToken, Reference, SearchID, ViewData["FirstName"].ToString(), ViewData["DeceasedDate"].ToString(), ViewData["IDVerified"].ToString(), ViewData["SurnameVerified"].ToString(), ViewData["Warnings"].ToString(), null, null, null, null, null, time);
                //CreditInformation
                ViewData["Accounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.Accounts;
                ViewData["Enquires"] = rootObject.ResponseObject.CreditInformation.DataCounts.Enquires;
                ViewData["Judgments"] = rootObject.ResponseObject.CreditInformation.DataCounts.Judgments;
                ViewData["Notices"] = rootObject.ResponseObject.CreditInformation.DataCounts.Notices;
                ViewData["BankDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.BankDefaults;
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
                ViewData["Loans"] = rootObject.ResponseObject.CreditInformation.DataCounts.Loans;
                ViewData["FraudAlerts"] = rootObject.ResponseObject.CreditInformation.DataCounts.FraudAlerts;
                ViewData["Companies"] = rootObject.ResponseObject.CreditInformation.DataCounts.Companies;
                ViewData["Properties"] = rootObject.ResponseObject.CreditInformation.DataCounts.Properties;
                ViewData["Documents"] = rootObject.ResponseObject.CreditInformation.DataCounts.Documents;
                ViewData["DemandLetters"] = rootObject.ResponseObject.CreditInformation.DataCounts.DemandLetters;
                ViewData["Trusts"] = rootObject.ResponseObject.CreditInformation.DataCounts.Trusts;
                ViewData["BondsBonds"] = rootObject.ResponseObject.CreditInformation.DataCounts.BondsBonds;
                ViewData["PublicDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults;
                ViewData["NLRAccounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts;

                //DebtReviewStatus
                ViewData["StatusDate"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDate;
                ViewData["StatusDescription"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription;
                //EnquiryHistory
                List<EnquiryHistory> EnqHIst;
                Newtonsoft.Json.Linq.JArray elements4 = new Newtonsoft.Json.Linq.JArray();
                elements4 = rootObject.ResponseObject.HistoricalInformation.AddressHistory;
                String EnquiryDate = "";
                String EnquiredBy = "";
                String EnquiredByContact = "";
                EnqHIst = new List<EnquiryHistory>();
                for (int count = 0; count < (elements4.Count); count++)
                {
                    EnquiryDate = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate;
                    EnquiredBy = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy;
                    EnquiredByContact = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact;

                    EnqHIst.Add(new EnquiryHistory
                    {
                        EnquiryDate = EnquiryDate,
                        EnquiredBy = EnquiredBy,
                        EnquiredByContact = EnquiredByContact
                    });
                }
                ViewData["EnqHIst"] = EnqHIst;

                List<InternalEnquiryHistory> IntEnqHistory;
                List<AddressHistory> AddressHist;
                List<TelephoneHistory> TelHist;
                List<EmploymentHistory> EmpHist;
                Newtonsoft.Json.Linq.JArray elements, elements1, elements2, elements3, elements5 = new Newtonsoft.Json.Linq.JArray();
                elements = rootObject.ResponseObject.CreditInformation.EnquiryHistory;
                elements1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory;
                elements2 = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;
                elements3 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;
                elements5 = rootObject.ResponseObject.InternalEnquiryHistory;
                //AddressHIstoryValues
                String TypeDescription = "";
                String Line1 = "";
                String Line2 = "";
                String Line3 = "";
                String PostalCode = "";
                String FullAddress = "";
                String LastUpdatedDate = "";
                //TelephoneHIstory
                String TypeDescriptionTel = "";
                String DialCode = "";
                String Number = "";
                String FullNumber = "";
                String LastUpdatedDateTel = "";
                //EmploymentHistory
                String EmployerName = "";
                String Designation = "";
                //InternalEnquiryHistory
                string CompanyName = "";
                string IntEnquiryDate = "";
                string ContactPerson = "";
                string PhoneNumber = "";
                string EmailAddress = "";

                EnqHIst = new List<EnquiryHistory>();
                AddressHist = new List<AddressHistory>();
                TelHist = new List<TelephoneHistory>();
                EmpHist = new List<EmploymentHistory>();
                IntEnqHistory = new List<InternalEnquiryHistory>();

                for (int count = 0; count < (elements.Count); count++)
                {
                    EnquiryDate = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate;
                    EnquiredBy = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy;
                    EnquiredByContact = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact;

                    EnqHIst.Add(new EnquiryHistory
                    {
                        EnquiryDate = EnquiryDate,
                        EnquiredBy = EnquiredBy,
                        EnquiredByContact = EnquiredByContact
                    });
                }
                for (int count = 0; count < (elements1.Count); count++)
                {
                    TypeDescription = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription;
                    Line1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1;
                    Line2 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2;
                    Line3 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3;
                    PostalCode = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode;
                    FullAddress = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress;
                    LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                    AddressHist.Add(new AddressHistory
                    {
                        TypeDescription = TypeDescription,
                        Line1 = Line1,
                        Line2 = Line2,
                        Line3 = Line3,
                        PostalCode = PostalCode,
                        FullAddress = FullAddress,
                        LastUpdatedDate = LastUpdatedDate,
                    });
                }
                for (int count = 0; count < (elements2.Count); count++)
                {
                    TypeDescriptionTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                    DialCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode;
                    Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number;
                    FullNumber = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber;
                    LastUpdatedDateTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDateTel;

                    TelHist.Add(new TelephoneHistory
                    {
                        TypeDescriptionTel = TypeDescriptionTel,
                        DialCode = DialCode,
                        Number = Number,
                        FullNumber = FullNumber,
                        LastUpdatedDateTel = LastUpdatedDate,
                    });
                }
                for (int count = 0; count < (elements3.Count); count++)
                {
                    EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName;
                    Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation; ;

                    EmpHist.Add(new EmploymentHistory
                    {
                        EmployerName = EmployerName,
                        Designation = Designation,
                    });
                }

                for (int count = 0; count < (elements5.Count); count++)
                {
                    CompanyName = rootObject.ResponseObject.InternalEnquiryHistory[count].CompanyName;
                    IntEnquiryDate = rootObject.ResponseObject.InternalEnquiryHistory[count].EnquiryDate;
                    ContactPerson = rootObject.ResponseObject.InternalEnquiryHistory[count].ContactPerson;
                    PhoneNumber = rootObject.ResponseObject.InternalEnquiryHistory[count].PhoneNumber;
                    EmailAddress = rootObject.ResponseObject.InternalEnquiryHistory[count].EmailAddress;

                    IntEnqHistory.Add(new InternalEnquiryHistory
                    {
                        CompanyName = CompanyName,
                        IntEnquiryDate = IntEnquiryDate,
                        ContactPerson = ContactPerson,
                        PhoneNumber = PhoneNumber,
                        EmailAddress = EmailAddress,
                    });
                }

                ViewData["EnqHIst"] = EnqHIst;
                ViewData["AddressHist"] = AddressHist;
                ViewData["TelHist"] = TelHist;
                ViewData["EmpHist"] = EmpHist;
                ViewData["IntEnqHistory"] = IntEnqHistory;
            }
            catch (Exception e)
            {
                TempData["msg"] = "An error occured, please check the entered values.";
            }

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

            if (traceType == "enquiryID")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "TransUnion Consumer Trace By EnquiryID";
                string action = "Equiry ID: " + enquiryID + "; Equiry Result ID: " + enquiryResultID + "; Search Description: " + seaDesc;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);
            }
            else if (traceType == "ID")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "TransUnion Consumer Trace By ID Number";
                string action = "ID: " + id;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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
                System.Diagnostics.Debug.WriteLine(JToken.Parse(response.Content));
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
                    int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                    string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                    string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                    string ResponseType = rootObject.ResponseMessage; ;
                    string Name = ViewData["user"].ToString();
                    string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                    string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                    string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                    string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                    string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                    string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                    saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                    ViewData["Message"] = "good";
                    //ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                    ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
                    var name = ViewData["FirstName"].ToString();

                    ViewData["DateOfBirth"] = rootObject.ResponseObject[0].PersonInformation.DateOfBirth;

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

                    // ViewData["AddressLine3"] =
                    // rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
                    // ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

                    //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
                    //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
                    //}

                    //for (int i = 0; i < 5; i++)
                    //{
                    //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
                    //}
                    //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                    //extract list of companies returned

                    //PersonInformation lst = getIndividualList(response);

                    return View();
                }
            }
            else if (traceType == "mobile")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "TransUnion Consumer Trace By Mobile Number";
                string action = "Mobile Number: " + mobile;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }
            else if (traceType == "surname")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "TransUnion Consumer Trace By Surname and Date of Birth";
                string action = "Surname: " + surname + "; Date Of Birth: " + dob;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }
            else if (traceType == "tele")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "TransUnion Consumer Trace By Telephone Number";
                string action = "Telephone Number: " + tele;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage; ;
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "VeriCred Account Verification";
            string action = "ID: " + id + "; Surname: " + surname + "; Initials: " + initials + "; Account Type: " + accType + "; Account Number: " + accNumber + "; Branch Code: " + branchCode;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
            string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
            string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
            string ResponseType = ViewData["ResponseMessage"].ToString();
            string Name = ViewData["user"].ToString();
            string Reference = rootObject.ResponseObject.SearchInformation.Reference;
            string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
            string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
            string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
            string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
            string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
            saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

            ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;
            ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;

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

            //if (rootObject.ResponseObject.HistoricalInformation.AddressHistory !=null)
            //{
            //    ViewData["AddressLine2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].FullAddress;
            //    ViewData["AddressDate2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[1].LastUpdatedDate;

            // ViewData["AddressLine3"] =
            // rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].FullAddress;
            // ViewData["AddressDate3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[2].LastUpdatedDate;

            //    ViewData["AddressLine4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].FullAddress;
            //    ViewData["AddressDate4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[3].LastUpdatedDate;
            //}

            //for (int i = 0; i < 5; i++)
            //{
            //    Console.WriteLine(rootObject.ResponseObject.HistoricalInformation.AddressHistory[i].Line3);
            //}
            //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
            //extract list of companies returned

            //PersonInformation lst = getIndividualList(response);

            return View();
        }

        public ActionResult VeriCredConsumerProfile()
        {
            return View();
        }

        //Save to databse done!!!!!!!!
        public ActionResult VeriCredConsumerProfileResults(VeriCred veri)
        {
            string id = veri.idNumber;
            string enquiryReason = veri.EnquiryReason;
            string refe = veri.Reference;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "VeriCred Consumer Profile";
            string action = "ID: " + id + "; Enquiry Reason: " + enquiryReason;
            string user_id = Session["ID"].ToString();
            System.Diagnostics.Debug.WriteLine(user_id);
            string us = Session["Name"].ToString();

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
            var url = "https://rest.searchworks.co.za/credit/vericred/consumerprofile/";

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

            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
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

                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                //PersonalInformation
                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                savePersonInformation(SearchToken, Reference, SearchID, null, null, null, ViewData["DateOfBirth"].ToString(), null, null, ViewData["Fullname"].ToString(), ViewData["IDNumber"].ToString(), null, null, null, null, ViewData["Gender"].ToString(), ViewData["Age"].ToString(), null, null, null, null, null, null, null, null, ViewData["HasProperties"], time);
                //CreditInformation
                ViewData["DelphiScoreChartURL"] = rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL;
                ViewData["DelphiScore"] = rootObject.ResponseObject.CreditInformation.DelphiScore;
                ViewData["RiskColour"] = rootObject.ResponseObject.CreditInformation.RiskColour;
                saveCreditInformation(SearchID, SearchUserName, ResponseType, " ", rootObject.ResponseObject.CreditInformation.DelphiScore, rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL, ViewData["RiskColour"], " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", time);
                //~~~ConsumerStatistics~~~//
                ViewData["MonthlyInstalment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                saveCCAStats(SearchToken, Reference, SearchID, " ", " ", " ", " ", " ", rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment, " ", time);

                List<CPA_Accounts> CPAACCOUNTS;
                List<CPA_Accounts> CPATitles;

                Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
                elements1 = rootObject.ResponseObject.CreditInformation.CPA_Accounts;

                String Account_ID = "";
                String SubscriberCode = "";
                String SubscriberName = "";
                String AccountNO = "";
                String OpenDate = "";
                String LastPaymentDate = "";
                String OpenBalance = "";
                String CurrentBalance = "";
                String OverdueAmount = "";
                String InstalmentAmount = "";
                String StatusCodeDesc = "";
                String StatusDate = "";
                String IndustryType = "";
                String PaymentHistoryChartURL = "";
                Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails = new Newtonsoft.Json.Linq.JArray();
                CPAACCOUNTS = new List<CPA_Accounts>();
                CPATitles = new List<CPA_Accounts>();

                for (int count = 0; count < (elements1.Count); count++)
                {
                    Account_ID = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].Account_ID;
                    SubscriberCode = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].SubscriberCode;
                    SubscriberName = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].SubscriberName;
                    AccountNO = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].AccountNO;
                    OpenDate = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].OpenDate;
                    LastPaymentDate = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].LastPaymentDate;
                    OpenBalance = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].OpenBalance;
                    CurrentBalance = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].CurrentBalance;
                    OverdueAmount = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].OverdueAmount;
                    InstalmentAmount = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].InstalmentAmount;
                    StatusCodeDesc = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].StatusCodeDesc;
                    StatusDate = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].StatusDate;
                    IndustryType = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].IndustryType;
                    PaymentHistoryChartURL = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].PaymentHistoryChartURL;
                    PaymentHistoryAccountDetails = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].PaymentHistoryAccountDetails;
                    CPAACCOUNTS.Add(new CPA_Accounts
                    {
                        Account_ID = Account_ID,
                        SubscriberCode = SubscriberCode,
                        SubscriberName = SubscriberName,
                        AccountNO = AccountNO,
                        OpenDate = OpenDate,
                        LastPaymentDate = LastPaymentDate,
                        OpenBalance = OpenBalance,
                        CurrentBalance = CurrentBalance,
                        OverdueAmount = OverdueAmount,
                        InstalmentAmount = InstalmentAmount,
                        StatusCodeDesc = StatusCodeDesc,
                        StatusDate = StatusDate,
                        IndustryType = IndustryType,
                        PaymentHistoryChartURL = PaymentHistoryChartURL,
                        PaymentHistoryAccountDetails = PaymentHistoryAccountDetails,
                    });
                    saveCPA_Accounts(SearchToken, Reference, SearchID, Account_ID, SubscriberCode, SubscriberName, AccountNO, null, null, null, null, null, null, null, null, OpenDate, null, LastPaymentDate, OpenBalance, null, CurrentBalance, null, OverdueAmount, InstalmentAmount, null, null, null, null, StatusCodeDesc, IndustryType, PaymentHistoryChartURL, StatusDate, null, null, null, null, null, null, null, null, DateTime.Now);
                }

                ViewData["CPAACCOUNTS"] = CPAACCOUNTS;

                //HistoricalInformation
                List<AddressHistory> AddressHist;
                List<TelephoneHistory> TelHist;
                List<EmploymentHistory> EmpHist;
                Newtonsoft.Json.Linq.JArray element1, elements2, elements3 = new Newtonsoft.Json.Linq.JArray();
                element1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory;
                elements2 = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;
                elements3 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;
                //AddressHIstoryValues
                String TypeDescription = "";
                String Line1 = "";
                String Line2 = "";
                String Line3 = "";
                String PostalCode = "";
                String FullAddress = "";
                String LastUpdatedDate = "";
                //TelephoneHIstory
                String TypeDescriptionTel = "";
                String DialCode = "";
                String Number = "";
                String FullNumber = "";
                String LastUpdatedDateTel = "";
                //EmploymentHistory
                String EmployerName = "";
                String Designation = "";
                AddressHist = new List<AddressHistory>();
                TelHist = new List<TelephoneHistory>();
                EmpHist = new List<EmploymentHistory>();
                for (int count = 0; count < (element1.Count); count++)
                {
                    TypeDescription = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription;
                    Line1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1;
                    Line2 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2;
                    Line3 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3;
                    PostalCode = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode;
                    FullAddress = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress;
                    LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate;
                    saveAddressHistory(SearchToken, Reference, SearchID, null, TypeDescription, Line1, Line2, Line3, null, PostalCode, FullAddress, LastUpdatedDate, time);
                    AddressHist.Add(new AddressHistory
                    {
                        TypeDescription = TypeDescription,
                        Line1 = Line1,
                        Line2 = Line2,
                        Line3 = Line3,
                        PostalCode = PostalCode,
                        FullAddress = FullAddress,
                        LastUpdatedDate = LastUpdatedDate,
                    });
                }
                for (int count = 0; count < (elements2.Count); count++)
                {
                    TypeDescriptionTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                    DialCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode;
                    Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number;
                    FullNumber = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber;
                    LastUpdatedDateTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDateTel;
                    saveTelephoneHistory(SearchToken, Reference, SearchID, null, TypeDescription, DialCode, Number, FullNumber, LastUpdatedDate, time);
                    TelHist.Add(new TelephoneHistory
                    {
                        TypeDescriptionTel = TypeDescriptionTel,
                        DialCode = DialCode,
                        Number = Number,
                        FullNumber = FullNumber,
                        LastUpdatedDateTel = LastUpdatedDate,
                    });
                }
                for (int count = 0; count < (elements3.Count); count++)
                {
                    EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName;
                    LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate; ;
                    saveEmploymentHistory(SearchToken, Reference, SearchID, EmployerName, Designation, LastUpdatedDate, time);
                    EmpHist.Add(new EmploymentHistory
                    {
                        EmployerName = EmployerName,
                        LastUpdatedDate = LastUpdatedDate,
                    });
                }
                ViewData["AddressHist"] = AddressHist;
                ViewData["TelHist"] = TelHist;
                ViewData["EmpHist"] = EmpHist;
                return View();
            }
        }

        public ActionResult VeriCredContactInfoByIDNumber()
        {
            return View();
        }

        public ActionResult VeriCredContactInfoByIDNumberResults(VeriCred veri)
        {
            string id = veri.idNumber;
            string refe = veri.Reference;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "VeriCred Contact Info By IDNumber";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

            JToken token = JToken.Parse(response.Content);

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

                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                //PersonInformation
                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
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
        }

        public ActionResult VeriCredIDPhotoVerification()
        {
            return View();
        }

        public ActionResult VeriCredIDPhotoVerificationResults(VeriCred veri)
        {
            string id = veri.idNumber;
            string refe = veri.Reference;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "VeriCred ID Photo Verification";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            JToken token = JToken.Parse(response.Content);

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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
        }

        public ActionResult VeriCredIncomeEstimateByIDNumber()
        {
            return View();
        }

        public ActionResult VeriCredIncomeEstimateByIDNumberResults(VeriCred veri)
        {
            string id = veri.idNumber;
            string refe = veri.Reference;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "VeriCred Income Estimate By IDNumber";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            JToken token = JToken.Parse(response.Content);

            ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;

            var mes = ViewData["ResponseMessage"].ToString();

            if (mes == "NotFound" || mes == "Invalid sessionToken")
            {
                ViewData["Message"] = "Not Found";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";
                return View();
            }
            else
            {
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["Message"] = "good";

                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
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
        }

        public ActionResult VeriCredPersonVerificationByIDNumber()
        {
            return View();
        }

        public ActionResult VeriCredPersonVerificationByIDNumberResults(VeriCred search)
        {
            string id = search.idNumber;
            string refe = search.Reference;

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            DateTime time = DateTime.Now;

            string date_add = DateTime.Today.ToShortDateString();
            string time_add = time.ToString("T");
            string page = "VeriCred Person Verification By IDNumber";
            string action = "ID: " + id;
            string user_id = Session["ID"].ToString();
            string us = Session["Name"].ToString();

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

            System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
            ViewData["ResponseMessage"] = rootObject.ResponseMessage;

            JToken token = JToken.Parse(response.Content);

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
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                ViewData["Message"] = "good";

                ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
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

            if (type == "photo")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS ID Photo Verification";
                string action = "ID: " + id;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

                JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

                JToken token = JToken.Parse(response.Content);

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
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer ID Verification By EnquiryID";
                string action = "Equiry ID: " + enquiryID + "; Equiry Result ID: " + enquiryResultID + "; Search Description: " + seaDesc;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }
            else
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer ID Verification";
                string action = "Name: " + name + "; Surname: " + sur + "; ID: " + id;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

            if (type == "address")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer Trace By Address";
                string action = "Suburb: " + suburb + "; Street Number: " + streetNumber + "; Street Name: " + streetName + "; City: " + city + "; Province: " + province;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

                System.Diagnostics.Debug.WriteLine(JObject.Parse(response.Content));
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = ViewData["ResponseMessage"].ToString();
                string Name = ViewData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription);

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
                //ViewData["FirstName1"] = (Array)o.SelectToken("ResponseObject");
                //extract list of companies returned

                //PersonInformation lst = getIndividualList(response);
            }
            else if (type == "enquiryID")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer Trace By EnquiryID";
                string action = "Equiry ID: " + enquiryID + "; Equiry Result ID: " + enquiryResultID + "; Search Description: " + seaDesc;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
            }
            else if (type == "ID")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer Trace By ID Number";
                string action = "ID: " + id;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer Trace by Name";
                string action = "First Name: " + name + "; Surname: " + surname + "; Date Of Birth: " + dob;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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
            else if (type == "passport")
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer Trace By PassportNumber";
                string action = "Passport Number: " + passport;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "XDS Consumer Trace by TelephoneNumber";
                string action = "Surname: " + surname + "; Telephone Code: " + teleCode + "; Telephone Number: " + teleNumber;
                string user_id = Session["ID"].ToString();
                string us = Session["Name"].ToString();

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