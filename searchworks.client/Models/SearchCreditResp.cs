using System;
using System.Collections.Generic;

namespace searchworks.client.Credit
{
    public class SearchHistoryModel
    {
        public string SearchID { get; set; }
        public string SearchUserName { get; set; }
        public string ResponseType { get; set; }
        public string Name { get; set; }
        public string ReportDate { get; set; }
        public string Reference { get; set; }
        public string SearchToken { get; set; }
        public string CallerModule { get; set; }
        public string DataSupplier { get; set; }
        public string SearchType { get; set; }
        public string SearchDescription { get; set; }
        public string typeOfSearch { get; set; }
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
        public string InformationDate { get; set; }

        public string PersonID { get; set; }

        public string Title { get; set; }

        public string DateOfBirth { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string IDNumber { get; set; }
        public string IDNumber_Alternate { get; set; }
        public string PassportNumber { get; set; }
        public string EnquiryID { get; set; }
        public string EnquiryResultID { get; set; }
        public string Reference { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Initials { get; set; }
        public string MiddleName1 { get; set; }
        public string MiddleName2 { get; set; }
        public string SpouseFirstName { get; set; }
        public string SpouseSurname { get; set; }
        public string NumberOfDependants { get; set; }
        public string ConsumerID { get; set; }
        public string AkaName { get; set; }
        public string Remarks { get; set; }

        public string MaritalStatus { get; set; }
        public string Quality { get; set; }
        public bool HasProperties { get; set; }
    }

    public class UserManagementCompany
    {
        public string parent_orgtenantid { get; set; }
        public string orgname { get; set; }
        public string orgabbreviation { get; set; }
        public string orgcode { get; set; }
        public string orgcategoryid { get; set; }
        public string org_regno { get; set; }
        public string org_vatno { get; set; }
    }

    public class HomeAffairsInformation
    {
        public string FirstName { get; set; }

        public string IDVerified { get; set; }
        public string DeceasedStatus { get; set; }
        public string SurnameVerified { get; set; }
        public string Warnings { get; set; }
        public string InitialsVerified { get; set; }
        public string CauseOfDeath { get; set; }
        public string VerifiedDate { get; set; }
        public string DeceasedDate { get; set; }
        public string PlaceOfDeath { get; set; }
        public string PlaceOfMarriage { get; set; }
        public string IDIssuedDate { get; set; }
        public string IDCardIssuedDate { get; set; }
        public string IDCardIssued { get; set; }
        public string VerifiedStatus { get; set; }
    }

    public class CreditInformation
    {
        public string CreditSummaryChartURL { get; set; }
        public string DelphiScore { get; set; }
        public string DelphiScoreChartURL { get; set; }
        public string MonthlyInstalment { get; set; }
        public string RiskColour { get; set; }
        public string FlagCount { get; set; }
        public string FlagDetails { get; set; }
        public string TotalInstallmentAmountCPAAccounts_CompuScan { get; set; }
        public string TotalInstallmentAmountNLRAccounts_CompuScan { get; set; }
        public string TotalNumberCPAAccounts_CompuScan { get; set; }
        public string TotalNumberNLRAccounts_CompuScan { get; set; }
        public string TotalNumberActiveCPAAccounts_CompuScan { get; set; }
        public string TotalNumberActiveNLRAccounts_CompuScan { get; set; }
        public string TotalNumberClosedCPAAccounts_CompuScan { get; set; }
        public string TotalNumberClosedNLRAccounts_CompuScan { get; set; }
        public string Percent0ArrearsLast12Histories { get; set; }
    }

    public class ContactInformation
    {
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string HomeTelephoneNumber { get; set; }
        public string WorkTelephoneNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string PostalAddress { get; set; }
    }

    public class CPAaccounts
    {
        public string Account_ID { get; set; }

        public string SubscriberCode { get; set; }

        public string SubscriberName { get; set; }

        public string AccountNO { get; set; }

        public string SubAccountNO { get; set; }

        public string OwnershipType { get; set; }

        public string OwnershipTypeDescription { get; set; }

        public string Reason { get; set; }

        public string ReasonDescription { get; set; }

        public string PaymentType { get; set; }

        public string PaymentTypeDescription { get; set; }

        public string AccountType { get; set; }

        public string AccountTypeDescription { get; set; }

        public string OpenDate { get; set; }

        public string DeferredPaymentDate { get; set; }

        public string LastPaymentDate { get; set; }

        public string OpenBalance { get; set; }

        public string OpenBalanceIND { get; set; }

        public string CurrentBalance { get; set; }

        public string CurrentBalanceIND { get; set; }

        public string OverdueAmount { get; set; }

        public string OverdueAmountIND { get; set; }

        public string InstalmentAmount { get; set; }

        public string ArrearsPeriod { get; set; }
        public string RepaymentFrequency { get; set; }

        public string RepaymentFrequencyDescription { get; set; }

        public string Terms { get; set; }

        public string StatusCode { get; set; }

        public string StatusCodeDesc { get; set; }

        public string IndustryType { get; set; }

        public string PaymentHistoryChartURL { get; set; }

        public string StatusDate { get; set; }

        public string ThirdPartyName { get; set; }

        public string ThirdPartySold { get; set; }

        public string ThirdPartySoldDescription { get; set; }

        public string JointLoanParticipants { get; set; }

        public string PaymentHistory { get; set; }

        public string PaymentHistoryStatus { get; set; }

        public string PaymentHistoryChart { get; set; }

        public string MonthEndDate { get; set; }

        public string DateCreated { get; set; }
        public Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails { get; set; }
    }

    public class NLRaccounts
    {
        public string Account_ID { get; set; }

        public string SubscriberCode { get; set; }

        public string SubscriberName { get; set; }

        public string AccountNO { get; set; }

        public string SubAccountNO { get; set; }

        public string OwnershipType { get; set; }

        public string OwnershipTypeDescription { get; set; }

        public string Reason { get; set; }

        public string ReasonDescription { get; set; }

        public string PaymentType { get; set; }

        public string PaymentTypeDescription { get; set; }

        public string AccountType { get; set; }

        public string AccountTypeDescription { get; set; }

        public string OpenDate { get; set; }

        public string DeferredPaymentDate { get; set; }

        public string LastPaymentDate { get; set; }

        public string OpenBalance { get; set; }

        public string OpenBalanceIND { get; set; }

        public string CurrentBalance { get; set; }

        public string CurrentBalanceIND { get; set; }

        public string OverdueAmount { get; set; }

        public string OverdueAmountIND { get; set; }

        public string InstalmentAmount { get; set; }

        public string ArrearsPeriod { get; set; }
        public string RepaymentFrequency { get; set; }

        public string RepaymentFrequencyDescription { get; set; }

        public string Terms { get; set; }

        public string StatusCode { get; set; }

        public string StatusCodeDesc { get; set; }

        public string IndustryType { get; set; }

        public string PaymentHistoryChartURL { get; set; }

        public string StatusDate { get; set; }

        public string ThirdPartyName { get; set; }

        public string ThirdPartySold { get; set; }

        public string ThirdPartySoldDescription { get; set; }

        public string JointLoanParticipants { get; set; }

        public string PaymentHistory { get; set; }

        public string PaymentHistoryStatus { get; set; }

        public string PaymentHistoryChart { get; set; }

        public string MonthEndDate { get; set; }

        public string DateCreated { get; set; }
        public Newtonsoft.Json.Linq.JArray PaymentHistoryAccountDetails { get; set; }
    }

    //public class Directorship
    //{
    //    public string DesignationCode { get; set; }
    //    public string AppointmentDate { get; set; }
    //    public string DirectorStatus { get; set; }
    //    public string DirectorStatusDate { get; set; }
    //    public string CompanyName { get; set; }
    //    public string CompanyType { get; set; }
    //    public string CompanyStatus { get; set; }
    //    public string CompanyStatusCode { get; set; }
    //    public string CompanyRegistrationNumber { get; set; }
    //    public string CompanyRegistrationDate { get; set; }
    //    public string CompanyStartDate { get; set; }
    //    public string CompanyTaxNumber { get; set; }
    //    public string DirectorTypeCode { get; set; }
    //    public string DirectorType { get; set; }
    //    public string MemberSize { get; set; }
    //    public string MemberContribution { get; set; }
    //    public string MemberContributionType { get; set; }
    //    public string ResignationDate { get; set; }
    //}

    public class DataCounts
    {
        public string Accounts { get; set; }
        public string Enquires { get; set; }
        public string Notices { get; set; }
        public string BankDefaults { get; set; }
        public string Collections { get; set; }
        public string Directors { get; set; }
        public string Addresses { get; set; }
        public string Telephones { get; set; }
        public string Occupants { get; set; }
        public string Employers { get; set; }
        public string TraceAlerts { get; set; }
        public string PaymentProfiles { get; set; }
        public string OwnEnquiries { get; set; }
        public string Judgements { get; set; }
        public string Defaults { get; set; }
        public string AdminOrders { get; set; }
        public string PossibleMatches { get; set; }
        public string DefiniteMatches { get; set; }
        public string Loans { get; set; }
        public string FraudAlerts { get; set; }
        public string Companies { get; set; }
        public string Properties { get; set; }
        public string Documents { get; set; }
        public string DemandLetters { get; set; }
        public string Trusts { get; set; }
        public string Bonds { get; set; }
        public string Deeds { get; set; }
        public string PublicDefaults { get; set; }
        public string NLRAccounts { get; set; }
    }

    public class DebtReviewStatus
    {
        public string StatusCode { get; set; }
        public string StatusDate { get; set; }
        public string StatusDescription { get; set; }
        public string ApplicationDate { get; set; }
    }

    public class Directorship
    {
        public string DesignationCode { get; set; }
        public string AppointmentDate { get; set; }
        public string DirectorStatus { get; set; }
        public string DirectorStatusDate { get; set; }
        public string CompanyName { get; set; }
        public string CompanyType { get; set; }
        public string CompanyStatus { get; set; }
        public string CompanyStatusCode { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string CompanyRegistrationDate { get; set; }
        public string CompanyStartDate { get; set; }
        public string CompanyTaxNumber { get; set; }
        public string DirectorTypeCode { get; set; }
        public string DirectorType { get; set; }
        public string MemberSize { get; set; }
        public string MemberContribution { get; set; }
        public string MemberContributionType { get; set; }
        public string ResignationDate { get; set; }
    }

    public class ConsumerStatistics
    {
        public string HighestJudgment { get; set; }
        public string RevolvingAccounts { get; set; }
        public string InstalmentAccounts { get; set; }
        public string OpenAccounts { get; set; }
        public string AdverseAccounts { get; set; }
        public string Percent0ArrearsLast12Histories { get; set; }
        public string MonthsOldestOpenedPPSEver { get; set; }
        public string NumberPPSLast12Months { get; set; }
        public string NLRMicroloansPast12Months { get; set; }
    }

    public class NLRStats
    {
        public string ActiveAccounts { get; set; }

        public string ClosedAccounts { get; set; }
        public string WorstMonthArrears { get; set; }
        public string WorstArrearsStatus { get; set; }
        public string MonthlyInstalment { get; set; }
        public string CumulativeArrears { get; set; }
        public string BalanceExposure { get; set; }
    }

    public class CCAStats
    {
        public string ActiveAccounts { get; set; }

        public string ClosedAccounts { get; set; }
        public string WorstMonthArrears { get; set; }
        public string WorstArrearsStatus { get; set; }
        public string MonthlyInstalment { get; set; }
        public string CumulativeArrears { get; set; }
        public string BalanceExposure { get; set; }
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

    public class CCA12months
    {
        public string EnquiriesByClient { get; set; }
        public string EnquiriesByOther { get; set; }
        public string PositiveLoans { get; set; }
        public string HighestMonthsInArrears { get; set; }
    }

    public class CCA24months
    {
        public string EnquiriesByClient { get; set; }
        public string EnquiriesByOther { get; set; }
        public string PositiveLoans { get; set; }
        public string HighestMonthsInArrears { get; set; }
    }

    public class CCA36months
    {
        public string EnquiriesByClient { get; set; }
        public string EnquiriesByOther { get; set; }
        public string PositiveLoans { get; set; }
        public string HighestMonthsInArrears { get; set; }
    }

    public class NLR12months
    {
        public string EnquiriesByClient { get; set; }
        public string EnquiriesByOther { get; set; }
        public string PositiveLoans { get; set; }
        public string HighestMonthsInArrears { get; set; }
    }

    public class NLR24months
    {
        public string EnquiriesByClient { get; set; }
        public string EnquiriesByOther { get; set; }
        public string PositiveLoans { get; set; }
        public string HighestMonthsInArrears { get; set; }
    }

    public class NLR36months
    {
        public string EnquiriesByClient { get; set; }
        public string EnquiriesByOther { get; set; }
        public string PositiveLoans { get; set; }
        public string HighestMonthsInArrears { get; set; }
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

    public class DatabaseSearch
    {
        public string id { get; set; }
        public string token { get; set; }
        public string refe { get; set; }
        public string type { get; set; }
    }

    public class EnquiryHistory
    {
        public string EnquiryDate { get; set; }
        public string EnquiredBy { get; set; }
        public string EnquiredByContact { get; set; }
        public string EnquiredByType { get; set; }
        public string ReasonForEnquiry { get; set; }
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