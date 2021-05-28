using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace searchworks.client.Models
{
    public class IntelligenceReport
    {

            [Required]
            [Display(Name = "First Name")]
            public string FullFirstName { get; set; }

            [Required]
            public string Surname { get; set; }

            [Display(Name = "ID Number")]
            public string IDNumber { get; set; }


            [Display(Name = "Passport Number")]
            public string PassportNumber { get; set; }

            [Required]
            [Display(Name = "Date Of Birth")]
            public string DateOfBirth { get; set; }

            [Required]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Display(Name = "Maiden Name")]
            public string MaidenName { get; set; }

            [Required]
            [Display(Name = "Mobile")]
            public string Mobile { get; set; }

            [Required]
            [Display(Name = "Reason")]
            public string Reason { get; set; }



            [Required]
            [ValidateFileAttribute]
            public HttpPostedFileBase ConsentForm { get; set; }
            [ValidateCheckCount(ErrorMessage = "Too many checks added. 10 checks must be submitted at most.")]
            public List<Check> Check { get; set; }


    }

    public class Check
    {
        [Required]
        public string CheckType { get; set; }
        public string CheckInfo { get; set; }
        public decimal CheckPrice { get; set; }

        [ValidateFileAttribute]
        public HttpPostedFileBase CheckDocument { get; set; }
    }

    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int MaxContentLength = 1024 * 1024 * 300; //300 MB
            string[] AllowedFileExtensions = new string[] { ".pdf" };

            var file = value as HttpPostedFileBase;

            if (file == null)
                return true;
            if (!AllowedFileExtensions.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))
            {
                ErrorMessage = "Please upload a file of type PDF";
                return false;
            }
            else if (file.ContentLength > MaxContentLength)
            {
                ErrorMessage = "File must be 300MB or else.";
                return false;
            }
            else
                return true;
        }
    }
    public class ValidateCheckCount : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var list = value as IList;
            if (list != null)
            {
                return list.Count < 11;
            }
            return true;
        }
    }
}