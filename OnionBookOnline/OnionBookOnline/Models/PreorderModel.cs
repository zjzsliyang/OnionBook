using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnionBookOnline.Models
{
    public class PREORDER
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string BOOKID { get; set; }

        [Column(TypeName = "number(4,0)")]
        public int AMOUNT { get; set; }
    }
}