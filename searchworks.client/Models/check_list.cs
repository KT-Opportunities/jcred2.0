namespace searchworks.client.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("jcred.check_list")]
    public partial class check_list
    {
        public int id { get; set; }

        public int? checks_id { get; set; }

        [StringLength(255)]
        public string checks { get; set; }

        [StringLength(255)]
        public string detail_attached_file_name { get; set; }
    }
}