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
        [Column(TypeName = "varchar2")]
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

        public double PRICE { get; set; }

        public int PAGES { get; set; }

        public double DISCOUNT { get; set; }

        public int STOCK { get; set; }

        public double SCORE { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PUBLISHINGDATE { get; set; }

        public int SALE { get; set; }

        public string INTRODUCTION { get; set; }
    }
}