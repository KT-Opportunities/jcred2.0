using System;
using System.Collections.Generic;

namespace searchworks.client.Credit
{
    public class SearchHistoryModel
    {
        public string searchID { get; set; }
        public string searchUserName { get; set; }
        public string ResponseType { get; set; }
        public string Name { get; set; }
        public string reportDate { get; set; }
        public string reference { get; set; }
        public string searchToken { get; set; }
        public string callerModule { get; set; }
        public string dataSupplier { get; set; }
        public string searchType { get; set; }
        public string searchDescription { get; set; }
    }

    public class SearchInformation
    {
        public string SearchUserName { get; set; }
        public string ReportDate { get; set; }
        public string Reference { get; set; }
        public string SearchToken { get; set; }
        public string SearchDescription { get; set; }
        public string CallerModule { get; set; }
        public int SearchID { get; set; }
        public int DataSupplier { get; set; }
        public int SearchType { get; set; }
    }

    public class PersonInformation
    {
        public string PersonID { get; set; }
        public string DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string IDNumber { get; set; }
        public string PassportNumber { get; set; }
        public string EnquiryID { get; set; }
        public string EnquiryResultID { get; set; }
        public string Reference { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Initials { get; set; }
        public string MaritalStatus { get; set; }
        public string Quality { get; set; }
    }

    public class HomeAffairsInformation
    {
        public string DeceasedStatus { get; set; }
        public string DeceasedDate { get; set; }
        public string PlaceOfDeath { get; set; }
        public string PlaceOfMarriage { get; set; }
        public string IDIssuedDate { get; set; }
        public string IDCardIssuedDate { get; set; }
        public string IDCardIssued { get; set; }
        public string VerifiedStatus { get; set; }
    }

    public class HistoricalInformation
    {
        public string DeceasedStatus { get; set; }
        public string DeceasedDate { get; set; }
        public string PlaceOfDeath { get; set; }
        public string PlaceOfMarriage { get; set; }
        public string IDIssuedDate { get; set; }
        public string IDCardIssuedDate { get; set; }
        public string IDCardIssued { get; set; }
        public string VerifiedStatus { get; set; }
    }

    public class EmploymentHistory
    {
        public string EmployerName { get; set; }
        public string Designation { get; set; }
        public string LastUpdatedDate { get; set; }
    }

    public class ResponseObject
    {
        public SearchInformation SearchInformation { get; set; }
        public PersonInformation PersonInformation { get; set; }
        public HomeAffairsInformation HomeAffairsInformation { get; set; }
        public HistoricalInformation HistoricalInformation { get; set; }
    }

    public class RootObject
    {
        public string ResponseMessage { get; set; }
        public string PDFCopyURL { get; set; }
        public List<ResponseObject> ResponseObject { get; set; }
    }

    public class Search
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string Reference { get; set; }
        public int EnquiryReason { get; set; }
    }

    public class CompuScan
    {
        public string IDNumber { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public int EnquiryReason { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string clientName { get; set; }
        public string bankName { get; set; }
        public string branchCode { get; set; }
        public string branchName { get; set; }
        public string accountNumber { get; set; }
        public int amount { get; set; }
        public string terms { get; set; }
        public int ReportType { get; set; }
        public string TelephoneNumber { get; set; }
        public string TelephoneID { get; set; }
        public string passport { get; set; }
        public string TraceType { get; set; }

        public string Reference { get; set; }
    }

    public class Experian
    {
        public string enquiryReason { get; set; }
        public string reference { get; set; }
        public string iDNumber { get; set; }
        public string surname { get; set; }
        public string firstName { get; set; }
        public string passportNumber { get; set; }
    }

    public class EnquiryHistory
    {
        public string EnquiryDate { get; set; }
        public string EnquiredBy { get; set; }
        public string EnquiredByContact { get; set; }
    }

    public class InternalEnquiryHistory
    {
        public string CompanyName { get; set; }
        public string IntEnquiryDate { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
    }

    public class CPA_Accounts

    {
        public string Account_ID { get; set; }
        public string SubscriberCode { get; set; }
        public string SubscriberName { get; set; }
        public string AccountNO { get; set; }
        public string OpenDate { get; set; }
        public string LastPaymentDate { get; set; }
        public string OpenBalance { get; set; }
        public string CurrentBalance { get; set; }
        public string OverdueAmount { get; set; }
        public string InstalmentAmount { get; set; }
        public string StatusCodeDesc { get; set; }
        public string StatusDate { get; set; }
        public string IndustryType { get; set; }
        public string PaymentHistoryChartURL { get; set; }
        public Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails { get; set; }
    }

    public class PaymentHistoryAccountDetails
    {
        public string LastPaymentDate { get; set; }
        public string PaymentHistory { get; set; }
        public string IsEstimated { get; set; }
    }

    public class AddressHistory
    {
        public string AddressID { get; set; }
        public string TypeDescription { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
        public string LastUpdatedDate { get; set; }
    }

    public class TelephoneHistory
    {
        public string TypeDescriptionTel { get; set; }
        public string DialCode { get; set; }
        public string Number { get; set; }
        public string FullNumber { get; set; }
        public string LastUpdatedDateTel { get; set; }
    }

    public class TransUnion
    {
        public string EnquiryReason { get; set; }
        public string SearchDescription { get; set; }
        public string CompanyID { get; set; }
        public Array ModuleCodes { get; set; }
        public string EnquiryType { get; set; }
        public string EntityNumber { get; set; }
        public string EntityName { get; set; }
        public string IDNumber { get; set; }
        public string Surname { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string FirstName { get; set; }
        public string PassportNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string enquiryID { get; set; }
        public string enquiryResultID { get; set; }
        public string mobileNumber { get; set; }
        public string telephoneNumber { get; set; }
        public string TraceType { get; set; }
        public string Reference { get; set; }
    }

    public class VeriCred
    {
        public string idNumber { get; set; }
        public string accountType { get; set; }
        public string initials { get; set; }
        public string branchCode { get; set; }
        public string accountNumber { get; set; }
        public string surname { get; set; }
        public string EnquiryReason { get; set; }
        public string Reference { get; set; }
    }

    public class XDS
    {
        public string IDNumber { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string enquiryID { get; set; }
        public string enquiryResultID { get; set; }
        public string searchDescription { get; set; }
        public string Suburb { get; set; }
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public string TelephoneCode { get; set; }
        public string TelephoneNumber { get; set; }
        public string Type { get; set; }
        public string Reference { get; set; }
    }
}