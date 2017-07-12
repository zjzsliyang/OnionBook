using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class RECIPIENT
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CUSTOMERID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string RECIPIENTID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string NAME { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string TELEPHONE { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string DISTINCTID { get; set; }

        [MaxLength(512)]
        [Column(TypeName = "varchar2")]
        public string ADDITIONADDRESS { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string COUNTRYID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PROVINCEID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string CITYID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string AREAID { get; set; }
    }
}