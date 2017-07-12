using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnionBookOnline.Models
{
    public class PRIMARYCATEGORY
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string PRIMARYID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string NAME { get; set; }
    }
}