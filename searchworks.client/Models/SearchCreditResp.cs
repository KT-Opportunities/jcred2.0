using System;
using System.Collections.Generic;

namespace searchworks.client.Credit
{
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



