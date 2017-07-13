using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionBookOnline.Models
{
    public class OrderViewModel
    {
        public List<string> orderIds { get; set; }
        public int orderCount { get; set; }
        public List<DetailOrder> orders { get; set; }  
        public double total { get; set; }

        public double calcTotal()
        {
            total = 0;
            foreach(DetailOrder dOrder in orders)
            {
                total += dOrder.SUM;
            }
            return total;
        }
    }

    public class DetailOrder
    {
        public string PICTURE { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public int COUNT { get; set; }
        public double SUM { get; set; }
    }
    
}