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
    
    public partial class propertiesgeneralinformation
    {
        public int SearchToken { get; set; }
        public string Reference { get; set; }
        public string SearchID { get; set; }
        public Nullable<int> PropertyType { get; set; }
        public string RawPropertyType { get; set; }
        public string Municipality { get; set; }
        public string Township { get; set; }
        public string CityName { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string RegisteredSize { get; set; }
        public string DeedsOfficeName { get; set; }
        public string OldTitleDeedNumber { get; set; }
        public string PhysicalAddress { get; set; }
        public string StandNumber { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public string typeOfSearch { get; set; }
    }
}