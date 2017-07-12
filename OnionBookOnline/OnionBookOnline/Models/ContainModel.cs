using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class CONTAIN
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string ORDERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string BOOKID { get; set; }

        [Column(TypeName = "number(4,0)")]
        public double AMOUNT { get; set; }

        [Column(TypeName = "number(6,0)")]
        public double SUM { get; set; }
    }
}