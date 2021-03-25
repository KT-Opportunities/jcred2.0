using System.ComponentModel.DataAnnotations;

namespace searchworks.client.Models
{
    public class ExistingClient
    {
        [EmailAddress]
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
    }
}