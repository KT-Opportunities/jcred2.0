namespace searchworks.client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("jcred.users")]
    public partial class users
    {
        public int uid { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime date_added { get; set; }

        public int? fullname { get; set; }

        [StringLength(255)]
        public string phone { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string address { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        [StringLength(255)]
        public string code { get; set; }

        [StringLength(255)]
        public string password { get; set; }



    }
}