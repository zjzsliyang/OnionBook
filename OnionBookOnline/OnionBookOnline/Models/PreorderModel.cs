using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnionBookOnline.Models
{
    public class PREORDER
    {
        [Key]
        [MaxLength(128)]
        [Column(Order = 1, TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(Order = 2, TypeName = "varchar2")]
        public string BOOKID { get; set; }

        public int AMOUNT { get; set; }
    }
}