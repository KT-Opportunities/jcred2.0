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
    
    public partial class addresshistory
    {
        public int ID { get; set; }
        public string SearchToken { get; set; }
        public string Reference { get; set; }
        public string SearchID { get; set; }
        public string AddressID { get; set; }
        public string TypeDescription { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }
        public string PostalCode { get; set; }
        public string FullAddress { get; set; }
        public string LastUpdatedDate { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string typeOfSearch { get; set; }
    }
}
