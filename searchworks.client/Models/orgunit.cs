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
    
    public partial class orgunit
    {
        public int orgunitid { get; set; }
        public Nullable<int> parent_orgunitid { get; set; }
        public Nullable<int> orgtenantid { get; set; }
        public string orgunitname { get; set; }
        public string orgunitcode { get; set; }
        public Nullable<int> regionid { get; set; }
        public string telephone { get; set; }
        public string fax { get; set; }
        public string postal_address { get; set; }
        public string postal_code { get; set; }
        public string physical_address { get; set; }
        public string physical_code { get; set; }
        public Nullable<bool> isbillable { get; set; }
        public string billing_orgname { get; set; }
        public string billing_address { get; set; }
        public string billing_code { get; set; }
        public string orgunit_regno { get; set; }
        public string orgunit_vatno { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
    }
}