//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace searchworks.client.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ccastat
    {
        public int ID { get; set; }
        public string SearchToken { get; set; }
        public string Reference { get; set; }
        public string SearchID { get; set; }
        public string CCAStatscol { get; set; }
        public string ActiveAccounts { get; set; }
        public string ClosedAccounts { get; set; }
        public string WorstMonthArrears { get; set; }
        public string WorstArrearsStatus { get; set; }
        public string BalanceExposure { get; set; }
        public string MonthlyInstalment { get; set; }
        public string CumulativeArrears { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string typeOfSearch { get; set; }
    }
}
