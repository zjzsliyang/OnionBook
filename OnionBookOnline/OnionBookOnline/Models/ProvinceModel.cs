using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class PROVINCE
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string COUNTRYID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PROVINCEID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PROVINCENAME { get; set; }
    }
}