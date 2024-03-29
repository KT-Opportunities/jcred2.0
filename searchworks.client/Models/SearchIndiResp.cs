﻿using System.Collections.Generic;

namespace searchworks.client.Individual
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
        public string Title { get; set; }
        public string DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string IDNumber { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
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

    public class EmploymentHistory
    {
        public string EmployerName { get; set; }
        public string Designation { get; set; }
        public string LastUpdatedDate { get; set; }
        public string PlaceOfMarriage { get; set; }
        public string IDIssuedDate { get; set; }
        public string IDCardIssuedDate { get; set; }
        public string IDCardIssued { get; set; }
        public string VerifiedStatus { get; set; }
    }

    public class TelephoneHistory
    {
        public string TypeDescription { get; set; }
        public string TypeCode { get; set; }
        public string Number { get; set; }
        public string LastUpdatedDate { get; set; }
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
        public TelephoneHistory TelephoneHistory { get; set; }
        public EmploymentHistory SearchInformation { get; set; }
    }

    public class ResponseObject
    {
        public SearchInformation SearchInformation { get; set; }
        public PersonInformation PersonInformation { get; set; }
        public HomeAffairsInformation HomeAffairsInformation { get; set; }
        public List<HistoricalInformation> HistoricalInformation { get; set; }
        public DeedsInformation DeedsInformation { get; set; }
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
    }

    public class CSI
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string IDNumber { get; set; }
        public string seaType { get; set; }
        public string eqType { get; set; }
        public string Reference { get; set; }
    }

    public class Deeds
    {
        public string Reference { get; set; }
        public string DeedsOffice { get; set; }
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string IDNumber { get; set; }
    }

    public class DeedsInformation
    {
        public string PersonID { get; set; }
        public string PersonType { get; set; }
        public string PersonTypeCode { get; set; }
        public string Sequestration { get; set; }
        public string DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }
        public string IDNumber { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string DeedsOfficeID { get; set; }
        public string DeedsOfficeName { get; set; }
    }
}