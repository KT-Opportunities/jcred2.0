using searchworks.client.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace searchworks.client.DAL
{
    public class OrgUnitUser
    {
        public int id { get; set; }
        [Display(Name = "First Name")]
        public string firstName { get; set; }
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        public string fullname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        [DataType(DataType.MultilineText)]
        public string address { get; set; }
        public string city { get; set; }
        public string code { get; set; }
        [Display(Name = "Branch Name")]
        public string Orgname { get; set; }
        public string orgcode { get; set; }
        [Display(Name = "Branch Name")]
        public string orgunitname { get; set; }
        public IEnumerable<string> orgunits { get; set; }
        public string orgunitcode { get; set; }       
        public int orgunitprivmapid { get; set; }
        public string aspiden_uid { get; set; }
        public Nullable<int> orgtenantid { get; set; }
        public Nullable<int> orgunitid { get; set; }
        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public Nullable<bool> deleted { get; set; }
        public Nullable<System.DateTime> deleted_at { get; set; }

       
    }
}