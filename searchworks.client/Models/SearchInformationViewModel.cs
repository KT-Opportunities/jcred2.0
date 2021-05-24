using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace searchworks.client.Models
{
    public class SearchInformationViewModel
    {
        public string SearchUserName { get; set; }
        public DateTime ReportDate { get; set; }
        public string Reference { get; set; }
        public string SearchToken { get; set; }
        public string SearchDescription { get; set; }
        public string CallerModule { get; set; }
        public int SearchID { get; set; }
        public int DataSupplier { get; set; }//enums
        public int SearchType { get; set; }
    }
}