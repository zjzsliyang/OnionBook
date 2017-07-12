using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class OORDER
    {
        [Key]
        [MaxLength(128)]
        [Column(Order = 1, TypeName = "varchar2")]
        public string ORDERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(Order = 2, TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(Order = 3, TypeName = "varchar2")]
        public string RECIPIENTID { get; set; }

        public  int TOTAL{get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string TIME { get; set; }

        public int COUNT { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string REMARK { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string STATUS { get; set; }

        public double SCORE { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string FEEDBACK { get; set; }
    }
}