using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class CITY
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string COUNTRYID { get; set; }
    
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PROVINCEID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CITYID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CITYNAME { get; set; }
    }
}