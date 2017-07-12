using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class COUNTRY
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string COUNTRYID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string COUNTRYNAME { get; set; }
    }
}