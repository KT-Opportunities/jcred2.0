namespace searchworks.client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("jcred.search_history")]
    public partial class search_history
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string user_id { get; set; }

        public DateTime application_date { get; set; }

        [Required]
        [StringLength(255)]
        public string applicant_Fname { get; set; }

        [Required]
        [StringLength(255)]
        public string applicant_Lname { get; set; }

        [Required]
        [StringLength(255)]
        public string status { get; set; }

        [Required]
        [StringLength(255)]
        public string id_Number { get; set; }

        [Required]
        [StringLength(255)]
        public string account_user { get; set; }

        [Required]
        [StringLength(255)]
        public string region { get; set; }
    }
}