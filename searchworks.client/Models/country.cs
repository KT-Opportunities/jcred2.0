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
    
    public partial class country
    {
        public long countryid { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}