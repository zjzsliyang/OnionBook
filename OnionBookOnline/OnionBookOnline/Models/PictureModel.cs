using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnionBookOnline.Models
{
    public class PICTURE
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string BOOKID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PICTUREID { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string PATH { get; set; }
    }
}