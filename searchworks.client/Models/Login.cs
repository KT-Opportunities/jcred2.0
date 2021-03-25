using System.ComponentModel.DataAnnotations;

namespace searchworks.client.Models
{
    public class Login
    {

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string Password { get; set; }




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