using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnionBookOnline.Models
{
    public class CheckoutViewModel
    {
        public RECIPIENT DefualtRec { get; set; }
        public List<RECIPIENT> RecList { get; set; }
        public RECIPIENT NewRec { get; set; }

        public List<CONTAIN> Contains;

        public List<OrderItem> OrderItems;

        public List<DetailOrder> DOrders;

        public OORDER NewOrder;
    }

    public class DetailOrder
    {
        public BasicOrder BORDER { get; set; }
        public List<OrderItem> OITEMS { get; set; }

        public DetailOrder(BasicOrder b, List<OrderItem> o)
        {
            BORDER = new BasicOrder(b);
            OITEMS = new List<OrderItem>(o);
        }
    }
    public class BasicOrder
    {
        public string ORDERID { get; set; }
        public double TOTAL { get; set; }
        public string TIME { get; set; }
        public string STATUS { get; set; }

        public BasicOrder() { }
        public BasicOrder(BasicOrder rhs)
        {
            this.ORDERID = rhs.ORDERID;
            this.TOTAL = rhs.TOTAL;
            this.TIME = rhs.TIME;
            this.STATUS = rhs.STATUS;
        }
    }
    public class OrderItem
    {
        public string PATH { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public int AMOUNT { get; set; }
        public double SUBTOTAL { get; set; }

        public OrderItem() { }
        public OrderItem(OrderItem rhs)
        {
            PATH = rhs.PATH;
            NAME = rhs.NAME;
            PRICE = rhs.PRICE;
            AMOUNT = rhs.AMOUNT;
            SUBTOTAL = rhs.SUBTOTAL;
        }
    }

}