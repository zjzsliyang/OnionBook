using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionBookOnline.Models
{
    public class GoodSVIewModel
    {
        public List<Goods> GOODS { get; set; }
        public double TOTAL { get; set; }

        public double calcTotal()
        {
            TOTAL = 0;
            foreach(Goods good in GOODS)
            {
                TOTAL += good.calcSubcount();
            }
            return TOTAL;
        }
    }

    public class Goods
    {
        public string PICTURE { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public int AMOUNT { get; set; }
        public double SUBCOUNT { get; set; }
        public string PUBLISHER { get; set; }
        public string AUTHOR { get; set; }

        public double calcSubcount()
        {
            SUBCOUNT = this.PRICE * this.AMOUNT;
            return SUBCOUNT;
        }
    }
}