using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace searchworks.client.Models
{
    public class CompanyInformationViewModel
    {
        public string CompanyID { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        string CompanyName { get; set; }
        public string CompanyTranslatedName { get; set; }
        public string RegistrationDate { get; set; }
        public string CompanyStatusCode { get; set; }
        public string CompanyStatus { get; set; }
    }
}