using System.Collections.Generic;

namespace searchworks.client.Company
{
    public class CapitalInformation
    {
        public string CapitalType { get; set; }
        public string CompanyCapitalID { get; set; }
        public string CompanyID { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string NoShares { get; set; }
        public string ParriValue { get; set; }
        public string Premium { get; set; }
        public string ShareAmount { get; set; }
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

    public class CompanyInformation
    {
        public string CompanyID { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyTranslatedName { get; set; }
        public string RegistrationDate { get; set; }
        public string CompanyStatusCode { get; set; }
        public string CompanyStatus { get; set; }
        public string CompanyType { get; set; }
        public string FinancialYearEnd { get; set; }
        public string PhysicalAddressLine1 { get; set; }
        public string PhysicalAddressLine2 { get; set; }
        public string PhysicalAddressLine3 { get; set; }
        public string PhysicalAddressLine4 { get; set; }
        public string PhysicalPostCode { get; set; }
        public string PostalAddressLine1 { get; set; }
        public string PostalAddressLine2 { get; set; }
        public string PostalAddressLine3 { get; set; }
        public string PostalAddressLine4 { get; set; }
        public string PostalPostCode { get; set; }
        public string CountryCode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string AuthorisedCapital { get; set; }
        public string AuthorisedShares { get; set; }
        public string IssuedCapital { get; set; }
        public string IssuedShares { get; set; }
        public string FormReceivedDate { get; set; }
        public string FormDate { get; set; }
        public string ConversionNumber { get; set; }
        public string TaxNumber { get; set; }
        public string CompanyActTypeDescription { get; set; }
        public string PrincipalDescription { get; set; }
        public string AverageDirectorAge { get; set; }
        public string seaType { get; set; }


    }

    public class Directors
    {
        public string DirectorID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string IdNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Age { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string AppointmentDate { get; set; }
        public string ResignationDate { get; set; }
        public string MemberContribution { get; set; }
        public string MemberSize { get; set; }
        public string ResidentialAddress1 { get; set; }
        public string ResidentialAddress2 { get; set; }
        public string ResidentialAddress3 { get; set; }
        public string ResidentialAddress4 { get; set; }
        public string ResidentialPostalCode { get; set; }
        public string PostalAddress1 { get; set; }
        public string PostalAddress2 { get; set; }
        public string PostalAddress3 { get; set; }
        public string PostalAddress4 { get; set; }
        public string PostalPostCode { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }



    }

    public class ResponseObject
    {
        public SearchInformation SearchInformation { get; set; }
        public CompanyInformation CompanyInformation { get; set; }
        public Directors Directors { get; set; }
        public CapitalInformation CapitalInformation { get; set; }

    }
    public class RootObject
    {
        public string ResponseMessage { get; set; }
        public string PDFCopyURL { get; set; }
        public List<ResponseObject> ResponseObject { get; set; }
    }

    public class Search
    {
        public string CipcSearchBy { get; set; }
        public string CompanyName { get; set; }
        public string RegistrationNumber { get; set; }
        public string CompanyID { get; set; }
        public string PDF { get; set; }
        public string seaType { get; set; }
        public string Reference { get; set; }




    }
}