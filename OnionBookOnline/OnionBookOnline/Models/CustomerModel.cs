using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class CUSTOMER
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string NAME { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PASSWORD { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string EMAIL { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string AVATAR { get; set; }

        public double BALANCE { get; set; }

        public int CREDITS { get; set; }
    }
}