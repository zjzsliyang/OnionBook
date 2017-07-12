using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnionBookOnline.Models
{
    public class BOOK
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string BOOKID { get; set; }

        [MaxLength(128)]
        [Column(TypeName ="varchar2")]
        public string ISBN { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar2")]
        public string NAME { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PRIMARYID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string SECONDARYID { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar2")]
        public string PUBLISHER { get; set; }

        [Column(TypeName = "number(8,2)")]
        public double PRICE { get; set; }

        [Column(TypeName = "number(5,0)")]
        public int PAGES { get; set; }

        [Column(TypeName = "number(3,2)")]
        public double DISCOUNT { get; set; }

        [Column(TypeName = "number(4,0)")]
        public int STOCK { get; set; }

        [Column(TypeName = "number(2,1)")]
        public double SCORE { get; set; }

        [Column(TypeName = "number(38,0)")]
        public int SALE { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PUBLICHINGDATE { get; set; }
    }
}