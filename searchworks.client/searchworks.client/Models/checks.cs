namespace searchworks.client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("jcred.checks")]
    public partial class check
    {
        public int id { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime search_date { get; set; }

        public int? check_id { get; set; }

        [StringLength(255)]
        public string first_name { get; set; }

        [StringLength(255)]
        public string maiden_name { get; set; }

        [StringLength(255)]
        public string surname { get; set; }

        [StringLength(255)]
        public string IDNum { get; set; }

        [StringLength(255)]
        public string passportNum { get; set; }

        [StringLength(255)]
        public string country { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        public int mobile { get; set; }

        public int? Num_search { get; set; }

        [StringLength(255)]
        public string reason { get; set; }

        [StringLength(255)]
        public string consent_Form { get; set; }

        public int user_id { get; set; }

        [Required]
        [StringLength(255)]
        public string user_email { get; set; }

        [StringLength(255)]
        public string status { get; set; }

        [StringLength(255)]
        public string complete_date { get; set; }

        [StringLength(255)]
        public string checks { get; set; }

        [StringLength(255)]
        public string results { get; set; }

        [StringLength(255)]
        public string summary { get; set; }
    }
}