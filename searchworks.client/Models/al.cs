namespace searchworks.client.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("jcred.logs")]
    public partial class al
    {
        public int id { get; set; }

        [StringLength(255)]
        public string date { get; set; }

        public int? time { get; set; }

        [StringLength(255)]
        public string action { get; set; }

        [StringLength(255)]
        public string page { get; set; }

        [StringLength(255)]
        public int user_id { get; set; }

        [StringLength(255)]
        public string user { get; set; }

        




    }
}