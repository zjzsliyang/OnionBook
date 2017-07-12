using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class ADVERTISEMENT
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string ADVERTISEMENTID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string TITLE { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string STARTTIME { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string ENDTIME { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string POSTERPATH { get; set; }
    }
}