using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using searchworks.client.Credit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web.Mvc;

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

        public void saveCompuScanSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO compuscansearchhist (SearchID,searchUserName,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,typeOfSearch) VALUES('" + SearchID + "','" + searchUserName + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveTransUnionSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO transunionsearchHistory (SearchID,searchUserName,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,typeOfSearch) VALUES('" + SearchID + "','" + searchUserName + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveXDSSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO xdssearchHistory (SearchID,searchUserName,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,typeOfSearch) VALUES('" + SearchID + "','" + searchUserName + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveVeriCredSearchHistory(dynamic SearchID, dynamic searchUserName, dynamic reportDate, dynamic reference, dynamic searchToken, dynamic callerModule, dynamic dataSupplier, dynamic searchType, dynamic SearchDescription, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO vericredsearchHistory (SearchID,searchUserName,reportDate,reference,searchToken,callerModule,dataSupplier,searchType,SearchDescription,typeOfSearch) VALUES('" + SearchID + "','" + searchUserName + "','" + reportDate + "','" + reference + "','" + searchToken + "','" + callerModule + "','" + dataSupplier + "','" + searchType + "','" + SearchDescription + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void savePersonInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic InformationDate, dynamic PersonID, dynamic Title, dynamic DateOfBirth, dynamic FirstName, dynamic Surname, dynamic Fullname, dynamic IDNumber, dynamic IDNumber_Alternate, dynamic PassportNumber, dynamic Ref, dynamic MaritalStatus, dynamic Gender, dynamic Age, dynamic MiddleName1, dynamic MiddleName2, dynamic SpouseFirstName, dynamic SpouseSurname, dynamic NumberOfDependants, dynamic Remarks, dynamic CurrentEmployer, dynamic VerificationStatus, dynamic HasProperties, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO personinformation (SearchToken,Reference,SearchID,InformationDate,PersonID,Title,DateOfBirth,FirstName,Surname,Fullname,IDNumber,IDNumber_Alternate,PassportNumber,Ref,MaritalStatus,Gender,Age,MiddleName1,MiddleName2,SpouseFirstName,SpouseSurname,NumberOfDependants,Remarks,CurrentEmployer,VerificationStatus,HasProperties,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + InformationDate + "','" + PersonID + "','" + Title + "','" + DateOfBirth + "','" + FirstName + "','" + Surname + "','" + Fullname + "','" + IDNumber + "','" + IDNumber_Alternate + "','" + PassportNumber + "','" + Ref + "','" + MaritalStatus + "','" + Gender + "','" + Age + "','" + MiddleName1 + "','" + MiddleName2 + "','" + SpouseFirstName + "','" + SpouseSurname + "','" + NumberOfDependants + "','" + Remarks + "','" + CurrentEmployer + "','" + VerificationStatus + "','" + HasProperties + "','" + typeOfSearch + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveContactInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EmailAddress, dynamic MobileNumber, dynamic HomeTelephoneNumber, dynamic WorkTelephoneNumber, dynamic PhysicalAddress, dynamic PostalAddress, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO contactinformation (SearchToken,Reference,SearchID,EmailAddress,MobileNumber,HomeTelephoneNumber,WorkTelephoneNumber,PhysicalAddress,PostalAddress,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EmailAddress + "','" + MobileNumber + "','" + HomeTelephoneNumber + "','" + WorkTelephoneNumber + "','" + PhysicalAddress + "','" + PostalAddress + "','" + typeOfSearch + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveHomeAffairsInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic FirstName, dynamic DeceasedDate, dynamic IDVerified, dynamic SurnameVerified, dynamic Warnings, dynamic DeceasedStatus, dynamic VerifiedStatus, dynamic InitialsVerified, dynamic CauseOfDeath, dynamic VerifiedDate, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO homeaffairsinformation (SearchToken,Reference,SearchID,FirstName,DeceasedDate,IDVerified,SurnameVerified,Warnings,DeceasedStatus,VerifiedStatus,InitialsVerified,CauseOfDeath,VerifiedDate,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + FirstName + "','" + DeceasedDate + "','" + IDVerified + "','" + SurnameVerified + "','" + Warnings + "','" + DeceasedStatus + "','" + VerifiedStatus + "','" + InitialsVerified + "','" + CauseOfDeath + "','" + VerifiedDate + "','" + typeOfSearch + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCreditInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic CreditSummaryChartURL, dynamic DelphiScore, dynamic DelphiScoreChartURL, dynamic RiskColour, dynamic FlagCount, dynamic FlagDetails, dynamic TotalInstallmentAmountCPAAccounts_CompuScan, dynamic TotalInstallmentAmountNLRAccounts_CompuScan, dynamic TotalNumberCPAAccounts_CompuScan, dynamic TotalNumberNLRAccounts_CompuScan, dynamic TotalNumberActiveCPAAccounts_CompuScan, dynamic TotalNumberActiveNLRAccounts_CompuScan, dynamic TotalNumberClosedCPAAccounts_CompuScan, dynamic TotalNumberClosedNLRAccounts_CompuScan, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO creditinformation (SearchToken,Reference,SearchID,CreditSummaryChartURL,DelphiScore,DelphiScoreChartURL,RiskColour,FlagCount,FlagDetails,TotalInstallmentAmountCPAAccounts_CompuScan,TotalInstallmentAmountNLRAccounts_CompuScan,TotalNumberCPAAccounts_CompuScan,TotalNumberNLRAccounts_CompuScan,TotalNumberActiveCPAAccounts_CompuScan,TotalNumberActiveNLRAccounts_CompuScan,TotalNumberClosedCPAAccounts_CompuScan,TotalNumberClosedNLRAccounts_CompuScan,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + CreditSummaryChartURL + "','" + DelphiScore + "','" + DelphiScoreChartURL + "','" + RiskColour + "','" + FlagCount + "','" + FlagDetails + "','" + TotalInstallmentAmountCPAAccounts_CompuScan + "','" + TotalInstallmentAmountNLRAccounts_CompuScan + "','" + TotalNumberCPAAccounts_CompuScan + "','" + TotalNumberNLRAccounts_CompuScan + "','" + TotalNumberActiveCPAAccounts_CompuScan + "','" + TotalNumberActiveNLRAccounts_CompuScan + "','" + TotalNumberClosedCPAAccounts_CompuScan + "','" + TotalNumberClosedNLRAccounts_CompuScan + "','" + typeOfSearch + "' )";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveFraudIndicatorSummary(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic SAFPSListing, dynamic EmployerFraudVerification, dynamic ProtectiveVerification, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO fraudindicatorsummary (SearchToken,Reference,SearchID,SAFPSListing, EmployerFraudVerification,ProtectiveVerification,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + SAFPSListing + "','" + ProtectiveVerification + "','" + ProtectiveVerification + "','" + typeOfSearch + "')";

            MakeConnection(query_uid);
        }

        public void saveCreditDeclineReason(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic ReasonCode, dynamic ReasonDescription, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO creditdeclinereason (SearchToken,Reference,SearchID,ReasonCode, ReasonDescription,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + ReasonCode + "','" + ReasonDescription + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveDataCounts(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic Accounts, dynamic Enquiries, dynamic Judgments, dynamic Notices, dynamic BankDefaults, dynamic Defaults, dynamic Collections, dynamic Directors, dynamic Addresses, dynamic Telephones, dynamic Occupants, dynamic Employers, dynamic TraceAlerts, dynamic PaymentProfiles, dynamic OwnEnquiries, dynamic AdminOrders, dynamic PossibleMatches, dynamic DefiniteMatches, dynamic Loans, dynamic FraudAlerts, dynamic Companies, dynamic Properties, dynamic Documents, dynamic DemandLetters, dynamic Trusts, dynamic Bonds, dynamic Deeds, dynamic PublicDefaults, dynamic NLRAccounts, dynamic typeOfSearch)

        {
            string query_uid = "INSERT INTO datacounts (SearchToken,Reference,SearchID, Accounts, Enquiries, Judgments, Notices, BankDefaults, Defaults, Collections, Directors, Addresses, Telephones, Occupants, Employers, TraceAlerts, PaymentProfiles, OwnEnquiries, AdminOrders, PossibleMatches, DefiniteMatches, Loans, FraudAlerts, Companies, Properties, Documents, DemandLetters, Trusts, Bonds, Deeds, PublicDefaults, NLRAccounts, typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + Accounts + "','" + Enquiries + "','" + Judgments + "','" + Notices + "','" + BankDefaults + "','" + Defaults + "','" + Collections + "','" + Directors + "','" + Addresses + "','" + Telephones + "','" + Occupants + "','" + Employers + "','" + TraceAlerts + "','" + PaymentProfiles + "','" + OwnEnquiries + "','" + AdminOrders + "','" + PossibleMatches + "','" + DefiniteMatches + "','" + Loans + "','" + FraudAlerts + "','" + Companies + "','" + Properties + "','" + Documents + "','" + DemandLetters + "','" + Trusts + "','" + Bonds + "','" + Deeds + "','" + PublicDefaults + "','" + NLRAccounts + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveDebtReviewStatus(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic StatusCode, dynamic StatusDate, dynamic StatusDescription, dynamic ApplicationDate, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO debtreviewstatus (SearchToken,Reference,SearchID,StatusCode,StatusDate, StatusDescription,ApplicationDate,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + StatusCode + "','" + StatusDate + "','" + StatusDescription + "','" + ApplicationDate + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveConsumerStatistics(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic HighestJudgment, dynamic RevolvingAccounts, dynamic InstalmentAccounts, dynamic OpenAccounts, dynamic AdverseAccounts, dynamic Percent0ArrearsLast12Histories, dynamic MonthsOldestOpenedPPSEver, dynamic NumberPPSLast12Months, dynamic NLRMicroloansPast12Months, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO consumerstatistics (SearchToken,Reference,SearchID,HighestJudgment,RevolvingAccounts,InstalmentAccounts,OpenAccounts,AdverseAccounts,Percent0ArrearsLast12Histories,MonthsOldestOpenedPPSEver,NumberPPSLast12Months,NLRMicroloansPast12Months,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + HighestJudgment + "','" + RevolvingAccounts + "','" + InstalmentAccounts + "','" + OpenAccounts + "','" + AdverseAccounts + "','" + Percent0ArrearsLast12Histories + "','" + MonthsOldestOpenedPPSEver + "','" + NumberPPSLast12Months + "','" + NLRMicroloansPast12Months + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLRStats(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic ActiveAccounts, dynamic ClosedAccounts, dynamic WorstMonthArrears, dynamic WorstArrearsStatus, dynamic BalanceExposure, dynamic MonthlyInstalment, dynamic CumulativeArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO nlrstats (SearchToken,Reference,SearchID,ActiveAccounts, ClosedAccounts,WorstMonthArrears,WorstArrearsStatus,BalanceExposure,MonthlyInstalment,CumulativeArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + ActiveAccounts + "','" + ClosedAccounts + "','" + WorstMonthArrears + "','" + WorstArrearsStatus + "','" + BalanceExposure + "','" + MonthlyInstalment + "','" + CumulativeArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCAStats(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic ActiveAccounts, dynamic ClosedAccounts, dynamic WorstMonthArrears, dynamic WorstArrearsStatus, dynamic BalanceExposure, dynamic MonthlyInstalment, dynamic CumulativeArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO ccastats (SearchToken,Reference,SearchID,ActiveAccounts, ClosedAccounts,WorstMonthArrears,WorstArrearsStatus,BalanceExposure,MonthlyInstalment,CumulativeArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + ActiveAccounts + "','" + ClosedAccounts + "','" + WorstMonthArrears + "','" + WorstArrearsStatus + "','" + BalanceExposure + "','" + MonthlyInstalment + "','" + CumulativeArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLR12Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO nlr12months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLR24Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO nlr24months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLR36Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO nlr36months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCA12Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO cca12months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCA24Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO cca24months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCCA36Months(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiriesByClient, dynamic EnquiriesByOther, dynamic PositiveLoans, dynamic HighestMonthsInArrears, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO cca36months (SearchToken,Reference,SearchID,EnquiriesByClient, EnquiriesByOther,PositiveLoans,HighestMonthsInArrears,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiriesByClient + "','" + EnquiriesByOther + "','" + PositiveLoans + "','" + HighestMonthsInArrears + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveEnquiryHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EnquiryDate, dynamic EnquiredBy, dynamic EnquiredByContact, dynamic EnquiredByType, dynamic ReasonForEnquiry, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO enquiryhistory (SearchToken,Reference,SearchID,EnquiryDate, EnquiredBy,EnquiredByContact,EnquiredByType,ReasonForEnquiry,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EnquiryDate + "','" + EnquiredBy + "','" + EnquiredByContact + "','" + EnquiredByType + "','" + ReasonForEnquiry + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveCPA_Accounts(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic Account_ID, dynamic SubscriberCode, dynamic SubscriberName, dynamic AccountNO, dynamic SubAccountNO, dynamic OwnershipTypeDescription, dynamic Reason, dynamic ReasonDescription, dynamic PaymentType, dynamic PaymentTypeDescription, dynamic AccountType, dynamic AccountTypeDescription, dynamic OpenDate, dynamic DeferredPaymentDate, dynamic LastPaymentDate, dynamic OpenBalance, dynamic OpenBalanceIND, dynamic CurrentBalance, dynamic CurrentBalanceIND, dynamic OverdueAmount, dynamic InstalmentAmount, dynamic ArrearsPeriod, dynamic RepaymentFrequencyDescription, dynamic Terms, dynamic StatusCode, dynamic StatusCodeDesc, dynamic IndustryType, dynamic PaymentHistoryChartURL, dynamic StatusDate, dynamic ThirdPartyName, dynamic ThirdPartySold, dynamic JointLoanParticipants, dynamic PaymentHistory, dynamic PaymentHistoryStatus, dynamic PaymentHistoryChart, dynamic MonthEndDate, dynamic DateCreated, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO cpa_accounts (SearchToken,Reference,SearchID,Account_ID,SubscriberCode,SubscriberName,AccountNO,SubAccountNO,OwnershipTypeDescription,Reason,ReasonDescription,PaymentType,PaymentTypeDescription,AccountType,AccountTypeDescription,OpenDate,DeferredPaymentDate,LastPaymentDate,OpenBalance,OpenBalanceIND,CurrentBalance,CurrentBalanceIND,OverdueAmount,InstalmentAmount,ArrearsPeriod,RepaymentFrequencyDescription,Terms,StatusCode,StatusCodeDesc,IndustryType,PaymentHistoryChartURL,StatusDate,ThirdPartyName,ThirdPartySold,JointLoanParticipants,PaymentHistory,PaymentHistoryStatus,PaymentHistoryChart,MonthEndDate,DateCreated,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + Account_ID + "','" + SubscriberCode + "','" + SubscriberName + "','" + AccountNO + "','" + SubAccountNO + "','" + OwnershipTypeDescription + "','" + Reason + "','" + ReasonDescription + "','" + PaymentType + "','" + PaymentTypeDescription + "','" + AccountType + "','" + AccountTypeDescription + "','" + OpenDate + "','" + DeferredPaymentDate + "','" + LastPaymentDate + "','" + OpenBalance + "','" + OpenBalanceIND + "','" + CurrentBalance + "','" + CurrentBalanceIND + "','" + OverdueAmount + "','" + InstalmentAmount + "','" + ArrearsPeriod + "','" + RepaymentFrequencyDescription + "','" + Terms + "','" + StatusCode + "','" + StatusCodeDesc + "','" + IndustryType + "','" + PaymentHistoryChartURL + "','" + StatusDate + "','" + ThirdPartyName + "','" + ThirdPartySold + "','" + JointLoanParticipants + "','" + PaymentHistory + "','" + PaymentHistoryStatus + "','" + PaymentHistoryChart + "','" + MonthEndDate + "','" + DateCreated + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveGeneralInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO generalinformation (SearchToken,Reference,SearchID,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveTransferInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO transferInformation (SearchToken,Reference,SearchID,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveErfInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO erfInformation (SearchToken,Reference,SearchID,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveFarmInformation(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO farminformation (SearchToken,Reference,SearchID,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveNLR_Accounts(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic Account_ID, dynamic SubscriberCode, dynamic SubscriberName, dynamic AccountNO, dynamic SubAccountNO, dynamic OwnershipTypeDescription, dynamic Reason, dynamic ReasonDescription, dynamic PaymentType, dynamic PaymentTypeDescription, dynamic AccountType, dynamic AccountTypeDescription, dynamic OpenDate, dynamic DeferredPaymentDate, dynamic LastPaymentDate, dynamic OpenBalance, dynamic OpenBalanceIND, dynamic CurrentBalance, dynamic CurrentBalanceIND, dynamic OverdueAmount, dynamic InstalmentAmount, dynamic ArrearsPeriod, dynamic RepaymentFrequencyDescription, dynamic Terms, dynamic StatusCode, dynamic StatusCodeDesc, dynamic IndustryType, dynamic PaymentHistoryChartURL, dynamic StatusDate, dynamic ThirdPartyName, dynamic ThirdPartySold, dynamic JointLoanParticipants, dynamic PaymentHistory, dynamic PaymentHistoryStatus, dynamic PaymentHistoryChart, dynamic MonthEndDate, dynamic DateCreated, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO nlr_accounts (SearchToken,Reference,SearchID,Account_ID,SubscriberCode,SubscriberName,AccountNO,SubAccountNO,OwnershipTypeDescription,Reason,ReasonDescription,PaymentType,PaymentTypeDescription,AccountType,AccountTypeDescription,OpenDate,DeferredPaymentDate,LastPaymentDate,OpenBalance,OpenBalanceIND,CurrentBalance,CurrentBalanceIND,OverdueAmount,InstalmentAmount,ArrearsPeriod,RepaymentFrequencyDescription,Terms,StatusCode,StatusCodeDesc,IndustryType,PaymentHistoryChartURL,StatusDate,ThirdPartyName,ThirdPartySold,JointLoanParticipants,PaymentHistory,PaymentHistoryStatus,PaymentHistoryChart,MonthEndDate,DateCreated,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + Account_ID + "','" + SubscriberCode + "','" + SubscriberName + "','" + AccountNO + "','" + SubAccountNO + "','" + OwnershipTypeDescription + "','" + Reason + "','" + ReasonDescription + "','" + PaymentType + "','" + PaymentTypeDescription + "','" + AccountType + "','" + AccountTypeDescription + "','" + OpenDate + "','" + DeferredPaymentDate + "','" + LastPaymentDate + "','" + OpenBalance + "','" + OpenBalanceIND + "','" + CurrentBalance + "','" + CurrentBalanceIND + "','" + OverdueAmount + "','" + InstalmentAmount + "','" + ArrearsPeriod + "','" + RepaymentFrequencyDescription + "','" + Terms + "','" + StatusCode + "','" + StatusCodeDesc + "','" + IndustryType + "','" + PaymentHistoryChartURL + "','" + StatusDate + "','" + ThirdPartyName + "','" + ThirdPartySold + "','" + JointLoanParticipants + "','" + PaymentHistory + "','" + PaymentHistoryStatus + "','" + PaymentHistoryChart + "','" + MonthEndDate + "','" + DateCreated + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveAddressHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic AddressID, dynamic TypeDescription, dynamic Line1, dynamic Line2, dynamic Line3, dynamic Line4, dynamic PostalCode, dynamic FullAddress, dynamic LastUpdatedDate, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO addresshistory (SearchToken,Reference,SearchID,AddressID,TypeDescription,Line1,Line2,Line3,Line4,PostalCode,FullAddress,LastUpdatedDate,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + AddressID + "','" + TypeDescription + "','" + Line1 + "','" + Line2 + "','" + Line3 + "','" + Line4 + "','" + PostalCode + "','" + FullAddress + "','" + LastUpdatedDate + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveTelephoneHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic DialCode, dynamic TelephoneID, dynamic TypeDescription, dynamic TypeCode, dynamic Number, dynamic FullNumber, dynamic LastUpdatedDateTel, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO telephonehistory (SearchToken,Reference,SearchID,DialCode,TelephoneID,TypeDescriptionTel,TypeCode,Number,FullNumber,LastUpdatedDateTel,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + DialCode + "','" + TelephoneID + "','" + TypeDescription + "','" + TypeCode + "','" + Number + "','" + FullNumber + "','" + LastUpdatedDateTel + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveEmploymentHistory(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic EmployerName, dynamic Designation, dynamic LastUpdatedDate, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO employmenthistory (SearchToken,Reference,SearchID,EmployerName,Designation,LastUpdatedDate,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + EmployerName + "','" + Designation + "','" + LastUpdatedDate + "','" + typeOfSearch + "')";

            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

            conn.Open();

            var cmd2 = new MySqlCommand(query_uid, conn);

            var reader2 = cmd2.ExecuteReader();

            conn.Close();
        }

        public void saveDirectorship(dynamic SearchToken, dynamic Reference, dynamic SearchID, dynamic DesignationCode, dynamic AppointmentDate, dynamic DirectorStatus, dynamic DirectorStatusDate, dynamic CompanyName, dynamic CompanyType, dynamic CompanyStatus, dynamic PhysicalAddress, dynamic CompanyStatusCode, dynamic CompanyRegistrationNumber, dynamic CompanyRegistrationDate, dynamic CompanyStartDate, dynamic CompanyTaxNumber, dynamic DirectorTypeCode, dynamic DirectorType, dynamic MemberSize, dynamic MemberContribution, dynamic MemberContributionType, dynamic ResignationDate, dynamic typeOfSearch)
        {
            string query_uid = "INSERT INTO directorships (SearchToken,Reference,SearchID,DesignationCode,AppointmentDate,DirectorStatus,DirectorStatusDate,CompanyName,CompanyType,CompanyStatus,PhysicalAddress,CompanyStatusCode,CompanyRegistrationNumber,CompanyRegistrationDate,CompanyStartDate,CompanyTaxNumber,DirectorTypeCode,DirectorType,MemberSize,MemberContribution,MemberContributionType,ResignationDate,typeOfSearch) VALUES('" + SearchToken + "','" + Reference + "','" + SearchID + "','" + DesignationCode + "','" + AppointmentDate + "','" + DirectorStatus + "','" + DirectorStatusDate + "','" + CompanyName + "','" + CompanyType + "','" + CompanyStatus + "','" + CompanyStatusCode + "','" + CompanyRegistrationNumber + "','" + CompanyRegistrationDate + "','" + CompanyStartDate + "','" + CompanyTaxNumber + "','" + DirectorTypeCode + "','" + DirectorType + "','" + MemberSize + "','" + MemberContribution + "','" + MemberContributionType + "','" + ResignationDate + "','" + typeOfSearch + "')";

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
            string loginToken;
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

        //Complete Integrations Start here
        public ActionResult CombinedConsumerCreditReport()
        {
            return View();
        }

        public ActionResult CombinedConsumerCreditReportResults(Search search)
        {
            /*string id = search.IDNumber != null ? search.IDNumber : null;
            string name = search.FirstName != null ? search.FirstName : null;
            string sur = search.Surname != null ? search.Surname : null;
            int er = search.EnquiryReason;
            string refe = search.Reference != null ? search.Reference : null;

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
            request.AddParameter("Authorization", "Bearer " + authtoken, ParameterType.HttpHeader);*/
            //ApiResponse is a class to model the data we want from the API response

            //LocalAPI
            //company search API call
            var url = "http://localhost:5000";
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);

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
            int SearchID;
            string SearchUserName;
            string ReportDate;
            string ResponseType;
            string Name;
            string Reference;
            string SearchToken;
            string CallerModule;
            string DataSupplier;
            string SearchType;
            string SearchDescription;
            try
            {
                SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                ResponseType = rootObject.ResponseMessage; ;
                Name = ViewData["user"].ToString();
                Reference = rootObject.ResponseObject.SearchInformation.Reference;
                SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CombinedCreditReport");
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Error saving to database. ";
                return View();
            }

            if (rootObject.ResponseMessage != "CombinedConsumerCreditReport")
            {
                ViewData["Message"] = "Service is offline";
                return View();
            }
            else
            {
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                ViewData["CompuScanMessage"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScan;
                ViewData["ExperianMessage"] = rootObject.ResponseObject.CombinedCreditInformation.Experian;
                ViewData["TransUnion"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnion;
                ViewData["XDSMessage"] = rootObject.ResponseObject.CombinedCreditInformation.XDS;
                try
                {
                    if (ViewData["CompuScanMessage"].ToString() == "CONSUMER MATCH")
                    {
                        saveCompuScanSearchHistory(SearchID, SearchUserName, ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanCombinedCreditReport");
                        //PersonaInformantion
                        {
                            ViewData["ComDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.DateOfBirth;
                            ViewData["ComFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.FirstName;
                            ViewData["ComSurname"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Surname;
                            ViewData["ComIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.IDNumber;
                            ViewData["ComGender"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Gender;
                            ViewData["ComAge"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Age;
                            ViewData["ComVerificationStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.VerificationStatus;
                            savePersonInformation(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.InformationDate,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.PersonID,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Title,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.DateOfBirth,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.FirstName,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Surname,
                                  rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Fullname,
                                   rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.IDNumber,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.IDNumber_Alternate,
                                     rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.PassportNumber,
                                      rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Reference,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.MaritalStatus,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Gender,
                                         rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Age,
                                          rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.MiddleName1,
                                           rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.MiddleName2,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.SpouseFirstName,
                                             rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.SpouseSurname,
                                              rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.NumberOfDependants,
                                               rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Remarks,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.CurrentEmployer,
                                                 rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.VerificationStatus,
                                                  rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.HasProperties, "CompuScanCombinedCreditReport");
                        }
                        //CreditInformation
                        {
                            JToken CreditInformationExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["CreditInformation"];
                            if (CreditInformationExists != null)
                            {
                                ViewData["ComDelphiScore"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScore;
                                ViewData["ComRisk"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.Risk;
                                ViewData["ComDelphiScoreChartURL"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScoreChartURL;
                                saveCreditInformation(SearchToken, Reference, SearchID, rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CreditSummaryChartURL,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScore,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DelphiScoreChartURL,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.RiskColour,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.FlagCount,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.FlagDetails,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalInstallmentAmountCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalInstallmentAmountNLRAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalNumberCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalNumberNLRAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalNumberActiveCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalNumberActiveNLRAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalNumberClosedCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.TotalNumberClosedNLRAccounts_CompuScan, "CompuScanCombinedCreditReport");

                                JToken DeclineReasonExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["DeclineReason"];
                                if (DeclineReasonExists != null)
                                {
                                    Newtonsoft.Json.Linq.JArray element = new Newtonsoft.Json.Linq.JArray();
                                    element = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DeclineReason;
                                    DeclineReason DeclineInfo = new DeclineReason();

                                    List<DeclineReason> DeclReasonList;
                                    DeclReasonList = new List<DeclineReason>();

                                    for (int count = 0; count < (element.Count); count++)

                                    {
                                        saveCreditDeclineReason(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DeclineReason[count].ReasonCode,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DeclineReason[count].ReasonDescription,
                                            "CompuScanCombinedCreditReport");

                                        DeclReasonList.Add(new DeclineReason
                                        {
                                            ReasonCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DeclineReason[count].ReasonCode,
                                            ReasonDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DeclineReason[count].ReasonCode,
                                        });
                                    }
                                    //Add to view
                                    ViewData["DeclReasonList"] = DeclReasonList;
                                    ViewData["DeclReasonList"] = DeclReasonList.Count;
                                }

                                JToken DataCountsExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["DataCounts"];
                                if (DataCountsExists != null)
                                {
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
                                    saveDataCounts(SearchToken, Reference, SearchID,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Accounts,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Enquiries,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Judgments,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Notices,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.BankDefaults,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Defaults,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Collections,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Directors,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Addresses,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Telephones,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Occupants,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Employers,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.TraceAlerts,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.PaymentProfiles,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.OwnEnquiries,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.AdminOrders,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.PossibleMatches,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.DefiniteMatches,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Loans,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.FraudAlerts,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Companies,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Properties,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Documents,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.DemandLetters,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Trusts,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Bonds,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.Deeds,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.PublicDefaults,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DataCounts.NLRAccounts,
                                        "CompuScanCombinedCreditReport");
                                }
                                JToken DebtReviewStatusExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["DebtReviewStatus"];
                                if (DebtReviewStatusExists != null)
                                {
                                    ViewData["ApplicationDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.DebtReviewStatus.ApplicationDate;
                                }
                                JToken ConsumerStatisticsExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["ConsumerStatistics"];
                                if (ConsumerStatisticsExists != null)
                                {
                                    //ConsumerStatistics
                                    ViewData["ComHighestJudgment"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.HighestJudgment;
                                    ViewData["ComRevolvingAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                                    ViewData["ComInstalmentAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                                    ViewData["ComOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.OpenAccounts;
                                    ViewData["ComAdverseAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.AdverseAccounts;
                                    saveConsumerStatistics(SearchToken, Reference, SearchID,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.HighestJudgment,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.OpenAccounts,
                                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.AdverseAccounts, " ", " ", " ", " ", "CompuScanCombinedCreditReport");
                                }

                                //NLRStats
                                ViewData["ComNLRActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                                ViewData["ComNLRClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                                ViewData["ComNLRWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                                ViewData["ComNLRBalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                                ViewData["ComNLRCumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
                                saveNLRStats(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthStatus,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLRStats.CumulativeArrears, "CompuScanCombinedCreditReport");

                                //CCAStats
                                ViewData["ComCCAActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                                ViewData["ComCCAClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                                ViewData["ComCCAWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                                ViewData["ComCCABalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                                ViewData["ComCCACumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                                saveCCAStats(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears, " ",
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure, " ",
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment, "CompuScanCombinedCreditReport");

                                //NLR12Months
                                ViewData["ComNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                                ViewData["ComNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                                ViewData["ComNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                                ViewData["ComNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
                                saveNLR12Months(SearchToken, Reference, SearchID,
                                     rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient,
                                     rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther,
                                     rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans,
                                     rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears, "CompuScanCombinedCreditReport");
                                //NLR24Months
                                ViewData["ComNLR24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                                ViewData["ComNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                                ViewData["ComNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                                ViewData["ComNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
                                saveNLR24Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient,
                                     rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears,
                                    "CompuScanCombinedCreditReport");

                                //NLR36Months
                                ViewData["ComNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                                ViewData["ComNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                                ViewData["ComNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                                ViewData["ComNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
                                saveNLR36Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears, "CompuScanCombinedCreditReport");

                                //CCA12Months
                                ViewData["ComCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                                ViewData["ComCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                                ViewData["ComCCA12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                                ViewData["ComCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
                                saveCCA12Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears, "CompuScanCombinedCreditReport");

                                //CCA24Months
                                ViewData["ComCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                                ViewData["ComCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                                ViewData["ComCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                                ViewData["ComCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
                                saveCCA24Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears, "CompuScanCombinedCreditReport");

                                //CCA36Months
                                ViewData["ComCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                                ViewData["ComCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                                ViewData["ComCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                                ViewData["ComCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;
                                saveCCA36Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears, "CompuScanCombinedCreditReport");

                                //EnquiryHistory
                                {
                                    JToken EnquiryHistoryExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["EnquiryHistory"];
                                    if (EnquiryHistoryExists != null)
                                    {
                                        List<EnquiryHistory> EnqHIst;
                                        EnqHIst = new List<EnquiryHistory>();
                                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();

                                        elements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.EnquiryHistory;

                                        for (int count = 0; count < (elements.Count); count++)
                                        {
                                            saveEnquiryHistory(SearchToken, Reference, SearchID,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EnquiryHistory[count].EnquiryDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EnquiryHistory[count].EnquiredBy,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EnquiryHistory[count].EnquiredByContact,
                                                null,
                                                null, "CompuScanCombinedCreditReport");
                                            EnqHIst.Add(new EnquiryHistory
                                            {
                                                EnquiryDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EnquiryHistory[count].EnquiryDate,
                                                EnquiredBy = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EnquiryHistory[count].EnquiredBy,
                                                EnquiredByContact = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EnquiryHistory[count].EnquiredByContact,
                                            });
                                        }
                                        //Add to view
                                        ViewData["EnqHIst"] = EnqHIst;
                                        ViewData["EnqHIstCount"] = EnqHIst.Count;
                                    }

                                }
                                //CPAAccounts
                                {
                                    JToken CPAAccountsExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["CPA_Accounts"];
                                    if (CPAAccountsExists != null)
                                    {
                                        List<CPAaccounts> CPAACCOUNTS;
                                        CPAACCOUNTS = new List<CPAaccounts>();

                                        Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
                                        elements1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts;

                                        for (int count = 0; count < (elements1.Count); count++)
                                        {
                                            saveCPA_Accounts(SearchToken, Reference, SearchID,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].Account_ID,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].SubscriberCode,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].SubscriberName,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].AccountNO,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].SubAccountNO,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OwnershipTypeDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].Reason,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ReasonDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentType,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentTypeDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].AccountType,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].AccountTypeDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OpenDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].DeferredPaymentDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].LastPaymentDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OpenBalance,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OpenBalanceIND,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].CurrentBalance,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].CurrentBalanceIND,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OverdueAmount,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].InstalmentAmount,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ArrearsPeriod,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].RepaymentFrequencyDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].Terms,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].StatusCode,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].StatusCodeDesc,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].IndustryType,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistoryChartURL,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].StatusDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ThirdPartyName,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ThirdPartySold,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].JointLoanParticipants,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistory,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistoryStatus,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistoryChart,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].MonthEndDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].DateCreated,
                                                "CompuScanCombinedCreditReport");

                                            CPAACCOUNTS.Add(new CPAaccounts
                                            {
                                                Account_ID = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].Account_ID,
                                                SubscriberCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].SubscriberCode,
                                                SubscriberName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].SubscriberName,
                                                AccountNO = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].AccountNO,
                                                SubAccountNO = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].SubAccountNO,
                                                OwnershipTypeDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OwnershipTypeDescription,
                                                Reason = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].Reason,
                                                ReasonDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ReasonDescription,
                                                PaymentType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentType,
                                                PaymentTypeDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentTypeDescription,
                                                AccountType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].AccountType,
                                                AccountTypeDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].AccountTypeDescription,
                                                OpenDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OpenDate,
                                                DeferredPaymentDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].DeferredPaymentDate,
                                                LastPaymentDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].LastPaymentDate,
                                                OpenBalance = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OpenBalance,
                                                OpenBalanceIND = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OpenBalanceIND,
                                                CurrentBalance = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].CurrentBalance,
                                                CurrentBalanceIND = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].CurrentBalanceIND,
                                                OverdueAmount = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].OverdueAmount,
                                                OverdueAmountIND = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].InstalmentAmount,
                                                ArrearsPeriod = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ArrearsPeriod,
                                                RepaymentFrequencyDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].RepaymentFrequencyDescription,
                                                Terms = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].Terms,
                                                StatusCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].StatusCode,
                                                StatusCodeDesc = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].StatusCodeDesc,
                                                IndustryType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].IndustryType,
                                                PaymentHistoryChartURL = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistoryChartURL,
                                                StatusDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].StatusDate,
                                                ThirdPartyName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ThirdPartyName,
                                                ThirdPartySold = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].ThirdPartySold,
                                                JointLoanParticipants = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].JointLoanParticipants,
                                                PaymentHistory = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistory,
                                                PaymentHistoryStatus = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistoryStatus,
                                                PaymentHistoryChart = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].PaymentHistoryChart,
                                                MonthEndDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].MonthEndDate,
                                                DateCreated = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.CPA_Accounts[count].DateCreated,
                                                //PaymentHistoryAccountDetails = PaymentHistoryAccountDetails,
                                            });
                                            ViewData["CPAACCOUNTS"] = CPAACCOUNTS;
                                        }
                                    }
                                }
                                //NLRAccounts
                                {
                                    JToken NLRAccountsExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["NLR_Accounts"];
                                    if (NLRAccountsExists != null)
                                    {

                                        List<NLRaccounts> NLRACCOUNTS;
                                        NLRACCOUNTS = new List<NLRaccounts>();


                                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                                        elements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts;

                                        for (int count = 0; count < (elements.Count); count++)
                                        {
                                            saveNLR_Accounts(
                                                SearchToken, Reference, SearchID,
                                               rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].Account_ID,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].SubscriberCode,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].SubscriberName,
                                                //rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ADD BranchCode
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].AccountNO,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].SubAccountNO,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OwnershipTypeDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].Reason,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ReasonDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentType,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentTypeDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].AccountType,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].AccountTypeDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OpenDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].DeferredPaymentDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].LastPaymentDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OpenBalance,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OpenBalanceIND,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].CurrentBalance,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].CurrentBalanceIND,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OverdueAmount,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].InstalmentAmount,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ArrearsPeriod,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].RepaymentFrequencyDescription,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].Terms,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].StatusCode,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].StatusCodeDesc,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].IndustryType,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistoryChartURL,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].StatusDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ThirdPartyName,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ThirdPartySold,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].JointLoanParticipants,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistory,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistoryStatus,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistoryChart,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].MonthEndDate,
                                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].DateCreated,
                                                                                            "CompuScanCombinedCreditReport");
                                            NLRACCOUNTS.Add(new NLRaccounts
                                            {
                                                Account_ID = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].Account_ID,

                                                SubscriberCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].SubscriberCode,

                                                SubscriberName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].SubscriberName,

                                                AccountNO = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].AccountNO,

                                                SubAccountNO = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].SubAccountNO,

                                                OwnershipType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OwnershipType,

                                                OwnershipTypeDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OwnershipTypeDescription,

                                                Reason = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].Reason,

                                                ReasonDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ReasonDescription,

                                                PaymentType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentType,

                                                PaymentTypeDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentTypeDescription,

                                                AccountType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].AccountType,

                                                AccountTypeDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].AccountTypeDescription,

                                                OpenDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OpenDate,

                                                DeferredPaymentDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].DeferredPaymentDate,

                                                LastPaymentDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].LastPaymentDate,

                                                OpenBalance = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OpenBalance,

                                                OpenBalanceIND = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OpenBalanceIND,

                                                CurrentBalance = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].CurrentBalance,

                                                CurrentBalanceIND = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].CurrentBalanceIND,

                                                OverdueAmount = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OverdueAmount,

                                                OverdueAmountIND = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].OverdueAmountIND,

                                                InstalmentAmount = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].InstalmentAmount,

                                                ArrearsPeriod = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ArrearsPeriod,
                                                RepaymentFrequency = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].RepaymentFrequency,

                                                RepaymentFrequencyDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].RepaymentFrequencyDescription,

                                                Terms = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].Terms,

                                                StatusCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].StatusCode,

                                                StatusCodeDesc = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].StatusCodeDesc,

                                                IndustryType = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].IndustryType,

                                                PaymentHistoryChartURL = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistoryChartURL,

                                                StatusDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].StatusDate,

                                                ThirdPartyName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ThirdPartyName,

                                                ThirdPartySold = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ThirdPartySold,

                                                ThirdPartySoldDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].ThirdPartySoldDescription,

                                                JointLoanParticipants = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].JointLoanParticipants,

                                                PaymentHistory = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistory,

                                                PaymentHistoryStatus = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistoryStatus,

                                                PaymentHistoryChart = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].PaymentHistoryChart,
                                                MonthEndDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].MonthEndDate,
                                                DateCreated = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.NLR_Accounts[count].DateCreated,


                                            });
                                            //Add to view
                                            ViewData["NLRACCOUNTS"] = NLRACCOUNTS;
                                        }
                                    }
                                }
                            }
                        }
                        //HistoricalInformation
                        {
                            JToken HistoricalInformationExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HistoricalInformation"];
                            ViewData["AddressHist"] = null;
                            ViewData["EmpHist"] = null;
                            ViewData["TelHist"] = null;
                            if (HistoricalInformationExists != null)
                            {
                                JToken AddressExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation["AddressHistory"];
                                Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
                                elements1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory;

                                if (AddressExists != null)
                                {
                                    List<AddressHistory> AddressHist;
                                    AddressHist = new List<AddressHistory>();

                                    for (int count = 0; count < (elements1.Count); count++)
                                    {

                                        saveAddressHistory(SearchToken, Reference, SearchID,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].AddressID,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeDescription,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                                       rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                       "CompuScanCombinedCreditReport");


                                        AddressHist.Add(new AddressHistory
                                        {

                                            AddressID = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].AddressID,
                                            TypeDescription = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeDescription,
                                            Line1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1,
                                            Line2 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2,
                                            Line3 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3,
                                            Line4 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4,
                                            PostalCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                                            FullAddress = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                                            LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["AddressHist"] = AddressHist;
                                    ViewData["AddressHistCount"] = AddressHist.Count;
                                }

                                JToken TelephoneExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation["TelephoneHistory"];
                                Newtonsoft.Json.Linq.JArray elements2 = new Newtonsoft.Json.Linq.JArray();
                                elements2 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory;

                                if (TelephoneExists != null)

                                {
                                    List<TelephoneHistory> TelHist;
                                    TelHist = new List<TelephoneHistory>();

                                    for (int count = 0; count < (elements2.Count); count++)
                                    {
                                        saveTelephoneHistory(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeCode,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "CompuScanCombinedCreditReport");

                                        TelHist.Add(new TelephoneHistory
                                        {

                                            DialCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                                            TelephoneID = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                                            TypeDescriptionTel = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                            TypeCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeCode,
                                            Number = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number,
                                            FullNumber = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                            LastUpdatedDateTel = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["TelHist"] = TelHist;
                                }

                                JToken EmploymentExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation["EmploymentHistory"];
                                Newtonsoft.Json.Linq.JArray elements3 = new Newtonsoft.Json.Linq.JArray();
                                elements3 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory;

                                if (EmploymentExists != null)
                                {
                                    List<EmploymentHistory> EmpHist;
                                    EmpHist = new List<EmploymentHistory>();
                                    for (int count = 0; count < (elements3.Count); count++)
                                    {
                                        saveEmploymentHistory(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "CompuScanCombinedCreditReport");
                                        EmpHist.Add(new EmploymentHistory
                                        {
                                            EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                            Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation,
                                            LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["EmpHist"] = EmpHist;

                                }


                            }
                        }
                    }
                    else
                    {
                        ViewData["CompuScanMessage"] = "No Match";
                    }

                    if (ViewData["ExperianMessage"].ToString() == "CONSUMER MATCH")
                    {
                        //PersonInformation
                        {
                            ViewData["ExTitle"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Title;//add to view
                            ViewData["ExDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.DateOfBirth;
                            ViewData["ExFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.FirstName;
                            ViewData["ExSurname"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Surname;
                            ViewData["ExFullname"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Fullname;//Add to view
                            ViewData["ExIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.IDNumber;
                            ViewData["ExMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.MaritalStatus;
                            ViewData["ExGender"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Gender;
                            ViewData["ExAge"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Age;
                            ViewData["ExMiddleName1"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.MiddleName1;
                            ViewData["ExReference"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Reference;
                            ViewData["ExHasProperties"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.HasProperties;//Add to view

                            /*PersonInformation PerInfo = new PersonInformation();*/


                            savePersonInformation(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.InformationDate,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.PersonID,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Title,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.DateOfBirth,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.FirstName,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Surname,
                                  rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Fullname,
                                   rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.IDNumber,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.IDNumber_Alternate,
                                     rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.PassportNumber,
                                      rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Reference,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.MaritalStatus,
                                        rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Gender,
                                         rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Age,
                                          rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.MiddleName1,
                                           rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.MiddleName2,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.SpouseFirstName,
                                             rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.SpouseSurname,
                                              rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.NumberOfDependants,
                                               rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.Remarks,
                                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.CurrentEmployer,
                                                 rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.VerificationStatus,
                                                  rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.PersonInformation.HasProperties, "ExperianCombinedCreditReport");
                        }
                        //HomeAffairsInformation
                        {
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
                           rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HomeAffairsInformation.VerifiedDate, "ExperianCombinedCreditReport"
                           );
                        }
                        JToken ContactInformationExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo["ContactInformation"];
                        if (ContactInformationExists != null)
                        //ContactInformation
                        {
                            ViewData["ExPhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.PhysicalAddress; //<Add to view
                            saveContactInformation(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.EmailAddress,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.MobileNumber,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.HomeTelephoneNumber,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.WorkTelephoneNumber,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.PhysicalAddress,
                                rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.ContactInformation.PostalAddress, "ExperianCombinedCreditReport");
                        }
                        //CreditInformation
                        {
                            JToken CreditInformationExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo["CreditInformation"];
                            if (CreditInformationExists != null)
                            {
                                ViewData["ExCreditSummaryChartURL"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ExCreditSummaryChartURL;//<Add to view
                                ViewData["ExDelphiScoreChartURL"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DelphiScoreChartURL;
                                ViewData["ExDelphiScore"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DelphiScore;
                                ViewData["ExFlagCount"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.FlagCount;
                                ViewData["ExFlagDetails"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.FlagDetails;
                                saveCreditInformation(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.CreditSummaryChartURL,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DelphiScore,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DelphiScoreChartURL,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.RiskColour,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.FlagCount,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.FlagDetails,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalInstallmentAmountCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalInstallmentAmountNLRAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalNumberCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalNumberNLRAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalNumberActiveCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalNumberActiveNLRAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalNumberClosedCPAAccounts_CompuScan,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.TotalNumberClosedNLRAccounts_CompuScan, "ExperianCombinedCreditReport");

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
                                saveDataCounts(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Accounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Enquiries,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Judgments,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Notices,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.BankDefaults,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Defaults,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Collections,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Directors,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Addresses,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Telephones,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Occupants,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Employers,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.TraceAlerts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.PaymentProfiles,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.OwnEnquiries,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.AdminOrders,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.PossibleMatches,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.DefiniteMatches,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Loans,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.FraudAlerts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Companies,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Properties,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Documents,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.DemandLetters,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Trusts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Bonds,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.Deeds,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.PublicDefaults,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DataCounts.NLRAccounts, "ExperianCombinedCreditReport");
                                JToken DebtReviewStatusExits = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation["DebtReviewStatus"];
                                if (DebtReviewStatusExits != null)
                                {
                                    ViewData["ExStatusCode"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DebtReviewStatus.StatusCode;//<add to view
                                    ViewData["ExStatusDescription"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DebtReviewStatus.StatusDescription;//<add to view
                                    saveDebtReviewStatus(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DebtReviewStatus.StatusCode,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DebtReviewStatus.StatusDate,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DebtReviewStatus.StatusDescription,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.DebtReviewStatus.ApplicationDate, "ExperianCombinedCreditReport");

                                }

                                //ConsumerStatistics
                                ViewData["ExHighestJudgment"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.HighestJudgment;
                                ViewData["ExRevolvingAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                                ViewData["ExInstalmentAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                                ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.OpenAccounts;
                                ViewData["ExAdverseAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.AdverseAccounts;
                                ViewData["Percent0ArrearsLast12Histories"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.Percent0ArrearsLast12Histories;//<add to view
                                ViewData["MonthsOldestOpenedPPSEver"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.MonthsOldestOpenedPPSEver;//<add to view
                                ViewData["NumberPPSLast12Months"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NumberPPSLast12Months;//<add to view
                                ViewData["NLRMicroloansPast12Months"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRMicroloansPast12Months;//<add to view

                                saveConsumerStatistics(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.HighestJudgment,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.RevolvingAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.InstalmentAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.OpenAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.AdverseAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.Percent0ArrearsLast12Histories,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.MonthsOldestOpenedPPSEver,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NumberPPSLast12Months,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRMicroloansPast12Months, "ExperianCombinedCreditReport");
                                //NLRStats
                                ViewData["ExNLRActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                                ViewData["ExNLRClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                                ViewData["ExNLRWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                                ViewData["ExNLRBalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                                ViewData["ExNLRCumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
                                saveNLRStats(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.WorstArrearsStatus,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLRStats.CumulativeArrears, "ExperianCombinedCreditReport");
                                //CCAStats
                                ViewData["ExCCAActiveAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                                ViewData["ExCCAClosedAccounts"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                                ViewData["ExCCAWorstMonthArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                                ViewData["ExCCABalanceExposure"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                                ViewData["ExCCACumulativeArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                                saveCCAStats(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.WorstArrearsStatus,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCAStats.CumulativeArrears, "ExperianCombinedCreditReport");
                                //NLR12Months
                                ViewData["ExNLR12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                                ViewData["ExNLR12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                                ViewData["ExNLR12MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                                ViewData["ExNLR12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
                                saveNLR12Months(SearchToken, Reference, SearchID, ViewData["ExNLR12MonthsEnquiriesByClient"].ToString(), ViewData["ExNLR12MonthsEnquiriesByOther"].ToString(), ViewData["ExNLR12MonthsPositiveLoans"].ToString(), ViewData["ExNLR12MonthsHighestMonthsInArrears"].ToString(), "ExperianCombinedCreditReport");

                                //NLR24Months
                                ViewData["ExNLR24EnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                                ViewData["ExNLR24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                                ViewData["ExNLR24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                                ViewData["ExNLR24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
                                saveNLR24Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears,
                                    "ExperianCombinedCreditReport");

                                //NLR36Months
                                ViewData["ExNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                                ViewData["ExNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                                ViewData["ExNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                                ViewData["ExNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
                                saveNLR36Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears,
                                    "ExperianCombinedCreditReport");

                                //CCA12Months
                                ViewData["ExCCA12MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                                ViewData["ExCCA12MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                                ViewData["ExCCA12monthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                                ViewData["ExCCA12MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
                                saveCCA12Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient,
                                     rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears, "ExperianCombinedCreditReport");

                                //CCA24Months
                                ViewData["ExCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                                ViewData["ExCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                                ViewData["ExCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                                ViewData["ExCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
                                saveCCA24Months(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears, "ExperianCombinedCreditReport");

                                //CCA36Months
                                ViewData["ExCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                                ViewData["ExCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                                ViewData["ExCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                                ViewData["ExCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;
                                saveCCA36Months(SearchToken, Reference, SearchID,
                                   rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans,
                                    rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears,
                                    "ExperianCombinedCreditReport");

                                //Enquiry History
                                {
                                    JToken EnquiryHistoryExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation["EnquiryHistory"];
                                    if (EnquiryHistoryExists != null)
                                    {
                                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                                        elements = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformationEnquiryHistory;

                                        List<EnquiryHistory> EnqHIst;
                                        EnqHIst = new List<EnquiryHistory>();

                                        for (int count = 0; count < (elements.Count); count++)
                                        {
                                            saveEnquiryHistory(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation[count].EnquiryDate,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation[count].EnquiredBy,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation[count].EnquiredByContact,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation[count].EnquiredByType,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.CreditInformation[count].ReasonForEnquiry, "ExperianConsumerProfile");
                                            EnqHIst.Add(new EnquiryHistory
                                            {
                                                EnquiryDate = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate,
                                                EnquiredBy = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy,
                                                EnquiredByContact = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact,
                                                EnquiredByType = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByType,
                                                ReasonForEnquiry = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].ReasonForEnquiry
                                            });
                                        }
                                        ViewData["EnqHIst"] = EnqHIst;
                                        ViewData["EnqHIstCount"] = EnqHIst.Count;
                                    }
                                }

                            }
                        }
                        //HistoricalInformation
                        {
                            JToken HistoricalInformationExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo["HistoricalInformation"];
                            ViewData["AddressHist"] = null;
                            ViewData["EmpHist"] = null;
                            ViewData["TelHist"] = null;

                            if (HistoricalInformationExists != null)
                            {
                                JToken AddressExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation["AddressHistory"];
                                Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
                                elements1 = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory;

                                if (AddressExists != null)
                                {
                                    List<AddressHistory> AddressHist;
                                    AddressHist = new List<AddressHistory>();

                                    for (int count = 0; count < (elements1.Count); count++)
                                    {

                                        saveAddressHistory(SearchToken, Reference, SearchID,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].AddressID,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].TypeDescription,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line1,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line2,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line3,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line4,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                                       rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                       "ExperianCombinedCreditReport");


                                        AddressHist.Add(new AddressHistory
                                        {

                                            AddressID = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].AddressID,
                                            TypeDescription = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].TypeDescription,
                                            Line1 = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line1,
                                            Line2 = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line2,
                                            Line3 = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line3,
                                            Line4 = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].Line4,
                                            PostalCode = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                                            FullAddress = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                                            LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["AddressHist"] = AddressHist;
                                    ViewData["AddressHistCount"] = AddressHist.Count;
                                }

                                JToken TelephoneExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation["TelephoneHistory"];
                                Newtonsoft.Json.Linq.JArray elements2 = new Newtonsoft.Json.Linq.JArray();
                                elements2 = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory;

                                if (TelephoneExists != null)

                                {
                                    List<TelephoneHistory> TelHist;
                                    TelHist = new List<TelephoneHistory>();

                                    for (int count = 0; count < (elements2.Count); count++)
                                    {
                                        saveTelephoneHistory(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].TypeCode,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].Number,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "ExperianCombinedCreditReport");

                                        TelHist.Add(new TelephoneHistory
                                        {

                                            DialCode = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                                            TelephoneID = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                                            TypeDescriptionTel = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                            TypeCode = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].TypeCode,
                                            Number = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].Number,
                                            FullNumber = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                            LastUpdatedDateTel = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["TelHist"] = TelHist;
                                }

                                JToken EmploymentExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation["EmploymentHistory"];
                                Newtonsoft.Json.Linq.JArray elements3 = new Newtonsoft.Json.Linq.JArray();
                                elements3 = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.EmploymentHistory;

                                if (EmploymentExists != null)
                                {
                                    List<EmploymentHistory> EmpHist;
                                    EmpHist = new List<EmploymentHistory>();
                                    for (int count = 0; count < (elements3.Count); count++)
                                    {
                                        saveEmploymentHistory(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                                            rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "ExperianCombinedCreditReport");
                                        EmpHist.Add(new EmploymentHistory
                                        {
                                            EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                            Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation,
                                            LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["EmpHist"] = EmpHist;

                                }
                            }
                        }
                    }
                    else
                    {
                        ViewData["Experian"] = "No Match";
                    }

                    if (rootObject.ResponseObject.CombinedCreditInformation.TransUnion == "CONSUMER MATCH")
                    {
                        ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                        return View();
                    }
                    else
                    {
                        ViewData["TransUnion"] = "No Match";
                    }

                    if (ViewData["XDSMessage"].ToString() == "CONSUMER MATCH")
                    {
                        //Person Information
                        {
                            ViewData["PersonID"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.PersonID;
                            ViewData["Title"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Title;
                            ViewData["DateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.DateOfBirth;
                            ViewData["Initials"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Initials;
                            ViewData["IDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.IDNumber;
                            ViewData["MaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MaritalStatus;
                            ViewData["Gender"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Gender;
                            ViewData["MiddleName1"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MiddleName1;
                            ViewData["Fullname"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Fullname;
                            savePersonInformation(SearchToken, Reference, SearchID,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.InformationDate,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.PersonID,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Title,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.DateOfBirth,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.FirstName,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Surname,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Fullname,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.IDNumber,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.IDNumber_Alternate,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.PassportNumber,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Reference,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MaritalStatus,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Gender,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Age,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MiddleName1,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MiddleName2,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.SpouseFirstName,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.SpouseSurname,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.NumberOfDependants,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Remarks,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.CurrentEmployer,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.VerificationStatus,
                              rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.HasProperties, "XDSCombinedCreditReport");
                        }
                        //HomeAffairs Information
                        {
                            JToken HomeAffairsInformationExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HomeAffairsInformation"];
                            if (HomeAffairsInformationExists != null)
                            {
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
                               rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HomeAffairsInformation.VerifiedDate, "XDSCombinedCreditReport"
                               );
                            }
                        }
                        //ContactInformation
                        {
                            JToken ContactInformationExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["ContactInformation"];
                            if (ContactInformationExists != null)
                            {
                                ViewData["EmailAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.EmailAddress;
                                ViewData["MobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.MobileNumber;
                                ViewData["PhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PhysicalAddress;
                                ViewData["PostalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PostalAddress;
                                saveContactInformation(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.EmailAddress,
                                    rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.MobileNumber,
                                    rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.HomeTelephoneNumber,
                                    rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.WorkTelephoneNumber,
                                    rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PhysicalAddress,
                                    rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.ContactInformation.PostalAddress,
                                     "XDSCombinedCreditReport");
                            }
                        }
                        //CreditInformation
                        {
                            JToken CreditInformationExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["CreditInformation"];
                            if (CreditInformationExists != null)
                            {
                                ViewData["CreditSummaryChartURL"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.CreditSummaryChartURL;
                                JToken FraudIndicatorSummaryExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"];
                                if (FraudIndicatorSummaryExists != null)
                                {
                                    //FraudIndicatorSummary:
                                    ViewData["SAFPSListing"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.SAFPSListing;
                                    ViewData["EmployerFraudVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.EmployerFraudVerification;
                                    ViewData["ProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.ProtectiveVerification;
                                    saveFraudIndicatorSummary(SearchToken, Reference, SearchID,
                                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.SAFPSListing,
                                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.EmployerFraudVerification,
                                        rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation.FraudIndicatorSummary.ProtectiveVerification,
                                        "XDSCombinedCreditReport");
                                }
                                JToken DataCountsExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["DataCounts"];
                                if (DataCountsExists != null)
                                {
                                }

                                JToken EnquiryHistoryExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["EnquiryHistory"];
                                if (EnquiryHistoryExists != null)
                                {
                                }
                            }
                        }
                        //DirectorShipInformation
                        {
                            JToken DirectorSummaryExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["DirectorSummary"];
                            if (DirectorSummaryExists != null)
                            {
                                ViewData["NoOfCompanyDirectors"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorSummary.NoOfCompanyDirectors;//Add to view
                                //saveDirectorSummary()

                            }
                            JToken DirectorshipExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["DirectorshipInformation"];
                            if (DirectorshipExists != null)
                            {
                                List<Directorship> Direc = new List<Directorship>();
                                Newtonsoft.Json.Linq.JArray Directorshipelement = new Newtonsoft.Json.Linq.JArray();
                                Directorshipelement = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships;

                                for (int count = 0; count < (Directorshipelement.Count); count++)
                                {
                                    Direc.Add(new Directorship
                                    {
                                        DesignationCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DesignationCode,
                                        AppointmentDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].AppointmentDate,
                                        DirectorStatus = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorStatus,
                                        DirectorStatusDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorStatusDate,
                                        CompanyName = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyName,
                                        CompanyType = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyType,
                                        CompanyStatus = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyStatus,
                                        CompanyStatusCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyStatusCode,
                                        CompanyRegistrationNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyRegistrationNumber,
                                        CompanyRegistrationDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyRegistrationDate,
                                        CompanyStartDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyStartDate,
                                        CompanyTaxNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyTaxNumber,
                                        DirectorTypeCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorTypeCode,
                                        DirectorType = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorType,
                                        MemberSize = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].MemberSize,
                                        MemberContribution = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].MemberContribution,
                                        MemberContributionType = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].MemberContributionType,
                                        ResignationDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].ResignationDate,
                                    });

                                    ViewData["CompanyName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyName;
                                    ViewData["CompanyRegistrationNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyRegistrationNumber;
                                    ViewData["AppointmentDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].AppointmentDate;
                                    ViewData["PhysicalAddress"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].PhysicalAddress;

                                    saveDirectorship(SearchToken, Reference, SearchID,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DesignationCode,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].AppointmentDate,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorStatus,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorStatusDate,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyName,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyType,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyStatus,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].PhysicalAddress,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyStatusCode,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyRegistrationNumber,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyRegistrationDate,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyStartDate,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].CompanyTaxNumber,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorTypeCode,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].DirectorType,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].MemberSize,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].MemberContribution,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].MemberContributionType,
                                   rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.DirectorshipInformation.Directorships[count].ResignationDate,
                                   "XDSCombinedCreditReport");
                                }

                                ViewData["DirectorshipList"] = Direc;
                            }
                        }
                        //PropertyInformation
                        {
                            JToken PropertyInformationExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["PropertyInformation"];
                            List<PropertiesInformation> PropertiesList = new List<PropertiesInformation>();
                            //PropertyInformationSummary
                            if (PropertyInformationExists != null)
                            {
                                JToken PropertiesExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation["Properties"];
                                if (PropertiesExists != null)
                                {
                                    Newtonsoft.Json.Linq.JArray Propertyelement = new Newtonsoft.Json.Linq.JArray();
                                    Propertyelement = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties;

                                    //Properties
                                    for (int count = 0; count < (Propertyelement.Count); count++)

                                    {
                                        TransferInformation TransferInfo = new TransferInformation();
                                        List<TransferInformation> TransferList;

                                        List<BuyerInformation> BuyerList;
                                        BuyerList = new List<BuyerInformation>();

                                        SellerInformation SellerInfo = new SellerInformation();
                                        List<SellerInformation> SellerList;

                                        BondInformation BondInfo = new BondInformation();
                                        List<BondInformation> BondList;

                                        GeneralInformation GeneralInfo = new GeneralInformation();
                                        List<GeneralInformation> GeneralList;
                                        //TransferInformation
                                        {
                                            JToken TransferInfoExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties["TransferInformation"];

                                            TransferList = new List<TransferInformation>();
                                            if (TransferInfoExists != null)
                                            {
                                                ViewData["AttorneyFirmNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].TransferInformation.AttorneyFirmNumber;
                                                ViewData["AttorneyFileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].TransferInformation.AttorneyFileNumber;
                                                ViewData["TitleDeedFeeAmount"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].TransferInformation.TitleDeedFeeAmount;
                                                ViewData["TransferDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].TransferInformation.TransferDate;
                                                ViewData["PurchaseDate"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].TransferInformation.PurchaseDate;
                                                ViewData["PurchasePrice"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].TransferInformation.PurchasePrice;
                                                ViewData["TitleDeedNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].TransferInformation.TitleDeedNumber;
                                            TODO: /*saveTransferInformation();*/
                                                TransferInfo.PurchaseDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties.TransferInformation[count].PurchaseDate;
                                                TransferInfo.RegistrationDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties.TransferInformation[count].RegistrationDate;
                                                TransferInfo.PurchasePrice = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties.TransferInformation[count].PurchasePrice;
                                                TransferInfo.TitleDeedNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties.TransferInformation[count].TitleDeedNumber;
                                            }
                                            TransferList.Add(TransferInfo);
                                        }

                                        //BuyerInformation
                                        {
                                            JToken BuyerInfoExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties["BuyerInformation"];
                                            BuyerInformation BuyerInfo = new BuyerInformation();

                                            if (BuyerInfoExists != null)
                                            {
                                                ViewData["BuyerName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.Fullname;
                                                ViewData["BuyerIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.IDNumber;
                                                ViewData["BuyerMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.MaritalStatus;
                                                ViewData["BuyerPropertySharePercentage"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.PropertySharePercentage;
                                                /*saveBuyerInformation*/

                                                BuyerInfo.Fullname = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.Fullname;
                                                BuyerInfo.IDNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.Fullname;
                                                BuyerInfo.MaritalStatus = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.Fullname;
                                                BuyerInfo.PropertySharePercentage = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BuyerInformation.Fullname;
                                            }
                                            BuyerList.Add(BuyerInfo);
                                        }

                                        //SellerInformation
                                        {
                                            JToken SellerInfoExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties["SellerInformation"];

                                            SellerList = new List<SellerInformation>();

                                            if (SellerInfoExists != null)
                                            {
                                                ViewData["SellerName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].SellerInformation.Fullname;
                                                ViewData["SellerIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].SellerInformation.IDNumber;
                                                ViewData["SellerMaritalStatus"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].SellerInformation.MaritalStatus;

                                                SellerInfo.Fullname = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].SellerInformation.Fullname;
                                                SellerInfo.IDNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].SellerInformation.IDNumber;
                                                SellerInfo.MaritalStatus = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].SellerInformation.MaritalStatus;
                                            }
                                            SellerList.Add(SellerInfo);
                                        }
                                        //BondInformation
                                        {
                                            JToken BondInfoExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties["BondInformation"];

                                            BondList = new List<BondInformation>();

                                            if (BondInfoExists != null)
                                            {
                                                ViewData["Institution"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BondInformation.Institution;
                                                ViewData["BondNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BondInformation.BondNumber;
                                                ViewData["BondAmount"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BondInformation.BondAmount;

                                                BondInfo.Institution = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BondInformation.Institution;
                                                BondInfo.BondNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BondInformation.BondNumber;
                                                BondInfo.BondAmount = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].BondInformation.BondAmount;
                                            }
                                            BondList.Add(BondInfo);
                                        }
                                        //GeneralInformation
                                        {
                                            JToken GeneralInfoExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties["GeneralInformation"];

                                            GeneralList = new List<GeneralInformation>();

                                            if (GeneralInfoExists != null)
                                            {
                                                ViewData["Municipality"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.Municipality;
                                                ViewData["Township"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.Township;
                                                ViewData["CityName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.CityName;
                                                ViewData["StreetName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.StreetName;
                                                ViewData["StreetNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.StreetNumber;
                                                ViewData["RegisteredSize"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.RegisteredSize;
                                                ViewData["DeedsOfficeName"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.DeedsOfficeName;
                                                ViewData["OldTitleDeedNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.OldTitleDeedNumber;
                                                ViewData["PhysicalAddressG"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.PhysicalAddress;
                                                ViewData["StandNumber"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.StandNumber;

                                                GeneralInfo.Municipality = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.Municipality;
                                                GeneralInfo.Township = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.Township;
                                                GeneralInfo.CityName = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.CityName;
                                                GeneralInfo.StreetName = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.StreetName;
                                                GeneralInfo.StreetNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.StreetNumber;
                                                GeneralInfo.RegisteredSize = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.RegisteredSize;
                                                GeneralInfo.DeedsOfficeName = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.DeedsOfficeName;
                                                GeneralInfo.OldTitleDeedNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.OldTitleDeedNumber;
                                                GeneralInfo.PhysicalAddressG = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.PhysicalAddress;
                                                GeneralInfo.StandNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PropertyInformation.Properties[count].GeneralInformation.StandNumber;
                                            }
                                            GeneralList.Add(GeneralInfo);
                                        }

                                        PropertiesList.Add(new PropertiesInformation
                                        {
                                            TransferInformation = TransferList,
                                            BuyerInformation = BuyerList,
                                            SellerInformation = SellerList,
                                            BondInformation = BondList,
                                            GeneralInformation = GeneralList,
                                        });
                                        ViewData["PropertiesList"] = PropertiesList;
                                    }
                                }
                            }
                        }
                        //HistoricalInformation
                        {
                            JToken HistoricalInformationExists = rootObject.ResponseObject.CombinedCreditInformation.ExperianInfo["HistoricalInformation"];
                            ViewData["AddressHist"] = null;
                            ViewData["EmpHist"] = null;
                            ViewData["TelHist"] = null;

                            if (HistoricalInformationExists != null)
                            {
                                JToken AddressExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation["AddressHistory"];
                                Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
                                elements1 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory;

                                if (AddressExists != null)
                                {
                                    List<AddressHistory> AddressHist;
                                    AddressHist = new List<AddressHistory>();

                                    for (int count = 0; count < (elements1.Count); count++)
                                    {

                                        saveAddressHistory(SearchToken, Reference, SearchID,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].AddressID,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].TypeDescription,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line1,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line2,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line3,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line4,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                                       rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                       "XDSCombinedCreditReport");


                                        AddressHist.Add(new AddressHistory
                                        {

                                            AddressID = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].AddressID,
                                            TypeDescription = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].TypeDescription,
                                            Line1 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line1,
                                            Line2 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line2,
                                            Line3 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line3,
                                            Line4 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line4,
                                            PostalCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                                            FullAddress = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                                            LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["AddressHist"] = AddressHist;
                                    ViewData["AddressHistCount"] = AddressHist.Count;
                                }

                                JToken TelephoneExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation["TelephoneHistory"];
                                Newtonsoft.Json.Linq.JArray elements2 = new Newtonsoft.Json.Linq.JArray();
                                elements2 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory;

                                if (TelephoneExists != null)

                                {
                                    List<TelephoneHistory> TelHist;
                                    TelHist = new List<TelephoneHistory>();

                                    for (int count = 0; count < (elements2.Count); count++)
                                    {
                                        saveTelephoneHistory(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeCode,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].Number,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "XDSCombinedCreditReport");

                                        TelHist.Add(new TelephoneHistory
                                        {

                                            DialCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                                            TelephoneID = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                                            TypeDescriptionTel = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                            TypeCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeCode,
                                            Number = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].Number,
                                            FullNumber = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                            LastUpdatedDateTel = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["TelHist"] = TelHist;
                                }

                                JToken EmploymentExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation["EmploymentHistory"];
                                Newtonsoft.Json.Linq.JArray elements3 = new Newtonsoft.Json.Linq.JArray();
                                elements3 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory;

                                if (EmploymentExists != null)
                                {
                                    List<EmploymentHistory> EmpHist;
                                    EmpHist = new List<EmploymentHistory>();
                                    for (int count = 0; count < (elements3.Count); count++)
                                    {
                                        saveEmploymentHistory(SearchToken, Reference, SearchID,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "XDSCombinedCreditReport");
                                        EmpHist.Add(new EmploymentHistory
                                        {
                                            EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                            Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation,
                                            LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate,
                                        });
                                    }
                                    ViewData["EmpHist"] = EmpHist;

                                }

                                JToken EmailHistoryExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation["EmailHistory"];
                                Newtonsoft.Json.Linq.JArray elements4 = new Newtonsoft.Json.Linq.JArray();
                                elements4 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmailHistory;
                                if (EmailHistoryExists != null)
                                {
                                    List<EmailHistory> EmailHist;
                                    EmailHist = new List<EmailHistory>();

                                    /*saveEmailHistory()*/
                                    for (int count = 0; count < (elements4.Count); count++)
                                    {
                                        EmailHist.Add(new EmailHistory
                                        {
                                            EmailAddress = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmailHistory[count].EmailAddress,
                                            LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmailHistory[count].EmailAddress,

                                        });
                                    }
                                    ViewData["EmailHist"] = EmailHist; //<--add to view
                                }
                            }
                        }
                    }
                    else
                    {
                        ViewData["XDS"] = "No Match";
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e);
                    ViewData["msg"] = "Error Occured, Please verify the details that have been entered. ";

                    //ViewData["msg"] = "Error Occured, Please verify the details that have been entered";
                }
                return View();
            }
        }

        public ActionResult CombinedConsumerCreditReportDatabase(DatabaseSearch DbSearch)
        {
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
            System.Collections.Generic.List<PersonInformation> personInfoList = new System.Collections.Generic.List<PersonInformation>();
            System.Collections.Generic.List<HomeAffairsInformation> homeAffairsInformationList = new System.Collections.Generic.List<HomeAffairsInformation>();
            System.Collections.Generic.List<FraudIndicatorSummary> fraudIndicatorSummaryList = new System.Collections.Generic.List<FraudIndicatorSummary>();
            System.Collections.Generic.List<CreditInformation> creditInformationList = new System.Collections.Generic.List<CreditInformation>();
            System.Collections.Generic.List<DataCounts> dataCountsList = new System.Collections.Generic.List<DataCounts>();
            System.Collections.Generic.List<ConsumerStatistics> consumerstatsList = new System.Collections.Generic.List<ConsumerStatistics>();
            System.Collections.Generic.List<NLRStats> nlrstatsList = new System.Collections.Generic.List<NLRStats>();
            System.Collections.Generic.List<NLR12months> nlr12monthsList = new System.Collections.Generic.List<NLR12months>();
            System.Collections.Generic.List<NLR24months> nlr24monthsList = new System.Collections.Generic.List<NLR24months>();
            System.Collections.Generic.List<NLR36months> nlr36monthsList = new System.Collections.Generic.List<NLR36months>();
            System.Collections.Generic.List<CCAStats> ccastatsList = new System.Collections.Generic.List<CCAStats>();
            System.Collections.Generic.List<CCA12months> cca12monthsList = new System.Collections.Generic.List<CCA12months>();
            System.Collections.Generic.List<CCA24months> cca24monthsList = new System.Collections.Generic.List<CCA24months>();
            System.Collections.Generic.List<CCA36months> cca36monthsList = new System.Collections.Generic.List<CCA36months>();
            System.Collections.Generic.List<AddressHistory> addressInformationList = new System.Collections.Generic.List<AddressHistory>();
            System.Collections.Generic.List<EmploymentHistory> employmentInformationList = new System.Collections.Generic.List<EmploymentHistory>();
            System.Collections.Generic.List<TelephoneHistory> telephoneInformationList = new System.Collections.Generic.List<TelephoneHistory>();
            System.Collections.Generic.List<Directorship> directorshipList = new System.Collections.Generic.List<Directorship>();

            //Add TABLE paymenthistoryaccountdetails!!!!
            //CompuScanCombinedCreditReport
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    //************************************************* Start personal info ***********//
                    string query_uid_personinformation = $"SELECT * FROM personinformation as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_personinformation, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                int DateOfBirth = reader.GetOrdinal("DateOfBirth");
                                int FirstName = reader.GetOrdinal("FirstName");
                                int Surname = reader.GetOrdinal("Surname");
                                int IDNumber = reader.GetOrdinal("IDNumber");
                                int Gender = reader.GetOrdinal("Gender");
                                int Age = reader.GetOrdinal("Age");
                                int VerificationStatus = reader.GetOrdinal("VerificationStatus");

                                //PersonInformation
                                while (reader.Read())
                                {
                                    PersonInformation personInformation = new PersonInformation();
                                    personInformation.FirstName = (reader[FirstName] != Convert.DBNull) ? reader[FirstName].ToString() : null;
                                    personInformation.DateOfBirth = (reader[DateOfBirth] != Convert.DBNull) ? reader[DateOfBirth].ToString() : null;
                                    personInformation.Surname = (reader[Surname] != Convert.DBNull) ? reader[Surname].ToString() : null;
                                    personInformation.IDNumber = (reader[IDNumber] != Convert.DBNull) ? reader[IDNumber].ToString() : null;
                                    personInformation.Gender = (reader[Gender] != Convert.DBNull) ? reader[Gender].ToString() : null;
                                    personInformation.Age = (reader[Age] != Convert.DBNull) ? reader[Age].ToString() : null;
                                    personInformation.VerificationStatus = (reader[VerificationStatus] != Convert.DBNull) ? reader[VerificationStatus].ToString() : null;
                                    //add to the list
                                    personInfoList.Add(personInformation);
                                }
                            }
                            ViewData["PersonInfoList"] = personInfoList;
                            ViewData["PersonInfoListCount"] = personInfoList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //*************************************************END personal info ***********//

                    //************************************************* Start CreditInformation info ***********//
                    string query_uid_creditinformation = $"SELECT * FROM creditinformation as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_creditinformation, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CreditInformation
                                CreditInformation CreditInfo = new CreditInformation();

                                int DelphiScore = reader.GetOrdinal("DelphiScore");
                                int RiskColour = reader.GetOrdinal("RiskColour");

                                while (reader.Read())
                                {
                                    CreditInfo.DelphiScore = (reader[DelphiScore] != Convert.DBNull) ? reader[DelphiScore].ToString() : null;
                                    CreditInfo.RiskColour = (reader[RiskColour] != Convert.DBNull) ? reader[RiskColour].ToString() : null;

                                    //add to the list
                                    creditInformationList.Add(CreditInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["creditInformationList"] = creditInformationList;
                            ViewData["creditInformationListCount"] = creditInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End CreditInformation info ***********//
                    //************************************************* StartDataCOunts info ***********//
                    string query_uid_DataCOunts = $"SELECT * FROM datacounts as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_DataCOunts, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //DataCountsInformation
                                DataCounts DataCountInfo = new DataCounts();

                                int Accounts = reader.GetOrdinal("Accounts");
                                int Enquiries = reader.GetOrdinal("Enquiries");
                                //int Judgements = reader.GetOrdinal("Judgements");
                                int Notices = reader.GetOrdinal("Notices");
                                int BankDefaults = reader.GetOrdinal("BankDefaults");
                                int Defaults = reader.GetOrdinal("Defaults");
                                int Collections = reader.GetOrdinal("Collections");
                                int Directors = reader.GetOrdinal("Directors");
                                int Addresses = reader.GetOrdinal("Addresses");
                                int Telephones = reader.GetOrdinal("Telephones");
                                int Occupants = reader.GetOrdinal("Occupants");
                                int Employers = reader.GetOrdinal("Employers");
                                int TraceAlerts = reader.GetOrdinal("TraceAlerts");
                                int PaymentProfiles = reader.GetOrdinal("PaymentProfiles");
                                int OwnEnquiries = reader.GetOrdinal("OwnEnquiries");
                                int AdminOrders = reader.GetOrdinal("AdminOrders");
                                int PossibleMatches = reader.GetOrdinal("PossibleMatches");
                                int DefiniteMatches = reader.GetOrdinal("DefiniteMatches");
                                int Loans = reader.GetOrdinal("Loans");
                                int FraudAlerts = reader.GetOrdinal("FraudAlerts");
                                int Companies = reader.GetOrdinal("Companies");
                                int Properties = reader.GetOrdinal("Properties");
                                int Documents = reader.GetOrdinal("Documents");
                                int DemandLetters = reader.GetOrdinal("DemandLetters");
                                int Trusts = reader.GetOrdinal("Trusts");
                                int Bonds = reader.GetOrdinal("Bonds");
                                int Deeds = reader.GetOrdinal("Deeds");
                                int PublicDefaults = reader.GetOrdinal("PublicDefaults");
                                int NLRAccounts = reader.GetOrdinal("NLRAccounts");
                                while (reader.Read())
                                {
                                    DataCountInfo.Accounts = (reader[Accounts] != Convert.DBNull) ? reader[Accounts].ToString() : null;
                                    DataCountInfo.Enquires = (reader[Enquiries] != Convert.DBNull) ? reader[Enquiries].ToString() : null;
                                    //DataCountInfo.Judgements = (reader[Judgements] != Convert.DBNull) ? reader[Judgements].ToString() : null;
                                    DataCountInfo.Notices = (reader[Notices] != Convert.DBNull) ?
                                    reader[Notices].ToString() : null; DataCountInfo.BankDefaults =
                                    (reader[BankDefaults] != Convert.DBNull) ? reader[BankDefaults].ToString() : null;
                                    DataCountInfo.Defaults = (reader[Defaults] != Convert.DBNull) ?
                                    reader[Defaults].ToString() : null; DataCountInfo.Collections =
                                    (reader[Collections] != Convert.DBNull) ? reader[Collections].ToString() : null;
                                    DataCountInfo.Directors = (reader[Directors] != Convert.DBNull) ?
                                    reader[Directors].ToString() : null; DataCountInfo.Addresses = (reader[Addresses]
                                    != Convert.DBNull) ? reader[Addresses].ToString() : null; DataCountInfo.Telephones =
                                    (reader[Telephones] != Convert.DBNull) ? reader[Telephones].ToString() : null;
                                    DataCountInfo.Occupants = (reader[Occupants] != Convert.DBNull) ?
                                    reader[Occupants].ToString() : null; DataCountInfo.Employers = (reader[Employers]
                                    != Convert.DBNull) ? reader[Employers].ToString() : null; DataCountInfo.TraceAlerts
                                    = (reader[TraceAlerts] != Convert.DBNull) ? reader[TraceAlerts].ToString() : null;
                                    DataCountInfo.PaymentProfiles = (reader[PaymentProfiles] != Convert.DBNull) ?
                                    reader[PaymentProfiles].ToString() : null; DataCountInfo.OwnEnquiries =
                                    (reader[OwnEnquiries] != Convert.DBNull) ? reader[OwnEnquiries].ToString() : null;
                                    DataCountInfo.AdminOrders = (reader[AdminOrders] != Convert.DBNull) ?
                                    reader[AdminOrders].ToString() : null; DataCountInfo.PossibleMatches =
                                    (reader[PossibleMatches] != Convert.DBNull) ? reader[PossibleMatches].ToString() :
                                    null; DataCountInfo.DefiniteMatches = (reader[DefiniteMatches] != Convert.DBNull) ?
                                    reader[DefiniteMatches].ToString() : null; DataCountInfo.Loans = (reader[Loans] !=
                                    Convert.DBNull) ? reader[Loans].ToString() : null; DataCountInfo.FraudAlerts =
                                    (reader[FraudAlerts] != Convert.DBNull) ? reader[FraudAlerts].ToString() : null;
                                    DataCountInfo.Companies = (reader[Companies] != Convert.DBNull) ?
                                    reader[Companies].ToString() : null; DataCountInfo.Properties = (reader[Properties]
                                    != Convert.DBNull) ? reader[Properties].ToString() : null; DataCountInfo.Documents =
                                    (reader[Documents] != Convert.DBNull) ? reader[Documents].ToString() : null;
                                    DataCountInfo.DemandLetters = (reader[DemandLetters] != Convert.DBNull) ?
                                    reader[DemandLetters].ToString() : null; DataCountInfo.Trusts = (reader[Trusts] !=
                                    Convert.DBNull) ? reader[Trusts].ToString() : null; DataCountInfo.Bonds =
                                    (reader[Bonds] != Convert.DBNull) ? reader[Bonds].ToString() : null;
                                    DataCountInfo.Deeds = (reader[Deeds] != Convert.DBNull) ? reader[Deeds].ToString()
                                    : null; DataCountInfo.PublicDefaults = (reader[PublicDefaults] != Convert.DBNull) ?
                                    reader[PublicDefaults].ToString() : null; DataCountInfo.NLRAccounts =
                                    (reader[NLRAccounts] != Convert.DBNull) ? reader[NLRAccounts].ToString() : null;

                                    dataCountsList.Add(DataCountInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["dataCountsList"] = dataCountsList;
                            ViewData["dataCountsListCount"] = dataCountsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End DataCOunts info ***********//
                    //************************************************* Start ConsumerStatisticsInformation ***********//
                    string query_uid_consumerStatistics = $"SELECT * FROM consumerstatistics as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_consumerStatistics, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //ConsumerStatisticsInformation
                                ConsumerStatistics ConsumerStatsInfo = new ConsumerStatistics();

                                int HighestJudgment = reader.GetOrdinal("HighestJudgment");
                                int RevolvingAccounts = reader.GetOrdinal("RevolvingAccounts");
                                int InstalmentAccounts = reader.GetOrdinal("InstalmentAccounts");
                                int AdverseAccounts = reader.GetOrdinal("AdverseAccounts");

                                while (reader.Read())
                                {
                                    ConsumerStatsInfo.HighestJudgment = (reader[HighestJudgment] != Convert.DBNull) ?
                                    reader[HighestJudgment].ToString() : null;

                                    ConsumerStatsInfo.RevolvingAccounts =
                                    (reader[RevolvingAccounts] != Convert.DBNull) ?
                                    reader[RevolvingAccounts].ToString() : null;

                                    ConsumerStatsInfo.InstalmentAccounts =
                                    (reader[InstalmentAccounts] != Convert.DBNull) ?
                                    reader[InstalmentAccounts].ToString() : null;

                                    ConsumerStatsInfo.AdverseAccounts = (reader[AdverseAccounts] != Convert.DBNull) ?
                                    reader[AdverseAccounts].ToString() : null;

                                    consumerstatsList.Add(ConsumerStatsInfo);
                                }
                            }
                            //add list to the viewbagviewdata
                            ViewData["consumerstatsList"] = consumerstatsList;
                            ViewData["consumerstatsListCount"] = consumerstatsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End ConsumerStatisticsInformation ***********//
                    //************************************************* Start nlrstatsInformation ***********//
                    string query_uid_nlrstats = $"SELECT * FROM nlrstats as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlrstats, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLRStatsInformation
                                NLRStats NLRStatsInfo = new NLRStats();

                                int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                                int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                                int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                                int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                                int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");

                                while (reader.Read())
                                {
                                    NLRStatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;
                                    NLRStatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                    NLRStatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                    NLRStatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                    NLRStatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                    nlrstatsList.Add(NLRStatsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlrstatsList"] = nlrstatsList;
                            ViewData["nlrstatsListCount"] = nlrstatsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlrstatsInformation ***********//
                    //************************************************* Start nlr12monthsInformation ***********//
                    string query_uid_nlr12months = $"SELECT * FROM nlr12months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlr12months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLR12monthsInformation
                                NLR12months nlr12monthsInfo = new NLR12months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    nlr12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    nlr12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    nlr12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    nlr12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    nlr12monthsList.Add(nlr12monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlr12monthsList"] = nlr12monthsList;
                            ViewData["nlr12monthsListCount"] = nlr12monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlr12monthsInformation ***********//
                    //************************************************* Start nlr24monthsInformation ***********//
                    string query_uid_nlr24months = $"SELECT * FROM nlr24months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlr24months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLR24monthsInformation
                                NLR24months nlr24monthsInfo = new NLR24months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    nlr24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    nlr24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    nlr24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    nlr24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    nlr24monthsList.Add(nlr24monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlr24monthsList"] = nlr24monthsList;
                            ViewData["nlr24monthsListCount"] = nlr24monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlr24monthsInformation ***********//
                    //************************************************* Start nlr36monthsInformation ***********//
                    string query_uid_nlr36months = $"SELECT * FROM nlr36months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlr36months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLR36monthsInformation
                                NLR36months nlr36monthsInfo = new NLR36months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    nlr36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    nlr36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    nlr36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    nlr36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    nlr36monthsList.Add(nlr36monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlr36monthsList"] = nlr36monthsList;
                            ViewData["nlr36monthsListCount"] = nlr36monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlr36monthsInformation ***********//
                    //************************************************* Start ccastatsInformation ***********//
                    string query_uid_ccastats = $"SELECT * FROM ccastats as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_ccastats, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCAStatsInformation
                                CCAStats ccastatsInfo = new CCAStats();

                                int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                                int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                                int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                                int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                                int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");

                                while (reader.Read())
                                {
                                    ccastatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;
                                    ccastatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                    ccastatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                    ccastatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                    ccastatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                    ccastatsList.Add(ccastatsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["ccastatsList"] = ccastatsList;
                            ViewData["ccastatsListCount"] = ccastatsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End ccastatsInformation ***********//
                    //************************************************* Start cca12monthsInformation ***********//
                    string query_uid_cca12months = $"SELECT * FROM cca12months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_cca12months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCA12monthsInformation
                                CCA12months cca12monthsInfo = new CCA12months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    cca12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    cca12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    cca12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    cca12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    cca12monthsList.Add(cca12monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["cca12monthsList"] = cca12monthsList;
                            ViewData["cca12monthsListCount"] = cca12monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* Start cca24monthsInformation ***********//
                    string query_uid_cca24months = $"SELECT * FROM cca24months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_cca24months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCA24monthsInformation
                                CCA24months cca24monthsInfo = new CCA24months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    cca24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    cca24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    cca24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    cca24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    cca24monthsList.Add(cca24monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["cca24monthsList"] = cca24monthsList;
                            ViewData["cca24monthsListCount"] = cca24monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End cca24monthsInformation ***********//
                    //************************************************* Start cca36monthsInformation ***********//
                    string query_uid_cca36months = $"SELECT * FROM cca36months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_cca36months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCA36monthsInformation
                                CCA36months cca36monthsInfo = new CCA36months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    cca36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    cca36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    cca36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    cca36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    cca36monthsList.Add(cca36monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["cca36monthsList"] = cca36monthsList;
                            ViewData["cca36monthsListCount"] = cca36monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End cca36monthsInformation ***********//
                    //************************************************* Start AddressHistoryInformation ***********//
                    string query_uid_AddressHistoryInfo = $"SELECT * FROM addresshistory as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_AddressHistoryInfo, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //addresshistoryInformation
                                AddressHistory AddressInfo = new AddressHistory();

                                int TypeDescription = reader.GetOrdinal("TypeDescription");
                                int Line1 = reader.GetOrdinal("Line1");
                                int Line2 = reader.GetOrdinal("Line2");
                                int Line3 = reader.GetOrdinal("Line3");
                                int PostalCode = reader.GetOrdinal("PostalCode");
                                int FullAddress = reader.GetOrdinal("FullAddress");
                                int AddressLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");
                                while (reader.Read())
                                {
                                    AddressInfo.TypeDescription = (reader[TypeDescription] != Convert.DBNull) ? reader[TypeDescription].ToString() : null;
                                    AddressInfo.Line1 = (reader[Line1] != Convert.DBNull) ? reader[Line1].ToString() : null;
                                    AddressInfo.Line2 = (reader[Line2] != Convert.DBNull) ? reader[Line2].ToString() : null;
                                    AddressInfo.Line3 = (reader[Line3] != Convert.DBNull) ? reader[Line3].ToString() : null;
                                    AddressInfo.PostalCode = (reader[PostalCode] != Convert.DBNull) ? reader[PostalCode].ToString() : null;
                                    AddressInfo.FullAddress = (reader[FullAddress] != Convert.DBNull) ? reader[FullAddress].ToString() : null;
                                    AddressInfo.LastUpdatedDate = (reader[AddressLastUpdatedDate] != Convert.DBNull) ? reader[AddressLastUpdatedDate].ToString() : null;

                                    addressInformationList.Add(AddressInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["addressInformationList"] = addressInformationList;
                            ViewData["addressInformationListCount"] = addressInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End AddressHistoryInformation ***********//

                    //************************************************* Start TelephonehistoryInformation ***********//
                    string query_uid_TelephoneHistoryInfo = $"SELECT * FROM telephonehistory as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_TelephoneHistoryInfo, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //TelephoneHistoryInformation
                                TelephoneHistory TelephoneInfo = new TelephoneHistory();

                                // //Telephone History
                                int TypeDescriptionTel = reader.GetOrdinal("TypeDescriptionTel");
                                int DialCode = reader.GetOrdinal("DialCode");
                                int Number = reader.GetOrdinal("Number");
                                int FullNumber = reader.GetOrdinal("FullNumber");
                                int LastUpdatedDateTel = reader.GetOrdinal("LastUpdatedDateTel");

                                while (reader.Read())
                                {
                                    TelephoneInfo.TypeDescriptionTel = (reader[TypeDescriptionTel] != Convert.DBNull) ? reader[TypeDescriptionTel].ToString() : null;
                                    TelephoneInfo.DialCode = (reader[DialCode] != Convert.DBNull) ? reader[DialCode].ToString() : null;
                                    TelephoneInfo.Number = (reader[Number] != Convert.DBNull) ? reader[Number].ToString() : null;
                                    TelephoneInfo.FullNumber = (reader[FullNumber] != Convert.DBNull) ? reader[FullNumber].ToString() : null;
                                    TelephoneInfo.LastUpdatedDateTel = (reader[LastUpdatedDateTel] != Convert.DBNull) ? reader[LastUpdatedDateTel].ToString() : null;

                                    telephoneInformationList.Add(TelephoneInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["telephoneInformationList"] = telephoneInformationList;
                            ViewData["telephoneInformationListCount"] = telephoneInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End TelephonehistoryInformation***********//

                    //************************************************* Start EmploymenthistoryInformation ***********//
                    string query_uid_EmploymentHistoryInfo = $"SELECT * FROM employmenthistory as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'CompuScanCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_EmploymentHistoryInfo, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //query_uid_EmploymentHistoryInformation
                                EmploymentHistory EmploymentInfo = new EmploymentHistory();

                                // EmploymentHistory
                                int EmployerName = reader.GetOrdinal("EmployerName");
                                int Designation = reader.GetOrdinal("Designation");
                                int EmployLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");

                                while (reader.Read())
                                {
                                    EmploymentInfo.EmployerName = (reader[EmployerName] != Convert.DBNull) ? reader[EmployerName].ToString() : null;
                                    EmploymentInfo.Designation = (reader[Designation] != Convert.DBNull) ? reader[Designation].ToString() : null;
                                    EmploymentInfo.LastUpdatedDate = (reader[EmployLastUpdatedDate] != Convert.DBNull) ? reader[EmployLastUpdatedDate].ToString() : null;

                                    employmentInformationList.Add(EmploymentInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["employmentInformationList"] = employmentInformationList;
                            ViewData["employmentInformationListCount"] = employmentInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End TelephonehistoryInformation***********//
                }
            }
            //ExperianCombinedCreditReport
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    //************************************************* Start personal info ***********//
                    string query_uid_personinformation = $"SELECT * FROM personinformation as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_personinformation, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                int DateOfBirth = reader.GetOrdinal("DateOfBirth");
                                int FirstName = reader.GetOrdinal("FirstName");
                                int Surname = reader.GetOrdinal("Surname");
                                int IDNumber = reader.GetOrdinal("IDNumber");
                                int Gender = reader.GetOrdinal("Gender");
                                int Age = reader.GetOrdinal("Age");
                                int MaritalStatus = reader.GetOrdinal("MaritalStatus");
                                int MiddleName1 = reader.GetOrdinal("MiddleName1");
                                int MiddleName2 = reader.GetOrdinal("MiddleName2");
                                int Reference = reader.GetOrdinal("Ref");

                                //PersonInformation
                                while (reader.Read())
                                {
                                    PersonInformation personInformation = new PersonInformation();
                                    personInformation.FirstName = (reader[FirstName] != Convert.DBNull) ? reader[FirstName].ToString() : null;
                                    personInformation.DateOfBirth = (reader[DateOfBirth] != Convert.DBNull) ? reader[DateOfBirth].ToString() : null;
                                    personInformation.Surname = (reader[Surname] != Convert.DBNull) ? reader[Surname].ToString() : null;
                                    personInformation.IDNumber = (reader[IDNumber] != Convert.DBNull) ? reader[IDNumber].ToString() : null;
                                    personInformation.Gender = (reader[Gender] != Convert.DBNull) ? reader[Gender].ToString() : null;
                                    personInformation.Age = (reader[Age] != Convert.DBNull) ? reader[Age].ToString() : null;
                                    personInformation.MaritalStatus = (reader[MaritalStatus] != Convert.DBNull) ? reader[MaritalStatus].ToString() : null;
                                    personInformation.MiddleName1 = (reader[MiddleName1] != Convert.DBNull) ? reader[MiddleName1].ToString() : null;
                                    personInformation.MiddleName2 = (reader[MiddleName2] != Convert.DBNull) ? reader[MiddleName2].ToString() : null;
                                    personInformation.Reference = (reader[Reference] != Convert.DBNull) ? reader[Reference].ToString() : null;

                                    //add to the list
                                    personInfoList.Add(personInformation);
                                }
                            }
                            ViewData["PersonInfoList"] = personInfoList;
                            ViewData["PersonInfoListCount"] = personInfoList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //*************************************************END personal info ***********//
                    //************************************************* Start CreditInformation info ***********//
                    string query_uid_creditinformation = $"SELECT * FROM creditinformation as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_creditinformation, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CreditInformation
                                CreditInformation CreditInfo = new CreditInformation();

                                int DelphiScore = reader.GetOrdinal("DelphiScore");
                                int FlagCount = reader.GetOrdinal("FlagCount");
                                int FlagDetails = reader.GetOrdinal("FlagDetails");

                                while (reader.Read())
                                {
                                    CreditInfo.DelphiScore = (reader[DelphiScore] != Convert.DBNull) ? reader[DelphiScore].ToString() : null;
                                    CreditInfo.FlagCount = (reader[FlagCount] != Convert.DBNull) ? reader[FlagCount].ToString() : null;
                                    CreditInfo.FlagDetails = (reader[FlagDetails] != Convert.DBNull) ? reader[FlagDetails].ToString() : null;

                                    //add to the list
                                    creditInformationList.Add(CreditInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["creditInformationList"] = creditInformationList;
                            ViewData["creditInformationListCount"] = creditInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End CreditInformation info ***********//
                    //************************************************* StartDataCOunts info ***********//
                    string query_uid_DataCOunts = $"SELECT * FROM datacounts as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_DataCOunts, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //DataCountsInformation
                                DataCounts DataCountInfo = new DataCounts();

                                int Accounts = reader.GetOrdinal("Accounts");
                                int Enquiries = reader.GetOrdinal("Enquiries");
                                //int Judgements = reader.GetOrdinal("Judgements");
                                int Notices = reader.GetOrdinal("Notices");
                                int BankDefaults = reader.GetOrdinal("BankDefaults");
                                int Defaults = reader.GetOrdinal("Defaults");
                                int Collections = reader.GetOrdinal("Collections");
                                int Directors = reader.GetOrdinal("Directors");
                                int Addresses = reader.GetOrdinal("Addresses");
                                int Telephones = reader.GetOrdinal("Telephones");
                                int Occupants = reader.GetOrdinal("Occupants");
                                int Employers = reader.GetOrdinal("Employers");
                                int TraceAlerts = reader.GetOrdinal("TraceAlerts");
                                int PaymentProfiles = reader.GetOrdinal("PaymentProfiles");
                                int OwnEnquiries = reader.GetOrdinal("OwnEnquiries");
                                int AdminOrders = reader.GetOrdinal("AdminOrders");
                                int PossibleMatches = reader.GetOrdinal("PossibleMatches");
                                int DefiniteMatches = reader.GetOrdinal("DefiniteMatches");
                                int Loans = reader.GetOrdinal("Loans");
                                int FraudAlerts = reader.GetOrdinal("FraudAlerts");
                                int Companies = reader.GetOrdinal("Companies");
                                int Properties = reader.GetOrdinal("Properties");
                                int Documents = reader.GetOrdinal("Documents");
                                int DemandLetters = reader.GetOrdinal("DemandLetters");
                                int Trusts = reader.GetOrdinal("Trusts");
                                int Bonds = reader.GetOrdinal("Bonds");
                                int Deeds = reader.GetOrdinal("Deeds");
                                int PublicDefaults = reader.GetOrdinal("PublicDefaults");
                                int NLRAccounts = reader.GetOrdinal("NLRAccounts");
                                while (reader.Read())
                                {
                                    DataCountInfo.Accounts = (reader[Accounts] != Convert.DBNull) ? reader[Accounts].ToString() : null;
                                    DataCountInfo.Enquires = (reader[Enquiries] != Convert.DBNull) ? reader[Enquiries].ToString() : null;
                                    //DataCountInfo.Judgements = (reader[Judgements] != Convert.DBNull) ? reader[Judgements].ToString() : null;
                                    DataCountInfo.Notices = (reader[Notices] != Convert.DBNull) ?
                                    reader[Notices].ToString() : null; DataCountInfo.BankDefaults =
                                    (reader[BankDefaults] != Convert.DBNull) ? reader[BankDefaults].ToString() : null;
                                    DataCountInfo.Defaults = (reader[Defaults] != Convert.DBNull) ?
                                    reader[Defaults].ToString() : null; DataCountInfo.Collections =
                                    (reader[Collections] != Convert.DBNull) ? reader[Collections].ToString() : null;
                                    DataCountInfo.Directors = (reader[Directors] != Convert.DBNull) ?
                                    reader[Directors].ToString() : null; DataCountInfo.Addresses = (reader[Addresses]
                                    != Convert.DBNull) ? reader[Addresses].ToString() : null; DataCountInfo.Telephones =
                                    (reader[Telephones] != Convert.DBNull) ? reader[Telephones].ToString() : null;
                                    DataCountInfo.Occupants = (reader[Occupants] != Convert.DBNull) ?
                                    reader[Occupants].ToString() : null; DataCountInfo.Employers = (reader[Employers]
                                    != Convert.DBNull) ? reader[Employers].ToString() : null; DataCountInfo.TraceAlerts
                                    = (reader[TraceAlerts] != Convert.DBNull) ? reader[TraceAlerts].ToString() : null;
                                    DataCountInfo.PaymentProfiles = (reader[PaymentProfiles] != Convert.DBNull) ?
                                    reader[PaymentProfiles].ToString() : null; DataCountInfo.OwnEnquiries =
                                    (reader[OwnEnquiries] != Convert.DBNull) ? reader[OwnEnquiries].ToString() : null;
                                    DataCountInfo.AdminOrders = (reader[AdminOrders] != Convert.DBNull) ?
                                    reader[AdminOrders].ToString() : null; DataCountInfo.PossibleMatches =
                                    (reader[PossibleMatches] != Convert.DBNull) ? reader[PossibleMatches].ToString() :
                                    null; DataCountInfo.DefiniteMatches = (reader[DefiniteMatches] != Convert.DBNull) ?
                                    reader[DefiniteMatches].ToString() : null; DataCountInfo.Loans = (reader[Loans] !=
                                    Convert.DBNull) ? reader[Loans].ToString() : null; DataCountInfo.FraudAlerts =
                                    (reader[FraudAlerts] != Convert.DBNull) ? reader[FraudAlerts].ToString() : null;
                                    DataCountInfo.Companies = (reader[Companies] != Convert.DBNull) ?
                                    reader[Companies].ToString() : null; DataCountInfo.Properties = (reader[Properties]
                                    != Convert.DBNull) ? reader[Properties].ToString() : null; DataCountInfo.Documents =
                                    (reader[Documents] != Convert.DBNull) ? reader[Documents].ToString() : null;
                                    DataCountInfo.DemandLetters = (reader[DemandLetters] != Convert.DBNull) ?
                                    reader[DemandLetters].ToString() : null; DataCountInfo.Trusts = (reader[Trusts] !=
                                    Convert.DBNull) ? reader[Trusts].ToString() : null; DataCountInfo.Bonds =
                                    (reader[Bonds] != Convert.DBNull) ? reader[Bonds].ToString() : null;
                                    DataCountInfo.Deeds = (reader[Deeds] != Convert.DBNull) ? reader[Deeds].ToString()
                                    : null; DataCountInfo.PublicDefaults = (reader[PublicDefaults] != Convert.DBNull) ?
                                    reader[PublicDefaults].ToString() : null; DataCountInfo.NLRAccounts =
                                    (reader[NLRAccounts] != Convert.DBNull) ? reader[NLRAccounts].ToString() : null;

                                    dataCountsList.Add(DataCountInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["dataCountsList"] = dataCountsList;
                            ViewData["dataCountsListCount"] = dataCountsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End DataCOunts info ***********//
                    //************************************************* Start ConsumerStatisticsInformation ***********//
                    string query_uid_consumerStatistics = $"SELECT * FROM consumerstatistics as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_consumerStatistics, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //ConsumerStatisticsInformation
                                ConsumerStatistics ConsumerStatsInfo = new ConsumerStatistics();

                                int HighestJudgment = reader.GetOrdinal("HighestJudgment");
                                int RevolvingAccounts = reader.GetOrdinal("RevolvingAccounts");
                                int InstalmentAccounts = reader.GetOrdinal("InstalmentAccounts");
                                int AdverseAccounts = reader.GetOrdinal("AdverseAccounts");

                                while (reader.Read())
                                {
                                    ConsumerStatsInfo.HighestJudgment = (reader[HighestJudgment] != Convert.DBNull) ?
                                    reader[HighestJudgment].ToString() : null;

                                    ConsumerStatsInfo.RevolvingAccounts =
                                    (reader[RevolvingAccounts] != Convert.DBNull) ?
                                    reader[RevolvingAccounts].ToString() : null;

                                    ConsumerStatsInfo.InstalmentAccounts =
                                    (reader[InstalmentAccounts] != Convert.DBNull) ?
                                    reader[InstalmentAccounts].ToString() : null;

                                    ConsumerStatsInfo.AdverseAccounts = (reader[AdverseAccounts] != Convert.DBNull) ?
                                    reader[AdverseAccounts].ToString() : null;

                                    consumerstatsList.Add(ConsumerStatsInfo);
                                }
                            }
                            //add list to the viewbagviewdata
                            ViewData["consumerstatsList"] = consumerstatsList;
                            ViewData["consumerstatsListCount"] = consumerstatsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End ConsumerStatisticsInformation ***********//
                    //************************************************* Start nlrstatsInformation ***********//
                    string query_uid_nlrstats = $"SELECT * FROM nlrstats as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlrstats, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLRStatsInformation
                                NLRStats NLRStatsInfo = new NLRStats();

                                int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                                int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                                int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                                int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                                int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");

                                while (reader.Read())
                                {
                                    NLRStatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;
                                    NLRStatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                    NLRStatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                    NLRStatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                    NLRStatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                    nlrstatsList.Add(NLRStatsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlrstatsList"] = nlrstatsList;
                            ViewData["nlrstatsListCount"] = nlrstatsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlrstatsInformation ***********//
                    //************************************************* Start nlr12monthsInformation ***********//
                    string query_uid_nlr12months = $"SELECT * FROM nlr12months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlr12months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLR12monthsInformation
                                NLR12months nlr12monthsInfo = new NLR12months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    nlr12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    nlr12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    nlr12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    nlr12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    nlr12monthsList.Add(nlr12monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlr12monthsList"] = nlr12monthsList;
                            ViewData["nlr12monthsListCount"] = nlr12monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlr12monthsInformation ***********//
                    //************************************************* Start nlr24monthsInformation ***********//
                    string query_uid_nlr24months = $"SELECT * FROM nlr24months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlr24months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLR24monthsInformation
                                NLR24months nlr24monthsInfo = new NLR24months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    nlr24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    nlr24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    nlr24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    nlr24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    nlr24monthsList.Add(nlr24monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlr24monthsList"] = nlr24monthsList;
                            ViewData["nlr24monthsListCount"] = nlr24monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlr24monthsInformation ***********//
                    //************************************************* Start nlr36monthsInformation ***********//
                    string query_uid_nlr36months = $"SELECT * FROM nlr36months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_nlr36months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //NLR36monthsInformation
                                NLR36months nlr36monthsInfo = new NLR36months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    nlr36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    nlr36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    nlr36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    nlr36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    nlr36monthsList.Add(nlr36monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["nlr36monthsList"] = nlr36monthsList;
                            ViewData["nlr36monthsListCount"] = nlr36monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End nlr36monthsInformation ***********//
                    //************************************************* Start ccastatsInformation ***********//
                    string query_uid_ccastats = $"SELECT * FROM ccastats as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_ccastats, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCAStatsInformation
                                CCAStats ccastatsInfo = new CCAStats();

                                int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                                int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                                int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                                int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                                int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");

                                while (reader.Read())
                                {
                                    ccastatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;
                                    ccastatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                    ccastatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                    ccastatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                    ccastatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                    ccastatsList.Add(ccastatsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["ccastatsList"] = ccastatsList;
                            ViewData["ccastatsListCount"] = ccastatsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End ccastatsInformation ***********//
                    //************************************************* Start cca12monthsInformation ***********//
                    string query_uid_cca12months = $"SELECT * FROM cca12months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_cca12months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCA12monthsInformation
                                CCA12months cca12monthsInfo = new CCA12months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    cca12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    cca12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    cca12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    cca12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    cca12monthsList.Add(cca12monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["cca12monthsList"] = cca12monthsList;
                            ViewData["cca12monthsListCount"] = cca12monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* Start cca24monthsInformation ***********//
                    string query_uid_cca24months = $"SELECT * FROM cca24months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_cca24months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCA24monthsInformation
                                CCA24months cca24monthsInfo = new CCA24months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    cca24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    cca24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    cca24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    cca24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    cca24monthsList.Add(cca24monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["cca24monthsList"] = cca24monthsList;
                            ViewData["cca24monthsListCount"] = cca24monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End cca24monthsInformation ***********//
                    //************************************************* Start cca36monthsInformation ***********//
                    string query_uid_cca36months = $"SELECT * FROM cca36months as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_cca36months, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //CCA36monthsInformation
                                CCA36months cca36monthsInfo = new CCA36months();

                                int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                                int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                                int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                                int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                                while (reader.Read())
                                {
                                    cca36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                    cca36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                    cca36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                    cca36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                    cca36monthsList.Add(cca36monthsInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["cca36monthsList"] = cca36monthsList;
                            ViewData["cca36monthsListCount"] = cca36monthsList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End cca36monthsInformation ***********//
                    //************************************************* Start AddressHistoryInformation ***********//
                    string query_uid_AddressHistoryInfo = $"SELECT * FROM addresshistory as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_AddressHistoryInfo, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //addresshistoryInformation
                                AddressHistory AddressInfo = new AddressHistory();

                                int TypeDescription = reader.GetOrdinal("TypeDescription");
                                int Line1 = reader.GetOrdinal("Line1");
                                int Line2 = reader.GetOrdinal("Line2");
                                int Line3 = reader.GetOrdinal("Line3");
                                int PostalCode = reader.GetOrdinal("PostalCode");
                                int FullAddress = reader.GetOrdinal("FullAddress");
                                int AddressLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");
                                while (reader.Read())
                                {
                                    AddressInfo.TypeDescription = (reader[TypeDescription] != Convert.DBNull) ? reader[TypeDescription].ToString() : null;
                                    AddressInfo.Line1 = (reader[Line1] != Convert.DBNull) ? reader[Line1].ToString() : null;
                                    AddressInfo.Line2 = (reader[Line2] != Convert.DBNull) ? reader[Line2].ToString() : null;
                                    AddressInfo.Line3 = (reader[Line3] != Convert.DBNull) ? reader[Line3].ToString() : null;
                                    AddressInfo.PostalCode = (reader[PostalCode] != Convert.DBNull) ? reader[PostalCode].ToString() : null;
                                    AddressInfo.FullAddress = (reader[FullAddress] != Convert.DBNull) ? reader[FullAddress].ToString() : null;
                                    AddressInfo.LastUpdatedDate = (reader[AddressLastUpdatedDate] != Convert.DBNull) ? reader[AddressLastUpdatedDate].ToString() : null;

                                    addressInformationList.Add(AddressInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["addressInformationList"] = addressInformationList;
                            ViewData["addressInformationListCount"] = addressInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End AddressHistoryInformation ***********//

                    //************************************************* Start TelephonehistoryInformation ***********//
                    string query_uid_TelephoneHistoryInfo = $"SELECT * FROM telephonehistory as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_TelephoneHistoryInfo, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //TelephoneHistoryInformation
                                TelephoneHistory TelephoneInfo = new TelephoneHistory();

                                // //Telephone History
                                int TypeDescriptionTel = reader.GetOrdinal("TypeDescriptionTel");
                                int DialCode = reader.GetOrdinal("DialCode");
                                int Number = reader.GetOrdinal("Number");
                                int FullNumber = reader.GetOrdinal("FullNumber");
                                int LastUpdatedDateTel = reader.GetOrdinal("LastUpdatedDateTel");

                                while (reader.Read())
                                {
                                    TelephoneInfo.TypeDescriptionTel = (reader[TypeDescriptionTel] != Convert.DBNull) ? reader[TypeDescriptionTel].ToString() : null;
                                    TelephoneInfo.DialCode = (reader[DialCode] != Convert.DBNull) ? reader[DialCode].ToString() : null;
                                    TelephoneInfo.Number = (reader[Number] != Convert.DBNull) ? reader[Number].ToString() : null;
                                    TelephoneInfo.FullNumber = (reader[FullNumber] != Convert.DBNull) ? reader[FullNumber].ToString() : null;
                                    TelephoneInfo.LastUpdatedDateTel = (reader[LastUpdatedDateTel] != Convert.DBNull) ? reader[LastUpdatedDateTel].ToString() : null;

                                    telephoneInformationList.Add(TelephoneInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["telephoneInformationList"] = telephoneInformationList;
                            ViewData["telephoneInformationListCount"] = telephoneInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End TelephonehistoryInformation***********//

                    //************************************************* Start EmploymenthistoryInformation ***********//
                    string query_uid_EmploymentHistoryInfo = $"SELECT * FROM employmenthistory as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'ExperianCombinedCreditReport'";
                    using (var cmd = new MySqlCommand(query_uid_EmploymentHistoryInfo, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //query_uid_EmploymentHistoryInformation
                                EmploymentHistory EmploymentInfo = new EmploymentHistory();

                                // EmploymentHistory
                                int EmployerName = reader.GetOrdinal("EmployerName");
                                int Designation = reader.GetOrdinal("Designation");
                                int EmployLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");

                                while (reader.Read())
                                {
                                    EmploymentInfo.EmployerName = (reader[EmployerName] != Convert.DBNull) ? reader[EmployerName].ToString() : null;
                                    EmploymentInfo.Designation = (reader[Designation] != Convert.DBNull) ? reader[Designation].ToString() : null;
                                    EmploymentInfo.LastUpdatedDate = (reader[EmployLastUpdatedDate] != Convert.DBNull) ? reader[EmployLastUpdatedDate].ToString() : null;

                                    employmentInformationList.Add(EmploymentInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["employmentInformationList"] = employmentInformationList;
                            ViewData["employmentInformationListCount"] = employmentInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End TelephonehistoryInformation***********//
                }
            }
            //XDSCombinedCreditReport
            {
                using (var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString))
                {
                    conn.Open();
                    //************************************************* Start personal info ***********//
                    string query_uid_personinformation = $"SELECT * FROM personinformation as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'XDSCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_personinformation, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                int PersonID = reader.GetOrdinal("PersonID");
                                int Title = reader.GetOrdinal("Title");
                                int DateOfBirth = reader.GetOrdinal("DateOfBirth");
                                int Initials = reader.GetOrdinal("Initials");
                                int Fullname = reader.GetOrdinal("Fullname");
                                int IDNumber = reader.GetOrdinal("IDNumber");
                                int MaritalStatus = reader.GetOrdinal("MaritalStatus");
                                int Gender = reader.GetOrdinal("Gender");
                                int MiddleName1 = reader.GetOrdinal("MiddleName1");

                                //PersonInformation
                                while (reader.Read())
                                {
                                    PersonInformation personInformation = new PersonInformation();

                                    personInformation.PersonID = (reader[PersonID] != Convert.DBNull) ? reader[PersonID].ToString() : null;
                                    personInformation.Title = (reader[Title] != Convert.DBNull) ? reader[Title].ToString() : null;
                                    personInformation.DateOfBirth = (reader[DateOfBirth] != Convert.DBNull) ? reader[DateOfBirth].ToString() : null;
                                    personInformation.Initials = (reader[Initials] != Convert.DBNull) ? reader[Initials].ToString() : null;
                                    personInformation.IDNumber = (reader[IDNumber] != Convert.DBNull) ? reader[IDNumber].ToString() : null;
                                    personInformation.Gender = (reader[Gender] != Convert.DBNull) ? reader[Gender].ToString() : null;
                                    //add to the list
                                    personInfoList.Add(personInformation);
                                }
                            }
                            ViewData["PersonInfoList"] = personInfoList;
                            ViewData["PersonInfoListCount"] = personInfoList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //*************************************************END personal info ***********//
                    //************************************************* Start homeaffairsinformation info ***********//
                    string query_uid_homeaffairsinformation = $"SELECT * FROM homeaffairsinformation as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'XDSCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_homeaffairsinformation, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //HomeAffairsInformation
                                HomeAffairsInformation homeAffairsInformation = new HomeAffairsInformation();
                                int DeceasedStatus = reader.GetOrdinal("DeceasedStatus");
                                int DeceasedDate = reader.GetOrdinal("DeceasedDate");
                                int VerifiedStatus = reader.GetOrdinal("VerifiedStatus");

                                while (reader.Read())
                                {
                                    homeAffairsInformation.DeceasedDate = (reader[DeceasedDate] != Convert.DBNull) ? reader[DeceasedDate].ToString() : null;
                                    homeAffairsInformation.DeceasedStatus = (reader[DeceasedStatus] != Convert.DBNull) ? reader[DeceasedStatus].ToString() : null;
                                    homeAffairsInformation.VerifiedStatus = (reader[VerifiedStatus] != Convert.DBNull) ? reader[VerifiedStatus].ToString() : null;

                                    //add to the list
                                    homeAffairsInformationList.Add(homeAffairsInformation);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["HomeAffairsInfoList"] = homeAffairsInformationList;
                            ViewData["HomeAffairsInfoListCount"] = homeAffairsInformationList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* END homeaffairsinformation info ***********//
                    //************************************************* Start fraudindicatorsummary info ***********//
                    string query_uid_fraudSummaryinformation = $"SELECT * FROM fraudindicatorsummary as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'XDSCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_fraudSummaryinformation, conn))
                    {
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                int SAFPSListing = reader.GetOrdinal("SAFPSListing");
                                int EmployerFraudVerification = reader.GetOrdinal("EmployerFraudVerification");
                                int ProtectiveVerification = reader.GetOrdinal("ProtectiveVerification");

                                while (reader.Read())
                                {
                                    FraudIndicatorSummary FraudIndicatorInfo = new FraudIndicatorSummary();

                                    FraudIndicatorInfo.SAFPSListing = (reader[SAFPSListing] != Convert.DBNull) ? reader[SAFPSListing].ToString() : null;
                                    FraudIndicatorInfo.EmployerFraudVerification = (reader[EmployerFraudVerification] != Convert.DBNull) ? reader[EmployerFraudVerification].ToString() : null;
                                    FraudIndicatorInfo.ProtectiveVerification = (reader[ProtectiveVerification] != Convert.DBNull) ? reader[ProtectiveVerification].ToString() : null;

                                    fraudIndicatorSummaryList.Add(FraudIndicatorInfo);
                                }
                            }
                            //add list to the viewbagviewdata
                            ViewData["fraudIndicatorSummaryList"] = fraudIndicatorSummaryList;
                            ViewData["fraudIndicatorSummaryList"] = fraudIndicatorSummaryList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    }
                    //************************************************* END fraudindicatorsummary info ***********//
                    //************************************************* Start DirectorShipInformation ***********//
                    string query_uid_DirectorShipInfo = $"SELECT * FROM directorships as a WHERE a.SearchToken = '{DbSearch.token}' AND a.typeOfSearch = 'XDSCombinedCreditReport' ";
                    using (var cmd = new MySqlCommand(query_uid_DirectorShipInfo, conn))
                        try
                        {
                            using (var reader = cmd.ExecuteReader())
                            {
                                //DirectorshipInformation
                                Directorship DirectorshipInfo = new Directorship();

                                // DirectorshipHistory
                                int DesignationCode = reader.GetOrdinal("DesignationCode");
                                int AppointmentDate = reader.GetOrdinal("AppointmentDate");
                                int DirectorStatus = reader.GetOrdinal("DirectorStatus");
                                int DirectorStatusDate = reader.GetOrdinal("DirectorStatusDate");
                                int CompanyName = reader.GetOrdinal("CompanyName");
                                int CompanyType = reader.GetOrdinal("CompanyType");
                                int CompanyStatus = reader.GetOrdinal("CompanyStatus");
                                int CompanyStatusCode = reader.GetOrdinal("CompanyStatusCode");
                                int CompanyRegistrationNumber = reader.GetOrdinal("CompanyRegistrationNumber");
                                int CompanyRegistrationDate = reader.GetOrdinal("CompanyRegistrationDate");
                                int CompanyStartDate = reader.GetOrdinal("CompanyStartDate");
                                int CompanyTaxNumber = reader.GetOrdinal("CompanyTaxNumber");
                                int DirectorTypeCode = reader.GetOrdinal("DirectorTypeCode");
                                int DirectorType = reader.GetOrdinal("DirectorType");
                                int MemberSize = reader.GetOrdinal("MemberSize");
                                int MemberContribution = reader.GetOrdinal("MemberContribution");
                                int MemberContributionType = reader.GetOrdinal("MemberContributionType");
                                int ResignationDate = reader.GetOrdinal("ResignationDate");

                                while (reader.Read())
                                {
                                    DirectorshipInfo.DesignationCode = (reader[DesignationCode] != Convert.DBNull) ? reader[DesignationCode].ToString() : null;
                                    DirectorshipInfo.AppointmentDate = (reader[AppointmentDate] != Convert.DBNull) ? reader[AppointmentDate].ToString() : null;
                                    DirectorshipInfo.DirectorStatus = (reader[DirectorStatus] != Convert.DBNull) ? reader[DirectorStatus].ToString() : null;
                                    DirectorshipInfo.DirectorStatusDate = (reader[DirectorStatusDate] != Convert.DBNull) ?
                                    reader[DirectorStatusDate].ToString() : null; DirectorshipInfo.CompanyName =
                                    (reader[CompanyName] != Convert.DBNull) ? reader[CompanyName].ToString() : null;
                                    DirectorshipInfo.CompanyType = (reader[CompanyType] != Convert.DBNull) ?
                                    reader[CompanyType].ToString() : null; DirectorshipInfo.CompanyStatus =
                                    (reader[CompanyStatus] != Convert.DBNull) ? reader[CompanyStatus].ToString() : null;
                                    DirectorshipInfo.CompanyStatusCode = (reader[CompanyStatusCode] != Convert.DBNull) ?
                                    reader[CompanyStatusCode].ToString() : null; DirectorshipInfo.CompanyRegistrationNumber
                                    = (reader[CompanyRegistrationNumber] != Convert.DBNull) ?
                                    reader[CompanyRegistrationNumber].ToString() : null;
                                    DirectorshipInfo.CompanyRegistrationDate = (reader[CompanyRegistrationDate] !=
                                    Convert.DBNull) ? reader[CompanyRegistrationDate].ToString() : null;
                                    DirectorshipInfo.CompanyStartDate = (reader[CompanyStartDate] != Convert.DBNull) ?
                                    reader[CompanyStartDate].ToString() : null; DirectorshipInfo.CompanyTaxNumber =
                                    (reader[CompanyTaxNumber] != Convert.DBNull) ? reader[CompanyTaxNumber].ToString() :
                                    null; DirectorshipInfo.DirectorTypeCode = (reader[DirectorTypeCode] != Convert.DBNull) ?
                                    reader[DirectorTypeCode].ToString() : null; DirectorshipInfo.DirectorType =
                                    (reader[DirectorType] != Convert.DBNull) ? reader[DirectorType].ToString() : null;
                                    DirectorshipInfo.MemberSize = (reader[MemberSize] != Convert.DBNull) ?
                                    reader[MemberSize].ToString() : null; DirectorshipInfo.MemberContribution =
                                    (reader[MemberContribution] != Convert.DBNull) ? reader[MemberContribution].ToString()
                                    : null; DirectorshipInfo.MemberContributionType = (reader[MemberContributionType] !=
                                    Convert.DBNull) ? reader[MemberContributionType].ToString() : null;
                                    DirectorshipInfo.ResignationDate = (reader[ResignationDate] != Convert.DBNull) ?
                                    reader[ResignationDate].ToString() : null;

                                    directorshipList.Add(DirectorshipInfo);
                                }
                            }

                            //add list to the viewbagviewdata
                            ViewData["directorshipList"] = directorshipList;
                            ViewData["directorshipListCount"] = directorshipList.Count;
                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err);
                        }
                    //************************************************* End DirectorShipInformation***********//
                }
            }
            return View();
        }

        public ActionResult CombinedConsumerTrace()
        {
            return View();
        }

        public ActionResult CombinedConsumerTraceResults(Search comp)
        {
            string id = comp.IDNumber != null ? comp.IDNumber.Trim() : null;
            string refe = comp.Reference != null ? comp.Reference.Trim() : null;

            ViewData["refe"] = id;

            try
            {
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
                var url = "https://uatrest.searchworks.co.za/credit/combinedreport/trace/";
                //var url = "https://uatuatrest.searchworks.co.za/credit/combinedreport/trace/";

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

                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;

                int CompuScanSearchID;
                string CompuScanSearchUserName;
                string CompuScanReportDate;
                string CompuScanResponseType;
                string CompuScanName;
                string CompuScanReference;
                string CompuScanSearchToken;
                string CompuScanCallerModule;
                string CompuScanDataSupplier;
                string CompuScanSearchType;
                string CompuScanSearchDescription;

                CompuScanSearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                CompuScanSearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                CompuScanReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                CompuScanResponseType = rootObject.ResponseMessage;
                CompuScanName = ViewData["user"].ToString();
                CompuScanReference = rootObject.ResponseObject.SearchInformation.Reference;
                CompuScanSearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                CompuScanCallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                CompuScanDataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                CompuScanSearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                CompuScanSearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(CompuScanSearchID, CompuScanSearchUserName, CompuScanResponseType, CompuScanName, CompuScanReportDate, CompuScanReference, CompuScanSearchToken, CompuScanCallerModule, CompuScanDataSupplier, CompuScanSearchType, CompuScanSearchDescription, "CompuScanCombinedConsumerTrace");

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
                    saveCompuScanSearchHistory(CSSearchID, CSSearchUserName, CSReportDate, CSReference, CSSearchToken, CSCallerModule, CSDataSupplier, CSSearchType, CSSearchDescription, "CompuScanCombinedConsumerTrace");

                    //PersonInformation
                    {
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
                        savePersonInformation(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.InformationDate,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.PersonID,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Title,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.DateOfBirth,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.FirstName,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Surname,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Fullname,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.IDNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.IDNumber_Alternate,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.PassportNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Reference,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.MaritalStatus,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Gender,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Age,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.MiddleName1,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.MiddleName2,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.SpouseFirstName,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.SpouseSurname,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.NumberOfDependants,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.Remarks,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.CurrentEmployer,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.VerificationStatus,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.PersonInformation.HasProperties, "CompuScanInfoCombinedConsumerTrace");
                    }
                    //Home Affairs Information
                    {
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
                        rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HomeAffairsInformation.VerifiedDate, "CompuScanCombinedConsumerTrace"
                        );
                        ViewData["CompuScanDeceasedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].DeceasedStatus;
                        ViewData["CompuScanDeceasedDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].DeceasedDate;
                        ViewData["CompuScanCauseOfDeath"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].CauseOfDeath;
                        ViewData["CompuScanVerifiedDate"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].VerifiedDate;
                        ViewData["CompuScanVerifiedStatus"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HomeAffairsInformation"].VerifiedStatus;
                    }

                    //Credit Information
                    JToken CreditInformationExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["CreditInformation"];

                    if (CreditInformationExists != null)
                    {
                        JToken FraudIndicatorSummaryExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["FraudIndicatorSummary"];
                        if (FraudIndicatorSummaryExists != null)
                        {
                            saveFraudIndicatorSummary(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.SAFPSListing,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.EmployerFraudVerification,
                                rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.ProtectiveVerification, "CompuScanCombinedConsumerTrace"
                                );
                            ViewData["CompuScanProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation.FraudIndicatorSummary.ProtectiveVerification;
                        }
                    }

                    //Historical Information
                    // Address
                    JToken AddressExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HistoricalInformation"].AddressHistory;
                    if (AddressExists != null)
                    {
                        List<AddressHistory> AddressHist;
                        AddressHist = new List<AddressHistory>();

                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                        elements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory;

                        for (int count = 0; count < (elements.Count); count++)
                        {
                            string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                            string Line1 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1;
                            string Line2 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2;
                            string Line3 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3;
                            string Line4 = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4;
                            string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                            AddressHist.Add(new AddressHistory
                            {
                                TypeDescription = TypeCode,
                                Line1 = Line1,
                                Line2 = Line2,
                                Line3 = Line3,
                                PostalCode = PostalCode,
                                FullAddress = null,
                                LastUpdatedDate = LastUpdatedDate,
                            });

                            saveAddressHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].AddressID,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line1,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line2,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line3,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].Line4,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, "CompuScanCombinedConsumerTrace"
                            );
                        }
                        ViewData["ArrayList"] = AddressHist;
                    }

                    // Telephone
                    JToken TelephoneExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HistoricalInformation"].TelephoneHistory;
                    if (TelephoneExists != null)
                    {
                        List<TelephoneHistory> TelHist;
                        TelHist = new List<TelephoneHistory>();
                        Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                        Telelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory;

                        for (int count = 0; count < (Telelements.Count); count++)
                        {
                            string TypeDescriptionTel = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                            string Number = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                            TelHist.Add(new TelephoneHistory
                            {
                                TypeDescriptionTel = TypeDescriptionTel,
                                DialCode = null,
                                Number = Number,
                                FullNumber = null,
                                LastUpdatedDateTel = LastUpdatedDate,
                            });
                            saveTelephoneHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].Number,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate
                            , "CompuScanCombinedConsumerTrace"
                            );
                        }
                        ViewData["TelArrayList"] = TelHist;
                    }

                    // Employment
                    JToken EmploymentExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo["HistoricalInformation"].EmploymentHistory;
                    if (EmploymentExists != null)
                    {
                        List<EmploymentHistory> EmpHist;
                        EmpHist = new List<EmploymentHistory>();
                        Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                        EMelements = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory;

                        for (int count = 0; count < (EMelements.Count); count++)
                        {
                            string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                            string Designation = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                            EmpHist.Add(new EmploymentHistory
                            {
                                EmployerName = EmployerName,
                                Designation = Designation,
                                LastUpdatedDate = LastUpdatedDate,
                            });

                            saveEmploymentHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                            rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "CompuScanCombinedConsumerTrace"
                            );
                        }
                        ViewData["EMArrayList"] = EmpHist;
                    }
                }
                else
                {
                    ViewData["CompuScanMessage"] = "NotFound";
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
                    saveTransUnionSearchHistory(TUSearchID, TUSearchUserName, TUReportDate, TUReference, TUSearchToken, TUCallerModule, TUDataSupplier, TUSearchType, TUSearchDescription, "TransUnionCombinedConsumerTrace");
                    //Personal Information
                    {
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
                        savePersonInformation(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.InformationDate,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.PersonID,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.Title,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.DateOfBirth,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.FirstName,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.Surname,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.Fullname,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.IDNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.IDNumber_Alternate,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.PassportNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.Reference,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.MaritalStatus,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.Gender,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.Age,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.MiddleName1,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.MiddleName2,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.SpouseFirstName,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.SpouseSurname,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.NumberOfDependants,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.Remarks,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.CurrentEmployer,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.VerificationStatus,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.PersonInformation.HasProperties, "TransUnionCombinedConsumerTrace");
                    }
                    //Contact Information
                    JToken ContactInformationExists = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"];
                    if (ContactInformationExists != null)
                    {
                        ViewData["TransUnionInfoEmailAddress"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].EmailAddress;
                        ViewData["TransUnionInfoMobileNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].MobileNumber;
                        ViewData["TransUnionInfoHomeTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].HomeTelephoneNumber;
                        ViewData["TransUnionInfoWorkTelephoneNumber"] = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].WorkTelephoneNumber;
                        saveContactInformation(SearchToken, Reference, SearchID,
                              rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].HomeTelephoneNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].MobileNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].HomeTelephoneNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].WorkTelephoneNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].PhysicalAddress,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["ContactInformation"].PostalAddress, "TransUnionCombinedConsumerTrace");
                    }

                    //Historical Information
                    // Address
                    JToken AddressExists = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["HistoricalInformation"].AddressHistory;
                    if (AddressExists != null)
                    {
                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                        elements = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory;
                        List<string> thatlist = new List<string>();
                        //Dictionary<string, string> arrayList = new Dictionary<string, string>();
                        List<AddressHistory> AddressHist;
                        AddressHist = new List<AddressHistory>();
                        for (int count = 0; count < (elements.Count); count++)
                        {
                            string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                            string Line1 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line1;
                            string Line2 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line2;
                            string Line3 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line3;
                            string Line4 = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line4;
                            string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                            string FullAddress = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].FullAddress;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                            AddressHist.Add(new AddressHistory
                            {
                                TypeDescription = TypeCode,
                                Line1 = Line1,
                                Line2 = Line2,
                                Line3 = Line3,
                                Line4 = Line4,
                                PostalCode = PostalCode,
                                FullAddress = FullAddress,
                                LastUpdatedDate = LastUpdatedDate,
                            });

                            saveAddressHistory(SearchToken, Reference, SearchID,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].AddressID,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line1,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line2,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line3,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].Line4,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                               rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, "TransUnionCombinedConsumerTrace"
                               );
                        }
                        ViewData["AddressHist"] = AddressHist;
                    }

                    // Telephone
                    JToken TelephoneExists = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["HistoricalInformation"].TelephoneHistory;
                    if (TelephoneExists != null)
                    {
                        Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                        Telelements = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory;

                        List<TelephoneHistory> TelHist;
                        TelHist = new List<TelephoneHistory>();

                        for (int count = 0; count < (Telelements.Count); count++)
                        {
                            string Type = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                            string Number = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].Number;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                            TelHist.Add(new TelephoneHistory
                            {
                                TypeDescriptionTel = Type,
                                Number = Number,
                                LastUpdatedDateTel = LastUpdatedDate,
                            });

                            saveTelephoneHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].Number,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "TransUnionCombinedConsumerTrace"

                            );
                        }
                        ViewData["TelHist"] = TelHist;
                    }

                    // Employment
                    JToken EmploymentExists = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo["HistoricalInformation"].EmploymentHistory;
                    if (EmploymentExists != null)
                    {
                        Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                        EMelements = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory;

                        List<EmploymentHistory> EmpHist;
                        EmpHist = new List<EmploymentHistory>();

                        for (int count = 0; count < (EMelements.Count); count++)
                        {
                            string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                            string Designation = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                            EmpHist.Add(new EmploymentHistory
                            {
                                EmployerName = EmployerName,
                                Designation = Designation,
                                LastUpdatedDate = LastUpdatedDate,
                            });

                            saveEmploymentHistory(SearchToken, Reference, SearchID,
                           rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                           rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                           rootObject.ResponseObject.CombinedCreditInformation.TransUnionInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "TransUnionCombinedConsumerTrace"
                           );
                        }
                        ViewData["EmpHist"] = EmpHist;
                    }
                }
                else
                {
                    ViewData["TransUnionMessage"] = "NotFound";
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
                    saveXDSSearchHistory(XDSSearchID, XDSSearchUserName, XDSReportDate, XDSReference, XDSSearchToken, XDSCallerModule, XDSDataSupplier, XDSSearchType, XDSSearchDescription, "XDSCombinedConsumerTrace");

                    //Personal Information
                    {
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
                        savePersonInformation(SearchToken, Reference, SearchID,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.InformationDate,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.PersonID,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Title,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.DateOfBirth,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.FirstName,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Surname,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Fullname,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.IDNumber,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.IDNumber_Alternate,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.PassportNumber,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Reference,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MaritalStatus,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Gender,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Age,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MiddleName1,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.MiddleName2,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.SpouseFirstName,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.SpouseSurname,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.NumberOfDependants,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.Remarks,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.CurrentEmployer,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.VerificationStatus,
                      rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.PersonInformation.HasProperties, "XDSInfoCombinedConsumerTrace");
                    }
                    //HomeAffairs
                    {
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
                            ViewData["XDSInfoVerifiedStatus"], "XDSCombinedConsumerTrace"
                            );
                    }
                    //Credit Information
                    JToken ContactInformationExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["ContactInformation"];
                    if (ContactInformationExists != null)
                    {
                        JToken FraudIndicatorSummaryExists = rootObject.ResponseObject.CombinedCreditInformation.CompuScanInfo.CreditInformation["FraudIndicatorSummary"];
                        if (FraudIndicatorSummaryExists != null)
                        {
                            ViewData["XDSInfoProtectiveVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].ProtectiveVerification;
                            ViewData["XDSInfoSAFPSListing"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].SAFPSListing;
                            ViewData["XDSInfoEmployerFraudVerification"] = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.CreditInformation["FraudIndicatorSummary"].EmployerFraudVerification;
                            saveFraudIndicatorSummary(SearchToken, Reference, SearchID,
                                ViewData["XDSInfoSAFPSListing"].ToString(),
                                ViewData["XDSInfoEmployerFraudVerification"].ToString(),
                                ViewData["XDSInfoProtectiveVerification"].ToString(), "XDSCombinedConsumerTrace");
                        }
                    }

                    // Address
                    JToken AddressExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HistoricalInformation"].AddressHistory;
                    if (AddressExists != null)
                    {
                        List<AddressHistory> AddressHist;
                        AddressHist = new List<AddressHistory>();

                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                        elements = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory;

                        for (int count = 0; count < (elements.Count); count++)
                        {
                            string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                            string Line1 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line1;
                            string Line2 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line2;
                            string Line3 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line3;
                            string Line4 = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line4;
                            string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                            AddressHist.Add(new AddressHistory
                            {
                                TypeDescription = TypeCode,
                                Line1 = Line1,
                                Line2 = Line2,
                                Line3 = Line3,
                                Line4 = Line4,
                                PostalCode = PostalCode,
                                FullAddress = null,
                                LastUpdatedDate = LastUpdatedDate,
                            });

                            saveAddressHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].AddressID,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line1,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line2,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line3,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].Line4,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, "XDSCombinedConsumerTrace"
                            );
                        }
                        ViewData["ArrayList"] = AddressHist;
                    }

                    // Telephone
                    JToken TelephoneExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HistoricalInformation"].TelephoneHistory;
                    if (TelephoneExists != null)
                    {
                        Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                        Telelements = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory;

                        List<TelephoneHistory> TelHist;
                        TelHist = new List<TelephoneHistory>();

                        for (int count = 0; count < (Telelements.Count); count++)
                        {
                            string Type = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                            string Number = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].Number;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                            TelHist.Add(new TelephoneHistory
                            {
                                TypeDescriptionTel = Type,
                                DialCode = null,
                                Number = Number,
                                FullNumber = null,
                                LastUpdatedDateTel = LastUpdatedDate,
                            });

                            saveTelephoneHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].Number,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "XDSCombinedConsumerTrace"
                            );
                        }
                        ViewData["TelArrayList"] = TelHist;
                    }

                    // Employment
                    JToken EmploymentExists = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo["HistoricalInformation"].EmploymentHistory;
                    if (EmploymentExists != null)
                    {
                        Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                        EMelements = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory;

                        List<EmploymentHistory> EmpHist;
                        EmpHist = new List<EmploymentHistory>();

                        for (int count = 0; count < (EMelements.Count); count++)
                        {
                            string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                            string Designation = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                            EmpHist.Add(new EmploymentHistory
                            {
                                EmployerName = EmployerName,
                                Designation = Designation,
                                LastUpdatedDate = LastUpdatedDate
                            });

                            saveEmploymentHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                            rootObject.ResponseObject.CombinedCreditInformation.XDSInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "XDSCombinedConsumerTrace"
                            );
                        }
                        ViewData["EMArrayList"] = EmpHist;
                    }
                }
                else
                {
                    ViewData["XDSMessage"] = "NotFound";
                }
                if (ViewData["VeriCredMessage"].ToString() == "Found")
                {
                    int VeriSearchID = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.SearchID;
                    string VeriSearchUserName = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.SearchUserName;
                    string VeriReportDate = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.ReportDate;
                    string VeriReference = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.Reference;
                    string VeriSearchToken = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.SearchToken;
                    string VeriCallerModule = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.CallerModule;
                    string VeriDataSupplier = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.DataSupplier;
                    string VeriSearchType = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.SearchType;
                    string VeriSearchDescription = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.SearchInformation.SearchDescription;
                    saveVeriCredSearchHistory(VeriSearchID,
                            VeriSearchUserName,
                            VeriReportDate,
                            VeriReference,
                            VeriSearchToken,
                            VeriCallerModule,
                            VeriDataSupplier,
                            VeriSearchType,
                            VeriSearchDescription,
                            "VeriCredCombinedConsumerTrace");
                    //Personal Information
                    {
                        ViewData["VeriCredInfoDateOfBirth"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].DateOfBirth;
                        ViewData["VeriCredInfoFirstName"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].FirstName;
                        ViewData["VeriCredInfoSurname"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Surname;
                        ViewData["VeriCredInfoFullname"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Fullname;
                        ViewData["VeriCredInfoIDNumber"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].IDNumber;

                        ViewData["VeriCredInfoGender"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Gender;
                        ViewData["VeriCredInfoAge"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].Age;
                        ViewData["VeriCredInfoCurrentEmployer"] = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["PersonInformation"].CurrentEmployer;
                        savePersonInformation(SearchToken, Reference, SearchID,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.InformationDate,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.PersonID,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.Title,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.DateOfBirth,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.FirstName,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.Surname,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.Fullname,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.IDNumber,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.IDNumber_Alternate,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.PassportNumber,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.Reference,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.MaritalStatus,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.Gender,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.Age,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.MiddleName1,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.MiddleName2,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.SpouseFirstName,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.SpouseSurname,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.NumberOfDependants,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.Remarks,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.CurrentEmployer,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.VerificationStatus,
                      rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.PersonInformation.HasProperties, "VeriCredCombinedConsumerTrace");
                    }

                    //Contact Information
                    {
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
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["ContactInformation"].PostalAddress, "VeriCredCombinedConsumerTrace");
                    }

                    //Historical Information
                    // Address
                    JToken AddressExists = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["HistoricalInformation"].AddressHistory;
                    if (AddressExists != null)
                    {
                        List<AddressHistory> AddressHist;
                        AddressHist = new List<AddressHistory>();

                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                        elements = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory;

                        for (int count = 0; count < (elements.Count); count++)
                        {
                            string TypeCode = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].TypeCode;
                            string Line1 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line1;
                            string Line2 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line2;
                            string Line3 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line3;
                            string Line4 = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line4;
                            string PostalCode = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].PostalCode;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate;

                            AddressHist.Add(new AddressHistory
                            {
                                TypeDescription = TypeCode,
                                Line1 = Line1,
                                Line2 = Line2,
                                Line3 = Line3,
                                Line4 = Line4,
                                PostalCode = PostalCode,
                                FullAddress = null,
                                LastUpdatedDate = LastUpdatedDate,
                            });

                            saveAddressHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].AddressID,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].TypeCode,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line1,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line2,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line3,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].Line4,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].PostalCode,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].FullAddress,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.AddressHistory[count].LastUpdatedDate, "VeriCredCombinedConsumerTrace"
                            );
                        }
                        ViewData["ArrayList"] = AddressHist;
                    }

                    // Telephone
                    JToken TelephoneExists = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["HistoricalInformation"].TelephoneHistory;
                    if (TelephoneExists != null)
                    {
                        List<TelephoneHistory> TelHist;
                        TelHist = new List<TelephoneHistory>();

                        Newtonsoft.Json.Linq.JArray Telelements = new Newtonsoft.Json.Linq.JArray();
                        Telelements = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory;

                        for (int count = 0; count < (Telelements.Count); count++)
                        {
                            string Type = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription;
                            string Number = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].Number;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate;

                            TelHist.Add(new TelephoneHistory
                            {
                                TypeDescriptionTel = Type,
                                DialCode = null,
                                Number = Number,
                                FullNumber = null,
                                LastUpdatedDateTel = LastUpdatedDate,
                            });

                            saveTelephoneHistory(SearchToken, Reference, SearchID,
                           rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                           rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].TelephoneID,
                           rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                           rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].DialCode,
                           rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].Number,
                           rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].FullNumber,
                           rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "VeriCredCombinedConsumerTrace"
                           );
                        }
                        ViewData["TelArrayList"] = TelHist;
                    }

                    // Employment
                    JToken EmploymentExists = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo["HistoricalInformation"].EmploymentHistory;
                    if (EmploymentExists != null)
                    {
                        Newtonsoft.Json.Linq.JArray EMelements = new Newtonsoft.Json.Linq.JArray();
                        EMelements = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory;

                        List<EmploymentHistory> EmpHist;
                        EmpHist = new List<EmploymentHistory>();

                        for (int count = 0; count < (EMelements.Count); count++)
                        {
                            string EmployerName = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].EmployerName;
                            string Designation = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].Designation;
                            string LastUpdatedDate = rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate;

                            EmpHist.Add(new EmploymentHistory
                            {
                                EmployerName = EmployerName,
                                Designation = Designation,
                                LastUpdatedDate = LastUpdatedDate
                            });

                            saveEmploymentHistory(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].EmployerName,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].Designation,
                            rootObject.ResponseObject.CombinedCreditInformation.VeriCredInfo.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "VeriCredCombinedConsumerTrace"
                            );
                        }

                        ViewData["EMArrayList"] = EmpHist;
                    }
                }
                else
                {
                    ViewData["VeriCredMessage"] = "NotFound";
                }
                return View();
            }
            catch (Exception e)
            {
                ViewData["Message"] = "Error Occured!";
            }
            return View();
        }

        public ActionResult CombinedConsumerTraceDatabase(DatabaseSearch combinedconsumerTraceSearch)
        {
            return View();
        }

        public ActionResult ExperianConsumerProfile()
        {
            return View();
        }

        public ActionResult ExperianConsumerProfileResults(Experian exp)
        {
            string id = exp.iDNumber != null ? exp.iDNumber.Trim() : null;
            string enquiryReason = exp.enquiryReason != null ? exp.enquiryReason.Trim() : null;
            string surname = exp.surname != null ? exp.surname.Trim() : null;
            string firstname = exp.firstName != null ? exp.firstName.Trim() : null;
            string passport = exp.passportNumber != null ? exp.passportNumber.Trim() : null;
            string refe = exp.reference != null ? exp.reference.Trim() : null;
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

            var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);
            try
            {
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
                saveSearchHistory(SearchID, SearchUserName, ResponseType,
                    ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "ExperianConsumerProfile");

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
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
                ViewData["Message"] = "good";
                ViewData["Message2"] = "No recent searches available. Please modify criteria above.";

                //PersonInformation
                {
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

                    savePersonInformation(SearchToken, Reference, SearchID,
                       rootObject.ResponseObject.PersonInformation.InformationDate,
                       rootObject.ResponseObject.PersonInformation.PersonID,
                       rootObject.ResponseObject.PersonInformation.Title,
                       rootObject.ResponseObject.PersonInformation.DateOfBirth,
                       rootObject.ResponseObject.PersonInformation.FirstName,
                       rootObject.ResponseObject.PersonInformation.Surname,
                       rootObject.ResponseObject.PersonInformation.Fullname,
                       rootObject.ResponseObject.PersonInformation.IDNumber,
                       rootObject.ResponseObject.PersonInformation.IDNumber_Alternate,
                       rootObject.ResponseObject.PersonInformation.PassportNumber,
                       rootObject.ResponseObject.PersonInformation.Reference,
                       rootObject.ResponseObject.PersonInformation.MaritalStatus,
                       rootObject.ResponseObject.PersonInformation.Gender,
                       rootObject.ResponseObject.PersonInformation.Age,
                       rootObject.ResponseObject.PersonInformation.MiddleName1,
                       rootObject.ResponseObject.PersonInformation.MiddleName2,
                       rootObject.ResponseObject.PersonInformation.SpouseFirstName,
                       rootObject.ResponseObject.PersonInformation.SpouseSurname,
                       rootObject.ResponseObject.PersonInformation.NumberOfDependants,
                       rootObject.ResponseObject.PersonInformation.Remarks,
                       rootObject.ResponseObject.PersonInformation.CurrentEmployer,
                       rootObject.ResponseObject.PersonInformation.VerificationStatus,
                       rootObject.ResponseObject.PersonInformation.HasProperties, "ExperianConsumerProfile");
                }

                //ContactInformation
                {
                    JToken ContactInfoExists = rootObject.ResponseObject["ContactInformation"];
                    if (ContactInfoExists != null)
                    {
                        ViewData["ExPhysicalAddress"] = rootObject.ResponseObject.ContactInformation.PhysicalAddress;
                        saveContactInformation(SearchToken, Reference, SearchID,
                         rootObject.ResponseObject.ContactInformation.EmailAddress,
                         rootObject.ResponseObject.ContactInformation.MobileNumber,
                         rootObject.ResponseObject.ContactInformation.HomeTelephoneNumber,
                         rootObject.ResponseObject.ContactInformation.WorkTelephoneNumber,
                         rootObject.ResponseObject.ContactInformation.PhysicalAddress,
                         rootObject.ResponseObject.ContactInformation.PostalAddress,
                         "ExperianConsumerProfile");
                    }
                }

                //HomeAffairsInformation
                {
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
                       rootObject.ResponseObject.HomeAffairsInformation.VerifiedDate, "ExperianConsumerProfile"
                       );
                }

                //CreditInformation
                {
                    JToken CreditInfoExists = rootObject.ResponseObject["CreditInformation"];
                    ViewData["EnqHIst"] = null;

                    if (CreditInfoExists != null)
                    {
                        ViewData["ExDelphiScoreChartURL"] = rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL;
                        ViewData["ExDelphiScore"] = rootObject.ResponseObject.CreditInformation.DelphiScore;
                        ViewData["ExFlagCount"] = rootObject.ResponseObject.CreditInformation.FlagCount;
                        ViewData["ExFlagDetails"] = rootObject.ResponseObject.CreditInformation.FlagDetails;

                        saveCreditInformation(SearchToken, Reference, SearchID,
                            rootObject.ResponseObject.CreditInformation.CreditSummaryChartURL,
                            rootObject.ResponseObject.CreditInformation.DelphiScore,
                            rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL,
                            rootObject.ResponseObject.CreditInformation.RiskColour,
                            rootObject.ResponseObject.CreditInformation.FlagCount,
                            rootObject.ResponseObject.CreditInformation.FlagDetails,
                            rootObject.ResponseObject.CreditInformation.TotalInstallmentAmountCPAAccounts_CompuScan,
                            rootObject.ResponseObject.CreditInformation.TotalInstallmentAmountNLRAccounts_CompuScan,
                            rootObject.ResponseObject.CreditInformation.TotalNumberCPAAccounts_CompuScan,
                            rootObject.ResponseObject.CreditInformation.TotalNumberNLRAccounts_CompuScan,
                            rootObject.ResponseObject.CreditInformation.TotalNumberActiveCPAAccounts_CompuScan,
                            rootObject.ResponseObject.CreditInformation.TotalNumberActiveNLRAccounts_CompuScan,
                            rootObject.ResponseObject.CreditInformation.TotalNumberClosedCPAAccounts_CompuScan,
                            rootObject.ResponseObject.CreditInformation.TotalNumberClosedNLRAccounts_CompuScan, "ExperianConsumerProfile");

                        //ViewData["ExApplicationDate"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.ApplicationDate; <--- WHere is this saved or displayed???

                        //DataCounts
                        JToken DataCountsExists = rootObject.ResponseObject.CreditInformation["DataCounts"];
                        if (DataCountsExists != null)
                        {
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
                            ViewData["ExBondsBonds"] = rootObject.ResponseObject.CreditInformation.DataCounts.Bonds;
                            ViewData["ExDeeds"] = rootObject.ResponseObject.CreditInformation.DataCounts.Deeds;
                            ViewData["ExPublicDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults;
                            ViewData["ExNLRAccounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts;
                            saveDataCounts(SearchToken, Reference, SearchID,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Accounts,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Enquiries,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Judgments,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Notices,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.BankDefaults,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Defaults,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Collections,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Directors,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Addresses,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Telephones,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Occupants,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Employers,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.TraceAlerts,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.PaymentProfiles,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.OwnEnquiries,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.AdminOrders,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.PossibleMatches,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.DefiniteMatches,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Loans,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.FraudAlerts,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Companies,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Properties,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Documents,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.DemandLetters,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Trusts,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Bonds,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Deeds,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts,
                                 "ExperianConsumerProfile");
                        }

                        //ConsumerStatistics
                        JToken ConsumerStatisticsExists = rootObject.ResponseObject.CreditInformation["ConsumerStatistics"];
                        if (ConsumerStatisticsExists != null)
                        {
                            ViewData["ExHighestJudgment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.HighestJudgment;
                            ViewData["ExRevolvingAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.RevolvingAccounts;
                            ViewData["ExInstalmentAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.InstalmentAccounts;
                            ViewData["ExOpenAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.OpenAccounts;
                            ViewData["ExAdverseAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.AdverseAccounts;
                            ViewData["ExPercent0ArrearsLast12Histories"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.Percent0ArrearsLast12Histories;
                            ViewData["ExMonthsOldestOpenedPPSEver"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.MonthsOldestOpenedPPSEver;
                            ViewData["ExNumberPPSLast12Months"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NumberPPSLast12Months;
                            ViewData["ExNLRMicroloansPast12Months"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRMicroloansPast12Months;
                            saveConsumerStatistics(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.HighestJudgment,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.RevolvingAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.InstalmentAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.OpenAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.AdverseAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.Percent0ArrearsLast12Histories,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.MonthsOldestOpenedPPSEver,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NumberPPSLast12Months,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRMicroloansPast12Months,
                                "ExperianConsumerProfile");
                            //NLRStats
                            ViewData["ExNLRActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
                            ViewData["ExNLRClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
                            ViewData["ExNLRWorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
                            ViewData["ExNLRBalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
                            ViewData["ExNLRCumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
                            saveNLRStats(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.ActiveAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.ClosedAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.WorstMonthArrears,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.WorstArrearsStatus,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.BalanceExposure,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.MonthlyInstalment,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CumulativeArrears,
                                "ExperianConsumerProfile");

                            //CCAStats
                            ViewData["ExCCAActiveAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
                            ViewData["ExCCAClosedAccounts"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
                            ViewData["ExCCAWorstMonthArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
                            ViewData["ExCCABalanceExposure"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
                            ViewData["ExCCACumulativeArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                            saveCCAStats(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstArrearsStatus,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.CumulativeArrears,
                                "ExperianConsumerProfile");
                            //Months
                            ViewData["ExMonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
                            ViewData["ExMonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
                            ViewData["ExMonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
                            ViewData["ExMonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
                            saveNLR12Months(SearchToken, Reference, SearchID,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClien,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears,
                               "ExperianConsumerProfile");
                            //Months
                            ViewData["ExMonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
                            ViewData["ExMonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
                            ViewData["ExMonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
                            ViewData["ExMonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
                            saveNLR24Months(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears,
                                "ExperianConsumerProfile");

                            //NLR36Months
                            ViewData["ExNLR36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
                            ViewData["ExNLR36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
                            ViewData["ExNLR36MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
                            ViewData["ExNLR36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
                            saveNLR36Months(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears,
                                "ExperianConsumerProfile");

                            //CCA12Months
                            ViewData["ExMonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
                            ViewData["ExMonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
                            ViewData["ExMonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
                            ViewData["ExMonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
                            saveCCA12Months(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears,
                                "ExperianConsumerProfile");

                            //CCA24Months
                            ViewData["ExCCA24MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
                            ViewData["ExCCA24MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
                            ViewData["ExCCA24MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
                            ViewData["ExCCA24MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
                            saveCCA24Months(SearchToken, Reference, SearchID,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans,
                               rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears,
                               "ExperianConsumerProfile");

                            //CCA36Months
                            ViewData["ExCCA36MonthsEnquiriesByClient"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
                            ViewData["ExCCA36MonthsEnquiriesByOther"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
                            ViewData["ExCCA36MonthsPositiveLoans"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
                            ViewData["ExCCA36MonthsHighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;
                            saveCCA36Months(SearchToken, Reference, SearchID,
                                     rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient,
                                     rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther,
                                     rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans,
                                     rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears,
                                     "ExperianConsumerProfile");
                        }

                        //DebtReviewStatus
                        JToken DebtReviewStatusExists = rootObject.ResponseObject.CreditInformation["DebtReviewStatus"];
                        if (DebtReviewStatusExists != null)
                        {
                            ViewData["DRStatusCode"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusCode;
                            ViewData["DRStatusDescription"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription;
                            saveDebtReviewStatus(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusCode,
                                null,
                                rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription,
                                null, "ExperianConsumerProfile");
                        }
                        Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();

                        //Enquiry History
                        JToken EnquiryHistoryExists = rootObject.ResponseObject.CreditInformation["EnquiryHistory"];
                        if (EnquiryHistoryExists != null)
                        {
                            elements = rootObject.ResponseObject.CreditInformation.EnquiryHistory;

                            List<EnquiryHistory> EnqHIst;
                            EnqHIst = new List<EnquiryHistory>();

                            for (int count = 0; count < (elements.Count); count++)
                            {
                                saveEnquiryHistory(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate,
                                rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy,
                                rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact,
                                null,
                                null, "ExperianConsumerProfile");
                                EnqHIst.Add(new EnquiryHistory
                                {
                                    EnquiryDate = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate,
                                    EnquiredBy = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy,
                                    EnquiredByContact = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact,
                                });
                            }
                            ViewData["EnqHIst"] = EnqHIst;
                            ViewData["EnqHIstCount"] = EnqHIst.Count;
                        }
                    }
                }
                //HistoricalInformation
                {
                    JToken HistoricalInformationExists = rootObject.ResponseObject["HistoricalInformation"];
                    ViewData["AddressHist"] = null;
                    ViewData["EmpHist"] = null;
                    ViewData["TelHist"] = null;
                    if (HistoricalInformationExists != null)
                    {
                        JToken AddressExists = rootObject.ResponseObject.HistoricalInformation["AddressHistory"];
                        Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();

                        if (AddressExists != null)
                        {
                            List<AddressHistory> AddressHist;
                            AddressHist = new List<AddressHistory>();

                            elements1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory;
                            for (int count = 0; count < (elements1.Count); count++)
                            {
                                saveAddressHistory(SearchToken, Reference, SearchID,
                                    null,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3,
                                    null,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                    "ExperianConsumerProfile");

                                AddressHist.Add(new AddressHistory
                                {
                                    TypeDescription = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription,
                                    Line1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1,
                                    Line2 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2,
                                    Line3 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3,
                                    PostalCode = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode,
                                    FullAddress = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress,
                                    LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                });
                            }
                            ViewData["AddressHist"] = AddressHist;
                            ViewData["AddressHistCount"] = AddressHist.Count;
                        }

                        JToken TelephoneExists = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;
                        if (TelephoneExists != null)
                        {
                            Newtonsoft.Json.Linq.JArray elements2 = new Newtonsoft.Json.Linq.JArray();

                            List<TelephoneHistory> TelHist;
                            TelHist = new List<TelephoneHistory>();

                            elements2 = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;

                            for (int count = 0; count < (elements2.Count); count++)
                            {
                                saveTelephoneHistory(SearchToken, Reference, SearchID, rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode, null,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription, null,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "ExperianConsumerProfile");

                                TelHist.Add(new TelephoneHistory
                                {
                                    TypeDescriptionTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                    DialCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode,
                                    Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number,
                                    FullNumber = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                    LastUpdatedDateTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate,
                                });
                            }
                            ViewData["TelHist"] = TelHist;
                            ViewData["TelHistCount"] = TelHist.Count;
                        }

                        JToken EmploymentExists = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;
                        if (EmploymentExists != null)
                        {
                            Newtonsoft.Json.Linq.JArray elements3 = new Newtonsoft.Json.Linq.JArray();

                            List<EmploymentHistory> EmpHist;
                            EmpHist = new List<EmploymentHistory>();
                            elements3 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;

                            for (int count = 0; count < (elements3.Count); count++)
                            {
                                saveEmploymentHistory(SearchToken, Reference, SearchID, rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                    rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation, null, "ExperianConsumerProfile");

                                EmpHist.Add(new EmploymentHistory
                                {
                                    EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                    Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation,
                                });
                            }
                            ViewData["EmpHist"] = EmpHist;
                            ViewData["EmpHistCount"] = EmpHist.Count;
                        }
                    }
                }
                return View();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());
                TempData["msg"] = "Error Occured, Please verify the details that have been entered. ";

                return View();
            }
        }

        public ActionResult ExperianConsumerProfileDatabase(DatabaseSearch DbSearch)
        {
            System.Collections.Generic.List<PersonInformation> personInfoList = new System.Collections.Generic.List<PersonInformation>();
            System.Collections.Generic.List<HomeAffairsInformation> homeAffairsInformationList = new System.Collections.Generic.List<HomeAffairsInformation>();
            System.Collections.Generic.List<ContactInformation> contactInformationList = new System.Collections.Generic.List<ContactInformation>();
            System.Collections.Generic.List<CreditInformation> creditInformationList = new System.Collections.Generic.List<CreditInformation>();
            System.Collections.Generic.List<DataCounts> dataCountsList = new System.Collections.Generic.List<DataCounts>();
            System.Collections.Generic.List<DebtReviewStatus> debtReviewStatusList = new System.Collections.Generic.List<DebtReviewStatus>();
            System.Collections.Generic.List<ConsumerStatistics> consumerstatsList = new System.Collections.Generic.List<ConsumerStatistics>();
            System.Collections.Generic.List<NLRStats> nlrstatsList = new System.Collections.Generic.List<NLRStats>();
            System.Collections.Generic.List<CCAStats> ccastatsList = new System.Collections.Generic.List<CCAStats>();
            System.Collections.Generic.List<CCA12months> cca12monthsList = new System.Collections.Generic.List<CCA12months>();
            System.Collections.Generic.List<CCA24months> cca24monthsList = new System.Collections.Generic.List<CCA24months>();
            System.Collections.Generic.List<CCA36months> cca36monthsList = new System.Collections.Generic.List<CCA36months>();
            System.Collections.Generic.List<NLR12months> nlr12monthsList = new System.Collections.Generic.List<NLR12months>();
            System.Collections.Generic.List<NLR24months> nlr24monthsList = new System.Collections.Generic.List<NLR24months>();
            System.Collections.Generic.List<NLR36months> nlr36monthsList = new System.Collections.Generic.List<NLR36months>();
            System.Collections.Generic.List<EnquiryHistory> enquiryInformationList = new System.Collections.Generic.List<EnquiryHistory>();
            System.Collections.Generic.List<AddressHistory> addressInformationList = new System.Collections.Generic.List<AddressHistory>();
            System.Collections.Generic.List<EmploymentHistory> employmentInformationList = new System.Collections.Generic.List<EmploymentHistory>();
            System.Collections.Generic.List<TelephoneHistory> telephoneInformationList = new System.Collections.Generic.List<TelephoneHistory>();
            System.Collections.Generic.List<CPAaccounts> cppaAccountsList = new System.Collections.Generic.List<CPAaccounts>();
            //System.Collections.Generic.List<PaymentHistoryAccountDetails> paymentHistoryAccountList = new System.Collections.Generic.List<PaymentHistoryAccountDetails>();
            System.Collections.Generic.List<Directorship> directorshipList = new System.Collections.Generic.List<Directorship>();

            //AND SearchToken = 'cc329011-76c8-4c8c-9ff6-4b5ce6c05d13' AND Reference = 'devadmin@ktopportunities.co.za' AND typeOfSearch = 'ExperianConsumerProfile'
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
                                                                                                                   //string query_uid = $"SELECT * FROM personinformation,homeaffairsinformation,creditinformation,datacounts,debtreviewstatus,addresshistory,telephonehistory,consumerstatistics,nlrstats,ccastats,cca12months,cca24months,cca36months,enquiryhistory,employmenthistory,months,months,nlr36months,cpa_accounts WHERE personinformation.SearchToken = '{DbSearch.token}'";
                                                                                                                   //Add TABLE paymenthistoryaccountdetails!!!!

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString))
            {
                conn.Open();

                //************************************************* Start personal info ***********//
                string query_uid_personinformation = $"SELECT * FROM personinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_personinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            int DateOfBirth = reader.GetOrdinal("DateOfBirth");
                            int Title = reader.GetOrdinal("Title");
                            int FirstName = reader.GetOrdinal("FirstName");
                            int Surname = reader.GetOrdinal("Surname");
                            int Fullname = reader.GetOrdinal("Fullname");
                            int IDNumber = reader.GetOrdinal("IDNumber");
                            int Gender = reader.GetOrdinal("Gender");
                            int Age = reader.GetOrdinal("Age");
                            int MaritalStatus = reader.GetOrdinal("MaritalStatus");
                            int MiddleName1 = reader.GetOrdinal("MiddleName1");
                            int HasProperties = reader.GetOrdinal("HasProperties");
                            int Reference = reader.GetOrdinal("Ref");
                            //PersonInformation
                            while (reader.Read())
                            {
                                PersonInformation personInformation = new PersonInformation();
                                personInformation.DateOfBirth = (reader[DateOfBirth] != Convert.DBNull) ? reader[DateOfBirth].ToString() : null;
                                personInformation.Title = (reader[Title] != Convert.DBNull) ? reader[Title].ToString() : null;
                                personInformation.FirstName = (reader[FirstName] != Convert.DBNull) ? reader[FirstName].ToString() : null;
                                personInformation.Surname = (reader[Surname] != Convert.DBNull) ? reader[Surname].ToString() : null;
                                personInformation.Fullname = (reader[Fullname] != Convert.DBNull) ? reader[Fullname].ToString() : null;
                                personInformation.IDNumber = (reader[IDNumber] != Convert.DBNull) ? reader[IDNumber].ToString() : null;
                                personInformation.Gender = (reader[Gender] != Convert.DBNull) ? reader[Gender].ToString() : null;
                                personInformation.Age = (reader[Age] != Convert.DBNull) ? reader[Age].ToString() : null;
                                personInformation.MaritalStatus = (reader[MaritalStatus] != Convert.DBNull) ? reader[MaritalStatus].ToString() : null;
                                personInformation.MiddleName1 = (reader[MiddleName1] != Convert.DBNull) ? reader[MiddleName1].ToString() : null;
                                personInformation.Reference = (reader[Reference] != Convert.DBNull) ? reader[Reference].ToString() : null;
                                personInformation.HasProperties = (reader[HasProperties] != Convert.DBNull) ? Convert.ToBoolean(reader[HasProperties]) : false;
                                //add to the list
                                personInfoList.Add(personInformation);
                            }
                        }
                        ViewData["PersonInfoList"] = personInfoList;
                        ViewData["PersonInfoListCount"] = personInfoList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //*************************************************END personal info ***********//
                //************************************************* Start contactInformation ***********//
                string query_uid_contactinformationinformation = $"SELECT * FROM contactinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_contactinformationinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //Contactinformation
                            int EmailAddress = reader.GetOrdinal("EmailAddress");
                            int MobileNumber = reader.GetOrdinal("MobileNumber");
                            int HomeTelephoneNumber = reader.GetOrdinal("HomeTelephoneNumber");
                            int WorkTelephoneNumber = reader.GetOrdinal("WorkTelephoneNumber");
                            int PhysicalAddress = reader.GetOrdinal("PhysicalAddress");
                            int PostalAddress = reader.GetOrdinal("PostalAddress");
                            while (reader.Read())
                            {
                                ContactInformation contactInformation = new ContactInformation();

                                contactInformation.EmailAddress = (reader[EmailAddress] != Convert.DBNull) ? reader[EmailAddress].ToString() : null;
                                contactInformation.MobileNumber = (reader[MobileNumber] != Convert.DBNull) ? reader[MobileNumber].ToString() : null;
                                contactInformation.HomeTelephoneNumber = (reader[HomeTelephoneNumber] != Convert.DBNull) ? reader[HomeTelephoneNumber].ToString() : null;
                                contactInformation.WorkTelephoneNumber = (reader[WorkTelephoneNumber] != Convert.DBNull) ? reader[WorkTelephoneNumber].ToString() : null;
                                contactInformation.PhysicalAddress = (reader[PhysicalAddress] != Convert.DBNull) ? reader[PhysicalAddress].ToString() : null;
                                contactInformation.PostalAddress = (reader[PostalAddress] != Convert.DBNull) ? reader[PostalAddress].ToString() : null;

                                //add to the list
                                contactInformationList.Add(contactInformation);
                            }
                        }
                        ViewData["contactInformationList"] = contactInformationList;
                        ViewData["contactInformationListCount"] = contactInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }

                //*************************************************END contactInformation ***********//

                //************************************************* Start homeaffairsinformation info ***********//
                string query_uid_homeaffairsinformation = $"SELECT * FROM homeaffairsinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_homeaffairsinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //HomeAffairsInformation
                            HomeAffairsInformation homeAffairsInformation = new HomeAffairsInformation();
                            int ExFirstName = reader.GetOrdinal("FirstName");
                            int DeceasedDate = reader.GetOrdinal("DeceasedDate");
                            int IDVerified = reader.GetOrdinal("IDVerified");
                            int SurnameVerified = reader.GetOrdinal("SurnameVerified");
                            int Warnings = reader.GetOrdinal("Warnings");
                            int DeceasedStatus = reader.GetOrdinal("DeceasedStatus");
                            int VerifiedStatus = reader.GetOrdinal("VerifiedStatus");
                            int InitialsVerified = reader.GetOrdinal("InitialsVerified");
                            int CauseOfDeath = reader.GetOrdinal("CauseOfDeath");
                            int VerifiedDate = reader.GetOrdinal("VerifiedDate");
                            while (reader.Read())
                            {
                                homeAffairsInformation.FirstName = (reader[ExFirstName] != Convert.DBNull) ? reader[ExFirstName].ToString() : null;
                                homeAffairsInformation.IDVerified = (reader[IDVerified] != Convert.DBNull) ? reader[IDVerified].ToString() : null;
                                homeAffairsInformation.SurnameVerified = (reader[SurnameVerified] != Convert.DBNull) ? reader[SurnameVerified].ToString() : null;
                                homeAffairsInformation.Warnings = (reader[Warnings] != Convert.DBNull) ? reader[Warnings].ToString() : null;
                                homeAffairsInformation.DeceasedDate = (reader[DeceasedDate] != Convert.DBNull) ? reader[DeceasedDate].ToString() : null;
                                homeAffairsInformation.DeceasedStatus = (reader[DeceasedStatus] != Convert.DBNull) ? reader[DeceasedStatus].ToString() : null;
                                homeAffairsInformation.VerifiedStatus = (reader[VerifiedStatus] != Convert.DBNull) ? reader[VerifiedStatus].ToString() : null;
                                homeAffairsInformation.InitialsVerified = (reader[InitialsVerified] != Convert.DBNull) ? reader[InitialsVerified].ToString() : null;
                                homeAffairsInformation.CauseOfDeath = (reader[CauseOfDeath] != Convert.DBNull) ? reader[CauseOfDeath].ToString() : null;
                                homeAffairsInformation.VerifiedDate = (reader[VerifiedDate] != Convert.DBNull) ? reader[VerifiedDate].ToString() : null;
                                //add to the list
                                homeAffairsInformationList.Add(homeAffairsInformation);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["HomeAffairsInfoList"] = homeAffairsInformationList;
                        ViewData["HomeAffairsInfoListCount"] = homeAffairsInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* END homeaffairsinformation info ***********//
                //************************************************* Start CreditInformation info ***********//
                string query_uid_creditinformation = $"SELECT * FROM creditinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_creditinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CreditInformation
                            CreditInformation CreditInfo = new CreditInformation();

                            int DelphiScore = reader.GetOrdinal("DelphiScore");
                            int RiskColour = reader.GetOrdinal("RiskColour");
                            int DelphiScoreChartURL = reader.GetOrdinal("DelphiScoreChartURL");
                            int FlagCount = reader.GetOrdinal("FlagCount");
                            int FlagDetails = reader.GetOrdinal("FlagDetails");

                            while (reader.Read())
                            {
                                CreditInfo.DelphiScore = (reader[DelphiScore] != Convert.DBNull) ? reader[DelphiScore].ToString() : null;
                                CreditInfo.RiskColour = (reader[RiskColour] != Convert.DBNull) ? reader[RiskColour].ToString() : null;
                                CreditInfo.DelphiScoreChartURL = (reader[DelphiScoreChartURL] != Convert.DBNull) ? reader[DelphiScoreChartURL].ToString() : null;
                                CreditInfo.FlagCount = (reader[FlagCount] != Convert.DBNull) ? reader[FlagCount].ToString() : null;
                                CreditInfo.FlagDetails = (reader[FlagDetails] != Convert.DBNull) ? reader[FlagDetails].ToString() : null;

                                //add to the list
                                creditInformationList.Add(CreditInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["creditInformationList"] = creditInformationList;
                        ViewData["creditInformationListCount"] = creditInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CreditInformation info ***********//
                //************************************************* StartDataCOunts info ***********//
                string query_uid_DataCOunts = $"SELECT * FROM datacounts as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_DataCOunts, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DataCountsInformation
                            DataCounts DataCountInfo = new DataCounts();

                            int Accounts = reader.GetOrdinal("Accounts");
                            int Enquiries = reader.GetOrdinal("Enquiries");
                            //int Judgements = reader.GetOrdinal("Judgements");
                            int Notices = reader.GetOrdinal("Notices");
                            int BankDefaults = reader.GetOrdinal("BankDefaults");
                            int Defaults = reader.GetOrdinal("Defaults");
                            int Collections = reader.GetOrdinal("Collections");
                            int Directors = reader.GetOrdinal("Directors");
                            int Addresses = reader.GetOrdinal("Addresses");
                            int Telephones = reader.GetOrdinal("Telephones");
                            int Occupants = reader.GetOrdinal("Occupants");
                            int Employers = reader.GetOrdinal("Employers");
                            int TraceAlerts = reader.GetOrdinal("TraceAlerts");
                            int PaymentProfiles = reader.GetOrdinal("PaymentProfiles");
                            int OwnEnquiries = reader.GetOrdinal("OwnEnquiries");
                            int AdminOrders = reader.GetOrdinal("AdminOrders");
                            int PossibleMatches = reader.GetOrdinal("PossibleMatches");
                            int DefiniteMatches = reader.GetOrdinal("DefiniteMatches");
                            int Loans = reader.GetOrdinal("Loans");
                            int FraudAlerts = reader.GetOrdinal("FraudAlerts");
                            int Companies = reader.GetOrdinal("Companies");
                            int Properties = reader.GetOrdinal("Properties");
                            int Documents = reader.GetOrdinal("Documents");
                            int DemandLetters = reader.GetOrdinal("DemandLetters");
                            int Trusts = reader.GetOrdinal("Trusts");
                            int Bonds = reader.GetOrdinal("Bonds");
                            int Deeds = reader.GetOrdinal("Deeds");
                            int PublicDefaults = reader.GetOrdinal("PublicDefaults");
                            int NLRAccounts = reader.GetOrdinal("NLRAccounts");
                            while (reader.Read())
                            {
                                DataCountInfo.Accounts = (reader[Accounts] != Convert.DBNull) ? reader[Accounts].ToString() : null;
                                DataCountInfo.Enquires = (reader[Enquiries] != Convert.DBNull) ? reader[Enquiries].ToString() : null;
                                //DataCountInfo.Judgements = (reader[Judgements] != Convert.DBNull) ? reader[Judgements].ToString() : null;
                                DataCountInfo.Notices = (reader[Notices] != Convert.DBNull) ?
                                reader[Notices].ToString() : null; DataCountInfo.BankDefaults =
                                (reader[BankDefaults] != Convert.DBNull) ? reader[BankDefaults].ToString() : null;
                                DataCountInfo.Defaults = (reader[Defaults] != Convert.DBNull) ?
                                reader[Defaults].ToString() : null; DataCountInfo.Collections =
                                (reader[Collections] != Convert.DBNull) ? reader[Collections].ToString() : null;
                                DataCountInfo.Directors = (reader[Directors] != Convert.DBNull) ?
                                reader[Directors].ToString() : null; DataCountInfo.Addresses = (reader[Addresses]
                                != Convert.DBNull) ? reader[Addresses].ToString() : null; DataCountInfo.Telephones =
                                (reader[Telephones] != Convert.DBNull) ? reader[Telephones].ToString() : null;
                                DataCountInfo.Occupants = (reader[Occupants] != Convert.DBNull) ?
                                reader[Occupants].ToString() : null; DataCountInfo.Employers = (reader[Employers]
                                != Convert.DBNull) ? reader[Employers].ToString() : null; DataCountInfo.TraceAlerts
                                = (reader[TraceAlerts] != Convert.DBNull) ? reader[TraceAlerts].ToString() : null;
                                DataCountInfo.PaymentProfiles = (reader[PaymentProfiles] != Convert.DBNull) ?
                                reader[PaymentProfiles].ToString() : null; DataCountInfo.OwnEnquiries =
                                (reader[OwnEnquiries] != Convert.DBNull) ? reader[OwnEnquiries].ToString() : null;
                                DataCountInfo.AdminOrders = (reader[AdminOrders] != Convert.DBNull) ?
                                reader[AdminOrders].ToString() : null; DataCountInfo.PossibleMatches =
                                (reader[PossibleMatches] != Convert.DBNull) ? reader[PossibleMatches].ToString() :
                                null; DataCountInfo.DefiniteMatches = (reader[DefiniteMatches] != Convert.DBNull) ?
                                reader[DefiniteMatches].ToString() : null; DataCountInfo.Loans = (reader[Loans] !=
                                Convert.DBNull) ? reader[Loans].ToString() : null; DataCountInfo.FraudAlerts =
                                (reader[FraudAlerts] != Convert.DBNull) ? reader[FraudAlerts].ToString() : null;
                                DataCountInfo.Companies = (reader[Companies] != Convert.DBNull) ?
                                reader[Companies].ToString() : null; DataCountInfo.Properties = (reader[Properties]
                                != Convert.DBNull) ? reader[Properties].ToString() : null; DataCountInfo.Documents =
                                (reader[Documents] != Convert.DBNull) ? reader[Documents].ToString() : null;
                                DataCountInfo.DemandLetters = (reader[DemandLetters] != Convert.DBNull) ?
                                reader[DemandLetters].ToString() : null; DataCountInfo.Trusts = (reader[Trusts] !=
                                Convert.DBNull) ? reader[Trusts].ToString() : null; DataCountInfo.Bonds =
                                (reader[Bonds] != Convert.DBNull) ? reader[Bonds].ToString() : null;
                                DataCountInfo.Deeds = (reader[Deeds] != Convert.DBNull) ? reader[Deeds].ToString()
                                : null; DataCountInfo.PublicDefaults = (reader[PublicDefaults] != Convert.DBNull) ?
                                reader[PublicDefaults].ToString() : null; DataCountInfo.NLRAccounts =
                                (reader[NLRAccounts] != Convert.DBNull) ? reader[NLRAccounts].ToString() : null;

                                dataCountsList.Add(DataCountInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["dataCountsList"] = dataCountsList;
                        ViewData["dataCountsListCount"] = dataCountsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }

                //************************************************* End DataCOunts info ***********//
                //************************************************* Start Debtreviewstatus info ***********//
                string query_uid_debtreviewstatus = $"SELECT * FROM debtreviewstatus as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_debtreviewstatus, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DebtReviewStatusInformation
                            DebtReviewStatus DebtReviewInfo = new DebtReviewStatus();

                            int StatusCode = reader.GetOrdinal("StatusCode");
                            int StatusDate = reader.GetOrdinal("StatusDate");
                            int StatusDescription = reader.GetOrdinal("StatusDescription");
                            int ApplicationDate = reader.GetOrdinal("ApplicationDate");
                            while (reader.Read())
                            {
                                DebtReviewInfo.StatusCode = (reader[StatusCode] != Convert.DBNull) ?
                                reader[StatusCode].ToString() : null; DebtReviewInfo.StatusDate =
                                (reader[StatusDate] != Convert.DBNull) ? reader[StatusDate].ToString() : null;
                                DebtReviewInfo.StatusDescription = (reader[StatusDescription] != Convert.DBNull) ?
                                reader[StatusDescription].ToString() : null; DebtReviewInfo.ApplicationDate =
                                (reader[ApplicationDate] != Convert.DBNull) ? reader[ApplicationDate].ToString() : null;

                                debtReviewStatusList.Add(DebtReviewInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["debtReviewStatusList"] = debtReviewStatusList;
                        ViewData["debtReviewStatusListCount"] = debtReviewStatusList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End DebtReviewStatus info ***********//
                //************************************************* Start ConsumerStatisticsInformation ***********//
                string query_uid_consumerStatistics = $"SELECT * FROM consumerstatistics as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_consumerStatistics, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //ConsumerStatisticsInformation
                            ConsumerStatistics ConsumerStatsInfo = new ConsumerStatistics();

                            int HighestJudgment = reader.GetOrdinal("HighestJudgment");
                            int RevolvingAccounts = reader.GetOrdinal("RevolvingAccounts");
                            int InstalmentAccounts = reader.GetOrdinal("InstalmentAccounts");
                            int OpenAccounts = reader.GetOrdinal("OpenAccounts");
                            int AdverseAccounts = reader.GetOrdinal("AdverseAccounts");
                            int Percent0ArrearsLast12Histories = reader.GetOrdinal("Percent0ArrearsLast12Histories");
                            int MonthsOldestOpenedPPSEver = reader.GetOrdinal("MonthsOldestOpenedPPSEver");
                            int NumberPPSLast12Months = reader.GetOrdinal("NumberPPSLast12Months");
                            int NLRMicroloansPast12Months = reader.GetOrdinal("NLRMicroloansPast12Months");
                            while (reader.Read())
                            {
                                ConsumerStatsInfo.HighestJudgment = (reader[HighestJudgment] != Convert.DBNull) ?
                                reader[HighestJudgment].ToString() : null; ConsumerStatsInfo.RevolvingAccounts =
                                (reader[RevolvingAccounts] != Convert.DBNull) ?
                                reader[RevolvingAccounts].ToString() : null; ConsumerStatsInfo.InstalmentAccounts =
                                (reader[InstalmentAccounts] != Convert.DBNull) ?
                                reader[InstalmentAccounts].ToString() : null; ConsumerStatsInfo.OpenAccounts =
                                (reader[OpenAccounts] != Convert.DBNull) ? reader[OpenAccounts].ToString() : null;
                                ConsumerStatsInfo.AdverseAccounts = (reader[AdverseAccounts] != Convert.DBNull) ?
                                reader[AdverseAccounts].ToString() : null;
                                ConsumerStatsInfo.Percent0ArrearsLast12Histories =
                                (reader[Percent0ArrearsLast12Histories] != Convert.DBNull) ?
                                reader[Percent0ArrearsLast12Histories].ToString() : null;
                                ConsumerStatsInfo.MonthsOldestOpenedPPSEver = (reader[MonthsOldestOpenedPPSEver] !=
                                Convert.DBNull) ? reader[MonthsOldestOpenedPPSEver].ToString() : null;
                                ConsumerStatsInfo.NumberPPSLast12Months = (reader[NumberPPSLast12Months] !=
                                Convert.DBNull) ? reader[NumberPPSLast12Months].ToString() : null;
                                ConsumerStatsInfo.NLRMicroloansPast12Months = (reader[NLRMicroloansPast12Months] !=
                                Convert.DBNull) ? reader[NLRMicroloansPast12Months].ToString() : null;

                                consumerstatsList.Add(ConsumerStatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["consumerstatsList"] = consumerstatsList;
                        ViewData["consumerstatsListCount"] = consumerstatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End ConsumerStatisticsInformation ***********//

                //************************************************* Start nlrstatsInformation ***********//
                string query_uid_nlrstats = $"SELECT * FROM nlrstats as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlrstats, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLRStatsInformation
                            NLRStats NLRStatsInfo = new NLRStats();

                            int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                            int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                            int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                            int WorstArrearsStatus = reader.GetOrdinal("WorstArrearsStatus");
                            int MonthlyInstalment = reader.GetOrdinal("MonthlyInstalment");
                            int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");
                            int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                            while (reader.Read())
                            {
                                NLRStatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;

                                NLRStatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                NLRStatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                NLRStatsInfo.WorstArrearsStatus = (reader[WorstArrearsStatus] != Convert.DBNull) ? reader[WorstArrearsStatus].ToString() : null;
                                NLRStatsInfo.MonthlyInstalment = (reader[MonthlyInstalment] != Convert.DBNull) ? reader[MonthlyInstalment].ToString() : null;
                                NLRStatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                NLRStatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                nlrstatsList.Add(NLRStatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlrstatsList"] = nlrstatsList;
                        ViewData["nlrstatsListCount"] = nlrstatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlrstatsInformation ***********//
                //************************************************* Start ccastatsInformation ***********//
                string query_uid_ccastats = $"SELECT * FROM ccastats as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_ccastats, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCAStatsInformation
                            CCAStats ccastatsInfo = new CCAStats();

                            int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                            int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                            int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                            int WorstArrearsStatus = reader.GetOrdinal("WorstArrearsStatus");
                            int MonthlyInstalment = reader.GetOrdinal("MonthlyInstalment");
                            int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");
                            int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                            while (reader.Read())
                            {
                                ccastatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;
                                ccastatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                ccastatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                ccastatsInfo.WorstArrearsStatus = (reader[WorstArrearsStatus] != Convert.DBNull) ? reader[WorstArrearsStatus].ToString() : null;
                                ccastatsInfo.MonthlyInstalment = (reader[MonthlyInstalment] != Convert.DBNull) ? reader[MonthlyInstalment].ToString() : null;
                                ccastatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                ccastatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                ccastatsList.Add(ccastatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["ccastatsList"] = ccastatsList;
                        ViewData["ccastatsListCount"] = ccastatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End ccastatsInformation ***********//
                //************************************************* Start cca12monthsInformation ***********//
                string query_uid_cca12months = $"SELECT * FROM cca12months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca12months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA12monthsInformation
                            CCA12months cca12monthsInfo = new CCA12months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca12monthsList.Add(cca12monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca12monthsList"] = cca12monthsList;
                        ViewData["cca12monthsListCount"] = cca12monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* Start cca24monthsInformation ***********//
                string query_uid_cca24months = $"SELECT * FROM cca24months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca24months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA24monthsInformation
                            CCA24months cca24monthsInfo = new CCA24months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca24monthsList.Add(cca24monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca24monthsList"] = cca24monthsList;
                        ViewData["cca24monthsListCount"] = cca24monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End cca24monthsInformation ***********//
                //************************************************* Start cca36monthsInformation ***********//
                string query_uid_cca36months = $"SELECT * FROM cca36months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca36months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA36monthsInformation
                            CCA36months cca36monthsInfo = new CCA36months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca36monthsList.Add(cca36monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca36monthsList"] = cca36monthsList;
                        ViewData["cca36monthsListCount"] = cca36monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End cca36monthsInformation ***********//
                //************************************************* Start nlr12monthsInformation ***********//
                string query_uid_nlr12months = $"SELECT * FROM nlr12months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr12months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR12monthsInformation
                            NLR12months nlr12monthsInfo = new NLR12months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr12monthsList.Add(nlr12monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr12monthsList"] = nlr12monthsList;
                        ViewData["nlr12monthsListCount"] = nlr12monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr12monthsInformation ***********//
                //************************************************* Start nlr24monthsInformation ***********//
                string query_uid_nlr24months = $"SELECT * FROM nlr24months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr24months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR24monthsInformation
                            NLR24months nlr24monthsInfo = new NLR24months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr24monthsList.Add(nlr24monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr24monthsList"] = nlr24monthsList;
                        ViewData["nlr24monthsListCount"] = nlr24monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr24monthsInformation ***********//
                //************************************************* Start nlr36monthsInformation ***********//
                string query_uid_nlr36months = $"SELECT * FROM nlr36months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr36months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR36monthsInformation
                            NLR36months nlr36monthsInfo = new NLR36months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr36monthsList.Add(nlr36monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr36monthsList"] = nlr36monthsList;
                        ViewData["nlr36monthsListCount"] = nlr36monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr36monthsInformation ***********//

                //************************************************* Start EnquiryInformation ***********//
                string query_uid_enquiryHistoryInfo = $"SELECT * FROM enquiryhistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_enquiryHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //EnquiryhistoryInformation
                            EnquiryHistory EnquiryHistoryInfo = new EnquiryHistory();

                            int EnquiryDate = reader.GetOrdinal("EnquiryDate");
                            int EnquiredBy = reader.GetOrdinal("EnquiredBy");
                            int EnquiredByContact = reader.GetOrdinal("EnquiredByContact");
                            int EnquiredByType = reader.GetOrdinal("EnquiredByType");
                            int ReasonForEnquiry = reader.GetOrdinal("ReasonForEnquiry");
                            while (reader.Read())
                            {
                                EnquiryHistoryInfo.EnquiryDate = (reader[EnquiryDate] != Convert.DBNull) ? reader[EnquiryDate].ToString() : null;
                                EnquiryHistoryInfo.EnquiredBy = (reader[EnquiredBy] != Convert.DBNull) ? reader[EnquiredBy].ToString() : null;
                                EnquiryHistoryInfo.EnquiredByContact = (reader[EnquiredByContact] != Convert.DBNull) ? reader[EnquiredByContact].ToString() : null;
                                EnquiryHistoryInfo.EnquiredByType = (reader[EnquiredByType] != Convert.DBNull) ? reader[EnquiredByType].ToString() : null;
                                EnquiryHistoryInfo.ReasonForEnquiry = (reader[ReasonForEnquiry] != Convert.DBNull) ? reader[ReasonForEnquiry].ToString() : null;

                                enquiryInformationList.Add(EnquiryHistoryInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["enquiryInformationList"] = enquiryInformationList;
                        ViewData["enquiryInformationListCount"] = enquiryInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End EnquiryInformation ***********//

                //************************************************* Start AddressHistoryInformation ***********//
                string query_uid_AddressHistoryInfo = $"SELECT * FROM addresshistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_AddressHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //addresshistoryInformation
                            AddressHistory AddressInfo = new AddressHistory();

                            int TypeDescription = reader.GetOrdinal("TypeDescription");
                            int Line1 = reader.GetOrdinal("Line1");
                            int Line2 = reader.GetOrdinal("Line2");
                            int Line3 = reader.GetOrdinal("Line3");
                            int PostalCode = reader.GetOrdinal("PostalCode");
                            int FullAddress = reader.GetOrdinal("FullAddress");
                            int AddressLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");
                            while (reader.Read())
                            {
                                AddressInfo.TypeDescription = (reader[TypeDescription] != Convert.DBNull) ? reader[TypeDescription].ToString() : null;
                                AddressInfo.Line1 = (reader[Line1] != Convert.DBNull) ? reader[Line1].ToString() : null;
                                AddressInfo.Line2 = (reader[Line2] != Convert.DBNull) ? reader[Line2].ToString() : null;
                                AddressInfo.Line3 = (reader[Line3] != Convert.DBNull) ? reader[Line3].ToString() : null;
                                AddressInfo.PostalCode = (reader[PostalCode] != Convert.DBNull) ? reader[PostalCode].ToString() : null;
                                AddressInfo.FullAddress = (reader[FullAddress] != Convert.DBNull) ? reader[FullAddress].ToString() : null;
                                AddressInfo.LastUpdatedDate = (reader[AddressLastUpdatedDate] != Convert.DBNull) ? reader[AddressLastUpdatedDate].ToString() : null;

                                addressInformationList.Add(AddressInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["addressInformationList"] = addressInformationList;
                        ViewData["addressInformationListCount"] = addressInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End AddressHistoryInformation ***********//

                //************************************************* Start TelephonehistoryInformation ***********//
                string query_uid_TelephoneHistoryInfo = $"SELECT * FROM telephonehistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_TelephoneHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //TelephoneHistoryInformation
                            TelephoneHistory TelephoneInfo = new TelephoneHistory();

                            // //Telephone History
                            int TypeDescriptionTel = reader.GetOrdinal("TypeDescriptionTel");
                            int DialCode = reader.GetOrdinal("DialCode");
                            int Number = reader.GetOrdinal("Number");
                            int FullNumber = reader.GetOrdinal("FullNumber");
                            int LastUpdatedDateTel = reader.GetOrdinal("LastUpdatedDateTel");

                            while (reader.Read())
                            {
                                TelephoneInfo.TypeDescriptionTel = (reader[TypeDescriptionTel] != Convert.DBNull) ? reader[TypeDescriptionTel].ToString() : null;
                                TelephoneInfo.DialCode = (reader[DialCode] != Convert.DBNull) ? reader[DialCode].ToString() : null;
                                TelephoneInfo.Number = (reader[Number] != Convert.DBNull) ? reader[Number].ToString() : null;
                                TelephoneInfo.FullNumber = (reader[FullNumber] != Convert.DBNull) ? reader[FullNumber].ToString() : null;
                                TelephoneInfo.LastUpdatedDateTel = (reader[LastUpdatedDateTel] != Convert.DBNull) ? reader[LastUpdatedDateTel].ToString() : null;

                                telephoneInformationList.Add(TelephoneInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["telephoneInformationList"] = telephoneInformationList;
                        ViewData["telephoneInformationListCount"] = telephoneInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End TelephonehistoryInformation***********//

                //************************************************* Start EmploymenthistoryInformation ***********//
                string query_uid_EmploymentHistoryInfo = $"SELECT * FROM employmenthistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_EmploymentHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //query_uid_EmploymentHistoryInformation
                            EmploymentHistory EmploymentInfo = new EmploymentHistory();

                            // EmploymentHistory
                            int EmployerName = reader.GetOrdinal("EmployerName");
                            int Designation = reader.GetOrdinal("Designation");
                            int EmployLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");

                            while (reader.Read())
                            {
                                EmploymentInfo.EmployerName = (reader[EmployerName] != Convert.DBNull) ? reader[EmployerName].ToString() : null;
                                EmploymentInfo.Designation = (reader[Designation] != Convert.DBNull) ? reader[Designation].ToString() : null;
                                EmploymentInfo.LastUpdatedDate = (reader[EmployLastUpdatedDate] != Convert.DBNull) ? reader[EmployLastUpdatedDate].ToString() : null;

                                employmentInformationList.Add(EmploymentInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["employmentInformationList"] = employmentInformationList;
                        ViewData["employmentInformationListCount"] = employmentInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End TelephonehistoryInformation***********//

                //************************************************* Start DirectorShipInformation ***********//
                string query_uid_DirectorShipInfo = $"SELECT * FROM directorships as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_DirectorShipInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DirectorshipInformation
                            Directorship DirectorshipInfo = new Directorship();

                            // DirectorshipHistory
                            int DesignationCode = reader.GetOrdinal("DesignationCode");
                            int AppointmentDate = reader.GetOrdinal("AppointmentDate");
                            int DirectorStatus = reader.GetOrdinal("DirectorStatus");
                            int DirectorStatusDate = reader.GetOrdinal("DirectorStatusDate");
                            int CompanyName = reader.GetOrdinal("CompanyName");
                            int CompanyType = reader.GetOrdinal("CompanyType");
                            int CompanyStatus = reader.GetOrdinal("CompanyStatus");
                            int CompanyStatusCode = reader.GetOrdinal("CompanyStatusCode");
                            int CompanyRegistrationNumber = reader.GetOrdinal("CompanyRegistrationNumber");
                            int CompanyRegistrationDate = reader.GetOrdinal("CompanyRegistrationDate");
                            int CompanyStartDate = reader.GetOrdinal("CompanyStartDate");
                            int CompanyTaxNumber = reader.GetOrdinal("CompanyTaxNumber");
                            int DirectorTypeCode = reader.GetOrdinal("DirectorTypeCode");
                            int DirectorType = reader.GetOrdinal("DirectorType");
                            int MemberSize = reader.GetOrdinal("MemberSize");
                            int MemberContribution = reader.GetOrdinal("MemberContribution");
                            int MemberContributionType = reader.GetOrdinal("MemberContributionType");
                            int ResignationDate = reader.GetOrdinal("ResignationDate");

                            while (reader.Read())
                            {
                                DirectorshipInfo.DesignationCode = (reader[DesignationCode] != Convert.DBNull) ? reader[DesignationCode].ToString() : null;
                                DirectorshipInfo.AppointmentDate = (reader[AppointmentDate] != Convert.DBNull) ? reader[AppointmentDate].ToString() : null;
                                DirectorshipInfo.DirectorStatus = (reader[DirectorStatus] != Convert.DBNull) ? reader[DirectorStatus].ToString() : null;
                                DirectorshipInfo.DirectorStatusDate = (reader[DirectorStatusDate] != Convert.DBNull) ?
                                reader[DirectorStatusDate].ToString() : null; DirectorshipInfo.CompanyName =
                                (reader[CompanyName] != Convert.DBNull) ? reader[CompanyName].ToString() : null;
                                DirectorshipInfo.CompanyType = (reader[CompanyType] != Convert.DBNull) ?
                                reader[CompanyType].ToString() : null; DirectorshipInfo.CompanyStatus =
                                (reader[CompanyStatus] != Convert.DBNull) ? reader[CompanyStatus].ToString() : null;
                                DirectorshipInfo.CompanyStatusCode = (reader[CompanyStatusCode] != Convert.DBNull) ?
                                reader[CompanyStatusCode].ToString() : null; DirectorshipInfo.CompanyRegistrationNumber
                                = (reader[CompanyRegistrationNumber] != Convert.DBNull) ?
                                reader[CompanyRegistrationNumber].ToString() : null;
                                DirectorshipInfo.CompanyRegistrationDate = (reader[CompanyRegistrationDate] !=
                                Convert.DBNull) ? reader[CompanyRegistrationDate].ToString() : null;
                                DirectorshipInfo.CompanyStartDate = (reader[CompanyStartDate] != Convert.DBNull) ?
                                reader[CompanyStartDate].ToString() : null; DirectorshipInfo.CompanyTaxNumber =
                                (reader[CompanyTaxNumber] != Convert.DBNull) ? reader[CompanyTaxNumber].ToString() :
                                null; DirectorshipInfo.DirectorTypeCode = (reader[DirectorTypeCode] != Convert.DBNull) ?
                                reader[DirectorTypeCode].ToString() : null; DirectorshipInfo.DirectorType =
                                (reader[DirectorType] != Convert.DBNull) ? reader[DirectorType].ToString() : null;
                                DirectorshipInfo.MemberSize = (reader[MemberSize] != Convert.DBNull) ?
                                reader[MemberSize].ToString() : null; DirectorshipInfo.MemberContribution =
                                (reader[MemberContribution] != Convert.DBNull) ? reader[MemberContribution].ToString()
                                : null; DirectorshipInfo.MemberContributionType = (reader[MemberContributionType] !=
                                Convert.DBNull) ? reader[MemberContributionType].ToString() : null;
                                DirectorshipInfo.ResignationDate = (reader[ResignationDate] != Convert.DBNull) ?
                                reader[ResignationDate].ToString() : null;

                                directorshipList.Add(DirectorshipInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["directorshipList"] = directorshipList;
                        ViewData["directorshipListCount"] = directorshipList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End DirectorShipInformation***********//
                //************************************************* Start CPAAccountsInformation***********//

                string query_uid_cppaAccountsInfo = $"SELECT * FROM cpa_accounts as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cppaAccountsInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CPAInformation
                            CPAaccounts cppaAccounts = new CPAaccounts();

                            int Account_ID = reader.GetOrdinal("Account_ID");
                            int SubscriberCode = reader.GetOrdinal("SubscriberCode");
                            int SubscriberName = reader.GetOrdinal("SubscriberName");
                            int AccountNO = reader.GetOrdinal("AccountNO");
                            int SubAccountNO = reader.GetOrdinal("SubAccountNO");
                            int OwnershipType = reader.GetOrdinal("OwnershipType");
                            int OwnershipTypeDescription = reader.GetOrdinal("OwnershipTypeDescription");
                            int Reason = reader.GetOrdinal("Reason");
                            int ReasonDescription = reader.GetOrdinal("ReasonDescription");
                            int PaymentType = reader.GetOrdinal("PaymentType");
                            int PaymentTypeDescription = reader.GetOrdinal("PaymentTypeDescription");
                            int AccountType = reader.GetOrdinal("AccountType");
                            int AccountTypeDescription = reader.GetOrdinal("AccountTypeDescription");
                            int OpenDate = reader.GetOrdinal("OpenDate");
                            int DeferredPaymentDate = reader.GetOrdinal("DeferredPaymentDate");
                            int LastPaymentDate = reader.GetOrdinal("LastPaymentDate");
                            int OpenBalance = reader.GetOrdinal("OpenBalance");
                            int OpenBalanceIND = reader.GetOrdinal("OpenBalanceIND");
                            int CurrentBalance = reader.GetOrdinal("CurrentBalance");
                            int CurrentBalanceIND = reader.GetOrdinal("CurrentBalanceIND");
                            int OverdueAmount = reader.GetOrdinal("OverdueAmount");
                            int OverdueAmountIND = reader.GetOrdinal("OverdueAmountIND");
                            int InstalmentAmount = reader.GetOrdinal("InstalmentAmount");
                            int ArrearsPeriod = reader.GetOrdinal("ArrearsPeriod");
                            int RepaymentFrequency = reader.GetOrdinal("RepaymentFrequency");
                            int RepaymentFrequencyDescription = reader.GetOrdinal("RepaymentFrequencyDescription");
                            int Terms = reader.GetOrdinal("Terms");
                            int StatusCode = reader.GetOrdinal("StatusCode");
                            int StatusCodeDesc = reader.GetOrdinal("StatusCodeDesc");
                            int IndustryType = reader.GetOrdinal("IndustryType");
                            int PaymentHistoryChartURL = reader.GetOrdinal("PaymentHistoryChartURL");
                            int StatusDate = reader.GetOrdinal("StatusDate");
                            int ThirdPartyName = reader.GetOrdinal("ThirdPartyName");
                            int ThirdPartySold = reader.GetOrdinal("ThirdPartySold");
                            int ThirdPartySoldDescription = reader.GetOrdinal("ThirdPartySoldDescription");
                            int JointLoanParticipants = reader.GetOrdinal("JointLoanParticipants");
                            int PaymentHistory = reader.GetOrdinal("PaymentHistory");
                            int PaymentHistoryStatus = reader.GetOrdinal("PaymentHistoryStatus");
                            int PaymentHistoryChart = reader.GetOrdinal("PaymentHistoryChart");
                            int MonthEndDate = reader.GetOrdinal("MonthEndDate");
                            int DateCreated = reader.GetOrdinal("DateCreated");
                            //Fetch PaymenyHistory Array
                            //public string PaymentHistoryChartURL = reader.GetOrdonal("");
                            //public Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails = reader.GetOrdonal("");
                            // CPAInformation

                            while (reader.Read())
                            {
                                cppaAccounts.Account_ID = (reader[Account_ID] != Convert.DBNull) ? reader[Account_ID].ToString() : null;
                                cppaAccounts.SubscriberCode = (reader[SubscriberCode] != Convert.DBNull) ? reader[SubscriberCode].ToString() : null;
                                cppaAccounts.SubscriberName = (reader[SubscriberName] != Convert.DBNull) ? reader[SubscriberName].ToString() : null;
                                cppaAccounts.AccountNO = (reader[AccountNO] != Convert.DBNull) ? reader[AccountNO].ToString() : null;
                                cppaAccounts.SubAccountNO = (reader[SubAccountNO] != Convert.DBNull) ? reader[SubAccountNO].ToString() : null;
                                cppaAccounts.OwnershipType = (reader[OwnershipType] != Convert.DBNull) ? reader[OwnershipType].ToString() : null;
                                cppaAccounts.OwnershipTypeDescription = (reader[OwnershipTypeDescription] != Convert.DBNull) ? reader[OwnershipTypeDescription].ToString() : null;
                                cppaAccounts.Reason = (reader[Reason] != Convert.DBNull) ? reader[Reason].ToString() : null;
                                cppaAccounts.ReasonDescription = (reader[ReasonDescription] != Convert.DBNull) ? reader[ReasonDescription].ToString() : null;
                                cppaAccounts.PaymentType = (reader[PaymentType] != Convert.DBNull) ? reader[PaymentType].ToString() : null;
                                cppaAccounts.PaymentTypeDescription = (reader[PaymentTypeDescription] != Convert.DBNull) ? reader[PaymentTypeDescription].ToString() : null;
                                cppaAccounts.AccountType = (reader[AccountType] != Convert.DBNull) ? reader[AccountType].ToString() : null;
                                cppaAccounts.AccountTypeDescription = (reader[AccountTypeDescription] != Convert.DBNull) ? reader[AccountTypeDescription].ToString() : null;
                                cppaAccounts.OpenDate = (reader[OpenDate] != Convert.DBNull) ? reader[OpenDate].ToString() : null;
                                cppaAccounts.DeferredPaymentDate = (reader[DeferredPaymentDate] != Convert.DBNull) ? reader[DeferredPaymentDate].ToString() : null;
                                cppaAccounts.LastPaymentDate = (reader[LastPaymentDate] != Convert.DBNull) ? reader[LastPaymentDate].ToString() : null;
                                cppaAccounts.OpenBalance = (reader[OpenBalance] != Convert.DBNull) ? reader[OpenBalance].ToString() : null;
                                cppaAccounts.OpenBalanceIND = (reader[OpenBalanceIND] != Convert.DBNull) ? reader[OpenBalanceIND].ToString() : null;
                                cppaAccounts.CurrentBalance = (reader[CurrentBalance] != Convert.DBNull) ? reader[CurrentBalance].ToString() : null;
                                cppaAccounts.CurrentBalanceIND = (reader[CurrentBalanceIND] != Convert.DBNull) ? reader[CurrentBalanceIND].ToString() : null;
                                cppaAccounts.OverdueAmount = (reader[OverdueAmount] != Convert.DBNull) ? reader[OverdueAmount].ToString() : null;
                                cppaAccounts.OverdueAmountIND = (reader[OverdueAmountIND] != Convert.DBNull) ? reader[OverdueAmountIND].ToString() : null;
                                cppaAccounts.InstalmentAmount = (reader[InstalmentAmount] != Convert.DBNull) ? reader[InstalmentAmount].ToString() : null;
                                cppaAccounts.ArrearsPeriod = (reader[ArrearsPeriod] != Convert.DBNull) ? reader[ArrearsPeriod].ToString() : null;
                                cppaAccounts.RepaymentFrequency = (reader[RepaymentFrequency] != Convert.DBNull) ? reader[RepaymentFrequency].ToString() : null;
                                cppaAccounts.RepaymentFrequencyDescription = (reader[RepaymentFrequencyDescription] != Convert.DBNull) ? reader[RepaymentFrequencyDescription].ToString() : null;
                                cppaAccounts.Terms = (reader[Terms] != Convert.DBNull) ? reader[Terms].ToString() : null;
                                cppaAccounts.StatusCode = (reader[StatusCode] != Convert.DBNull) ? reader[StatusCode].ToString() : null;
                                cppaAccounts.StatusCodeDesc = (reader[StatusCodeDesc] != Convert.DBNull) ? reader[StatusCodeDesc].ToString() : null;
                                cppaAccounts.IndustryType = (reader[IndustryType] != Convert.DBNull) ? reader[IndustryType].ToString() : null;
                                cppaAccounts.PaymentHistoryChartURL = (reader[PaymentHistoryChartURL] != Convert.DBNull) ? reader[PaymentHistoryChartURL].ToString() : null;
                                cppaAccounts.StatusDate = (reader[StatusDate] != Convert.DBNull) ? reader[StatusDate].ToString() : null;
                                cppaAccounts.ThirdPartyName = (reader[ThirdPartyName] != Convert.DBNull) ? reader[ThirdPartyName].ToString() : null;
                                cppaAccounts.ThirdPartySold = (reader[ThirdPartySold] != Convert.DBNull) ? reader[ThirdPartySold].ToString() : null;
                                cppaAccounts.ThirdPartySoldDescription = (reader[ThirdPartySoldDescription] != Convert.DBNull) ? reader[ThirdPartySoldDescription].ToString() : null;
                                cppaAccounts.JointLoanParticipants = (reader[JointLoanParticipants] != Convert.DBNull) ? reader[JointLoanParticipants].ToString() : null;
                                cppaAccounts.PaymentHistory = (reader[PaymentHistory] != Convert.DBNull) ? reader[PaymentHistory].ToString() : null;
                                cppaAccounts.PaymentHistoryStatus = (reader[PaymentHistoryStatus] != Convert.DBNull) ? reader[PaymentHistoryStatus].ToString() : null;
                                cppaAccounts.PaymentHistoryChart = (reader[PaymentHistoryChart] != Convert.DBNull) ? reader[PaymentHistoryChart].ToString() : null;
                                cppaAccounts.MonthEndDate = (reader[MonthEndDate] != Convert.DBNull) ? reader[MonthEndDate].ToString() : null;
                                cppaAccounts.DateCreated = (reader[DateCreated] != Convert.DBNull) ? reader[DateCreated].ToString() : null;

                                //Read PaymentHistoryAccountDetails

                                cppaAccountsList.Add(cppaAccounts);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cppaAccountsList"] = cppaAccountsList;
                        ViewData["cppaAccountsList"] = cppaAccountsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CPAAccountsInformation***********//
            }
            return View();
        }

        public ActionResult TransUnionConsumerProfile()
        {
            return View();
        }

        public ActionResult TransUnionConsumerProfileResults(TransUnion trans)
        {
            string id = trans.IDNumber != null ? trans.IDNumber.Trim() : null;
            string conName = trans.ContactName != null ? trans.ContactName.Trim() : null;
            string conNumber = trans.ContactNumber != null ? trans.ContactNumber.Trim() : null;
            string enquiryReason = trans.EnquiryReason != null ? trans.EnquiryReason.Trim() : null;
            string surname = trans.Surname != null ? trans.Surname.Trim() : null;
            string firstName = trans.FirstName != null ? trans.FirstName.Trim() : null;
            string passport = trans.PassportNumber != null ? trans.PassportNumber.Trim() : null;
            string dob = trans.DateOfBirth != null ? trans.DateOfBirth.Trim() : null;
            string refe = trans.Reference != null ? trans.Reference.Trim() : null;
            try
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "TransUnion Consumer ID Verification";
                string action = "ID: " + id + "; First Name: " + firstName + "; Surname: " + surname + "; Contact Name: " + conName + "; Contact Number: " + conNumber + "; Passport Number: " + passport + "; Date Of Birth: " + dob;
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
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
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

                System.Diagnostics.Debug.WriteLine(o);
                //Save Search Information To Database
                int SearchID = rootObject.ResponseObject.SearchInformation.SearchID;
                string SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName;
                string ReportDate = rootObject.ResponseObject.SearchInformation.ReportDate;
                string ResponseType = rootObject.ResponseMessage;
                string Name = TempData["user"].ToString();
                string Reference = rootObject.ResponseObject.SearchInformation.Reference;
                string SearchToken = rootObject.ResponseObject.SearchInformation.SearchToken;
                string CallerModule = rootObject.ResponseObject.SearchInformation.CallerModule;
                string DataSupplier = rootObject.ResponseObject.SearchInformation.DataSupplier;
                string SearchType = rootObject.ResponseObject.SearchInformation.SearchType;
                string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, TempData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionConsumerProfile");
                //PersonalInfroamtion
                {
                    ViewData["AkaName"] = "-";
                    ViewData["ConsumerID"] = "-";

                    JToken AlsoKnownAsExists = rootObject.ResponseObject.PersonInformation["AlsoKnownAs"];
                    if (AlsoKnownAsExists != null)
                    {
                        ViewData["AkaName"] = rootObject.ResponseObject.PersonInformation.AlsoKnownAs[0].AkaName;//Add in Database
                        ViewData["ConsumerID"] = rootObject.ResponseObject.PersonInformation.AlsoKnownAs[0].ConsumerID;//Add in Database
                    }

                    ViewData["InformationDate"] = rootObject.ResponseObject.PersonInformation.InformationDate;
                    ViewData["PersonID"] = rootObject.ResponseObject.PersonInformation.PersonID;
                    ViewData["PersonTitle"] = rootObject.ResponseObject.PersonInformation.Title;
                    ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                    ViewData["IDNumber_Alternate"] = rootObject.ResponseObject.PersonInformation.IDNumber_Alternate;
                    ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
                    ViewData["MiddleName1"] = rootObject.ResponseObject.PersonInformation.MiddleName1;
                    ViewData["MiddleName2"] = rootObject.ResponseObject.PersonInformation.MiddleName2;
                    ViewData["NumberOfDependants"] = rootObject.ResponseObject.PersonInformation.NumberOfDependants;
                    ViewData["Remarks"] = rootObject.ResponseObject.PersonInformation.Remarks;
                    ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                    ViewData["SpouseFirstName"] = rootObject.ResponseObject.PersonInformation.SpouseFirstName;
                    ViewData["SpouseSurname"] = rootObject.ResponseObject.PersonInformation.SpouseSurname;
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

                    savePersonInformation(SearchToken, Reference, SearchID,
                        rootObject.ResponseObject.PersonInformation.InformationDate,
                        rootObject.ResponseObject.PersonInformation.PersonID,
                        rootObject.ResponseObject.PersonInformation.Title,
                        rootObject.ResponseObject.PersonInformation.DateOfBirth,
                        rootObject.ResponseObject.PersonInformation.FirstName,
                        rootObject.ResponseObject.PersonInformation.Surname,
                        rootObject.ResponseObject.PersonInformation.Fullname,
                        rootObject.ResponseObject.PersonInformation.IDNumber,
                        rootObject.ResponseObject.PersonInformation.IDNumber_Alternate,
                        rootObject.ResponseObject.PersonInformation.PassportNumber,
                        rootObject.ResponseObject.PersonInformation.Reference,
                        rootObject.ResponseObject.PersonInformation.MaritalStatus,
                        rootObject.ResponseObject.PersonInformation.Gender,
                        rootObject.ResponseObject.PersonInformation.Age,
                        rootObject.ResponseObject.PersonInformation.MiddleName1,
                        rootObject.ResponseObject.PersonInformation.MiddleName2,
                        rootObject.ResponseObject.PersonInformation.SpouseFirstName,
                        rootObject.ResponseObject.PersonInformation.SpouseSurname,
                        rootObject.ResponseObject.PersonInformation.NumberOfDependants,
                        rootObject.ResponseObject.PersonInformation.Remarks,
                        rootObject.ResponseObject.PersonInformation.CurrentEmployer,
                        rootObject.ResponseObject.PersonInformation.VerificationStatus,
                        rootObject.ResponseObject.PersonInformation.HasProperties, "TransUnionConsumerProfile");
                }
                //HomeAffairsInformation
                {
                    ViewData["FirstName"] = rootObject.ResponseObject.HomeAffairsInformation.FirstName;
                    ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
                    ViewData["IDVerified"] = rootObject.ResponseObject.HomeAffairsInformation.IDVerified;
                    ViewData["SurnameVerified"] = rootObject.ResponseObject.HomeAffairsInformation.SurnameVerified;
                    ViewData["Warnings"] = rootObject.ResponseObject.HomeAffairsInformation.Warnings;
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
                        rootObject.ResponseObject.HomeAffairsInformation.VerifiedDate,
                        "TransUnionConsumerProfile");
                }
                //CreditInformation
                {
                    JToken CreditInfoExists = rootObject.ResponseObject["CreditInformation"];
                    ViewData["EnqHIst"] = null;

                    if (CreditInfoExists != null)
                    {
                        //CreditInformation DataCounts
                        JToken DataCountssExists = rootObject.ResponseObject.CreditInformation["DataCounts"];
                        if (DataCountssExists != null)
                        {
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
                            ViewData["Bonds"] = rootObject.ResponseObject.CreditInformation.DataCounts.Bonds;
                            ViewData["PublicDefaults"] = rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults;
                            ViewData["NLRAccounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts;
                            saveDataCounts(SearchToken, Reference, SearchID,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Accounts,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Enquiries,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Judgments,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Notices,
                                rootObject.ResponseObject.CreditInformation.DataCounts.BankDefaults,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Defaults,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Collections,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Directors,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Addresses,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Telephones,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Occupants,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Employers,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.TraceAlerts,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.PaymentProfiles,
                                rootObject.ResponseObject.CreditInformation.DataCounts.OwnEnquiries,
                                rootObject.ResponseObject.CreditInformation.DataCounts.AdminOrders,
                                rootObject.ResponseObject.CreditInformation.DataCounts.PossibleMatches,
                                rootObject.ResponseObject.CreditInformation.DataCounts.DefiniteMatches,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Loans,
                                rootObject.ResponseObject.CreditInformation.DataCounts.FraudAlerts,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Companies,
                                 rootObject.ResponseObject.CreditInformation.DataCounts.Properties,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Documents,
                                rootObject.ResponseObject.CreditInformation.DataCounts.DemandLetters,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Trusts,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Bonds,
                                rootObject.ResponseObject.CreditInformation.DataCounts.Deeds,
                                rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults,
                                rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts,
                                "TransUnionConsumerProfile");
                        }

                        //DebtReviewStatus
                        JToken DebtReviewStatusExists = rootObject.ResponseObject["DebtReviewStatus"];
                        if (DebtReviewStatusExists != null)
                        {
                            ViewData["StatusDate"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDate;
                            ViewData["StatusDescription"] = rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription;
                            saveDebtReviewStatus(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusCode,
                                rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDate,
                                rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription,
                                rootObject.ResponseObject.CreditInformation.DebtReviewStatus.ApplicationDate, "TransUnionConsumerProfile");
                        }

                        JToken EnquiryExists = rootObject.ResponseObject["CreditInformation"].EnquiryHistory;
                        if (EnquiryExists != null)
                        {
                            List<EnquiryHistory> EnqHIst;
                            Newtonsoft.Json.Linq.JArray elements = new Newtonsoft.Json.Linq.JArray();
                            elements = rootObject.ResponseObject.CreditInformation.EnquiryHistory;

                            EnqHIst = new List<EnquiryHistory>();
                            for (int count = 0; count < (elements.Count); count++)
                            {
                                EnqHIst.Add(new EnquiryHistory
                                {
                                    EnquiryDate = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate,
                                    EnquiredBy = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy,
                                    EnquiredByContact = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact,
                                    EnquiredByType = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByType,
                                    ReasonForEnquiry = rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].ReasonForEnquiry
                                });
                                saveEnquiryHistory(SearchToken, Reference, SearchID,
                                     rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiryDate,
                                     rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredBy,
                                     rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByContact,
                                    rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].EnquiredByType,
                                     rootObject.ResponseObject.CreditInformation.EnquiryHistory[count].ReasonForEnquiry,
                                    "TransUnionConsumerProfile");
                            }
                            ViewData["EnqHIst"] = EnqHIst;
                        }
                    }
                }
                //HistoricalInformation
                {
                    JToken HistoricalInformationExists = rootObject.ResponseObject["HistoricalInformation"];

                    ViewData["AddressHist"] = null;
                    ViewData["EmpHist"] = null;
                    ViewData["TelHist"] = null;

                    if (HistoricalInformationExists != null)
                    {
                        JToken AddressExists = rootObject.ResponseObject["HistoricalInformation"].AddressHistory;
                        if (AddressExists != null)
                        {
                            List<AddressHistory> AddressHist;
                            Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
                            elements1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory;

                            AddressHist = new List<AddressHistory>();

                            for (int count = 0; count < (elements1.Count); count++)
                            {
                                AddressHist.Add(new AddressHistory
                                {
                                    TypeDescription = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription,
                                    Line1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1,
                                    Line2 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2,
                                    Line3 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3,
                                    Line4 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line4,
                                    PostalCode = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode,
                                    FullAddress = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress,
                                    LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                                });
                                saveAddressHistory(SearchToken, Reference, SearchID, null, rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line4,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode,
                                    rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress,
                                   rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate, "TransUnionConsumerProfile");
                            }
                            ViewData["AddressHist"] = AddressHist;
                        }
                        JToken TelephoneExists = rootObject.ResponseObject["HistoricalInformation"].TelephoneHistory;
                        if (TelephoneExists != null)
                        {
                            List<TelephoneHistory> TelHist;
                            Newtonsoft.Json.Linq.JArray elements2 = new Newtonsoft.Json.Linq.JArray();

                            elements2 = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;

                            TelHist = new List<TelephoneHistory>();
                            for (int count = 0; count < (elements2.Count); count++)
                            {
                                TelHist.Add(new TelephoneHistory
                                {
                                    TypeDescriptionTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                    DialCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode,
                                    Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number,
                                    FullNumber = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                    LastUpdatedDateTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDateTel,
                                });
                                saveTelephoneHistory(SearchToken, Reference, SearchID, rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode,
                                    null, rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription, null,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDate, "TransUnionConsumerProfile");
                            }
                            ViewData["TelHist"] = TelHist;
                        }
                        JToken EmploymentExists = rootObject.ResponseObject["HistoricalInformation"].EmploymentHistory;
                        if (EmploymentExists != null)
                        {
                            List<EmploymentHistory> EmpHist;
                            EmpHist = new List<EmploymentHistory>();
                            Newtonsoft.Json.Linq.JArray elements3 = new Newtonsoft.Json.Linq.JArray();
                            elements3 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;

                            for (int count = 0; count < (elements3.Count); count++)
                            {
                                EmpHist.Add(new EmploymentHistory
                                {
                                    EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                    Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation,
                                });
                                saveEmploymentHistory(SearchToken, Reference, SearchID, rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                    rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation, null, "TransUnionConsumerProfile");
                            }

                            ViewData["EmpHist"] = EmpHist;
                        }
                    }
                }
                //InternalInquiryHistory
                {
                    JToken InternalEnquiryExists = rootObject.ResponseObject["InternalEnquiryHistory"];
                    if (InternalEnquiryExists != null)
                    {
                        List<InternalEnquiryHistory> IntEnqHistory;
                        Newtonsoft.Json.Linq.JArray elements5 = new Newtonsoft.Json.Linq.JArray();

                        elements5 = rootObject.ResponseObject.InternalEnquiryHistory;

                        IntEnqHistory = new List<InternalEnquiryHistory>();

                        for (int count = 0; count < (elements5.Count); count++)
                        {
                            IntEnqHistory.Add(new InternalEnquiryHistory
                            {
                                CompanyName = rootObject.ResponseObject.InternalEnquiryHistory[count].CompanyName,
                                IntEnquiryDate = rootObject.ResponseObject.InternalEnquiryHistory[count].IntEnquiryDate,
                                ContactPerson = rootObject.ResponseObject.InternalEnquiryHistory[count].ContactPerson,
                                PhoneNumber = rootObject.ResponseObject.InternalEnquiryHistory[count].PhoneNumber,
                                EmailAddress = rootObject.ResponseObject.InternalEnquiryHistory[count].EmailAddress,
                            });
                            saveEnquiryHistory(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.InternalEnquiryHistory[count].IntEnquiryDate,
                               rootObject.ResponseObject.InternalEnquiryHistory[count].CompanyName,
                               rootObject.ResponseObject.InternalEnquiryHistory[count].ContactPerson,
                               rootObject.ResponseObject.InternalEnquiryHistory[count].EmailAddress, null, "TransUnionConsumerProfile");
                        }
                        ViewData["IntEnqHistory"] = IntEnqHistory;
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.ToString());

                TempData["msg"] = "Error Occured, Please verify the details that have been entered. ";
                return View();
            }

            return View();
        }

        public ActionResult TransUnionConsumerProfileDatabase(DatabaseSearch DbSearch)
        {
            System.Collections.Generic.List<PersonInformation> personInfoList = new System.Collections.Generic.List<PersonInformation>();
            System.Collections.Generic.List<HomeAffairsInformation> homeAffairsInformationList = new System.Collections.Generic.List<HomeAffairsInformation>();
            System.Collections.Generic.List<CreditInformation> creditInformationList = new System.Collections.Generic.List<CreditInformation>();
            System.Collections.Generic.List<DataCounts> dataCountsList = new System.Collections.Generic.List<DataCounts>();
            System.Collections.Generic.List<DebtReviewStatus> debtReviewStatusList = new System.Collections.Generic.List<DebtReviewStatus>();
            System.Collections.Generic.List<ConsumerStatistics> consumerstatsList = new System.Collections.Generic.List<ConsumerStatistics>();
            System.Collections.Generic.List<NLRStats> nlrstatsList = new System.Collections.Generic.List<NLRStats>();
            System.Collections.Generic.List<CCAStats> ccastatsList = new System.Collections.Generic.List<CCAStats>();
            System.Collections.Generic.List<CCA12months> cca12monthsList = new System.Collections.Generic.List<CCA12months>();
            System.Collections.Generic.List<CCA24months> cca24monthsList = new System.Collections.Generic.List<CCA24months>();
            System.Collections.Generic.List<CCA36months> cca36monthsList = new System.Collections.Generic.List<CCA36months>();
            System.Collections.Generic.List<NLR12months> nlr12monthsList = new System.Collections.Generic.List<NLR12months>();
            System.Collections.Generic.List<NLR24months> nlr24monthsList = new System.Collections.Generic.List<NLR24months>();
            System.Collections.Generic.List<NLR36months> nlr36monthsList = new System.Collections.Generic.List<NLR36months>();
            System.Collections.Generic.List<EnquiryHistory> enquiryInformationList = new System.Collections.Generic.List<EnquiryHistory>();
            System.Collections.Generic.List<InternalEnquiryHistory> InternalEnqHistoryList = new System.Collections.Generic.List<InternalEnquiryHistory>();
            System.Collections.Generic.List<AddressHistory> addressInformationList = new System.Collections.Generic.List<AddressHistory>();
            System.Collections.Generic.List<EmploymentHistory> employmentInformationList = new System.Collections.Generic.List<EmploymentHistory>();
            System.Collections.Generic.List<TelephoneHistory> telephoneInformationList = new System.Collections.Generic.List<TelephoneHistory>();
            System.Collections.Generic.List<CPAaccounts> cppaAccountsList = new System.Collections.Generic.List<CPAaccounts>();
            //System.Collections.Generic.List<PaymentHistoryAccountDetails> paymentHistoryAccountList = new System.Collections.Generic.List<PaymentHistoryAccountDetails>();
            System.Collections.Generic.List<Directorship> directorshipList = new System.Collections.Generic.List<Directorship>();

            //AND SearchToken = 'cc329011-76c8-4c8c-9ff6-4b5ce6c05d13' AND Reference = 'devadmin@ktopportunities.co.za' AND typeOfSearch = 'ExperianConsumerProfile'
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
                                                                                                                   //string query_uid = $"SELECT * FROM personinformation,homeaffairsinformation,creditinformation,datacounts,debtreviewstatus,addresshistory,telephonehistory,consumerstatistics,nlrstats,ccastats,cca12months,cca24months,cca36months,enquiryhistory,employmenthistory,months,months,nlr36months,cpa_accounts WHERE personinformation.SearchToken = '{DbSearch.token}'";
                                                                                                                   //Add TABLE paymenthistoryaccountdetails!!!!

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString))
            {
                conn.Open();

                //************************************************* Start personal info ***********//
                string query_uid_personinformation = $"SELECT * FROM personinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_personinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            int DateOfBirth = reader.GetOrdinal("DateOfBirth");
                            int Title = reader.GetOrdinal("Title");
                            int FirstName = reader.GetOrdinal("FirstName");
                            int Surname = reader.GetOrdinal("Surname");
                            int Fullname = reader.GetOrdinal("Fullname");
                            int IDNumber = reader.GetOrdinal("IDNumber");
                            int Gender = reader.GetOrdinal("Gender");
                            int Age = reader.GetOrdinal("Age");
                            int MaritalStatus = reader.GetOrdinal("MaritalStatus");
                            int MiddleName1 = reader.GetOrdinal("MiddleName1");
                            int Reference = reader.GetOrdinal("Ref");
                            int HasProperties = reader.GetOrdinal("HasProperties");

                            //PersonInformation
                            while (reader.Read())
                            {
                                PersonInformation personInformation = new PersonInformation();
                                personInformation.DateOfBirth = (reader[DateOfBirth] != Convert.DBNull) ? reader[DateOfBirth].ToString() : null;
                                personInformation.Title = (reader[Title] != Convert.DBNull) ? reader[Title].ToString() : null;
                                personInformation.FirstName = (reader[FirstName] != Convert.DBNull) ? reader[FirstName].ToString() : null;
                                personInformation.Surname = (reader[Surname] != Convert.DBNull) ? reader[Surname].ToString() : null;
                                personInformation.Fullname = (reader[Fullname] != Convert.DBNull) ? reader[Fullname].ToString() : null;
                                personInformation.IDNumber = (reader[IDNumber] != Convert.DBNull) ? reader[IDNumber].ToString() : null;
                                personInformation.Gender = (reader[Gender] != Convert.DBNull) ? reader[Gender].ToString() : null;
                                personInformation.Age = (reader[Age] != Convert.DBNull) ? reader[Age].ToString() : null;
                                personInformation.MaritalStatus = (reader[MaritalStatus] != Convert.DBNull) ? reader[MaritalStatus].ToString() : null;
                                personInformation.MiddleName1 = (reader[MiddleName1] != Convert.DBNull) ? reader[MiddleName1].ToString() : null;
                                personInformation.Reference = (reader[Reference] != Convert.DBNull) ? reader[Reference].ToString() : null;
                                personInformation.HasProperties = (reader[HasProperties] != Convert.DBNull) ? Convert.ToBoolean(reader[HasProperties]) : false;
                                //add to the list
                                personInfoList.Add(personInformation);
                            }
                        }
                        ViewData["PersonInfoList"] = personInfoList;
                        ViewData["PersonInfoListCount"] = personInfoList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //*************************************************END personal info ***********//
                //************************************************* Start homeaffairsinformation info ***********//
                string query_uid_homeaffairsinformation = $"SELECT * FROM homeaffairsinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_homeaffairsinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //HomeAffairsInformation
                            HomeAffairsInformation homeAffairsInformation = new HomeAffairsInformation();
                            int ExFirstName = reader.GetOrdinal("FirstName");
                            int DeceasedDate = reader.GetOrdinal("DeceasedDate");
                            int IDVerified = reader.GetOrdinal("IDVerified");
                            int SurnameVerified = reader.GetOrdinal("SurnameVerified");
                            int Warnings = reader.GetOrdinal("Warnings");
                            int DeceasedStatus = reader.GetOrdinal("DeceasedStatus");
                            int VerifiedStatus = reader.GetOrdinal("VerifiedStatus");
                            int InitialsVerified = reader.GetOrdinal("InitialsVerified");
                            int CauseOfDeath = reader.GetOrdinal("CauseOfDeath");
                            int VerifiedDate = reader.GetOrdinal("VerifiedDate");
                            while (reader.Read())
                            {
                                homeAffairsInformation.FirstName = (reader[ExFirstName] != Convert.DBNull) ? reader[ExFirstName].ToString() : null;
                                homeAffairsInformation.IDVerified = (reader[IDVerified] != Convert.DBNull) ? reader[IDVerified].ToString() : null;
                                homeAffairsInformation.SurnameVerified = (reader[SurnameVerified] != Convert.DBNull) ? reader[SurnameVerified].ToString() : null;
                                homeAffairsInformation.Warnings = (reader[Warnings] != Convert.DBNull) ? reader[Warnings].ToString() : null;
                                homeAffairsInformation.DeceasedDate = (reader[DeceasedDate] != Convert.DBNull) ? reader[DeceasedDate].ToString() : null;
                                homeAffairsInformation.DeceasedStatus = (reader[DeceasedStatus] != Convert.DBNull) ? reader[DeceasedStatus].ToString() : null;
                                homeAffairsInformation.VerifiedStatus = (reader[VerifiedStatus] != Convert.DBNull) ? reader[VerifiedStatus].ToString() : null;
                                homeAffairsInformation.InitialsVerified = (reader[InitialsVerified] != Convert.DBNull) ? reader[InitialsVerified].ToString() : null;
                                homeAffairsInformation.CauseOfDeath = (reader[CauseOfDeath] != Convert.DBNull) ? reader[CauseOfDeath].ToString() : null;
                                homeAffairsInformation.VerifiedDate = (reader[VerifiedDate] != Convert.DBNull) ? reader[VerifiedDate].ToString() : null;
                                //add to the list
                                homeAffairsInformationList.Add(homeAffairsInformation);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["HomeAffairsInfoList"] = homeAffairsInformationList;
                        ViewData["HomeAffairsInfoListCount"] = homeAffairsInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* END homeaffairsinformation info ***********//
                //************************************************* Start CreditInformation info ***********//
                string query_uid_creditinformation = $"SELECT * FROM creditinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_creditinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CreditInformation
                            CreditInformation CreditInfo = new CreditInformation();

                            int DelphiScore = reader.GetOrdinal("DelphiScore");
                            int RiskColour = reader.GetOrdinal("RiskColour");
                            int DelphiScoreChartURL = reader.GetOrdinal("DelphiScoreChartURL");
                            while (reader.Read())
                            {
                                CreditInfo.DelphiScore = (reader[DelphiScore] != Convert.DBNull) ? reader[DelphiScore].ToString() : null;
                                CreditInfo.RiskColour = (reader[RiskColour] != Convert.DBNull) ? reader[RiskColour].ToString() : null;
                                CreditInfo.DelphiScoreChartURL = (reader[DelphiScoreChartURL] != Convert.DBNull) ? reader[DelphiScoreChartURL].ToString() : null;

                                //add to the list
                                creditInformationList.Add(CreditInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["creditInformationList"] = creditInformationList;
                        ViewData["creditInformationListCount"] = creditInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CreditInformation info ***********//
                //************************************************* StartDataCOunts info ***********//
                string query_uid_DataCOunts = $"SELECT * FROM datacounts as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_DataCOunts, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DataCountsInformation
                            DataCounts DataCountInfo = new DataCounts();

                            int Accounts = reader.GetOrdinal("Accounts");
                            int Enquiries = reader.GetOrdinal("Enquiries");
                            //int Judgements = reader.GetOrdinal("Judgements");
                            int Notices = reader.GetOrdinal("Notices");
                            int BankDefaults = reader.GetOrdinal("BankDefaults");
                            int Defaults = reader.GetOrdinal("Defaults");
                            int Collections = reader.GetOrdinal("Collections");
                            int Directors = reader.GetOrdinal("Directors");
                            int Addresses = reader.GetOrdinal("Addresses");
                            int Telephones = reader.GetOrdinal("Telephones");
                            int Occupants = reader.GetOrdinal("Occupants");
                            int Employers = reader.GetOrdinal("Employers");
                            int TraceAlerts = reader.GetOrdinal("TraceAlerts");
                            int PaymentProfiles = reader.GetOrdinal("PaymentProfiles");
                            int OwnEnquiries = reader.GetOrdinal("OwnEnquiries");
                            int AdminOrders = reader.GetOrdinal("AdminOrders");
                            int PossibleMatches = reader.GetOrdinal("PossibleMatches");
                            int DefiniteMatches = reader.GetOrdinal("DefiniteMatches");
                            int Loans = reader.GetOrdinal("Loans");
                            int FraudAlerts = reader.GetOrdinal("FraudAlerts");
                            int Companies = reader.GetOrdinal("Companies");
                            int Properties = reader.GetOrdinal("Properties");
                            int Documents = reader.GetOrdinal("Documents");
                            int DemandLetters = reader.GetOrdinal("DemandLetters");
                            int Trusts = reader.GetOrdinal("Trusts");
                            int Bonds = reader.GetOrdinal("Bonds");
                            int Deeds = reader.GetOrdinal("Deeds");
                            int PublicDefaults = reader.GetOrdinal("PublicDefaults");
                            int NLRAccounts = reader.GetOrdinal("NLRAccounts");
                            while (reader.Read())
                            {
                                DataCountInfo.Accounts = (reader[Accounts] != Convert.DBNull) ? reader[Accounts].ToString() : null;
                                DataCountInfo.Enquires = (reader[Enquiries] != Convert.DBNull) ? reader[Enquiries].ToString() : null;
                                //DataCountInfo.Judgements = (reader[Judgements] != Convert.DBNull) ? reader[Judgements].ToString() : null;
                                DataCountInfo.Notices = (reader[Notices] != Convert.DBNull) ?
                                reader[Notices].ToString() : null; DataCountInfo.BankDefaults =
                                (reader[BankDefaults] != Convert.DBNull) ? reader[BankDefaults].ToString() : null;
                                DataCountInfo.Defaults = (reader[Defaults] != Convert.DBNull) ?
                                reader[Defaults].ToString() : null; DataCountInfo.Collections =
                                (reader[Collections] != Convert.DBNull) ? reader[Collections].ToString() : null;
                                DataCountInfo.Directors = (reader[Directors] != Convert.DBNull) ?
                                reader[Directors].ToString() : null; DataCountInfo.Addresses = (reader[Addresses]
                                != Convert.DBNull) ? reader[Addresses].ToString() : null; DataCountInfo.Telephones =
                                (reader[Telephones] != Convert.DBNull) ? reader[Telephones].ToString() : null;
                                DataCountInfo.Occupants = (reader[Occupants] != Convert.DBNull) ?
                                reader[Occupants].ToString() : null; DataCountInfo.Employers = (reader[Employers]
                                != Convert.DBNull) ? reader[Employers].ToString() : null; DataCountInfo.TraceAlerts
                                = (reader[TraceAlerts] != Convert.DBNull) ? reader[TraceAlerts].ToString() : null;
                                DataCountInfo.PaymentProfiles = (reader[PaymentProfiles] != Convert.DBNull) ?
                                reader[PaymentProfiles].ToString() : null; DataCountInfo.OwnEnquiries =
                                (reader[OwnEnquiries] != Convert.DBNull) ? reader[OwnEnquiries].ToString() : null;
                                DataCountInfo.AdminOrders = (reader[AdminOrders] != Convert.DBNull) ?
                                reader[AdminOrders].ToString() : null; DataCountInfo.PossibleMatches =
                                (reader[PossibleMatches] != Convert.DBNull) ? reader[PossibleMatches].ToString() :
                                null; DataCountInfo.DefiniteMatches = (reader[DefiniteMatches] != Convert.DBNull) ?
                                reader[DefiniteMatches].ToString() : null; DataCountInfo.Loans = (reader[Loans] !=
                                Convert.DBNull) ? reader[Loans].ToString() : null; DataCountInfo.FraudAlerts =
                                (reader[FraudAlerts] != Convert.DBNull) ? reader[FraudAlerts].ToString() : null;
                                DataCountInfo.Companies = (reader[Companies] != Convert.DBNull) ?
                                reader[Companies].ToString() : null; DataCountInfo.Properties = (reader[Properties]
                                != Convert.DBNull) ? reader[Properties].ToString() : null; DataCountInfo.Documents =
                                (reader[Documents] != Convert.DBNull) ? reader[Documents].ToString() : null;
                                DataCountInfo.DemandLetters = (reader[DemandLetters] != Convert.DBNull) ?
                                reader[DemandLetters].ToString() : null; DataCountInfo.Trusts = (reader[Trusts] !=
                                Convert.DBNull) ? reader[Trusts].ToString() : null; DataCountInfo.Bonds =
                                (reader[Bonds] != Convert.DBNull) ? reader[Bonds].ToString() : null;
                                DataCountInfo.Deeds = (reader[Deeds] != Convert.DBNull) ? reader[Deeds].ToString()
                                : null; DataCountInfo.PublicDefaults = (reader[PublicDefaults] != Convert.DBNull) ?
                                reader[PublicDefaults].ToString() : null; DataCountInfo.NLRAccounts =
                                (reader[NLRAccounts] != Convert.DBNull) ? reader[NLRAccounts].ToString() : null;

                                dataCountsList.Add(DataCountInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["dataCountsList"] = dataCountsList;
                        ViewData["dataCountsListCount"] = dataCountsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }

                //************************************************* End DataCOunts info ***********//
                //************************************************* Start Debtreviewstatus info ***********//
                string query_uid_debtreviewstatus = $"SELECT * FROM debtreviewstatus as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_debtreviewstatus, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DebtReviewStatusInformation
                            DebtReviewStatus DebtReviewInfo = new DebtReviewStatus();

                            int StatusCode = reader.GetOrdinal("StatusCode");
                            int StatusDate = reader.GetOrdinal("StatusDate");
                            int StatusDescription = reader.GetOrdinal("StatusDescription");
                            int ApplicationDate = reader.GetOrdinal("ApplicationDate");
                            while (reader.Read())
                            {
                                DebtReviewInfo.StatusCode = (reader[StatusCode] != Convert.DBNull) ?
                                reader[StatusCode].ToString() : null; DebtReviewInfo.StatusDate =
                                (reader[StatusDate] != Convert.DBNull) ? reader[StatusDate].ToString() : null;
                                DebtReviewInfo.StatusDescription = (reader[StatusDescription] != Convert.DBNull) ?
                                reader[StatusDescription].ToString() : null; DebtReviewInfo.ApplicationDate =
                                (reader[ApplicationDate] != Convert.DBNull) ? reader[ApplicationDate].ToString() : null;

                                debtReviewStatusList.Add(DebtReviewInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["debtReviewStatusList"] = debtReviewStatusList;
                        ViewData["debtReviewStatusListCount"] = debtReviewStatusList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End DebtReviewStatus info ***********//
                //************************************************* Start ConsumerStatisticsInformation ***********//
                string query_uid_consumerStatistics = $"SELECT * FROM consumerstatistics as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_consumerStatistics, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //ConsumerStatisticsInformation
                            ConsumerStatistics ConsumerStatsInfo = new ConsumerStatistics();

                            int HighestJudgment = reader.GetOrdinal("HighestJudgment");
                            int RevolvingAccounts = reader.GetOrdinal("RevolvingAccounts");
                            int InstalmentAccounts = reader.GetOrdinal("InstalmentAccounts");
                            int OpenAccounts = reader.GetOrdinal("OpenAccounts");
                            int AdverseAccounts = reader.GetOrdinal("AdverseAccounts");
                            int Percent0ArrearsLast12Histories = reader.GetOrdinal("Percent0ArrearsLast12Histories");
                            int MonthsOldestOpenedPPSEver = reader.GetOrdinal("MonthsOldestOpenedPPSEver");
                            int NumberPPSLast12Months = reader.GetOrdinal("NumberPPSLast12Months");
                            int NLRMicroloansPast12Months = reader.GetOrdinal("NLRMicroloansPast12Months");
                            while (reader.Read())
                            {
                                ConsumerStatsInfo.HighestJudgment = (reader[HighestJudgment] != Convert.DBNull) ?
                                reader[HighestJudgment].ToString() : null; ConsumerStatsInfo.RevolvingAccounts =
                                (reader[RevolvingAccounts] != Convert.DBNull) ?
                                reader[RevolvingAccounts].ToString() : null; ConsumerStatsInfo.InstalmentAccounts =
                                (reader[InstalmentAccounts] != Convert.DBNull) ?
                                reader[InstalmentAccounts].ToString() : null; ConsumerStatsInfo.OpenAccounts =
                                (reader[OpenAccounts] != Convert.DBNull) ? reader[OpenAccounts].ToString() : null;
                                ConsumerStatsInfo.AdverseAccounts = (reader[AdverseAccounts] != Convert.DBNull) ?
                                reader[AdverseAccounts].ToString() : null;
                                ConsumerStatsInfo.Percent0ArrearsLast12Histories =
                                (reader[Percent0ArrearsLast12Histories] != Convert.DBNull) ?
                                reader[Percent0ArrearsLast12Histories].ToString() : null;
                                ConsumerStatsInfo.MonthsOldestOpenedPPSEver = (reader[MonthsOldestOpenedPPSEver] !=
                                Convert.DBNull) ? reader[MonthsOldestOpenedPPSEver].ToString() : null;
                                ConsumerStatsInfo.NumberPPSLast12Months = (reader[NumberPPSLast12Months] !=
                                Convert.DBNull) ? reader[NumberPPSLast12Months].ToString() : null;
                                ConsumerStatsInfo.NLRMicroloansPast12Months = (reader[NLRMicroloansPast12Months] !=
                                Convert.DBNull) ? reader[NLRMicroloansPast12Months].ToString() : null;

                                consumerstatsList.Add(ConsumerStatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["consumerstatsList"] = consumerstatsList;
                        ViewData["consumerstatsListCount"] = consumerstatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End ConsumerStatisticsInformation ***********//

                //************************************************* Start nlrstatsInformation ***********//
                string query_uid_nlrstats = $"SELECT * FROM nlrstats as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlrstats, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLRStatsInformation
                            NLRStats NLRStatsInfo = new NLRStats();

                            int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                            int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                            int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                            int WorstArrearsStatus = reader.GetOrdinal("WorstArrearsStatus");
                            int MonthlyInstalment = reader.GetOrdinal("MonthlyInstalment");
                            int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");
                            int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                            while (reader.Read())
                            {
                                NLRStatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;

                                NLRStatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                NLRStatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                NLRStatsInfo.WorstArrearsStatus = (reader[WorstArrearsStatus] != Convert.DBNull) ? reader[WorstArrearsStatus].ToString() : null;
                                NLRStatsInfo.MonthlyInstalment = (reader[MonthlyInstalment] != Convert.DBNull) ? reader[MonthlyInstalment].ToString() : null;
                                NLRStatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                NLRStatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                nlrstatsList.Add(NLRStatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlrstatsList"] = nlrstatsList;
                        ViewData["nlrstatsListCount"] = nlrstatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlrstatsInformation ***********//
                //************************************************* Start ccastatsInformation ***********//
                string query_uid_ccastats = $"SELECT * FROM ccastats as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_ccastats, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCAStatsInformation
                            CCAStats ccastatsInfo = new CCAStats();

                            int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                            int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                            int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                            int WorstArrearsStatus = reader.GetOrdinal("WorstArrearsStatus");
                            int MonthlyInstalment = reader.GetOrdinal("MonthlyInstalment");
                            int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");
                            int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                            while (reader.Read())
                            {
                                ccastatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;
                                ccastatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                ccastatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                ccastatsInfo.WorstArrearsStatus = (reader[WorstArrearsStatus] != Convert.DBNull) ? reader[WorstArrearsStatus].ToString() : null;
                                ccastatsInfo.MonthlyInstalment = (reader[MonthlyInstalment] != Convert.DBNull) ? reader[MonthlyInstalment].ToString() : null;
                                ccastatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                ccastatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                ccastatsList.Add(ccastatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["ccastatsList"] = ccastatsList;
                        ViewData["ccastatsListCount"] = ccastatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End ccastatsInformation ***********//
                //************************************************* Start cca12monthsInformation ***********//
                string query_uid_cca12months = $"SELECT * FROM cca12months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca12months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA12monthsInformation
                            CCA12months cca12monthsInfo = new CCA12months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca12monthsList.Add(cca12monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca12monthsList"] = cca12monthsList;
                        ViewData["cca12monthsListCount"] = cca12monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* Start cca24monthsInformation ***********//
                string query_uid_cca24months = $"SELECT * FROM cca24months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca24months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA24monthsInformation
                            CCA24months cca24monthsInfo = new CCA24months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca24monthsList.Add(cca24monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca24monthsList"] = cca24monthsList;
                        ViewData["cca24monthsListCount"] = cca24monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End cca24monthsInformation ***********//
                //************************************************* Start cca36monthsInformation ***********//
                string query_uid_cca36months = $"SELECT * FROM cca36months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca36months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA36monthsInformation
                            CCA36months cca36monthsInfo = new CCA36months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca36monthsList.Add(cca36monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca36monthsList"] = cca36monthsList;
                        ViewData["cca36monthsListCount"] = cca36monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End cca36monthsInformation ***********//
                //************************************************* Start nlr12monthsInformation ***********//
                string query_uid_nlr12months = $"SELECT * FROM nlr12months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr12months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR12monthsInformation
                            NLR12months nlr12monthsInfo = new NLR12months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr12monthsList.Add(nlr12monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr12monthsList"] = nlr12monthsList;
                        ViewData["nlr12monthsListCount"] = nlr12monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr12monthsInformation ***********//
                //************************************************* Start nlr24monthsInformation ***********//
                string query_uid_nlr24months = $"SELECT * FROM nlr24months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr24months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR24monthsInformation
                            NLR24months nlr24monthsInfo = new NLR24months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr24monthsList.Add(nlr24monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr24monthsList"] = nlr24monthsList;
                        ViewData["nlr24monthsListCount"] = nlr24monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr24monthsInformation ***********//
                //************************************************* Start nlr36monthsInformation ***********//
                string query_uid_nlr36months = $"SELECT * FROM nlr36months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr36months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR36monthsInformation
                            NLR36months nlr36monthsInfo = new NLR36months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr36monthsList.Add(nlr36monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr36monthsList"] = nlr36monthsList;
                        ViewData["nlr36monthsListCount"] = nlr36monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr36monthsInformation ***********//

                //************************************************* Start EnquiryInformation ***********//
                string query_uid_enquiryHistoryInfo = $"SELECT * FROM enquiryhistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_enquiryHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //EnquiryhistoryInformation
                            EnquiryHistory EnquiryHistoryInfo = new EnquiryHistory();

                            int EnquiryDate = reader.GetOrdinal("EnquiryDate");
                            int EnquiredBy = reader.GetOrdinal("EnquiredBy");
                            int EnquiredByContact = reader.GetOrdinal("EnquiredByContact");
                            int EnquiredByType = reader.GetOrdinal("EnquiredByType");
                            int ReasonForEnquiry = reader.GetOrdinal("ReasonForEnquiry");
                            while (reader.Read())
                            {
                                EnquiryHistoryInfo.EnquiryDate = (reader[EnquiryDate] != Convert.DBNull) ? reader[EnquiryDate].ToString() : null;
                                EnquiryHistoryInfo.EnquiredBy = (reader[EnquiredBy] != Convert.DBNull) ? reader[EnquiredBy].ToString() : null;
                                EnquiryHistoryInfo.EnquiredByContact = (reader[EnquiredByContact] != Convert.DBNull) ? reader[EnquiredByContact].ToString() : null;
                                EnquiryHistoryInfo.EnquiredByType = (reader[EnquiredByType] != Convert.DBNull) ? reader[EnquiredByType].ToString() : null;
                                EnquiryHistoryInfo.ReasonForEnquiry = (reader[ReasonForEnquiry] != Convert.DBNull) ? reader[ReasonForEnquiry].ToString() : null;

                                enquiryInformationList.Add(EnquiryHistoryInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["enquiryInformationList"] = enquiryInformationList;
                        ViewData["enquiryInformationListCount"] = enquiryInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End EnquiryInformation ***********//

                //************************************************* Start AddressHistoryInformation ***********//
                string query_uid_AddressHistoryInfo = $"SELECT * FROM addresshistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_AddressHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //addresshistoryInformation
                            AddressHistory AddressInfo = new AddressHistory();

                            int AddressID = reader.GetOrdinal("AddressID");
                            int TypeDescription = reader.GetOrdinal("TypeDescription");
                            int Line1 = reader.GetOrdinal("Line1");
                            int Line2 = reader.GetOrdinal("Line2");
                            int Line3 = reader.GetOrdinal("Line3");
                            int Line4 = reader.GetOrdinal("Line4");
                            int PostalCode = reader.GetOrdinal("PostalCode");
                            int FullAddress = reader.GetOrdinal("FullAddress");
                            int AddressLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");
                            while (reader.Read())
                            {
                                AddressInfo.AddressID = (reader[AddressID] != Convert.DBNull) ? reader[AddressID].ToString() : null;
                                AddressInfo.TypeDescription = (reader[TypeDescription] != Convert.DBNull) ? reader[TypeDescription].ToString() : null;
                                AddressInfo.Line1 = (reader[Line1] != Convert.DBNull) ? reader[Line1].ToString() : null;
                                AddressInfo.Line2 = (reader[Line2] != Convert.DBNull) ? reader[Line2].ToString() : null;
                                AddressInfo.Line3 = (reader[Line3] != Convert.DBNull) ? reader[Line3].ToString() : null;
                                AddressInfo.Line4 = (reader[Line4] != Convert.DBNull) ? reader[Line4].ToString() : null;
                                AddressInfo.PostalCode = (reader[PostalCode] != Convert.DBNull) ? reader[PostalCode].ToString() : null;
                                AddressInfo.FullAddress = (reader[FullAddress] != Convert.DBNull) ? reader[FullAddress].ToString() : null;
                                AddressInfo.LastUpdatedDate = (reader[AddressLastUpdatedDate] != Convert.DBNull) ? reader[AddressLastUpdatedDate].ToString() : null;

                                addressInformationList.Add(AddressInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["addressInformationList"] = addressInformationList;
                        ViewData["addressInformationListCount"] = addressInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End AddressHistoryInformation ***********//

                //************************************************* Start TelephonehistoryInformation ***********//
                string query_uid_TelephoneHistoryInfo = $"SELECT * FROM telephonehistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_TelephoneHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //TelephoneHistoryInformation
                            TelephoneHistory TelephoneInfo = new TelephoneHistory();

                            // //Telephone History
                            int TypeDescriptionTel = reader.GetOrdinal("TypeDescriptionTel");
                            int DialCode = reader.GetOrdinal("DialCode");
                            int Number = reader.GetOrdinal("Number");
                            int FullNumber = reader.GetOrdinal("FullNumber");
                            int LastUpdatedDateTel = reader.GetOrdinal("LastUpdatedDateTel");

                            while (reader.Read())
                            {
                                TelephoneInfo.TypeDescriptionTel = (reader[TypeDescriptionTel] != Convert.DBNull) ? reader[TypeDescriptionTel].ToString() : null;
                                TelephoneInfo.DialCode = (reader[DialCode] != Convert.DBNull) ? reader[DialCode].ToString() : null;
                                TelephoneInfo.Number = (reader[Number] != Convert.DBNull) ? reader[Number].ToString() : null;
                                TelephoneInfo.FullNumber = (reader[FullNumber] != Convert.DBNull) ? reader[FullNumber].ToString() : null;
                                TelephoneInfo.LastUpdatedDateTel = (reader[LastUpdatedDateTel] != Convert.DBNull) ? reader[LastUpdatedDateTel].ToString() : null;

                                telephoneInformationList.Add(TelephoneInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["telephoneInformationList"] = telephoneInformationList;
                        ViewData["telephoneInformationListCount"] = telephoneInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End TelephonehistoryInformation***********//

                //************************************************* Start EmploymenthistoryInformation ***********//
                string query_uid_EmploymentHistoryInfo = $"SELECT * FROM employmenthistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_EmploymentHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //query_uid_EmploymentHistoryInformation
                            EmploymentHistory EmploymentInfo = new EmploymentHistory();

                            // EmploymentHistory
                            int EmployerName = reader.GetOrdinal("EmployerName");
                            int Designation = reader.GetOrdinal("Designation");
                            int EmployLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");

                            while (reader.Read())
                            {
                                EmploymentInfo.EmployerName = (reader[EmployerName] != Convert.DBNull) ? reader[EmployerName].ToString() : null;
                                EmploymentInfo.Designation = (reader[Designation] != Convert.DBNull) ? reader[Designation].ToString() : null;
                                EmploymentInfo.LastUpdatedDate = (reader[EmployLastUpdatedDate] != Convert.DBNull) ? reader[EmployLastUpdatedDate].ToString() : null;

                                employmentInformationList.Add(EmploymentInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["employmentInformationList"] = employmentInformationList;
                        ViewData["employmentInformationListCount"] = employmentInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End TelephonehistoryInformation***********//

                //************************************************* Start DirectorShipInformation ***********//
                string query_uid_DirectorShipInfo = $"SELECT * FROM directorships as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_DirectorShipInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DirectorshipInformation
                            Directorship DirectorshipInfo = new Directorship();

                            // DirectorshipHistory
                            int DesignationCode = reader.GetOrdinal("DesignationCode");
                            int AppointmentDate = reader.GetOrdinal("AppointmentDate");
                            int DirectorStatus = reader.GetOrdinal("DirectorStatus");
                            int DirectorStatusDate = reader.GetOrdinal("DirectorStatusDate");
                            int CompanyName = reader.GetOrdinal("CompanyName");
                            int CompanyType = reader.GetOrdinal("CompanyType");
                            int CompanyStatus = reader.GetOrdinal("CompanyStatus");
                            int CompanyStatusCode = reader.GetOrdinal("CompanyStatusCode");
                            int CompanyRegistrationNumber = reader.GetOrdinal("CompanyRegistrationNumber");
                            int CompanyRegistrationDate = reader.GetOrdinal("CompanyRegistrationDate");
                            int CompanyStartDate = reader.GetOrdinal("CompanyStartDate");
                            int CompanyTaxNumber = reader.GetOrdinal("CompanyTaxNumber");
                            int DirectorTypeCode = reader.GetOrdinal("DirectorTypeCode");
                            int DirectorType = reader.GetOrdinal("DirectorType");
                            int MemberSize = reader.GetOrdinal("MemberSize");
                            int MemberContribution = reader.GetOrdinal("MemberContribution");
                            int MemberContributionType = reader.GetOrdinal("MemberContributionType");
                            int ResignationDate = reader.GetOrdinal("ResignationDate");

                            while (reader.Read())
                            {
                                DirectorshipInfo.DesignationCode = (reader[DesignationCode] != Convert.DBNull) ? reader[DesignationCode].ToString() : null;
                                DirectorshipInfo.AppointmentDate = (reader[AppointmentDate] != Convert.DBNull) ? reader[AppointmentDate].ToString() : null;
                                DirectorshipInfo.DirectorStatus = (reader[DirectorStatus] != Convert.DBNull) ? reader[DirectorStatus].ToString() : null;
                                DirectorshipInfo.DirectorStatusDate = (reader[DirectorStatusDate] != Convert.DBNull) ?
                                reader[DirectorStatusDate].ToString() : null; DirectorshipInfo.CompanyName =
                                (reader[CompanyName] != Convert.DBNull) ? reader[CompanyName].ToString() : null;
                                DirectorshipInfo.CompanyType = (reader[CompanyType] != Convert.DBNull) ?
                                reader[CompanyType].ToString() : null; DirectorshipInfo.CompanyStatus =
                                (reader[CompanyStatus] != Convert.DBNull) ? reader[CompanyStatus].ToString() : null;
                                DirectorshipInfo.CompanyStatusCode = (reader[CompanyStatusCode] != Convert.DBNull) ?
                                reader[CompanyStatusCode].ToString() : null; DirectorshipInfo.CompanyRegistrationNumber
                                = (reader[CompanyRegistrationNumber] != Convert.DBNull) ?
                                reader[CompanyRegistrationNumber].ToString() : null;
                                DirectorshipInfo.CompanyRegistrationDate = (reader[CompanyRegistrationDate] !=
                                Convert.DBNull) ? reader[CompanyRegistrationDate].ToString() : null;
                                DirectorshipInfo.CompanyStartDate = (reader[CompanyStartDate] != Convert.DBNull) ?
                                reader[CompanyStartDate].ToString() : null; DirectorshipInfo.CompanyTaxNumber =
                                (reader[CompanyTaxNumber] != Convert.DBNull) ? reader[CompanyTaxNumber].ToString() :
                                null; DirectorshipInfo.DirectorTypeCode = (reader[DirectorTypeCode] != Convert.DBNull) ?
                                reader[DirectorTypeCode].ToString() : null; DirectorshipInfo.DirectorType =
                                (reader[DirectorType] != Convert.DBNull) ? reader[DirectorType].ToString() : null;
                                DirectorshipInfo.MemberSize = (reader[MemberSize] != Convert.DBNull) ?
                                reader[MemberSize].ToString() : null; DirectorshipInfo.MemberContribution =
                                (reader[MemberContribution] != Convert.DBNull) ? reader[MemberContribution].ToString()
                                : null; DirectorshipInfo.MemberContributionType = (reader[MemberContributionType] !=
                                Convert.DBNull) ? reader[MemberContributionType].ToString() : null;
                                DirectorshipInfo.ResignationDate = (reader[ResignationDate] != Convert.DBNull) ?
                                reader[ResignationDate].ToString() : null;

                                directorshipList.Add(DirectorshipInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["directorshipList"] = directorshipList;
                        ViewData["directorshipListCount"] = directorshipList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CPAAccountsInformation***********//
                string query_uid_cppaAccountsInfo = $"SELECT * FROM cpa_accounts as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cppaAccountsInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CPAInformation
                            CPAaccounts cppaAccounts = new CPAaccounts();

                            int Account_ID = reader.GetOrdinal("Account_ID");
                            int SubscriberCode = reader.GetOrdinal("SubscriberCode");
                            int SubscriberName = reader.GetOrdinal("SubscriberName");
                            int AccountNO = reader.GetOrdinal("AccountNO");
                            int SubAccountNO = reader.GetOrdinal("SubAccountNO");
                            int OwnershipType = reader.GetOrdinal("OwnershipType");
                            int OwnershipTypeDescription = reader.GetOrdinal("OwnershipTypeDescription");
                            int Reason = reader.GetOrdinal("Reason");
                            int ReasonDescription = reader.GetOrdinal("ReasonDescription");
                            int PaymentType = reader.GetOrdinal("PaymentType");
                            int PaymentTypeDescription = reader.GetOrdinal("PaymentTypeDescription");
                            int AccountType = reader.GetOrdinal("AccountType");
                            int AccountTypeDescription = reader.GetOrdinal("AccountTypeDescription");
                            int OpenDate = reader.GetOrdinal("OpenDate");
                            int DeferredPaymentDate = reader.GetOrdinal("DeferredPaymentDate");
                            int LastPaymentDate = reader.GetOrdinal("LastPaymentDate");
                            int OpenBalance = reader.GetOrdinal("OpenBalance");
                            int OpenBalanceIND = reader.GetOrdinal("OpenBalanceIND");
                            int CurrentBalance = reader.GetOrdinal("CurrentBalance");
                            int CurrentBalanceIND = reader.GetOrdinal("CurrentBalanceIND");
                            int OverdueAmount = reader.GetOrdinal("OverdueAmount");
                            int OverdueAmountIND = reader.GetOrdinal("OverdueAmountIND");
                            int InstalmentAmount = reader.GetOrdinal("InstalmentAmount");
                            int ArrearsPeriod = reader.GetOrdinal("ArrearsPeriod");
                            int RepaymentFrequency = reader.GetOrdinal("RepaymentFrequency");
                            int RepaymentFrequencyDescription = reader.GetOrdinal("RepaymentFrequencyDescription");
                            int Terms = reader.GetOrdinal("Terms");
                            int StatusCode = reader.GetOrdinal("StatusCode");
                            int StatusCodeDesc = reader.GetOrdinal("StatusCodeDesc");
                            int IndustryType = reader.GetOrdinal("IndustryType");
                            int PaymentHistoryChartURL = reader.GetOrdinal("PaymentHistoryChartURL");
                            int StatusDate = reader.GetOrdinal("StatusDate");
                            int ThirdPartyName = reader.GetOrdinal("ThirdPartyName");
                            int ThirdPartySold = reader.GetOrdinal("ThirdPartySold");
                            int ThirdPartySoldDescription = reader.GetOrdinal("ThirdPartySoldDescription");
                            int JointLoanParticipants = reader.GetOrdinal("JointLoanParticipants");
                            int PaymentHistory = reader.GetOrdinal("PaymentHistory");
                            int PaymentHistoryStatus = reader.GetOrdinal("PaymentHistoryStatus");
                            int PaymentHistoryChart = reader.GetOrdinal("PaymentHistoryChart");
                            int MonthEndDate = reader.GetOrdinal("MonthEndDate");
                            int DateCreated = reader.GetOrdinal("DateCreated");
                            //Fetch PaymenyHistory Array
                            //public string PaymentHistoryChartURL = reader.GetOrdonal("");
                            //public Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails = reader.GetOrdonal("");
                            // CPAInformation

                            while (reader.Read())
                            {
                                cppaAccounts.Account_ID = (reader[Account_ID] != Convert.DBNull) ? reader[Account_ID].ToString() : null;
                                cppaAccounts.SubscriberCode = (reader[SubscriberCode] != Convert.DBNull) ? reader[SubscriberCode].ToString() : null;
                                cppaAccounts.SubscriberName = (reader[SubscriberName] != Convert.DBNull) ? reader[SubscriberName].ToString() : null;
                                cppaAccounts.AccountNO = (reader[AccountNO] != Convert.DBNull) ? reader[AccountNO].ToString() : null;
                                cppaAccounts.SubAccountNO = (reader[SubAccountNO] != Convert.DBNull) ? reader[SubAccountNO].ToString() : null;
                                cppaAccounts.OwnershipType = (reader[OwnershipType] != Convert.DBNull) ? reader[OwnershipType].ToString() : null;
                                cppaAccounts.OwnershipTypeDescription = (reader[OwnershipTypeDescription] != Convert.DBNull) ? reader[OwnershipTypeDescription].ToString() : null;
                                cppaAccounts.Reason = (reader[Reason] != Convert.DBNull) ? reader[Reason].ToString() : null;
                                cppaAccounts.ReasonDescription = (reader[ReasonDescription] != Convert.DBNull) ? reader[ReasonDescription].ToString() : null;
                                cppaAccounts.PaymentType = (reader[PaymentType] != Convert.DBNull) ? reader[PaymentType].ToString() : null;
                                cppaAccounts.PaymentTypeDescription = (reader[PaymentTypeDescription] != Convert.DBNull) ? reader[PaymentTypeDescription].ToString() : null;
                                cppaAccounts.AccountType = (reader[AccountType] != Convert.DBNull) ? reader[AccountType].ToString() : null;
                                cppaAccounts.AccountTypeDescription = (reader[AccountTypeDescription] != Convert.DBNull) ? reader[AccountTypeDescription].ToString() : null;
                                cppaAccounts.OpenDate = (reader[OpenDate] != Convert.DBNull) ? reader[OpenDate].ToString() : null;
                                cppaAccounts.DeferredPaymentDate = (reader[DeferredPaymentDate] != Convert.DBNull) ? reader[DeferredPaymentDate].ToString() : null;
                                cppaAccounts.LastPaymentDate = (reader[LastPaymentDate] != Convert.DBNull) ? reader[LastPaymentDate].ToString() : null;
                                cppaAccounts.OpenBalance = (reader[OpenBalance] != Convert.DBNull) ? reader[OpenBalance].ToString() : null;
                                cppaAccounts.OpenBalanceIND = (reader[OpenBalanceIND] != Convert.DBNull) ? reader[OpenBalanceIND].ToString() : null;
                                cppaAccounts.CurrentBalance = (reader[CurrentBalance] != Convert.DBNull) ? reader[CurrentBalance].ToString() : null;
                                cppaAccounts.CurrentBalanceIND = (reader[CurrentBalanceIND] != Convert.DBNull) ? reader[CurrentBalanceIND].ToString() : null;
                                cppaAccounts.OverdueAmount = (reader[OverdueAmount] != Convert.DBNull) ? reader[OverdueAmount].ToString() : null;
                                cppaAccounts.OverdueAmountIND = (reader[OverdueAmountIND] != Convert.DBNull) ? reader[OverdueAmountIND].ToString() : null;
                                cppaAccounts.InstalmentAmount = (reader[InstalmentAmount] != Convert.DBNull) ? reader[InstalmentAmount].ToString() : null;
                                cppaAccounts.ArrearsPeriod = (reader[ArrearsPeriod] != Convert.DBNull) ? reader[ArrearsPeriod].ToString() : null;
                                cppaAccounts.RepaymentFrequency = (reader[RepaymentFrequency] != Convert.DBNull) ? reader[RepaymentFrequency].ToString() : null;
                                cppaAccounts.RepaymentFrequencyDescription = (reader[RepaymentFrequencyDescription] != Convert.DBNull) ? reader[RepaymentFrequencyDescription].ToString() : null;
                                cppaAccounts.Terms = (reader[Terms] != Convert.DBNull) ? reader[Terms].ToString() : null;
                                cppaAccounts.StatusCode = (reader[StatusCode] != Convert.DBNull) ? reader[StatusCode].ToString() : null;
                                cppaAccounts.StatusCodeDesc = (reader[StatusCodeDesc] != Convert.DBNull) ? reader[StatusCodeDesc].ToString() : null;
                                cppaAccounts.IndustryType = (reader[IndustryType] != Convert.DBNull) ? reader[IndustryType].ToString() : null;
                                cppaAccounts.PaymentHistoryChartURL = (reader[PaymentHistoryChartURL] != Convert.DBNull) ? reader[PaymentHistoryChartURL].ToString() : null;
                                cppaAccounts.StatusDate = (reader[StatusDate] != Convert.DBNull) ? reader[StatusDate].ToString() : null;
                                cppaAccounts.ThirdPartyName = (reader[ThirdPartyName] != Convert.DBNull) ? reader[ThirdPartyName].ToString() : null;
                                cppaAccounts.ThirdPartySold = (reader[ThirdPartySold] != Convert.DBNull) ? reader[ThirdPartySold].ToString() : null;
                                cppaAccounts.ThirdPartySoldDescription = (reader[ThirdPartySoldDescription] != Convert.DBNull) ? reader[ThirdPartySoldDescription].ToString() : null;
                                cppaAccounts.JointLoanParticipants = (reader[JointLoanParticipants] != Convert.DBNull) ? reader[JointLoanParticipants].ToString() : null;
                                cppaAccounts.PaymentHistory = (reader[PaymentHistory] != Convert.DBNull) ? reader[PaymentHistory].ToString() : null;
                                cppaAccounts.PaymentHistoryStatus = (reader[PaymentHistoryStatus] != Convert.DBNull) ? reader[PaymentHistoryStatus].ToString() : null;
                                cppaAccounts.PaymentHistoryChart = (reader[PaymentHistoryChart] != Convert.DBNull) ? reader[PaymentHistoryChart].ToString() : null;
                                cppaAccounts.MonthEndDate = (reader[MonthEndDate] != Convert.DBNull) ? reader[MonthEndDate].ToString() : null;
                                cppaAccounts.DateCreated = (reader[DateCreated] != Convert.DBNull) ? reader[DateCreated].ToString() : null;

                                //Read PaymentHistoryAccountDetails

                                cppaAccountsList.Add(cppaAccounts);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cppaAccountsList"] = cppaAccountsList;
                        ViewData["cppaAccountsList"] = cppaAccountsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CPAAccountsInformation***********//
                //************************************************* Start InternalEnquiryHistroy*********//
                string query_uid_InternalEnquiryHistory = $"SELECT * FROM internalenquiryhistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_InternalEnquiryHistory, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            InternalEnquiryHistory IntEnqHist = new InternalEnquiryHistory();

                            int CompanyName = reader.GetOrdinal("CompanyName");
                            int IntEnquiryDate = reader.GetOrdinal("IntEnquiryDate");
                            int ContactPerson = reader.GetOrdinal("ContactPerson");
                            int PhoneNumber = reader.GetOrdinal("PhoneNumber");
                            int EmailAddress = reader.GetOrdinal("EmailAddress");

                            while (reader.Read())
                            {
                                IntEnqHist.CompanyName = (reader[CompanyName] != Convert.DBNull) ? reader[CompanyName].ToString() : null;
                                IntEnqHist.IntEnquiryDate = (reader[IntEnquiryDate] != Convert.DBNull) ? reader[IntEnquiryDate].ToString() : null;
                                IntEnqHist.ContactPerson = (reader[ContactPerson] != Convert.DBNull) ? reader[ContactPerson].ToString() : null;
                                IntEnqHist.PhoneNumber = (reader[PhoneNumber] != Convert.DBNull) ? reader[PhoneNumber].ToString() : null;
                                IntEnqHist.EmailAddress = (reader[EmailAddress] != Convert.DBNull) ? reader[EmailAddress].ToString() : null;

                                InternalEnqHistoryList.Add(IntEnqHist);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["InternalEnqHistoryList"] = InternalEnqHistoryList;
                        ViewData["InternalEnqHistoryListCount"] = InternalEnqHistoryList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }

                //************************************************* End InternalEnquiryHistroy***********//
            }
            return View();
        }

        public ActionResult VeriCredConsumerProfile()
        {
            return View();
        }

        public ActionResult VeriCredConsumerProfileResults(VeriCred veri)
        {
            string id = veri.idNumber != null ? veri.idNumber.Trim() : null;
            string enquiryReason = veri.EnquiryReason != null ? veri.EnquiryReason.Trim() : null;
            string refe = veri.Reference != null ? veri.Reference.Trim() : null;
            try
            {
                string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);

                var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

                DateTime time = DateTime.Now;

                string date_add = DateTime.Today.ToShortDateString();
                string time_add = time.ToString("T");
                string page = "VeriCred Consumer Profile";
                string action = "ID: " + id + "; Enquiry Reason: " + enquiryReason;
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
                System.Diagnostics.Debug.WriteLine(o);
                JToken token = JToken.Parse(response.Content);

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;

                if (ViewData["ResponseMessage"].ToString() == "ServiceOffline")
                {
                    TempData["msg"] = "Sorry Service Is Currently Offline, Please try again later ";
                    return View();
                }
                if (rootObject.ResponseMessage == "NotFound")
                {
                    TempData["msg"] = "No Results ,Returned. ";
                    return View();
                }

                ViewData["PDFCopyURL"] = rootObject.PDFCopyURL;

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "VeriCredConsumerProfile");

                //PersonalInformation
                ViewData["Fullname"] = rootObject.ResponseObject.PersonInformation.Fullname;
                ViewData["IDNumber"] = rootObject.ResponseObject.PersonInformation.IDNumber;
                ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
                ViewData["Age"] = rootObject.ResponseObject.PersonInformation.Age;
                ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender;
                ViewData["HasProperties"] = rootObject.ResponseObject.PersonInformation.HasProperties;
                savePersonInformation(SearchToken, Reference, SearchID, null, null, null, ViewData["DateOfBirth"].ToString(), null, null, ViewData["Fullname"].ToString(), ViewData["IDNumber"].ToString(), null, null, null, null, ViewData["Gender"].ToString(), ViewData["Age"].ToString(), null, null, null, null, null, null, null, null, ViewData["HasProperties"], "VeriCredConsumerProfile");

                //CreditInformation
                //Check if CreditInformation exists in Response object
                JToken CreditInformationExists = rootObject.ResponseObject["CreditInformation"];
                ViewData["CPAACCOUNTS"] = null;
                if (CreditInformationExists != null)
                {
                    ViewData["DelphiScoreChartURL"] = rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL;
                    ViewData["DelphiScore"] = rootObject.ResponseObject.CreditInformation.DelphiScore;
                    ViewData["RiskColour"] = rootObject.ResponseObject.CreditInformation.RiskColour;
                    saveCreditInformation(SearchID, Reference, SearchID, null,
                        rootObject.ResponseObject.CreditInformation.DelphiScore,
                        rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL,
                        rootObject.ResponseObject.CreditInformation.RiskColour,
                        null, null, null, null, null, null, null, null, null, null,
                        "VeriCredConsumerProfile");
                    //ConsumerStatistics
                    JToken ConsumerStatisticsExists = rootObject.ResponseObject.CreditInformation["ConsumerStatistics"];

                    if (ConsumerStatisticsExists != null)
                    {
                        JToken CCAStatsInformationExists = rootObject.ResponseObject.CreditInformation.ConsumerStatistics["CCAStats"];

                        if (CCAStatsInformationExists != null)
                        {
                            ViewData["MonthlyInstalment"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
                            saveCCAStats(SearchToken, Reference, SearchID,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstArrearsStatus,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment,
                                rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.CumulativeArrears,
                                "VeriCredConsumerProfile");
                        }
                    }

                    List<CPAaccounts> CPAACCOUNTS;
                    CPAACCOUNTS = null;
                    JToken CPAACCOUNTSExists = rootObject.ResponseObject.CreditInformation["CPA_Accounts"];
                    if (CPAACCOUNTSExists != null)
                    {
                        Newtonsoft.Json.Linq.JArray elements1 = new Newtonsoft.Json.Linq.JArray();
                        elements1 = rootObject.ResponseObject.CreditInformation.CPA_Accounts;

                        String Account_ID;
                        String SubscriberCode;
                        String SubscriberName;
                        String AccountNO;
                        String OpenDate;
                        String LastPaymentDate;
                        String OpenBalance;
                        String CurrentBalance;
                        String OverdueAmount;
                        String InstalmentAmount;
                        String StatusCodeDesc;
                        String StatusDate;
                        String IndustryType;
                        String PaymentHistoryChartURL;
                        Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails = new Newtonsoft.Json.Linq.JArray();
                        CPAACCOUNTS = new List<CPAaccounts>();

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
                            PaymentHistoryAccountDetails = rootObject.ResponseObject.CreditInformation.CPA_Accounts[count].PaymentHistoryAccountDetails;//ADD TO DATABASE
                            CPAACCOUNTS.Add(new CPAaccounts
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
                                //PaymentHistoryAccountDetails = PaymentHistoryAccountDetails,
                            });
                            saveCPA_Accounts(SearchToken, Reference, SearchID, Account_ID, SubscriberCode, SubscriberName, AccountNO, null, null, null, null, null, null, null, null, OpenDate, null,
                                LastPaymentDate, OpenBalance, null, CurrentBalance, null, OverdueAmount, InstalmentAmount, null, null, null, null, StatusCodeDesc, IndustryType, PaymentHistoryChartURL,
                                StatusDate, null, null, null, null, null, null, null, null, "VeriCredConsumerProfile");
                        }

                        ViewData["CPAACCOUNTS"] = CPAACCOUNTS;
                    }
                }

                //Check if HistoricalInformation exists in Response object
                JToken HistoricalInformationExists = rootObject.ResponseObject["HistoricalInformation"];
                ViewData["AddressHist"] = null;
                ViewData["TelHist"] = null;
                ViewData["EmpHist"] = null;

                if (HistoricalInformationExists != null)
                {
                    //AddressHistory
                    JToken AddressExists = rootObject.ResponseObject["HistoricalInformation"].AddressHistory;
                    if (AddressExists != null)
                    {
                        List<AddressHistory> AddressHist;
                        Newtonsoft.Json.Linq.JArray element1 = new Newtonsoft.Json.Linq.JArray();
                        element1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory;
                        String TypeDescription;
                        String Line1;
                        String Line2;
                        String Line3;
                        String PostalCode;
                        String FullAddress;
                        String LastUpdatedDate;
                        AddressHist = new List<AddressHistory>();
                        for (int count = 0; count < (element1.Count); count++)
                        {
                            saveAddressHistory(SearchToken, Reference, SearchID, null,
                                 rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription,
                                rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1,
                                 rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2,
                                 rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3,

                                  rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line4,
                                 rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode,
                                 rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress,
                                 rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate, "VeriCredConsumerProfile");
                            AddressHist.Add(new AddressHistory
                            {
                                TypeDescription = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].TypeDescription,
                                Line1 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line1,
                                Line2 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line2,
                                Line3 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line3,
                                Line4 = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].Line4,
                                PostalCode = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].PostalCode,
                                FullAddress = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].FullAddress,
                                LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.AddressHistory[count].LastUpdatedDate,
                            });
                        }
                        ViewData["AddressHist"] = AddressHist;
                    }

                    //TelephoneHIstory
                    JToken TelephoneExists = rootObject.ResponseObject["HistoricalInformation"].TelephoneHistory;
                    if (TelephoneExists != null)
                    {
                        List<TelephoneHistory> TelHist;
                        Newtonsoft.Json.Linq.JArray elements2 = new Newtonsoft.Json.Linq.JArray();
                        elements2 = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory;

                        TelHist = new List<TelephoneHistory>();
                        for (int count = 0; count < (elements2.Count); count++)
                        {
                            saveTelephoneHistory(SearchToken, Reference, SearchID, rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode, null,
                                 rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription, null,
                                  rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number,
                                   rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                    rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDateTel, "VeriCredConsumerProfile");
                            TelHist.Add(new TelephoneHistory
                            {
                                TypeDescriptionTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].TypeDescription,
                                DialCode = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].DialCode,
                                Number = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].Number,
                                FullNumber = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].FullNumber,
                                LastUpdatedDateTel = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[count].LastUpdatedDateTel,
                            });
                        }
                        ViewData["TelHist"] = TelHist;
                    }

                    //EmploymentHistory
                    JToken EmploymentExists = rootObject.ResponseObject["HistoricalInformation"].EmploymentHistory;
                    if (EmploymentExists != null)
                    {
                        List<EmploymentHistory> EmpHist;
                        Newtonsoft.Json.Linq.JArray elements3 = new Newtonsoft.Json.Linq.JArray();
                        elements3 = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory;

                        EmpHist = new List<EmploymentHistory>();

                        for (int count = 0; count < (elements3.Count); count++)
                        {
                            saveEmploymentHistory(SearchToken, Reference, SearchID,
                                    rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                 rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation,
                                  rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate, "VeriCredConsumerProfile");
                            EmpHist.Add(new EmploymentHistory
                            {
                                EmployerName = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].EmployerName,
                                Designation = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].Designation,
                                LastUpdatedDate = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[count].LastUpdatedDate,
                            });
                        }
                        ViewData["EmpHist"] = EmpHist;
                    }
                }

                return View();
            }
            catch (Exception e)
            {
                TempData["msg"] = "Error Occured, Please verify the details that have been entered. ";
                return View();
            }
        }

        public ActionResult VeriCredConsumerProfileDatabase(DatabaseSearch DbSearch)
        {
            System.Collections.Generic.List<PersonInformation> personInfoList = new System.Collections.Generic.List<PersonInformation>();
            System.Collections.Generic.List<HomeAffairsInformation> homeAffairsInformationList = new System.Collections.Generic.List<HomeAffairsInformation>();
            System.Collections.Generic.List<CreditInformation> creditInformationList = new System.Collections.Generic.List<CreditInformation>();
            System.Collections.Generic.List<DataCounts> dataCountsList = new System.Collections.Generic.List<DataCounts>();
            System.Collections.Generic.List<DebtReviewStatus> debtReviewStatusList = new System.Collections.Generic.List<DebtReviewStatus>();
            System.Collections.Generic.List<ConsumerStatistics> consumerstatsList = new System.Collections.Generic.List<ConsumerStatistics>();
            System.Collections.Generic.List<NLRStats> nlrstatsList = new System.Collections.Generic.List<NLRStats>();
            System.Collections.Generic.List<CCAStats> ccastatsList = new System.Collections.Generic.List<CCAStats>();
            System.Collections.Generic.List<CCA12months> cca12monthsList = new System.Collections.Generic.List<CCA12months>();
            System.Collections.Generic.List<CCA24months> cca24monthsList = new System.Collections.Generic.List<CCA24months>();
            System.Collections.Generic.List<CCA36months> cca36monthsList = new System.Collections.Generic.List<CCA36months>();
            System.Collections.Generic.List<NLR12months> nlr12monthsList = new System.Collections.Generic.List<NLR12months>();
            System.Collections.Generic.List<NLR24months> nlr24monthsList = new System.Collections.Generic.List<NLR24months>();
            System.Collections.Generic.List<NLR36months> nlr36monthsList = new System.Collections.Generic.List<NLR36months>();
            System.Collections.Generic.List<EnquiryHistory> enquiryInformationList = new System.Collections.Generic.List<EnquiryHistory>();
            System.Collections.Generic.List<AddressHistory> addressInformationList = new System.Collections.Generic.List<AddressHistory>();
            System.Collections.Generic.List<EmploymentHistory> employmentInformationList = new System.Collections.Generic.List<EmploymentHistory>();
            System.Collections.Generic.List<TelephoneHistory> telephoneInformationList = new System.Collections.Generic.List<TelephoneHistory>();
            System.Collections.Generic.List<CPAaccounts> cppaAccountsList = new System.Collections.Generic.List<CPAaccounts>();
            //System.Collections.Generic.List<PaymentHistoryAccountDetails> paymentHistoryAccountList = new System.Collections.Generic.List<PaymentHistoryAccountDetails>();
            System.Collections.Generic.List<Directorship> directorshipList = new System.Collections.Generic.List<Directorship>();

            //AND SearchToken = 'cc329011-76c8-4c8c-9ff6-4b5ce6c05d13' AND Reference = 'devadmin@ktopportunities.co.za' AND typeOfSearch = 'ExperianConsumerProfile'
            string dbConnectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};", serverIp, username, password, databaseName);
                                                                                                                   //string query_uid = $"SELECT * FROM personinformation,homeaffairsinformation,creditinformation,datacounts,debtreviewstatus,addresshistory,telephonehistory,consumerstatistics,nlrstats,ccastats,cca12months,cca24months,cca36months,enquiryhistory,employmenthistory,months,months,nlr36months,cpa_accounts WHERE personinformation.SearchToken = '{DbSearch.token}'";
                                                                                                                   //Add TABLE paymenthistoryaccountdetails!!!!

            using (var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString))
            {
                conn.Open();

                //************************************************* Start personal info ***********//
                string query_uid_personinformation = $"SELECT * FROM personinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_personinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            int DateOfBirth = reader.GetOrdinal("DateOfBirth");
                            int Title = reader.GetOrdinal("Title");
                            int FirstName = reader.GetOrdinal("FirstName");
                            int Surname = reader.GetOrdinal("Surname");
                            int Fullname = reader.GetOrdinal("Fullname");
                            int IDNumber = reader.GetOrdinal("IDNumber");
                            int Gender = reader.GetOrdinal("Gender");
                            int Age = reader.GetOrdinal("Age");
                            int MaritalStatus = reader.GetOrdinal("MaritalStatus");
                            int MiddleName1 = reader.GetOrdinal("MiddleName1");
                            int Reference = reader.GetOrdinal("Ref");
                            int HasProperties = reader.GetOrdinal("HasProperties");

                            //PersonInformation
                            while (reader.Read())
                            {
                                PersonInformation personInformation = new PersonInformation();
                                personInformation.DateOfBirth = (reader[DateOfBirth] != Convert.DBNull) ? reader[DateOfBirth].ToString() : null;
                                personInformation.Title = (reader[Title] != Convert.DBNull) ? reader[Title].ToString() : null;
                                personInformation.FirstName = (reader[FirstName] != Convert.DBNull) ? reader[FirstName].ToString() : null;
                                personInformation.Surname = (reader[Surname] != Convert.DBNull) ? reader[Surname].ToString() : null;
                                personInformation.Fullname = (reader[Fullname] != Convert.DBNull) ? reader[Fullname].ToString() : null;
                                personInformation.IDNumber = (reader[IDNumber] != Convert.DBNull) ? reader[IDNumber].ToString() : null;
                                personInformation.Gender = (reader[Gender] != Convert.DBNull) ? reader[Gender].ToString() : null;
                                personInformation.Age = (reader[Age] != Convert.DBNull) ? reader[Age].ToString() : null;
                                personInformation.MaritalStatus = (reader[MaritalStatus] != Convert.DBNull) ? reader[MaritalStatus].ToString() : null;
                                personInformation.MiddleName1 = (reader[MiddleName1] != Convert.DBNull) ? reader[MiddleName1].ToString() : null;
                                personInformation.Reference = (reader[Reference] != Convert.DBNull) ? reader[Reference].ToString() : null;
                                personInformation.HasProperties = (reader[HasProperties] != Convert.DBNull) ? Convert.ToBoolean(reader[HasProperties]) : false;
                                //add to the list
                                personInfoList.Add(personInformation);
                            }
                        }
                        ViewData["PersonInfoList"] = personInfoList;
                        ViewData["PersonInfoListCount"] = personInfoList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //*************************************************END personal info ***********//
                //************************************************* Start CreditInformation info ***********//
                string query_uid_creditinformation = $"SELECT * FROM creditinformation as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_creditinformation, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CreditInformation
                            CreditInformation CreditInfo = new CreditInformation();

                            int DelphiScore = reader.GetOrdinal("DelphiScore");
                            int RiskColour = reader.GetOrdinal("RiskColour");
                            int DelphiScoreChartURL = reader.GetOrdinal("DelphiScoreChartURL");
                            while (reader.Read())
                            {
                                CreditInfo.DelphiScore = (reader[DelphiScore] != Convert.DBNull) ? reader[DelphiScore].ToString() : null;
                                CreditInfo.RiskColour = (reader[RiskColour] != Convert.DBNull) ? reader[RiskColour].ToString() : null;
                                CreditInfo.DelphiScoreChartURL = (reader[DelphiScoreChartURL] != Convert.DBNull) ? reader[DelphiScoreChartURL].ToString() : null;

                                //add to the list
                                creditInformationList.Add(CreditInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["creditInformationList"] = creditInformationList;
                        ViewData["creditInformationListCount"] = creditInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CreditInformation info ***********//
                //************************************************* StartDataCOunts info ***********//
                string query_uid_DataCOunts = $"SELECT * FROM datacounts as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_DataCOunts, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DataCountsInformation
                            DataCounts DataCountInfo = new DataCounts();

                            int Accounts = reader.GetOrdinal("Accounts");
                            int Enquiries = reader.GetOrdinal("Enquiries");
                            //int Judgements = reader.GetOrdinal("Judgements");
                            int Notices = reader.GetOrdinal("Notices");
                            int BankDefaults = reader.GetOrdinal("BankDefaults");
                            int Defaults = reader.GetOrdinal("Defaults");
                            int Collections = reader.GetOrdinal("Collections");
                            int Directors = reader.GetOrdinal("Directors");
                            int Addresses = reader.GetOrdinal("Addresses");
                            int Telephones = reader.GetOrdinal("Telephones");
                            int Occupants = reader.GetOrdinal("Occupants");
                            int Employers = reader.GetOrdinal("Employers");
                            int TraceAlerts = reader.GetOrdinal("TraceAlerts");
                            int PaymentProfiles = reader.GetOrdinal("PaymentProfiles");
                            int OwnEnquiries = reader.GetOrdinal("OwnEnquiries");
                            int AdminOrders = reader.GetOrdinal("AdminOrders");
                            int PossibleMatches = reader.GetOrdinal("PossibleMatches");
                            int DefiniteMatches = reader.GetOrdinal("DefiniteMatches");
                            int Loans = reader.GetOrdinal("Loans");
                            int FraudAlerts = reader.GetOrdinal("FraudAlerts");
                            int Companies = reader.GetOrdinal("Companies");
                            int Properties = reader.GetOrdinal("Properties");
                            int Documents = reader.GetOrdinal("Documents");
                            int DemandLetters = reader.GetOrdinal("DemandLetters");
                            int Trusts = reader.GetOrdinal("Trusts");
                            int Bonds = reader.GetOrdinal("Bonds");
                            int Deeds = reader.GetOrdinal("Deeds");
                            int PublicDefaults = reader.GetOrdinal("PublicDefaults");
                            int NLRAccounts = reader.GetOrdinal("NLRAccounts");
                            while (reader.Read())
                            {
                                DataCountInfo.Accounts = (reader[Accounts] != Convert.DBNull) ? reader[Accounts].ToString() : null;
                                DataCountInfo.Enquires = (reader[Enquiries] != Convert.DBNull) ? reader[Enquiries].ToString() : null;
                                //DataCountInfo.Judgements = (reader[Judgements] != Convert.DBNull) ? reader[Judgements].ToString() : null;
                                DataCountInfo.Notices = (reader[Notices] != Convert.DBNull) ?
                                reader[Notices].ToString() : null; DataCountInfo.BankDefaults =
                                (reader[BankDefaults] != Convert.DBNull) ? reader[BankDefaults].ToString() : null;
                                DataCountInfo.Defaults = (reader[Defaults] != Convert.DBNull) ?
                                reader[Defaults].ToString() : null; DataCountInfo.Collections =
                                (reader[Collections] != Convert.DBNull) ? reader[Collections].ToString() : null;
                                DataCountInfo.Directors = (reader[Directors] != Convert.DBNull) ?
                                reader[Directors].ToString() : null; DataCountInfo.Addresses = (reader[Addresses]
                                != Convert.DBNull) ? reader[Addresses].ToString() : null; DataCountInfo.Telephones =
                                (reader[Telephones] != Convert.DBNull) ? reader[Telephones].ToString() : null;
                                DataCountInfo.Occupants = (reader[Occupants] != Convert.DBNull) ?
                                reader[Occupants].ToString() : null; DataCountInfo.Employers = (reader[Employers]
                                != Convert.DBNull) ? reader[Employers].ToString() : null; DataCountInfo.TraceAlerts
                                = (reader[TraceAlerts] != Convert.DBNull) ? reader[TraceAlerts].ToString() : null;
                                DataCountInfo.PaymentProfiles = (reader[PaymentProfiles] != Convert.DBNull) ?
                                reader[PaymentProfiles].ToString() : null; DataCountInfo.OwnEnquiries =
                                (reader[OwnEnquiries] != Convert.DBNull) ? reader[OwnEnquiries].ToString() : null;
                                DataCountInfo.AdminOrders = (reader[AdminOrders] != Convert.DBNull) ?
                                reader[AdminOrders].ToString() : null; DataCountInfo.PossibleMatches =
                                (reader[PossibleMatches] != Convert.DBNull) ? reader[PossibleMatches].ToString() :
                                null; DataCountInfo.DefiniteMatches = (reader[DefiniteMatches] != Convert.DBNull) ?
                                reader[DefiniteMatches].ToString() : null; DataCountInfo.Loans = (reader[Loans] !=
                                Convert.DBNull) ? reader[Loans].ToString() : null; DataCountInfo.FraudAlerts =
                                (reader[FraudAlerts] != Convert.DBNull) ? reader[FraudAlerts].ToString() : null;
                                DataCountInfo.Companies = (reader[Companies] != Convert.DBNull) ?
                                reader[Companies].ToString() : null; DataCountInfo.Properties = (reader[Properties]
                                != Convert.DBNull) ? reader[Properties].ToString() : null; DataCountInfo.Documents =
                                (reader[Documents] != Convert.DBNull) ? reader[Documents].ToString() : null;
                                DataCountInfo.DemandLetters = (reader[DemandLetters] != Convert.DBNull) ?
                                reader[DemandLetters].ToString() : null; DataCountInfo.Trusts = (reader[Trusts] !=
                                Convert.DBNull) ? reader[Trusts].ToString() : null; DataCountInfo.Bonds =
                                (reader[Bonds] != Convert.DBNull) ? reader[Bonds].ToString() : null;
                                DataCountInfo.Deeds = (reader[Deeds] != Convert.DBNull) ? reader[Deeds].ToString()
                                : null; DataCountInfo.PublicDefaults = (reader[PublicDefaults] != Convert.DBNull) ?
                                reader[PublicDefaults].ToString() : null; DataCountInfo.NLRAccounts =
                                (reader[NLRAccounts] != Convert.DBNull) ? reader[NLRAccounts].ToString() : null;

                                dataCountsList.Add(DataCountInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["dataCountsList"] = dataCountsList;
                        ViewData["dataCountsListCount"] = dataCountsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }

                //************************************************* End DataCOunts info ***********//
                //************************************************* Start Debtreviewstatus info ***********//
                string query_uid_debtreviewstatus = $"SELECT * FROM debtreviewstatus as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_debtreviewstatus, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DebtReviewStatusInformation
                            DebtReviewStatus DebtReviewInfo = new DebtReviewStatus();

                            int StatusCode = reader.GetOrdinal("StatusCode");
                            int StatusDate = reader.GetOrdinal("StatusDate");
                            int StatusDescription = reader.GetOrdinal("StatusDescription");
                            int ApplicationDate = reader.GetOrdinal("ApplicationDate");
                            while (reader.Read())
                            {
                                DebtReviewInfo.StatusCode = (reader[StatusCode] != Convert.DBNull) ?
                                reader[StatusCode].ToString() : null; DebtReviewInfo.StatusDate =
                                (reader[StatusDate] != Convert.DBNull) ? reader[StatusDate].ToString() : null;
                                DebtReviewInfo.StatusDescription = (reader[StatusDescription] != Convert.DBNull) ?
                                reader[StatusDescription].ToString() : null; DebtReviewInfo.ApplicationDate =
                                (reader[ApplicationDate] != Convert.DBNull) ? reader[ApplicationDate].ToString() : null;

                                debtReviewStatusList.Add(DebtReviewInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["debtReviewStatusList"] = debtReviewStatusList;
                        ViewData["debtReviewStatusListCount"] = debtReviewStatusList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End DebtReviewStatus info ***********//
                //************************************************* Start ConsumerStatisticsInformation ***********//
                string query_uid_consumerStatistics = $"SELECT * FROM consumerstatistics as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_consumerStatistics, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //ConsumerStatisticsInformation
                            ConsumerStatistics ConsumerStatsInfo = new ConsumerStatistics();

                            int HighestJudgment = reader.GetOrdinal("HighestJudgment");
                            int RevolvingAccounts = reader.GetOrdinal("RevolvingAccounts");
                            int InstalmentAccounts = reader.GetOrdinal("InstalmentAccounts");
                            int OpenAccounts = reader.GetOrdinal("OpenAccounts");
                            int AdverseAccounts = reader.GetOrdinal("AdverseAccounts");
                            int Percent0ArrearsLast12Histories = reader.GetOrdinal("Percent0ArrearsLast12Histories");
                            int MonthsOldestOpenedPPSEver = reader.GetOrdinal("MonthsOldestOpenedPPSEver");
                            int NumberPPSLast12Months = reader.GetOrdinal("NumberPPSLast12Months");
                            int NLRMicroloansPast12Months = reader.GetOrdinal("NLRMicroloansPast12Months");
                            while (reader.Read())
                            {
                                ConsumerStatsInfo.HighestJudgment = (reader[HighestJudgment] != Convert.DBNull) ?
                                reader[HighestJudgment].ToString() : null; ConsumerStatsInfo.RevolvingAccounts =
                                (reader[RevolvingAccounts] != Convert.DBNull) ?
                                reader[RevolvingAccounts].ToString() : null; ConsumerStatsInfo.InstalmentAccounts =
                                (reader[InstalmentAccounts] != Convert.DBNull) ?
                                reader[InstalmentAccounts].ToString() : null; ConsumerStatsInfo.OpenAccounts =
                                (reader[OpenAccounts] != Convert.DBNull) ? reader[OpenAccounts].ToString() : null;
                                ConsumerStatsInfo.AdverseAccounts = (reader[AdverseAccounts] != Convert.DBNull) ?
                                reader[AdverseAccounts].ToString() : null;
                                ConsumerStatsInfo.Percent0ArrearsLast12Histories =
                                (reader[Percent0ArrearsLast12Histories] != Convert.DBNull) ?
                                reader[Percent0ArrearsLast12Histories].ToString() : null;
                                ConsumerStatsInfo.MonthsOldestOpenedPPSEver = (reader[MonthsOldestOpenedPPSEver] !=
                                Convert.DBNull) ? reader[MonthsOldestOpenedPPSEver].ToString() : null;
                                ConsumerStatsInfo.NumberPPSLast12Months = (reader[NumberPPSLast12Months] !=
                                Convert.DBNull) ? reader[NumberPPSLast12Months].ToString() : null;
                                ConsumerStatsInfo.NLRMicroloansPast12Months = (reader[NLRMicroloansPast12Months] !=
                                Convert.DBNull) ? reader[NLRMicroloansPast12Months].ToString() : null;

                                consumerstatsList.Add(ConsumerStatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["consumerstatsList"] = consumerstatsList;
                        ViewData["consumerstatsListCount"] = consumerstatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End ConsumerStatisticsInformation ***********//

                //************************************************* Start nlrstatsInformation ***********//
                string query_uid_nlrstats = $"SELECT * FROM nlrstats as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlrstats, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLRStatsInformation
                            NLRStats NLRStatsInfo = new NLRStats();

                            int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                            int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                            int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                            int WorstArrearsStatus = reader.GetOrdinal("WorstArrearsStatus");
                            int MonthlyInstalment = reader.GetOrdinal("MonthlyInstalment");
                            int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");
                            int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                            while (reader.Read())
                            {
                                NLRStatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;

                                NLRStatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                NLRStatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                NLRStatsInfo.WorstArrearsStatus = (reader[WorstArrearsStatus] != Convert.DBNull) ? reader[WorstArrearsStatus].ToString() : null;
                                NLRStatsInfo.MonthlyInstalment = (reader[MonthlyInstalment] != Convert.DBNull) ? reader[MonthlyInstalment].ToString() : null;
                                NLRStatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                NLRStatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                nlrstatsList.Add(NLRStatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlrstatsList"] = nlrstatsList;
                        ViewData["nlrstatsListCount"] = nlrstatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlrstatsInformation ***********//
                //************************************************* Start ccastatsInformation ***********//
                string query_uid_ccastats = $"SELECT * FROM ccastats as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_ccastats, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCAStatsInformation
                            CCAStats ccastatsInfo = new CCAStats();

                            int ActiveAccounts = reader.GetOrdinal("ActiveAccounts");
                            int ClosedAccounts = reader.GetOrdinal("ClosedAccounts");
                            int WorstMonthArrears = reader.GetOrdinal("WorstMonthArrears");
                            int WorstArrearsStatus = reader.GetOrdinal("WorstArrearsStatus");
                            int MonthlyInstalment = reader.GetOrdinal("MonthlyInstalment");
                            int CumulativeArrears = reader.GetOrdinal("CumulativeArrears");
                            int BalanceExposure = reader.GetOrdinal("BalanceExposure");
                            while (reader.Read())
                            {
                                ccastatsInfo.ActiveAccounts = (reader[ActiveAccounts] != Convert.DBNull) ? reader[ActiveAccounts].ToString() : null;
                                ccastatsInfo.ClosedAccounts = (reader[ClosedAccounts] != Convert.DBNull) ? reader[ClosedAccounts].ToString() : null;
                                ccastatsInfo.WorstMonthArrears = (reader[WorstMonthArrears] != Convert.DBNull) ? reader[WorstMonthArrears].ToString() : null;
                                ccastatsInfo.WorstArrearsStatus = (reader[WorstArrearsStatus] != Convert.DBNull) ? reader[WorstArrearsStatus].ToString() : null;
                                ccastatsInfo.MonthlyInstalment = (reader[MonthlyInstalment] != Convert.DBNull) ? reader[MonthlyInstalment].ToString() : null;
                                ccastatsInfo.CumulativeArrears = (reader[CumulativeArrears] != Convert.DBNull) ? reader[CumulativeArrears].ToString() : null;
                                ccastatsInfo.BalanceExposure = (reader[BalanceExposure] != Convert.DBNull) ? reader[BalanceExposure].ToString() : null;

                                ccastatsList.Add(ccastatsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["ccastatsList"] = ccastatsList;
                        ViewData["ccastatsListCount"] = ccastatsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End ccastatsInformation ***********//
                //************************************************* Start cca12monthsInformation ***********//
                string query_uid_cca12months = $"SELECT * FROM cca12months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca12months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA12monthsInformation
                            CCA12months cca12monthsInfo = new CCA12months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca12monthsList.Add(cca12monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca12monthsList"] = cca12monthsList;
                        ViewData["cca12monthsListCount"] = cca12monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* Start cca24monthsInformation ***********//
                string query_uid_cca24months = $"SELECT * FROM cca24months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca24months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA24monthsInformation
                            CCA24months cca24monthsInfo = new CCA24months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca24monthsList.Add(cca24monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca24monthsList"] = cca24monthsList;
                        ViewData["cca24monthsListCount"] = cca24monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End cca24monthsInformation ***********//
                //************************************************* Start cca36monthsInformation ***********//
                string query_uid_cca36months = $"SELECT * FROM cca36months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cca36months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CCA36monthsInformation
                            CCA36months cca36monthsInfo = new CCA36months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                cca36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                cca36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                cca36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                cca36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                cca36monthsList.Add(cca36monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["cca36monthsList"] = cca36monthsList;
                        ViewData["cca36monthsListCount"] = cca36monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End cca36monthsInformation ***********//
                //************************************************* Start nlr12monthsInformation ***********//
                string query_uid_nlr12months = $"SELECT * FROM nlr12months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr12months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR12monthsInformation
                            NLR12months nlr12monthsInfo = new NLR12months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr12monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr12monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr12monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr12monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr12monthsList.Add(nlr12monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr12monthsList"] = nlr12monthsList;
                        ViewData["nlr12monthsListCount"] = nlr12monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr12monthsInformation ***********//
                //************************************************* Start nlr24monthsInformation ***********//
                string query_uid_nlr24months = $"SELECT * FROM nlr24months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr24months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR24monthsInformation
                            NLR24months nlr24monthsInfo = new NLR24months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr24monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr24monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr24monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr24monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr24monthsList.Add(nlr24monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr24monthsList"] = nlr24monthsList;
                        ViewData["nlr24monthsListCount"] = nlr24monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr24monthsInformation ***********//
                //************************************************* Start nlr36monthsInformation ***********//
                string query_uid_nlr36months = $"SELECT * FROM nlr36months as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_nlr36months, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //NLR36monthsInformation
                            NLR36months nlr36monthsInfo = new NLR36months();

                            int EnquiriesByClient = reader.GetOrdinal("EnquiriesByClient");
                            int EnquiriesByOther = reader.GetOrdinal("EnquiriesByOther");
                            int PositiveLoans = reader.GetOrdinal("PositiveLoans");
                            int HighestMonthsInArrears = reader.GetOrdinal("HighestMonthsInArrears");
                            while (reader.Read())
                            {
                                nlr36monthsInfo.EnquiriesByClient = (reader[EnquiriesByClient] != Convert.DBNull) ? reader[EnquiriesByClient].ToString() : null;
                                nlr36monthsInfo.EnquiriesByOther = (reader[EnquiriesByOther] != Convert.DBNull) ? reader[EnquiriesByOther].ToString() : null;
                                nlr36monthsInfo.PositiveLoans = (reader[PositiveLoans] != Convert.DBNull) ? reader[PositiveLoans].ToString() : null;
                                nlr36monthsInfo.HighestMonthsInArrears = (reader[HighestMonthsInArrears] != Convert.DBNull) ? reader[HighestMonthsInArrears].ToString() : null;

                                nlr36monthsList.Add(nlr36monthsInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["nlr36monthsList"] = nlr36monthsList;
                        ViewData["nlr36monthsListCount"] = nlr36monthsList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End nlr36monthsInformation ***********//

                //************************************************* Start EnquiryInformation ***********//
                string query_uid_enquiryHistoryInfo = $"SELECT * FROM enquiryhistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_enquiryHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //EnquiryhistoryInformation
                            EnquiryHistory EnquiryHistoryInfo = new EnquiryHistory();

                            int EnquiryDate = reader.GetOrdinal("EnquiryDate");
                            int EnquiredBy = reader.GetOrdinal("EnquiredBy");
                            int EnquiredByContact = reader.GetOrdinal("EnquiredByContact");
                            int EnquiredByType = reader.GetOrdinal("EnquiredByType");
                            int ReasonForEnquiry = reader.GetOrdinal("ReasonForEnquiry");
                            while (reader.Read())
                            {
                                EnquiryHistoryInfo.EnquiryDate = (reader[EnquiryDate] != Convert.DBNull) ? reader[EnquiryDate].ToString() : null;
                                EnquiryHistoryInfo.EnquiredBy = (reader[EnquiredBy] != Convert.DBNull) ? reader[EnquiredBy].ToString() : null;
                                EnquiryHistoryInfo.EnquiredByContact = (reader[EnquiredByContact] != Convert.DBNull) ? reader[EnquiredByContact].ToString() : null;
                                EnquiryHistoryInfo.EnquiredByType = (reader[EnquiredByType] != Convert.DBNull) ? reader[EnquiredByType].ToString() : null;
                                EnquiryHistoryInfo.ReasonForEnquiry = (reader[ReasonForEnquiry] != Convert.DBNull) ? reader[ReasonForEnquiry].ToString() : null;

                                enquiryInformationList.Add(EnquiryHistoryInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["enquiryInformationList"] = enquiryInformationList;
                        ViewData["enquiryInformationListCount"] = enquiryInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End EnquiryInformation ***********//

                //************************************************* Start AddressHistoryInformation ***********//
                string query_uid_AddressHistoryInfo = $"SELECT * FROM addresshistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_AddressHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //addresshistoryInformation
                            AddressHistory AddressInfo = new AddressHistory();

                            int AddressID = reader.GetOrdinal("AddressID");
                            int TypeDescription = reader.GetOrdinal("TypeDescription");
                            int Line1 = reader.GetOrdinal("Line1");
                            int Line2 = reader.GetOrdinal("Line2");
                            int Line3 = reader.GetOrdinal("Line3");
                            int Line4 = reader.GetOrdinal("Line4");
                            int PostalCode = reader.GetOrdinal("PostalCode");
                            int FullAddress = reader.GetOrdinal("FullAddress");
                            int AddressLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");
                            while (reader.Read())
                            {
                                AddressInfo.AddressID = (reader[AddressID] != Convert.DBNull) ? reader[AddressID].ToString() : null;
                                AddressInfo.TypeDescription = (reader[TypeDescription] != Convert.DBNull) ? reader[TypeDescription].ToString() : null;
                                AddressInfo.Line1 = (reader[Line1] != Convert.DBNull) ? reader[Line1].ToString() : null;
                                AddressInfo.Line2 = (reader[Line2] != Convert.DBNull) ? reader[Line2].ToString() : null;
                                AddressInfo.Line3 = (reader[Line3] != Convert.DBNull) ? reader[Line3].ToString() : null;
                                AddressInfo.Line4 = (reader[Line4] != Convert.DBNull) ? reader[Line4].ToString() : null;
                                AddressInfo.PostalCode = (reader[PostalCode] != Convert.DBNull) ? reader[PostalCode].ToString() : null;
                                AddressInfo.FullAddress = (reader[FullAddress] != Convert.DBNull) ? reader[FullAddress].ToString() : null;
                                AddressInfo.LastUpdatedDate = (reader[AddressLastUpdatedDate] != Convert.DBNull) ? reader[AddressLastUpdatedDate].ToString() : null;

                                addressInformationList.Add(AddressInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["addressInformationList"] = addressInformationList;
                        ViewData["addressInformationListCount"] = addressInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End AddressHistoryInformation ***********//

                //************************************************* Start TelephonehistoryInformation ***********//
                string query_uid_TelephoneHistoryInfo = $"SELECT * FROM telephonehistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_TelephoneHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //TelephoneHistoryInformation
                            TelephoneHistory TelephoneInfo = new TelephoneHistory();

                            // //Telephone History
                            int TypeDescriptionTel = reader.GetOrdinal("TypeDescriptionTel");
                            int DialCode = reader.GetOrdinal("DialCode");
                            int Number = reader.GetOrdinal("Number");
                            int FullNumber = reader.GetOrdinal("FullNumber");
                            int LastUpdatedDateTel = reader.GetOrdinal("LastUpdatedDateTel");

                            while (reader.Read())
                            {
                                TelephoneInfo.TypeDescriptionTel = (reader[TypeDescriptionTel] != Convert.DBNull) ? reader[TypeDescriptionTel].ToString() : null;
                                TelephoneInfo.DialCode = (reader[DialCode] != Convert.DBNull) ? reader[DialCode].ToString() : null;
                                TelephoneInfo.Number = (reader[Number] != Convert.DBNull) ? reader[Number].ToString() : null;
                                TelephoneInfo.FullNumber = (reader[FullNumber] != Convert.DBNull) ? reader[FullNumber].ToString() : null;
                                TelephoneInfo.LastUpdatedDateTel = (reader[LastUpdatedDateTel] != Convert.DBNull) ? reader[LastUpdatedDateTel].ToString() : null;

                                telephoneInformationList.Add(TelephoneInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["telephoneInformationList"] = telephoneInformationList;
                        ViewData["telephoneInformationListCount"] = telephoneInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End TelephonehistoryInformation***********//

                //************************************************* Start EmploymenthistoryInformation ***********//
                string query_uid_EmploymentHistoryInfo = $"SELECT * FROM employmenthistory as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_EmploymentHistoryInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //query_uid_EmploymentHistoryInformation
                            EmploymentHistory EmploymentInfo = new EmploymentHistory();

                            // EmploymentHistory
                            int EmployerName = reader.GetOrdinal("EmployerName");
                            int Designation = reader.GetOrdinal("Designation");
                            int EmployLastUpdatedDate = reader.GetOrdinal("LastUpdatedDate");

                            while (reader.Read())
                            {
                                EmploymentInfo.EmployerName = (reader[EmployerName] != Convert.DBNull) ? reader[EmployerName].ToString() : null;
                                EmploymentInfo.Designation = (reader[Designation] != Convert.DBNull) ? reader[Designation].ToString() : null;
                                EmploymentInfo.LastUpdatedDate = (reader[EmployLastUpdatedDate] != Convert.DBNull) ? reader[EmployLastUpdatedDate].ToString() : null;

                                employmentInformationList.Add(EmploymentInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["employmentInformationList"] = employmentInformationList;
                        ViewData["employmentInformationListCount"] = employmentInformationList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End TelephonehistoryInformation***********//

                //************************************************* Start DirectorShipInformation ***********//
                string query_uid_DirectorShipInfo = $"SELECT * FROM directorships as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_DirectorShipInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //DirectorshipInformation
                            Directorship DirectorshipInfo = new Directorship();

                            // DirectorshipHistory
                            int DesignationCode = reader.GetOrdinal("DesignationCode");
                            int AppointmentDate = reader.GetOrdinal("AppointmentDate");
                            int DirectorStatus = reader.GetOrdinal("DirectorStatus");
                            int DirectorStatusDate = reader.GetOrdinal("DirectorStatusDate");
                            int CompanyName = reader.GetOrdinal("CompanyName");
                            int CompanyType = reader.GetOrdinal("CompanyType");
                            int CompanyStatus = reader.GetOrdinal("CompanyStatus");
                            int CompanyStatusCode = reader.GetOrdinal("CompanyStatusCode");
                            int CompanyRegistrationNumber = reader.GetOrdinal("CompanyRegistrationNumber");
                            int CompanyRegistrationDate = reader.GetOrdinal("CompanyRegistrationDate");
                            int CompanyStartDate = reader.GetOrdinal("CompanyStartDate");
                            int CompanyTaxNumber = reader.GetOrdinal("CompanyTaxNumber");
                            int DirectorTypeCode = reader.GetOrdinal("DirectorTypeCode");
                            int DirectorType = reader.GetOrdinal("DirectorType");
                            int MemberSize = reader.GetOrdinal("MemberSize");
                            int MemberContribution = reader.GetOrdinal("MemberContribution");
                            int MemberContributionType = reader.GetOrdinal("MemberContributionType");
                            int ResignationDate = reader.GetOrdinal("ResignationDate");

                            while (reader.Read())
                            {
                                DirectorshipInfo.DesignationCode = (reader[DesignationCode] != Convert.DBNull) ? reader[DesignationCode].ToString() : null;
                                DirectorshipInfo.AppointmentDate = (reader[AppointmentDate] != Convert.DBNull) ? reader[AppointmentDate].ToString() : null;
                                DirectorshipInfo.DirectorStatus = (reader[DirectorStatus] != Convert.DBNull) ? reader[DirectorStatus].ToString() : null;
                                DirectorshipInfo.DirectorStatusDate = (reader[DirectorStatusDate] != Convert.DBNull) ?
                                reader[DirectorStatusDate].ToString() : null; DirectorshipInfo.CompanyName =
                                (reader[CompanyName] != Convert.DBNull) ? reader[CompanyName].ToString() : null;
                                DirectorshipInfo.CompanyType = (reader[CompanyType] != Convert.DBNull) ?
                                reader[CompanyType].ToString() : null; DirectorshipInfo.CompanyStatus =
                                (reader[CompanyStatus] != Convert.DBNull) ? reader[CompanyStatus].ToString() : null;
                                DirectorshipInfo.CompanyStatusCode = (reader[CompanyStatusCode] != Convert.DBNull) ?
                                reader[CompanyStatusCode].ToString() : null; DirectorshipInfo.CompanyRegistrationNumber
                                = (reader[CompanyRegistrationNumber] != Convert.DBNull) ?
                                reader[CompanyRegistrationNumber].ToString() : null;
                                DirectorshipInfo.CompanyRegistrationDate = (reader[CompanyRegistrationDate] !=
                                Convert.DBNull) ? reader[CompanyRegistrationDate].ToString() : null;
                                DirectorshipInfo.CompanyStartDate = (reader[CompanyStartDate] != Convert.DBNull) ?
                                reader[CompanyStartDate].ToString() : null; DirectorshipInfo.CompanyTaxNumber =
                                (reader[CompanyTaxNumber] != Convert.DBNull) ? reader[CompanyTaxNumber].ToString() :
                                null; DirectorshipInfo.DirectorTypeCode = (reader[DirectorTypeCode] != Convert.DBNull) ?
                                reader[DirectorTypeCode].ToString() : null; DirectorshipInfo.DirectorType =
                                (reader[DirectorType] != Convert.DBNull) ? reader[DirectorType].ToString() : null;
                                DirectorshipInfo.MemberSize = (reader[MemberSize] != Convert.DBNull) ?
                                reader[MemberSize].ToString() : null; DirectorshipInfo.MemberContribution =
                                (reader[MemberContribution] != Convert.DBNull) ? reader[MemberContribution].ToString()
                                : null; DirectorshipInfo.MemberContributionType = (reader[MemberContributionType] !=
                                Convert.DBNull) ? reader[MemberContributionType].ToString() : null;
                                DirectorshipInfo.ResignationDate = (reader[ResignationDate] != Convert.DBNull) ?
                                reader[ResignationDate].ToString() : null;

                                directorshipList.Add(DirectorshipInfo);
                            }
                        }

                        //add list to the viewbagviewdata
                        ViewData["directorshipList"] = directorshipList;
                        ViewData["directorshipListCount"] = directorshipList.Count;
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CPAAccountsInformation***********//
                string query_uid_cppaAccountsInfo = $"SELECT * FROM cpa_accounts as a WHERE a.SearchToken = '{DbSearch.token}'";
                using (var cmd = new MySqlCommand(query_uid_cppaAccountsInfo, conn))
                    try
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            //CPAInformation
                            CPAaccounts cppaAccounts = new CPAaccounts();

                            int Account_ID = reader.GetOrdinal("Account_ID");
                            /*int SubscriberCode = reader.GetOrdinal("SubscriberCode");
                            int SubscriberName = reader.GetOrdinal("SubscriberName");
                            int AccountNO = reader.GetOrdinal("AccountNO");
                            int SubAccountNO = reader.GetOrdinal("SubAccountNO");
                            int OwnershipType = reader.GetOrdinal("OwnershipType");
                            int OwnershipTypeDescription = reader.GetOrdinal("OwnershipTypeDescription");
                            int Reason = reader.GetOrdinal("Reason");
                            int ReasonDescription = reader.GetOrdinal("ReasonDescription");
                            int PaymentType = reader.GetOrdinal("PaymentType");
                            int PaymentTypeDescription = reader.GetOrdinal("PaymentTypeDescription");
                            int AccountType = reader.GetOrdinal("AccountType");
                            int AccountTypeDescription = reader.GetOrdinal("AccountTypeDescription");
                            int OpenDate = reader.GetOrdinal("OpenDate");
                            int DeferredPaymentDate = reader.GetOrdinal("DeferredPaymentDate");
                            int LastPaymentDate = reader.GetOrdinal("LastPaymentDate");
                            int OpenBalance = reader.GetOrdinal("OpenBalance");
                            int OpenBalanceIND = reader.GetOrdinal("OpenBalanceIND");
                            int CurrentBalance = reader.GetOrdinal("CurrentBalance");
                            int CurrentBalanceIND = reader.GetOrdinal("CurrentBalanceIND");
                            int OverdueAmount = reader.GetOrdinal("OverdueAmount");
                            int OverdueAmountIND = reader.GetOrdinal("OverdueAmountIND");
                            int InstalmentAmount = reader.GetOrdinal("InstalmentAmount");
                            int ArrearsPeriod = reader.GetOrdinal("ArrearsPeriod");
                            int RepaymentFrequency = reader.GetOrdinal("RepaymentFrequency");
                            int RepaymentFrequencyDescription = reader.GetOrdinal("RepaymentFrequencyDescription");
                            int Terms = reader.GetOrdinal("Terms");
                            int StatusCode = reader.GetOrdinal("StatusCode");
                            int StatusCodeDesc = reader.GetOrdinal("StatusCodeDesc");
                            int IndustryType = reader.GetOrdinal("IndustryType");
                            int PaymentHistoryChartURL = reader.GetOrdinal("PaymentHistoryChartURL");
                            int StatusDate = reader.GetOrdinal("StatusDate");
                            int ThirdPartyName = reader.GetOrdinal("ThirdPartyName");
                            int ThirdPartySold = reader.GetOrdinal("ThirdPartySold");
                            int ThirdPartySoldDescription = reader.GetOrdinal("ThirdPartySoldDescription");
                            int JointLoanParticipants = reader.GetOrdinal("JointLoanParticipants");
                            int PaymentHistory = reader.GetOrdinal("PaymentHistory");
                            int PaymentHistoryStatus = reader.GetOrdinal("PaymentHistoryStatus");
                            int PaymentHistoryChart = reader.GetOrdinal("PaymentHistoryChart");
                            int MonthEndDate = reader.GetOrdinal("MonthEndDate");
                            int DateCreated = reader.GetOrdinal("DateCreated");*/
                            //Fetch PaymenyHistory Array
                            //public string PaymentHistoryChartURL = reader.GetOrdonal("");
                            //public Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails = reader.GetOrdonal("");
                            // CPAInformation

                            while (reader.Read())
                            {
                                cppaAccounts.Account_ID = (reader[Account_ID] != Convert.DBNull) ? reader[Account_ID].ToString() : null;
                                /*cppaAccounts.SubscriberCode = (reader[SubscriberCode] != Convert.DBNull) ? reader[SubscriberCode].ToString() : null;
                                cppaAccounts.SubscriberName = (reader[SubscriberName] != Convert.DBNull) ? reader[SubscriberName].ToString() : null;
                                cppaAccounts.AccountNO = (reader[AccountNO] != Convert.DBNull) ? reader[AccountNO].ToString() : null;
                                cppaAccounts.SubAccountNO = (reader[SubAccountNO] != Convert.DBNull) ? reader[SubAccountNO].ToString() : null;
                                cppaAccounts.OwnershipType = (reader[OwnershipType] != Convert.DBNull) ? reader[OwnershipType].ToString() : null;
                                cppaAccounts.OwnershipTypeDescription = (reader[OwnershipTypeDescription] != Convert.DBNull) ? reader[OwnershipTypeDescription].ToString() : null;
                                cppaAccounts.Reason = (reader[Reason] != Convert.DBNull) ? reader[Reason].ToString() : null;
                                cppaAccounts.ReasonDescription = (reader[ReasonDescription] != Convert.DBNull) ? reader[ReasonDescription].ToString() : null;
                                cppaAccounts.PaymentType = (reader[PaymentType] != Convert.DBNull) ? reader[PaymentType].ToString() : null;
                                cppaAccounts.PaymentTypeDescription = (reader[PaymentTypeDescription] != Convert.DBNull) ? reader[PaymentTypeDescription].ToString() : null;
                                cppaAccounts.AccountType = (reader[AccountType] != Convert.DBNull) ? reader[AccountType].ToString() : null;
                                cppaAccounts.AccountTypeDescription = (reader[AccountTypeDescription] != Convert.DBNull) ? reader[AccountTypeDescription].ToString() : null;
                                cppaAccounts.OpenDate = (reader[OpenDate] != Convert.DBNull) ? reader[OpenDate].ToString() : null;
                                cppaAccounts.DeferredPaymentDate = (reader[DeferredPaymentDate] != Convert.DBNull) ? reader[DeferredPaymentDate].ToString() : null;
                                cppaAccounts.LastPaymentDate = (reader[LastPaymentDate] != Convert.DBNull) ? reader[LastPaymentDate].ToString() : null;
                                cppaAccounts.OpenBalance = (reader[OpenBalance] != Convert.DBNull) ? reader[OpenBalance].ToString() : null;
                                cppaAccounts.OpenBalanceIND = (reader[OpenBalanceIND] != Convert.DBNull) ? reader[OpenBalanceIND].ToString() : null;
                                cppaAccounts.CurrentBalance = (reader[CurrentBalance] != Convert.DBNull) ? reader[CurrentBalance].ToString() : null;
                                cppaAccounts.CurrentBalanceIND = (reader[CurrentBalanceIND] != Convert.DBNull) ? reader[CurrentBalanceIND].ToString() : null;
                                cppaAccounts.OverdueAmount = (reader[OverdueAmount] != Convert.DBNull) ? reader[OverdueAmount].ToString() : null;
                                cppaAccounts.OverdueAmountIND = (reader[OverdueAmountIND] != Convert.DBNull) ? reader[OverdueAmountIND].ToString() : null;
                                cppaAccounts.InstalmentAmount = (reader[InstalmentAmount] != Convert.DBNull) ? reader[InstalmentAmount].ToString() : null;
                                cppaAccounts.ArrearsPeriod = (reader[ArrearsPeriod] != Convert.DBNull) ? reader[ArrearsPeriod].ToString() : null;
                                cppaAccounts.RepaymentFrequency = (reader[RepaymentFrequency] != Convert.DBNull) ? reader[RepaymentFrequency].ToString() : null;
                                cppaAccounts.RepaymentFrequencyDescription = (reader[RepaymentFrequencyDescription] != Convert.DBNull) ? reader[RepaymentFrequencyDescription].ToString() : null;
                                cppaAccounts.Terms = (reader[Terms] != Convert.DBNull) ? reader[Terms].ToString() : null;
                                cppaAccounts.StatusCode = (reader[StatusCode] != Convert.DBNull) ? reader[StatusCode].ToString() : null;
                                cppaAccounts.StatusCodeDesc = (reader[StatusCodeDesc] != Convert.DBNull) ? reader[StatusCodeDesc].ToString() : null;
                                cppaAccounts.IndustryType = (reader[IndustryType] != Convert.DBNull) ? reader[IndustryType].ToString() : null;
                                cppaAccounts.PaymentHistoryChartURL = (reader[PaymentHistoryChartURL] != Convert.DBNull) ? reader[PaymentHistoryChartURL].ToString() : null;
                                cppaAccounts.StatusDate = (reader[StatusDate] != Convert.DBNull) ? reader[StatusDate].ToString() : null;
                                cppaAccounts.ThirdPartyName = (reader[ThirdPartyName] != Convert.DBNull) ? reader[ThirdPartyName].ToString() : null;
                                cppaAccounts.ThirdPartySold = (reader[ThirdPartySold] != Convert.DBNull) ? reader[ThirdPartySold].ToString() : null;
                                cppaAccounts.ThirdPartySoldDescription = (reader[ThirdPartySoldDescription] != Convert.DBNull) ? reader[ThirdPartySoldDescription].ToString() : null;
                                cppaAccounts.JointLoanParticipants = (reader[JointLoanParticipants] != Convert.DBNull) ? reader[JointLoanParticipants].ToString() : null;
                                cppaAccounts.PaymentHistory = (reader[PaymentHistory] != Convert.DBNull) ? reader[PaymentHistory].ToString() : null;
                                cppaAccounts.PaymentHistoryStatus = (reader[PaymentHistoryStatus] != Convert.DBNull) ? reader[PaymentHistoryStatus].ToString() : null;
                                cppaAccounts.PaymentHistoryChart = (reader[PaymentHistoryChart] != Convert.DBNull) ? reader[PaymentHistoryChart].ToString() : null;
                                cppaAccounts.MonthEndDate = (reader[MonthEndDate] != Convert.DBNull) ? reader[MonthEndDate].ToString() : null;
                                cppaAccounts.DateCreated = (reader[DateCreated] != Convert.DBNull) ? reader[DateCreated].ToString() : null;*/

                                //Read PaymentHistoryAccountDetails

                                cppaAccountsList.Add(cppaAccounts);
                            }
                            //add list to the viewbagviewdata cppaAccountsList
                            ViewData["cppaAccountsList"] = cppaAccountsList;
                            ViewData["cppaAccountsListCount"] = cppaAccountsList.Count;
                        }
                    }
                    catch (Exception err)
                    {
                        System.Diagnostics.Debug.WriteLine(err);
                    }
                //************************************************* End CPAAccountsInformation***********//
            }
            return View();
        }

        //Incomplete Integrations Start Here
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
            saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionCompanyProfileByCompanyID");

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
            try
            {
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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionCompanyProfile");

                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                return View();
            }
            catch (Exception e)
            {
                ViewData["msg"] = "Error Occured, Please verify the details that have been entered";
                return View();
            }
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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionConsumerContactInformation");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionConsumerIDVerification");

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
                TempData["ResponseMessage"] = rootObject.ResponseMessage;
                var mes = TempData["ResponseMessage"].ToString();
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
                    saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionConsumerTraceID");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionConsumerTracemobile");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionConsumerTracesurname");

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
                ViewData["ResponseMessage"] = rootObject.ResponseMessage;
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "TransUnionConsumerTracetele");
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
            saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "VeriCredAccountVerification");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "VeriCredContactInfoByIDNumbe");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "VeriCredIDPhotoVerification");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "VeriCredIncomeEstimateByIDNumber");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "VeriCredPersonVerificationByIDNumber");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "XDSConsumerIDphoto");

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
                saveSearchHistory(SearchID, SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken, CallerModule, DataSupplier, SearchType, SearchDescription, "XDSConsumerTraceaddress");

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

//----------------------------------COMPUSCAN CODE STARTS FROM HERE!!!!!  1) UNCOMMENT FROM NEXT LINE, CUT AND PASTE INSIDE A CLASS.-----------------------------
//    public ActionResult CompuScan()
//    {
//        return View();
//    }

// public ActionResult CompuScanBankCodesDocument() { return View(); }

// public ActionResult CompuScanBankCodesDocumentResults(CompuScan comp) { try { string id =
// comp.IDNumber; string clientName = comp.clientName; string bankName = comp.bankName; string
// branchCode = comp.branchCode; string branchName = comp.branchName; string accountNumber =
// comp.accountNumber; int amount = comp.amount; string terms = comp.terms; int reportType = comp.ReportType;

// string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "Combined Consumer Trace"; string action = "Client Name:" + clientName + "; Bank
// Name: " + bankName + "; Branch Code:" + branchCode + "; Branch Name: " + branchName + "; Account
// Number:" + accountNumber + "; Amount:" + amount + "; Terms:" + terms + "; Report Type" +
// reportType; string user_id = Session["ID"].ToString(); string us = Session["Name"].ToString();

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/documents/compuscan/bankcodes/"; //create RestSharp client and
// POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { sessionToken = authtoken, reference = us,//search reference: probably store in
// logs idNumber = id, clientName = clientName, bankName = bankName, branchCode = branchCode,
// branchName = branchName, accountNumber = accountNumber, amount = amount, terms = terms,
// ReportType = reportType, };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

// JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage; int SearchID =
// rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Name = ViewData["user"].ToString(); string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; saveSearchHistory(SearchID,
// SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken,
// CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanBankCodesDocument"); } catch
// (Exception e) { TempData["msg"] = "An error occured, please check the entered values."; }

// return View(); }

// public ActionResult CompuScanBankOnFile() { return View(); }

// public ActionResult CompuScanBankOnFileResults(CompuScan comp) { string id = comp.IDNumber; try {
// string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Bank On File"; string action = "ID: " + id; string user_id =
// Session["ID"].ToString(); string us = Session["Name"].ToString();

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/compuscan/bankcodes/idnumber/"; //create RestSharp client and
// POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { sessionToken = authtoken, reference = us,//search reference: probably store in
// logs iDNumber = id };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
// System.Diagnostics.Debug.WriteLine(o); JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage;

// var mes = ViewData["ResponseMessage"].ToString(); if (mes == "ServiceOffline") {
// ViewData["Message"] = "Service is offline"; return View(); } int SearchID =
// rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; //string ResponseType =
// rootObject.ResponseMessage; ; saveSearchHistory(SearchID, SearchUserName, "CompuScanBankOnFile",
// Session["Name"].ToString(), ReportDate, Reference, SearchToken, "credit/compuScan", null,
// SearchType, SearchDescription, "CompuScanBankOnFile"); } catch (Exception e) { TempData["msg"] =
// "An error occured, please check the entered values."; } return View(); }

// public ActionResult CompuScanConsumerProfile() { return View(); }

// public ActionResult CompuScanConsumerProfileResults(CompuScan comp) { string id = comp.IDNumber;
// int enquiryReason = comp.EnquiryReason; string surname = comp.Surname; string firstname =
// comp.FirstName; string refe = comp.Reference;

// string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName); try { var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Consumer Profile"; string action = "First Name: " + firstname + ";
// Surname: " + surname + "; Enquiry Reason: " + enquiryReason + "; ID: " + id; string user_id =
// Session["ID"].ToString(); string us = Session["Name"].ToString();

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/credit/compuscan/consumerprofile/"; //create RestSharp client
// and POST request object var client = new RestClient(url); var request = new
// RestRequest(Method.POST); ViewData["user"] = Session["Name"].ToString();

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { sessionToken = authtoken, reference = us,//search reference: probably store in
// logs idNumber = id, enquiryReason = enquiryReason, surname = surname, firstname = firstname, };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

// JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage; var mes = ViewData["ResponseMessage"].ToString();

// if (mes == "ServiceOffline") { ViewData["Message"] = "Service is offline"; return View(); } else
// { ViewData["Message"] = "good";

// int SearchID = rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; saveSearchHistory(SearchID,
// SearchUserName, ResponseType, Session["Name"].ToString(), ReportDate, Reference, SearchToken,
// CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanConsumerProfile");

// if (rootObject.ResponseObject.PersonInformation != null) { //personaInformantion
// ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
// ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
// ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname; ViewData["Fullname"] =
// rootObject.ResponseObject.PersonInformation.Fullname; ViewData["IDNumber"] =
// rootObject.ResponseObject.PersonInformation.IDNumber; ViewData["Gender"] =
// rootObject.ResponseObject.PersonInformation.Gender; ViewData["Age"] =
// rootObject.ResponseObject.PersonInformation.Age; ViewData["Country"] =
// rootObject.ResponseObject.PersonInformation.Country; ViewData["VerificationStatus"] =
// rootObject.ResponseObject.PersonInformation.VerificationStatus; ViewData["HasProperties"] =
// rootObject.ResponseObject.PersonInformation.HasProperties; savePersonInformation(SearchToken,
// Reference, SearchID, null, null, null, ViewData["DateOfBirth"].ToString(),
// ViewData["FirstName"].ToString(), ViewData["Surname"].ToString(),
// ViewData["Fullname"].ToString(), ViewData["IDNumber"].ToString(), null, null, null, null,
// ViewData["Gender"].ToString(), ViewData["Age"].ToString(), null, null, null, null, null, null ,
// null, ViewData["VerificationStatus"].ToString(), ViewData["HasProperties"], "CompuScan"); } else
// { ViewData["PersonInformationMessage"] = "No Match"; }

// if (rootObject.ResponseObject.CreditInformation != null) { //CreditInformation
// ViewData["DelphiScore"] = rootObject.ResponseObject.CreditInformation.DelphiScore;
// ViewData["Risk"] = rootObject.ResponseObject.CreditInformation.Risk; ViewData["RiskColour"] =
// rootObject.ResponseObject.CreditInformation.RiskColour; ViewData["DelphiScoreChartURL"] =
// rootObject.ResponseObject.CreditInformation.DelphiScoreChartURL;
// ViewData["TotalInstallmentAmountCPAAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalInstallmentAmountCPAAccounts_CompuScan;
// ViewData["TotalInstallmentAmountNLRAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalInstallmentAmountNLRAccounts_CompuScan;
// ViewData["TotalNumberCPAAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalNumberCPAAccounts_CompuScan;
// ViewData["TotalNumberNLRAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalNumberNLRAccounts_CompuScan;
// ViewData["TotalNumberActiveCPAAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalNumberActiveCPAAccounts_CompuScan;
// ViewData["TotalNumberActiveNLRAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalNumberActiveNLRAccounts_CompuScan;
// ViewData["TotalNumberClosedCPAAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalNumberClosedCPAAccounts_CompuScan;
// ViewData["TotalNumberClosedNLRAccounts_CompuScan"] =
// rootObject.ResponseObject.CreditInformation.TotalNumberClosedNLRAccounts_CompuScan;
// //saveCreditInformation(SearchToken, Reference, SearchID, " ", //
// ViewData["DelphiScore"].ToString(), // ViewData["DelphiScoreChartURL"].ToString(),
// ViewData["RiskColour"].ToString(), // " ", " ",
// ViewData["TotalInstallmentAmountCPAAccounts_CompuScan"].ToString(), //
// ViewData["TotalInstallmentAmountNLRAccounts_CompuScan"].ToString(),
// ViewData["TotalNumberCPAAccounts_CompuScan"].ToString(), //
// ViewData["TotalNumberNLRAccounts_CompuScan"].ToString(),
// ViewData["TotalNumberActiveCPAAccounts_CompuScan"].ToString(), //
// ViewData["TotalNumberActiveNLRAccounts_CompuScan"].ToString(),
// ViewData["TotalNumberClosedCPAAccounts_CompuScan"].ToString(), // ViewData["TotalNumberClosedNLRAccounts_CompuScan"].ToString());

// //DeclineReason ViewData["ReasonDescription"] =
// rootObject.ResponseObject.CreditInformation.DeclineReason[0].ReasonDescription;
// saveCreditDeclineReason(SearchToken, Reference, SearchID, null,
// ViewData["ReasonDescription"].ToString(), "CompuScan"); //DataCounts ViewData["Accounts"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Accounts; ViewData["Enquiries"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Enquiries; ViewData["Judgments"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Judgments; ViewData["Notices"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Notices; ViewData["BankDefaults"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.BankDefaults; ViewData["Defaults"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Defaults; ViewData["Collections"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Collections; ViewData["Directors"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Directors; ViewData["Addresses"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Addresses; ViewData["Telephones"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Telephones; ViewData["Occupants"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Occupants; ViewData["Employers"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Employers; ViewData["TraceAlerts"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.TraceAlerts; ViewData["PaymentProfiles"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.PaymentProfiles; ViewData["OwnEnquiries"]
// = rootObject.ResponseObject.CreditInformation.DataCounts.OwnEnquiries; ViewData["AdminOrders"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.AdminOrders; ViewData["PossibleMatches"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.PossibleMatches;
// ViewData["DefiniteMatches"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.DefiniteMatches; ViewData["Loans"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Loans; ViewData["FraudAlerts"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.FraudAlerts; ViewData["Companies"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Companies; ViewData["Properties"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Properties; ViewData["Documents"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Documents; ViewData["DemandLetters"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.DemandLetters; ViewData["Trusts"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Trusts; ViewData["Bonds"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Bonds; ViewData["Deeds"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.Deeds; ViewData["PublicDefaults"] =
// rootObject.ResponseObject.CreditInformation.DataCounts.PublicDefaults; ViewData["NLRAccounts"] = rootObject.ResponseObject.CreditInformation.DataCounts.NLRAccounts;

// //DebtReviewStatus ViewData["DRStatusCode"] =
// rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusCode;
// ViewData["DRStatusDescription"] =
// rootObject.ResponseObject.CreditInformation.DebtReviewStatus.StatusDescription;
// //saveDebtReviewStatus(SearchToken, Reference, SearchID, ViewData["DRStatusCode"].ToString(),
// null, ViewData["DRStatusDescription"].ToString(), null); //ConsumerStatistics
// ViewData["HighestJudgment"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.HighestJudgment;
// ViewData["RevolvingAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.RevolvingAccounts;
// ViewData["InstalmentAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.InstalmentAccounts;
// ViewData["OpenAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.OpenAccounts;
// ViewData["AdverseAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.AdverseAccounts; //NLRStats
// ViewData["NLRStats_ActiveAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ActiveAccounts;
// ViewData["NLRStats_ClosedAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.ClosedAccounts;
// ViewData["NLRStats_WorstMonthArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.WorstMonthArrears;
// ViewData["NLRStats_BalanceExposure"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.BalanceExposure;
// ViewData["NLRStats_MonthlyInstalment"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.MonthlyInstalment;
// ViewData["NLRStats_CumulativeArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLRStats.CumulativeArrears;
// //CCAStats ViewData["CCAStats_ActiveAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ActiveAccounts;
// ViewData["CCAStats_ClosedAccounts"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.ClosedAccounts;
// ViewData["CCAStats_WorstMonthArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.WorstMonthArrears;
// ViewData["CCAStats_BalanceExposure"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.BalanceExposure;
// ViewData["CCAStats_MonthlyInstalment"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.MonthlyInstalment;
// ViewData["CCAStats_CumulativeArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCAStats.CumulativeArrears;
// //NLR12Months ViewData["NLR12Months_EnquiriesByClient"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByClient;
// ViewData["NLR12Months_EnquiriesByOther"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.EnquiriesByOther;
// ViewData["NLR12Months_PositiveLoans"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.PositiveLoans;
// ViewData["NLR12Months_HighestMonthsInArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR12Months.HighestMonthsInArrears;
// //NLR36Months ViewData["NLR36Months_EnquiriesByClient"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByClient;
// ViewData["NLR36Months_EnquiriesByOther"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.EnquiriesByOther;
// ViewData["NLR36Months_PositiveLoans"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.PositiveLoans;
// ViewData["NLR36Months_HighestMonthsInArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR36Months.HighestMonthsInArrears;
// //NLR24Months ViewData["NLR24Months_EnquiriesByClient"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByClient;
// ViewData["NLR24Months_EnquiriesByOther"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.EnquiriesByOther;
// ViewData["NLR24Months_PositiveLoans"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.PositiveLoans;
// ViewData["NLR24Months_HighestMonthsInArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.NLR24Months.HighestMonthsInArrears;
// //CCA12Months ViewData["CCA12Months_EnquiriesByClient"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByClient;
// ViewData["CCA12Months_EnquiriesByOther"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.EnquiriesByOther;
// ViewData["CCA12Months_PositiveLoans"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.PositiveLoans;
// ViewData["CCA12Months_HighestMonthsInArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA12Months.HighestMonthsInArrears;
// //CCA24Months ViewData["CCA24Months_EnquiriesByClient"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByClient;
// ViewData["CCA24Months_EnquiriesByOther"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.EnquiriesByOther;
// ViewData["CCA24Months_PositiveLoans"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.PositiveLoans;
// ViewData["CCA24Months_HighestMonthsInArrears"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA24Months.HighestMonthsInArrears;
// //CCA36Months ViewData["CCA36Months_EnquiriesByClient"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByClient;
// ViewData["CCA36Months_EnquiriesByOther"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.EnquiriesByOther;
// ViewData["CCA36Months_PositiveLoans"] =
// rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.PositiveLoans;
// ViewData["CCA36Months_HighestMonthsInArrears"] = rootObject.ResponseObject.CreditInformation.ConsumerStatistics.CCA36Months.HighestMonthsInArrears;

// //EnquiryHistory ViewData["EnquiryHistory_EnquiryDate"] =
// rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiryDate;
// ViewData["EnquiryHistory_EnquiredBy"] =
// rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiredBy;
// ViewData["EnquiryHistory_EnquiredByContact"] =
// rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiredByContact;
// ViewData["EnquiryHistory_EnquiredByContactNumber"] = rootObject.ResponseObject.CreditInformation.EnquiryHistory[0].EnquiredByContactNumber;

// //CPA_Accounts if (rootObject.ResponseObject.CreditInformation.CPA_Accounts != null) {
// ViewData["SubscriberCode"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].SubscriberCode;
// ViewData["SubscriberName"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].SubscriberName;
// ViewData["BranchCode"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].BranchCode;
// ViewData["AccountNO"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].AccountNO;
// ViewData["SubAccountNO"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].SubAccountNO;
// ViewData["OwnershipType"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OwnershipType;
// ViewData["OwnershipTypeDescription"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OwnershipTypeDescription;
// ViewData["Reason"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].Reason;
// ViewData["ReasonDescription"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ReasonDescription;
// ViewData["PaymentType"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentType;
// ViewData["PaymentTypeDescription"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentTypeDescription;
// ViewData["AccountType"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].AccountType;
// ViewData["AccountTypeDescription"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].AccountTypeDescription;
// ViewData["OpenDate"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OpenDate;
// ViewData["DeferredPaymentDate"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].DeferredPaymentDate;
// ViewData["LastPaymentDate"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].LastPaymentDate;
// ViewData["OpenBalance"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OpenBalance;
// ViewData["OpenBalanceIND"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OpenBalanceIND;
// ViewData["CurrentBalance"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].CurrentBalance;
// ViewData["CurrentBalanceIND"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].CurrentBalanceIND;
// ViewData["OverdueAmount"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OverdueAmount;
// ViewData["OverdueAmountIND"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].OverdueAmountIND;
// ViewData["InstalmentAmount"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].InstalmentAmount;
// ViewData["ArrearsPeriod"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ArrearsPeriod;
// ViewData["RepaymentFrequency"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].RepaymentFrequency;
// ViewData["RepaymentFrequencyDescription"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].RepaymentFrequencyDescription;
// ViewData["Terms"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].Terms;
// ViewData["StatusCode"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].StatusCode;
// ViewData["StatusCodeDesc"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].StatusCodeDesc;
// ViewData["StatusDate"] = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].StatusDate;
// ViewData["ThirdPartyName"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ThirdPartyName;
// ViewData["ThirdPartySold"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ThirdPartySold;
// ViewData["ThirdPartySoldDescription"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].ThirdPartySoldDescription;
// ViewData["JointLoanParticipants"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].JointLoanParticipants;
// ViewData["PaymentHistory"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentHistory;
// ViewData["PaymentHistoryStatus"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentHistoryStatus;
// ViewData["PaymentHistoryChart"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].PaymentHistoryChart;
// ViewData["MonthEndDate"] =
// rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].MonthEndDate; ViewData["DateCreated"]
// = rootObject.ResponseObject.CreditInformation.CPA_Accounts[0].DateCreated; }

// //NLR_Accounts if (rootObject.ResponseObject.CreditInformation.NLR_Accounts != null) {
// ViewData["NLR_SubscriberCode"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubscriberCode;
// ViewData["NLR_SubscriberName"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubscriberName;
// ViewData["NLR_BranchCode"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].BranchCode; ViewData["NLR_AccountNO"]
// = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].AccountNO;
// ViewData["NLR_SubAccountNO"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubAccountNO;
// ViewData["NLR_OwnershipType"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OwnershipType;
// ViewData["NLR_OwnershipTypeDescription"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OwnershipTypeDescription;
// ViewData["NLR_Reason"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].Reason;
// ViewData["NLR_ReasonDescription"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ReasonDescription;
// ViewData["NLR_PaymentType"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentType;
// ViewData["NLR_PaymentTypeDescription"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentTypeDescription;
// ViewData["NLR_AccountType"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].AccountType;
// ViewData["NLR_AccountTypeDescription"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].AccountTypeDescription;
// ViewData["NLR_OpenDate"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OpenDate;
// ViewData["NLR_DeferredPaymentDate"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].DeferredPaymentDate;
// ViewData["NLR_LastPaymentDate"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].LastPaymentDate;
// ViewData["NLR_OpenBalance"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OpenBalance;
// ViewData["NLR_OpenBalanceIND"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OpenBalanceIND;
// ViewData["NLR_CurrentBalance"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].CurrentBalance;
// ViewData["NLR_CurrentBalanceIND"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].CurrentBalanceIND;
// ViewData["NLR_OverdueAmount"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OverdueAmount;
// ViewData["NLR_OverdueAmountIND"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].OverdueAmountIND;
// ViewData["NLR_InstalmentAmount"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].InstalmentAmount;
// ViewData["NLR_ArrearsPeriod"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ArrearsPeriod;
// ViewData["NLR_RepaymentFrequency"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].SubscriberCodeRepaymentFrequency;
// ViewData["NLR_RepaymentFrequencyDescription"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].RepaymentFrequencyDescription;
// ViewData["NLR_Terms"] = rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].Terms;
// ViewData["NLR_StatusCode"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].StatusCode;
// ViewData["NLR_StatusCodeDesc"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].StatusCodeDesc;
// ViewData["NLR_StatusDate"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].StatusDate;
// ViewData["NLR_ThirdPartyName"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ThirdPartyName;
// ViewData["NLR_ThirdPartySold"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ThirdPartySold;
// ViewData["NLR_ThirdPartySoldDescription"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].ThirdPartySoldDescription;
// ViewData["NLR_JointLoanParticipants"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].JointLoanParticipants;
// ViewData["NLR_PaymentHistory"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentHistory;
// ViewData["NLR_PaymentHistoryStatus"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentHistoryStatus;
// ViewData["NLR_PaymentHistoryChart"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].PaymentHistoryChart;
// ViewData["NLR_MonthEndDate"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].MonthEndDate;
// ViewData["NLR_DateCreated"] =
// rootObject.ResponseObject.CreditInformation.NLR_Accounts[0].DateCreated; } } else {
// ViewData["CreditInformationMessage"] = "No Match"; }

// if (rootObject.ResponseObject.DirectorshipInformation != null) { //Directorships
// ViewData["D_DesignationCode"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DesignationCode;
// ViewData["D_AppointmentDate"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].AppointmentDate;
// ViewData["D_DirectorStatus"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorStatus;
// ViewData["D_DirectorStatusDate"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorStatusDate;
// ViewData["D_CompanyName"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyName;
// ViewData["D_CompanyType"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyType;
// ViewData["D_CompanyStatus"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyStatus;
// ViewData["D_CompanyStatusCode"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyStatusCode;
// ViewData["D_CompanyRegistrationNumber"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyRegistrationNumber;
// ViewData["D_CompanyRegistrationDate"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyRegistrationDate;
// ViewData["D_CompanyStartDate"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyStartDate;
// ViewData["D_CompanyTaxNumber"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].CompanyTaxNumber;
// ViewData["D_DirectorTypeCode"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorTypeCode;
// ViewData["D_DirectorType"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].DirectorType;
// ViewData["D_MemberSize"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].MemberSize;
// ViewData["D_MemberContribution"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].MemberContribution;
// ViewData["D_MemberContributionType"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].MemberContributionType;
// ViewData["D_ResignationDate"] =
// rootObject.ResponseObject.DirectorshipInformation.Directorships[0].ResignationDate; } else {
// ViewData["DirectorshipInformationMessage"] = "No Match"; }

// if (rootObject.ResponseObject.HistoricalInformation.AddressHistory != null) { //AddressHistory
// ViewData["AH_TypeDescription"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;
// ViewData["AH_Line1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line1;
// ViewData["AH_Line2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line2;
// ViewData["AH_Line3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line3;
// ViewData["AH_Line4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line4;
// ViewData["AH_PostalCode"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].PostalCode;
// ViewData["AH_FullAddress"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
// ViewData["AH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;

// //TelephoneHistory ViewData["TH_TypeDescription"] =
// rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeDescription;
// ViewData["TH_FullNumber"] =
// rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].FullNumber;
// ViewData["TH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].LastUpdatedDate;

// //EmploymentHistory ViewData["EH_TypeDescription"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].TypeDescription;
// ViewData["EH_Designation"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
// ViewData["EH_LastUpdatedDate"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate;
// ViewData["EH_EmployeeType"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployeeType;
// ViewData["EH_SalaryFrequency"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].SalaryFrequency;
// ViewData["EH_PayslipReference"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].PayslipReference;
// ViewData["EH_EmployeeNumber"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployeeNumber; } else {
// ViewData["HistoricalInformationMessage"] = "No Match"; } return View(); } } catch (Exception e) {
// System.Diagnostics.Debug.WriteLine(e.ToString()); return View(); } }

// public ActionResult CompuScanConsumerProfileDatabase(DatabaseSearch DbSearch) {
// System.Collections.Generic.List<PersonInformation> personInfoList = new
// System.Collections.Generic.List<PersonInformation>();
// System.Collections.Generic.List<HomeAffairsInformation> homeAffairsInformationList = new
// System.Collections.Generic.List<HomeAffairsInformation>();
// System.Collections.Generic.List<CreditInformation> creditInformationList = new
// System.Collections.Generic.List<CreditInformation>(); System.Collections.Generic.List<DataCounts>
// dataCountsList = new System.Collections.Generic.List<DataCounts>();
// System.Collections.Generic.List<DebtReviewStatus> debtReviewStatusList = new
// System.Collections.Generic.List<DebtReviewStatus>();
// System.Collections.Generic.List<ConsumerStatistics> consumerstatsList = new
// System.Collections.Generic.List<ConsumerStatistics>(); System.Collections.Generic.List<NLRStats>
// nlrstatsList = new System.Collections.Generic.List<NLRStats>();
// System.Collections.Generic.List<CCAStats> ccastatsList = new
// System.Collections.Generic.List<CCAStats>(); System.Collections.Generic.List<CCA12months>
// cca12monthsLists = new System.Collections.Generic.List<CCA12months>();
// System.Collections.Generic.List<CCA24months> cca24monthsList = new
// System.Collections.Generic.List<CCA24months>(); System.Collections.Generic.List<CCA36months>
// cca36monthsList = new System.Collections.Generic.List<CCA36months>();
// System.Collections.Generic.List<NLR12months> nlr12monthsLists = new
// System.Collections.Generic.List<NLR12months>(); System.Collections.Generic.List<NLR24months>
// nlr24monthsLists = new System.Collections.Generic.List<NLR24months>();
// System.Collections.Generic.List<NLR36months> nlr36monthsList = new
// System.Collections.Generic.List<NLR36months>(); System.Collections.Generic.List<EnquiryHistory>
// enquiryInformationList = new System.Collections.Generic.List<EnquiryHistory>();
// System.Collections.Generic.List<AddressHistory> addressInformationList = new
// System.Collections.Generic.List<AddressHistory>();
// System.Collections.Generic.List<EmploymentHistory> employmentInformationList = new
// System.Collections.Generic.List<EmploymentHistory>();
// System.Collections.Generic.List<TelephoneHistory> telephoneInformationList = new
// System.Collections.Generic.List<TelephoneHistory>(); System.Collections.Generic.List<CPAaccounts>
// cppaAccountsList = new System.Collections.Generic.List<CPAaccounts>();
// //System.Collections.Generic.List<PaymentHistoryAccountDetails> paymentHistoryAccountList = new System.Collections.Generic.List<PaymentHistoryAccountDetails>();

// //AND SearchToken = 'cc329011-76c8-4c8c-9ff6-4b5ce6c05d13' AND Reference =
// 'devadmin@ktopportunities.co.za' AND typeOfSearch = 'ExperianConsumerProfile' string
// dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName); //string query_uid = $"SELECT * FROM
// personinformation,homeaffairsinformation,creditinformation,datacounts,debtreviewstatus,addresshistory,telephonehistory,consumerstatistics,nlrstats,ccastats,months,cca24months,cca36months,enquiryhistory,employmenthistory,months,months,nlr36months,cpa_accounts
// WHERE personinformation.SearchToken = '{DbSearch.token}'"; //Add TABLE paymenthistoryaccountdetails!!!!

// using (var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString)) { conn.Open();

// //**************************************************** personal info***********// string
// query_uid_personinformation = $"SELECT * FROM personinformation as a WHERE a.SearchToken =
// '{DbSearch.token}'"; using (var cmd = new MySqlCommand(query_uid_personinformation, conn)) try {
// using (var reader = cmd.ExecuteReader()) { int DateOfBirth = reader.GetOrdinal("DateOfBirth");
// int Title = reader.GetOrdinal("Title"); int FirstName = reader.GetOrdinal("FirstName"); int
// Surname = reader.GetOrdinal("Surname"); int Fullname
// = reader.GetOrdinal("Fullname"); int IDNumber = reader.GetOrdinal("IDNumber"); int Gender
// = reader.GetOrdinal("Gender"); int Age = reader.GetOrdinal("Age"); int MaritalStatus =
// reader.GetOrdinal("MaritalStatus"); int MiddleName1 = reader.GetOrdinal("MiddleName1"); int
// Reference = reader.GetOrdinal("Reference"); int HasProperties = reader.GetOrdinal("HasProperties");

// //PersonInformation

//                        PersonInformation personInformation = new PersonInformation(); personInformation.DateOfBirth
//                        = (reader[DateOfBirth] != Convert.DBNull) ? reader[DateOfBirth].ToString() : null;
//                        personInformation.Title = (reader[Title] != Convert.DBNull) ? reader[Title].ToString() : null;
//                        personInformation.FirstName = (reader[FirstName] != Convert.DBNull) ?
//                        reader[FirstName].ToString() : null; personInformation.Surname = (reader[Surname] !=
//                        Convert.DBNull) ? reader[Surname].ToString() : null; personInformation.Fullname =
//                        (reader[Fullname] != Convert.DBNull) ? reader[Fullname].ToString() : null;
//                        personInformation.IDNumber = (reader[IDNumber] != Convert.DBNull) ? reader[IDNumber].ToString() :
//                        null; personInformation.Gender = (reader[Gender] != Convert.DBNull) ? reader[Gender].ToString() :
//                        null; personInformation.Age = (reader[Age] != Convert.DBNull) ? reader[Age].ToString() : null;
//                        personInformation.MaritalStatus = (reader[MaritalStatus] != Convert.DBNull) ?
//                        reader[MaritalStatus].ToString() : null; personInformation.MiddleName1 = (reader[MiddleName1] !=
//                        Convert.DBNull) ? reader[MiddleName1].ToString() : null; personInformation.Reference =
//                        (reader[Reference] != Convert.DBNull) ? reader[Reference].ToString() : null;
//                        personInformation.HasProperties = (reader[HasProperties] != Convert.DBNull) ?
//                        Convert.ToBoolean(reader[HasProperties]) : false; //add to the list
//                        personInfoList.Add(personInformation);
//                    }
//                    ViewData["PersonInfoList"] = personInfoList;
//                    ViewData["PersonInfoListCount"] = personInfoList.Count;
//                }
//                catch (Exception err)
//                {
//                    //console.log
//                }
//            //*****************************************END personal info***********//
//            //**************************************************** homeaffairsinformation info***********//
//            string query_uid_homeaffairsinformation = $"SELECT * FROM homeaffairsinformation as a WHERE   a.SearchToken = '{DbSearch.token}'";
//            using (var cmd = new MySqlCommand(query_uid_homeaffairsinformation, conn)) try
//                {
//                    using (var reader = cmd.ExecuteReader())
//                    {
//                        //HomeAffairsInformation
//                        HomeAffairsInformation homeAffairsInformation
//= new HomeAffairsInformation(); int ExFirstName = reader.GetOrdinal("FirstName"); int
//DeceasedDate = reader.GetOrdinal("DeceasedDate"); int IDVerified =
//reader.GetOrdinal("IDVerified"); int SurnameVerified = reader.GetOrdinal("SurnameVerified"); int
//Warnings = reader.GetOrdinal("Warnings"); int DeceasedStatus =
//reader.GetOrdinal("DeceasedStatus"); int VerifiedStatus = reader.GetOrdinal("VerifiedStatus");
//                        int InitialsVerified = reader.GetOrdinal("InitialsVerified"); int CauseOfDeath =
//                        reader.GetOrdinal("CauseOfDeath"); int VerifiedDate = reader.GetOrdinal("VerifiedDate");

// homeAffairsInformation.FirstName = (reader[ExFirstName] != Convert.DBNull) ?
// reader[ExFirstName].ToString() : null; homeAffairsInformation.IDVerified = (reader[IDVerified] !=
// Convert.DBNull) ? reader[IDVerified].ToString() : null; homeAffairsInformation.SurnameVerified =
// (reader[SurnameVerified] != Convert.DBNull) ? reader[SurnameVerified].ToString() : null;
// homeAffairsInformation.Warnings = (reader[Warnings] != Convert.DBNull) ?
// reader[Warnings].ToString() : null; homeAffairsInformation.DeceasedDate = (reader[DeceasedDate]
// != Convert.DBNull) ? reader[DeceasedDate].ToString() : null;
// homeAffairsInformation.DeceasedStatus = (reader[DeceasedStatus] != Convert.DBNull) ?
// reader[DeceasedStatus].ToString() : null; homeAffairsInformation.VerifiedStatus =
// (reader[VerifiedStatus] != Convert.DBNull) ? reader[VerifiedStatus].ToString() : null;
// homeAffairsInformation.InitialsVerified = (reader[InitialsVerified] != Convert.DBNull) ?
// reader[InitialsVerified].ToString() : null; homeAffairsInformation.CauseOfDeath =
// (reader[CauseOfDeath] != Convert.DBNull) ? reader[CauseOfDeath].ToString() : null;
// homeAffairsInformation.VerifiedDate = (reader[VerifiedDate] != Convert.DBNull) ?
// reader[VerifiedDate].ToString() : null; //add to the list
// homeAffairsInformationList.Add(homeAffairsInformation); }

// //add list to the viewbagviewdata ViewData["HomeAffairsInfoList"] = homeAffairsInformationList;
// ViewData["HomeAffairsInfoListCount"] = homeAffairsInformationList.Count; } catch (Exception err)
// { System.Diagnostics.Debug.WriteLine(err.ToString()); } }

// return View(); }

// public ActionResult CompuScanConsumerTrace() { return View(); }

// public ActionResult CompuScanConsumerTraceResults(CompuScan comp) { try { string id =
// comp.IDNumber; string tele = comp.TelephoneNumber; string teleID = comp.TelephoneID; string
// traceType = comp.TraceType; string refe = comp.Reference;

// if (traceType == "ID") { string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Consumer Trace By IDNumber"; string action = "ID: " + id; string user_id
// = Session["ID"].ToString(); string us = Session["Name"].ToString();

// ViewData["user"] = Session["Name"].ToString(); ViewData["date"] =
// DateTime.Today.ToShortDateString(); ViewData["ref"] = refe;

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/credit/compuscan/consumertrace/idnumber/"; //create RestSharp
// client and POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { SessionToken = authtoken, Reference = us,//search reference: probably store in
// logs IDNumber = id };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!! JToken
// token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage;

// var mes = ViewData["ResponseMessage"].ToString(); if (mes == "ServiceOffline") {
// ViewData["Message"] = "Service is offline"; return View(); } else { int SearchID =
// rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Name = ViewData["user"].ToString(); string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; saveSearchHistory(SearchID,
// SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken,
// CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanConsumerTrace");

// ViewData["Message"] = "good"; ViewData["Message2"] = "No recent searches available. Please modify
// criteria above.";

// ViewData["PersonInformationMessage"] =
// rootObject.ResponseObject.PersonInformation["DateOfBirth"]; ViewData["CreditInformationMessage"]
// = rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
// ViewData["HomeAffairsInformationMessage"] =
// rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
// ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeCode;

// if (rootObject.ResponseObject.PersonInformation != null) { //personaInformantion
// ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
// ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
// ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname; ViewData["Fullname"] =
// rootObject.ResponseObject.PersonInformation.Fullname; ViewData["IDNumber"] =
// rootObject.ResponseObject.PersonInformation.IDNumber; ViewData["Gender"] =
// rootObject.ResponseObject.PersonInformation.Gender; ViewData["Age"] =
// rootObject.ResponseObject.PersonInformation.Age; ViewData["MiddleName1"] =
// rootObject.ResponseObject.PersonInformation.MiddleName1; ViewData["MiddleName2"] =
// rootObject.ResponseObject.PersonInformation.MiddleName2; ViewData["HasProperties"] =
// rootObject.ResponseObject.PersonInformation.HasProperties; } else {
// ViewData["PersonInformationMessage"] = "No Match"; }

// if (ViewData["CreditInformationMessage"].ToString() != "") { //FraudIndicatorSummary
// ViewData["ProtectiveVerification"] =
// rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"]; }
// else { ViewData["CreditInformationMessage"] = "No Match"; }

// if (ViewData["HomeAffairsInformationMessage"].ToString() != "") { //HomeAffairsInformation
// ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
// ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
// ViewData["CauseOfDeath"] = rootObject.ResponseObject.HomeAffairsInformation.CauseOfDeath;
// ViewData["VerifiedDate"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedDate;
// ViewData["VerifiedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.VerifiedStatus; }
// else { ViewData["HomeAffairsInformationMessage"] = "No Match"; }

// if (ViewData["HistoricalInformationMessage"].ToString() != "") { //AddressHistory
// ViewData["TypeCode"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeCode; ViewData["AH_Line1"]
// = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line1; ViewData["AH_Line2"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line2; ViewData["AH_Line3"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line3; ViewData["AH_Line4"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line4;
// ViewData["AH_PostalCode"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].PostalCode;
// ViewData["AH_FullAddress"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
// ViewData["AH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;

// //TelephoneHistory ViewData["TH_TypeDescription"] =
// rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeDescription;
// ViewData["TH_TypeCode"] =
// rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeCode;
// ViewData["TH_FullNumber"] =
// rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].Number;
// ViewData["TH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].LastUpdatedDate;

// //EmploymentHistory ViewData["EH_EmployerName"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;
// ViewData["EH_Designation"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
// ViewData["EH_LastUpdatedDate"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate; } else {
// ViewData["HistoricalInformationMessage"] = "No Match"; } return View(); } } else if (traceType ==
// "tele") { string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Consumer Trace By Telephone Number"; string action = "Telephone Number:
// " + tele; string user_id = Session["ID"].ToString(); string us = Session["Name"].ToString();

// ViewData["user"] = Session["Name"].ToString(); ViewData["date"] =
// DateTime.Today.ToShortDateString(); ViewData["ref"] = refe;

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/credit/compuscan/consumertrace/telephonenumber/"; //create
// RestSharp client and POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { SessionToken = authtoken, Reference = us,//search reference: probably store in
// logs TelephoneNumber = tele };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!
// System.Diagnostics.Debug.WriteLine(o); JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage;

// var mes = ViewData["ResponseMessage"].ToString(); if (mes == "ServiceOffline") {
// ViewData["Message"] = "Service is offline"; return View(); } else { int SearchID =
// rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Name = ViewData["user"].ToString(); string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription = rootObject.ResponseObject.SearchInformation.SearchDescription;

// ViewData["Message"] = "good"; ViewData["Message2"] = "No recent searches available. Please modify
// criteria above.";

// ViewData["PersonInformationMessage"] = rootObject.ResponseObject[0].PersonInformation.FirstName;

// if (ViewData["PersonInformationMessage"].ToString() != "") { //personaInformantion
// ViewData["FirstName"] = rootObject.ResponseObject[0].PersonInformation.FirstName;
// ViewData["Surname"] = rootObject.ResponseObject[0].PersonInformation.Surname;
// ViewData["Fullname"] = rootObject.ResponseObject[0].PersonInformation.Fullname;
// ViewData["IDNumber"] = rootObject.ResponseObject[0].PersonInformation.IDNumber;
// ViewData["MiddleName1"] = rootObject.ResponseObject[0].PersonInformation.MiddleName1;
// ViewData["HasProperties"] = rootObject.ResponseObject[0].PersonInformation.HasProperties; } else
// { ViewData["PersonInformationMessage"] = "No Match"; } return View(); } } else if (traceType ==
// "teleID") { string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Consumer Trace By TelephoneID"; string action = "TelephoneID: " + tele;
// string user_id = Session["ID"].ToString(); string us = Session["Name"].ToString();

// ViewData["user"] = Session["Name"].ToString(); ViewData["date"] =
// DateTime.Today.ToShortDateString(); ViewData["ref"] = refe;

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/credit/compuscan/consumertrace/telephoneid/"; //create
// RestSharp client and POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { SessionToken = authtoken, Reference = us,//search reference: probably store in
// logs TelephoneID = id };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

// JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage; } } catch (Exception e) {
// TempData["msg"] = "An error occured, please check the entered values."; }

// return View(); }

// public ActionResult CompuScanContactInformation() { return View(); }

// public ActionResult CompuScanContactInformationResults(CompuScan comp) { string id =
// comp.IDNumber; string passport = comp.passport; string surname = comp.Surname; string firstname =
// comp.FirstName; string refe = comp.Reference;

// string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Contact Information"; string action = "First Name: " + firstname + ";
// Surname: " + surname + "; Passport: " + passport + "; ID: " + id; string user_id =
// Session["ID"].ToString(); string us = Session["Name"].ToString();

// ViewData["user"] = Session["Name"].ToString(); ViewData["date"] =
// DateTime.Today.ToShortDateString(); ViewData["ref"] = refe;

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { sessionToken = authtoken, reference = us,//search reference: probably store in
// logs idNumber = id, passport = passport, surname = surname, firstname = firstname, };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o =
// JObject.Parse(response.Content); JObject o =
// JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

// JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage; var mes =
// ViewData["ResponseMessage"].ToString(); if (mes == "ServiceOffline") { ViewData["Message"] =
// "Service is offline"; return View(); } else { int SearchID =
// rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Name = ViewData["user"].ToString(); string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; saveSearchHistory(SearchID,
// SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken,
// CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanConsumerTrace");

// ViewData["Message"] = "good"; ViewData["Message2"] = "No recent searches available. Please modify
// criteria above.";

// ViewData["PersonInformationMessage"] =
// rootObject.ResponseObject.PersonInformation["DateOfBirth"];
// //ViewData["CreditInformationMessage"] =
// rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
// //ViewData["HomeAffairsInformationMessage"] =
// rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
// ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

// if (ViewData["PersonInformationMessage"].ToString() != "") { //personaInformantion
// ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
// ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
// ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname; ViewData["Fullname"] =
// rootObject.ResponseObject.PersonInformation.Fullname; ViewData["IDNumber"] =
// rootObject.ResponseObject.PersonInformation.IDNumber; ViewData["Gender"] =
// rootObject.ResponseObject.PersonInformation.Gender; ViewData["Age"] =
// rootObject.ResponseObject.PersonInformation.Age; ViewData["HasProperties"] =
// rootObject.ResponseObject.PersonInformation.HasProperties; } else {
// ViewData["PersonInformationMessage"] = "No Match"; }

// if (ViewData["HistoricalInformationMessage"].ToString() != "") { //AddressHistory
// ViewData["AH_TypeDescription"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;
// ViewData["AH_Line1"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line1;
// ViewData["AH_Line2"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line2;
// ViewData["AH_Line3"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line3;
// ViewData["AH_Line4"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].Line4;
// ViewData["AH_PostalCode"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].PostalCode;
// ViewData["AH_FullAddress"] =
// rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].FullAddress;
// ViewData["AH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].LastUpdatedDate;

// //TelephoneHistory ViewData["TH_TypeDescription"] =
// rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].TypeDescription;
// ViewData["TH_FullNumber"] =
// rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].Number;
// ViewData["TH_LastUpdatedDate"] = rootObject.ResponseObject.HistoricalInformation.TelephoneHistory[0].LastUpdatedDate;

// //EmploymentHistory ViewData["EH_EmployerName"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;
// ViewData["EH_Designation"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
// ViewData["EH_LastUpdatedDate"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate; } else {
// ViewData["HistoricalInformationMessage"] = "No Match"; } } return View(); }

// public ActionResult CompuScanEmploymentConfidenceIndex() { return View(); }

// public ActionResult CompuScanEmploymentConfidenceIndexResults(CompuScan comp) { string id =
// comp.IDNumber; string firstname = comp.FirstName; string surname = comp.Surname; string refe = comp.Reference;

// string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Employment Confidence Index"; string action = "First Name: " + firstname
// + "; Surname: " + surname + "; ID: " + id; string user_id = Session["ID"].ToString(); string us = Session["Name"].ToString();

// ViewData["user"] = Session["Name"].ToString(); ViewData["date"] =
// DateTime.Today.ToShortDateString(); ViewData["ref"] = refe;

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/credit/compuscan/EmploymentConfidenceIndex/"; //create
// RestSharp client and POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { SessionToken = authtoken, Reference = us,//search reference: probably store in
// logs IDNumber = id, Surname = surname, Firstname = firstname };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

// JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage; var mes =
// ViewData["ResponseMessage"].ToString(); if (mes == "ServiceOffline") { ViewData["Message"] =
// "Service is offline"; return View(); } else { int SearchID =
// rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Name = ViewData["user"].ToString(); string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; saveSearchHistory(SearchID,
// SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken,
// CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanEmploymentConfidenceIndex");

// ViewData["Message"] = "good"; ViewData["Message2"] = "No recent searches available. Please modify
// criteria above.";

// ViewData["PersonInformationMessage"] =
// rootObject.ResponseObject.PersonInformation["DateOfBirth"];
// //ViewData["CreditInformationMessage"] =
// rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
// //ViewData["HomeAffairsInformationMessage"] =
// rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
// ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;

// if (ViewData["PersonInformationMessage"].ToString() != "") { //personaInformantion
// ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
// ViewData["FirstName"] = rootObject.ResponseObject.PersonInformation.FirstName;
// ViewData["Surname"] = rootObject.ResponseObject.PersonInformation.Surname; ViewData["Fullname"] =
// rootObject.ResponseObject.PersonInformation.Fullname; ViewData["IDNumber"] =
// rootObject.ResponseObject.PersonInformation.IDNumber; ViewData["Gender"] =
// rootObject.ResponseObject.PersonInformation.Gender; ViewData["Age"] =
// rootObject.ResponseObject.PersonInformation.Age; ViewData["HasProperties"] =
// rootObject.ResponseObject.PersonInformation.HasProperties; } else {
// ViewData["PersonInformationMessage"] = "No Match"; }

// if (ViewData["HistoricalInformationMessage"].ToString() != "") { //EmploymentHistory
// ViewData["EH_EmployerName"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].EmployerName;
// ViewData["EH_Designation"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].Designation;
// ViewData["EH_LastUpdatedDate"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].LastUpdatedDate;
// ViewData["EH_FirstReportedDate"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].FirstReportedDate;
// ViewData["EH_NumberOfAccounts"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].NumberOfAccounts;
// ViewData["EH_ConfidenceIndex"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].ConfidenceIndex;
// ViewData["EH_HighestConfidence"] =
// rootObject.ResponseObject.HistoricalInformation.EmploymentHistory[0].HighestConfidence; } else {
// ViewData["HistoricalInformationMessage"] = "No Match"; } } return View(); }

// public ActionResult CompuScanGrossMonthlyIncomeByIDNumber() { return View(); }

// public ActionResult CompuScanGrossMonthlyIncomeByIDNumberResults(CompuScan comp) { string id =
// comp.IDNumber; string refe = comp.Reference;

// string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan Employment Confidence Index"; string action = "ID: " + id; string
// user_id = Session["ID"].ToString(); string us = Session["Name"].ToString();

// ViewData["user"] = Session["Name"].ToString(); ViewData["date"] =
// DateTime.Today.ToShortDateString(); ViewData["ref"] = refe;

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/credit/compuscan/grossmonthlyincome/idnumber/"; //create
// RestSharp client and POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { SessionToken = authtoken, Reference = us,//search reference: probably store in
// logs IDNumber = id, };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

// JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage; var mes =
// ViewData["ResponseMessage"].ToString(); if (mes == "ServiceOffline" || mes == "NotFound") {
// ViewData["Message"] = "Service is offline";

// ViewData["Message2"] = "No recent searches available. Please modify criteria above."; return
// View(); } else { int SearchID = rootObject.ResponseObject.SearchInformation.SearchID; string
// SearchUserName = rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Name = ViewData["user"].ToString(); string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; saveSearchHistory(SearchID,
// SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken,
// CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanGrossMonthlyIncomeByIDNumber");

// ViewData["Message"] = "good";

// ViewData["PersonInformationMessage"] = rootObject.ResponseObject.PersonInformation.IDNumber;
// //ViewData["CreditInformationMessage"] =
// rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
// //ViewData["HomeAffairsInformationMessage"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;

// if (ViewData["PersonInformationMessage"].ToString() != "") { //personaInformantion
// ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
// ViewData["IncomeBracket"] = rootObject.ResponseObject.PersonInformation.IncomeBracket;
// ViewData["IncomeGrossEstimate"] =
// rootObject.ResponseObject.PersonInformation.IncomeGrossEstimate; ViewData["IncomeConfidence"] =
// rootObject.ResponseObject.PersonInformation.IncomeConfidence; ViewData["IDNumber"] =
// rootObject.ResponseObject.PersonInformation.IDNumber; ViewData["Gender"] =
// rootObject.ResponseObject.PersonInformation.Gender; ViewData["Age"] =
// rootObject.ResponseObject.PersonInformation.Age; ViewData["HasProperties"] =
// rootObject.ResponseObject.PersonInformation.HasProperties; } else {
// ViewData["PersonInformationMessage"] = "No Match"; } } return View(); }

// public ActionResult CompuScanIDPhotoVerification() { return View(); }

// public ActionResult CompuScanIDPhotoVerificationResults(CompuScan comp) { string id =
// comp.IDNumber; string refe = comp.Reference;

// string dbConnectionString =
// ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;//string.Format("server={0};uid={1};pwd={2};database={3};",
// serverIp, username, password, databaseName);

// var conn = new MySql.Data.MySqlClient.MySqlConnection(dbConnectionString);

// DateTime time = DateTime.Now;

// string date_add = DateTime.Today.ToShortDateString(); string time_add = time.ToString("T");
// string page = "CompuScan ID Photo Verification"; string action = "ID: " + id; string user_id =
// Session["ID"].ToString(); string us = Session["Name"].ToString();

// ViewData["user"] = Session["Name"].ToString(); ViewData["date"] =
// DateTime.Today.ToShortDateString(); ViewData["ref"] = refe;

// string query_uid = "INSERT INTO logs (date,time,page,action,user_id,user) VALUES('" + date_add +
// "','" + time_add + "','" + page + "','" + action + "','" + user_id + "','" + us + "')";

// conn.Open();

// var cmd2 = new MySqlCommand(query_uid, conn);

// var reader2 = cmd2.ExecuteReader();

// conn.Close();

// string authtoken = GetLoginToken("uatapi@ktopportunities.co.za", "P@ssw0rd!"); if
// (!tokenValid(authtoken)) { //exit with a warning } //company search API call var url =
// "https://uatrest.searchworks.co.za/compuscan/idphotoverification/"; //create RestSharp client and
// POST request object var client = new RestClient(url); var request = new RestRequest(Method.POST);

// //request headers request.RequestFormat = DataFormat.Json; request.AddHeader("Content-Type",
// "application/json"); //object containing input parameter data for company() API method var
// apiInput = new { sessionToken = authtoken, reference = us,//search reference: probably store in
// logs idNumber = id, };

// //add parameters and token to request request.Parameters.Clear();
// request.AddParameter("application/json", JsonConvert.SerializeObject(apiInput),
// ParameterType.RequestBody); request.AddParameter("Authorization", "Bearer " + authtoken,
// ParameterType.HttpHeader); //ApiResponse is a class to model the data we want from the API response

// //make the API request and get a response IRestResponse response = client.Execute<RootObject>(request);

// dynamic rootObject = JObject.Parse(response.Content); //JObject o = JObject.Parse(response.Content);

// JObject o = JObject.Parse(response.Content);//Newtonsoft.Json.Linq.JObject search!!!!

// JToken token = JToken.Parse(response.Content);

// ViewData["ResponseMessage"] = rootObject.ResponseMessage; var mes =
// ViewData["ResponseMessage"].ToString(); if (mes == "ServiceOffline") { ViewData["Message"] =
// "Service is offline"; ViewData["Message2"] = "No recent searches available. Please modify
// criteria above."; return View(); } else { int SearchID =
// rootObject.ResponseObject.SearchInformation.SearchID; string SearchUserName =
// rootObject.ResponseObject.SearchInformation.SearchUserName; string ReportDate =
// rootObject.ResponseObject.SearchInformation.ReportDate; string ResponseType =
// rootObject.ResponseMessage; ; string Name = ViewData["user"].ToString(); string Reference =
// rootObject.ResponseObject.SearchInformation.Reference; string SearchToken =
// rootObject.ResponseObject.SearchInformation.SearchToken; string CallerModule =
// rootObject.ResponseObject.SearchInformation.CallerModule; string DataSupplier =
// rootObject.ResponseObject.SearchInformation.DataSupplier; string SearchType =
// rootObject.ResponseObject.SearchInformation.SearchType; string SearchDescription =
// rootObject.ResponseObject.SearchInformation.SearchDescription; saveSearchHistory(SearchID,
// SearchUserName, ResponseType, ViewData["user"].ToString(), ReportDate, Reference, SearchToken,
// CallerModule, DataSupplier, SearchType, SearchDescription, "CompuScanIDPhotoVerification");

// ViewData["Message"] = "good"; ViewData["Message2"] = "No recent searches available. Please modify
// criteria above.";

// ViewData["PersonInformationMessage"] =
// rootObject.ResponseObject.PersonInformation["DateOfBirth"];
// //ViewData["CreditInformationMessage"] =
// rootObject.ResponseObject.CreditInformation.FraudIndicatorSummary["ProtectiveVerification"];
// ViewData["HomeAffairsInformationMessage"] =
// rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
// //ViewData["HistoricalInformationMessage"] = rootObject.ResponseObject.HistoricalInformation.AddressHistory[0].TypeDescription;

// if (ViewData["PersonInformationMessage"].ToString() != "") { //personaInformantion
// ViewData["DateOfBirth"] = rootObject.ResponseObject.PersonInformation.DateOfBirth;
// ViewData["MaritalStatus"] = rootObject.ResponseObject.PersonInformation.MaritalStatus;
// ViewData["MarriageDate"] = rootObject.ResponseObject.PersonInformation.MarriageDate;
// ViewData["CountryOfBirth"] = rootObject.ResponseObject.PersonInformation.CountryOfBirth;
// ViewData["Gender"] = rootObject.ResponseObject.PersonInformation.Gender; ViewData["Age"] =
// rootObject.ResponseObject.PersonInformation.Age; ViewData["HasProperties"] =
// rootObject.ResponseObject.PersonInformation.HasProperties; } else {
// ViewData["PersonInformationMessage"] = "No Match"; }

// if (ViewData["HomeAffairsInformationMessage"].ToString() != "") { //personaInformantion
// ViewData["IDNumber"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumber;
// ViewData["IDPhotoURL"] = rootObject.ResponseObject.HomeAffairsInformation.IDPhotoURL;
// ViewData["FirstName"] = rootObject.ResponseObject.HomeAffairsInformation.FirstName;
// ViewData["Surname"] = rootObject.ResponseObject.HomeAffairsInformation.Surname;
// ViewData["DeceasedStatus"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedStatus;
// ViewData["DeceasedDate"] = rootObject.ResponseObject.HomeAffairsInformation.DeceasedDate;
// ViewData["IDIssuedDate"] = rootObject.ResponseObject.HomeAffairsInformation.IDIssuedDate;
// ViewData["IDCardIssued"] = rootObject.ResponseObject.HomeAffairsInformation.IDCardIssued;
// ViewData["IDNumberBlocked"] = rootObject.ResponseObject.HomeAffairsInformation.IDNumberBlocked;
// ViewData["IDSequenceNumber"] = rootObject.ResponseObject.HomeAffairsInformation.IDSequenceNumber;
// ViewData["OnHANIS"] = rootObject.ResponseObject.HomeAffairsInformation.OnHANIS; ViewData["OnNPR"]
// = rootObject.ResponseObject.HomeAffairsInformation.OnNPR; } else {
// ViewData["HomeAffairsInformationMessage"] = "No Match"; } } return View(); }