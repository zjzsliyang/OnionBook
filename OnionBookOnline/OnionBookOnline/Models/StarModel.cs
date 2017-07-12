using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class STAR
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string BOOKID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string TIME { get; set; }
    }