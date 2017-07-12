﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OnionBookOnline.Models
{
    public class ENGAGE
    {
        [Key]
        [MaxLength(128)]
        [Column(Order = 1, TypeName = "varchar2")]
        public string ADVERTISEMENTID { get; set; }

        [Key]
        [MaxLength(128)]
        [Column(Order = 2, TypeName = "varchar2")]
        public string BOOKID { get; set; }
    }
}