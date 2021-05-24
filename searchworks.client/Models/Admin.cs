using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace searchworks.client.Models
{
    public class Admin
    {

            [Required]
            [Display(Name = "Email")]
            public string email { get; set; }

            [Required]
            [Display(Name = "Password")]
            public string password { get; set; }

            [Required]
            [Display(Name = "Fullname")]
            public string fullname { get; set; }

            [Required]
            [Display(Name = "date_added")]
            public string date_added { get; set; }

            [Required]
            [Display(Name = "dob")]
            public string dob { get; set; }

            [Required]
            [Display(Name = "gender")]
            public string gender { get; set; }

            [Required]
            [Display(Name = "phone")]
            public string phone { get; set; }

            [Required]
            [Display(Name = "type")]
            public string type { get; set; }

            [Required]
            [Display(Name = "org")]
            public string org { get; set; }




    }

    //public class Check
    //{
    //    [Required]
    //    public string CheckType { get; set; }
    //    public string CheckInfo { get; set; }
    //    public decimal CheckPrice { get; set; }

    //    [ValidateFileAttribute]
    //    public HttpPostedFileBase CheckDocument { get; set; }
    //}

    //public class ValidateFileAttribute : ValidationAttribute
    //{
    //    public override bool IsValid(object value)
    //    {
    //        int MaxContentLength = 1024 * 1024 * 300; //300 MB
    //        string[] AllowedFileExtensions = new string[] { ".pdf" };

    //        var file = value as HttpPostedFileBase;

    //        if (file == null)
    //            return true;
    //        if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
    //        {
    //            ErrorMessage = "Please upload a file of type PDF";
    //            return false;
    //        }
    //        else if (file.ContentLength > MaxContentLength)
    //        {
    //            ErrorMessage = "File must be 300MB or else.";
    //            return false;
    //        }
    //        else
    //            return true;
    //    }
    //}
    //public class ValidateCheckCount : ValidationAttribute
    //{
    //    public override bool IsValid(object value)
    //    {
    //        var list = value as IList;
    //        if (list != null)
    //        {
    //            return list.Count < 11;
    //        }
    //        return true;
    //    }
    //}
}