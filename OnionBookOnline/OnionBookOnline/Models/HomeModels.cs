using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnionBookOnline.Models
{
    public class HomeBookInfo
    {

        public string NAME { get; set; }
        public string AUTHORNAME { get; set; }
        public double SCORE { get; set; }
        public double PRICE { get; set; }
        public double DISCOUNT { get; set; }
        public int SALE { get; set; }
        public string PUBLISHINGDATE { get; set; }
        public string PATH { get; set; }

        public HomeBookInfo()
        {

        }

    }

}