using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace searchworks.client.Models
{
    [Table("orgcategory")]
    public class OrgCategory
    {
        [Key]
        public int orgcategoryid  {get;set;}

        public string orgcategoryname { get; set; }

        public string orgcategorynameorgcategorycode { get; set; }

        public DateTime? created_at { get; }
        public DateTime? updated_at { get; }
        public DateTime? deleted_at { get; }

        public bool? deleted { get; }

    }
}