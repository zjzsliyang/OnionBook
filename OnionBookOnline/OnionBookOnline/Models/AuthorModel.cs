using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class AUTHOR
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string AUTHORID { get; set; }

        [MaxLength(256)]
        [Column(TypeName = "varchar2")]
        public string NAME { get; set; }
    }
}