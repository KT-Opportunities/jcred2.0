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
    using System.ComponentModel;

    public partial class orgtenant
    {
        public int orgtenantid { get; set; }
        public Nullable<int> parent_orgtenantid { get; set; }
        [DisplayName("Company Name")]
        public string orgname { get; set; }
        public string orgcode { get; set; }
        public Nullable<int> orgcategoryid { get; set; }
        public string org_regno { get; set; }
        public string org_vatno { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }
        public string orgabbreviation { get; set; }
    }
}