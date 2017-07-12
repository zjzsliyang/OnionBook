using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class OCOMMENT
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string BOOKID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string COMMENTID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string TITLE { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string CONTENTS { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string TIMEATTRIBUTE { get; set; }
    }
}