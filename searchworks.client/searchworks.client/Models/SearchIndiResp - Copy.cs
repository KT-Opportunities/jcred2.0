using System.Collections.Generic;

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
        public string Quality { get; set; }
        


    }


        public class ResponseObject
    {
        public SearchInformation SearchInformation { get; set; }
        public PersonInformation PersonInformation { get; set; }
        
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
         public string Surname{ get; set; }
         public string IDNumber{ get; set; }
        

    }
}