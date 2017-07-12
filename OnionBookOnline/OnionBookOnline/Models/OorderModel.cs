using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class OORDER
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string ORDERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string RECIPIENTID { get; set; }

        [Column(TypeName = "Number(6,0)")]
        public  int TOTAL{get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string TIME { get; set; }

        [Column(TypeName = "number(4,0)")]
        public int COUNT { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string REMARK { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string STATUS { get; set; }

        [Column(TypeName = "number(2,1)")]
        public double SCORE { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string FEEDBACK { get; set; }
    }
}