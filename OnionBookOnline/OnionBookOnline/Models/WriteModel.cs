using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class WRITE
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string AUTHORID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string BOOKID { get; set; }
    }
}