using System.Collections.Generic;

namespace OnionBookOnline.Models
{
    public class Detailbook
    {
        public string ID { get; set; }
        public string ISBN { get; set; }
        public string NAME { get; set; }
        public string PUBLISHER { get; set; }
        public double PRICE { get; set; }
        public double PAGES { get; set; }
        public string PUBLISHINGDATE { get; set; }
        public double SCORE { get; set; }
        public double DISCOUNT { get; set; }
        public double STOCK { get; set; }
        public string PATH { get; set; }
        public string AUTHOR { get; set; }
        public int SALE { get; set; }
        public string INTRODUCTION { get; set; }
        public string SECONDARYID { get; set; }
        public string PRIMARYID { get; set; }
    }

    public class BookViewModel
    {
        public Detailbook detailBook;
        public List<Detailbook> srcBook;
        public List<Detailbook> recBook;
        public List<Detailbook> newBook;
        public List<Detailbook> hotBook;
        public List<Detailbook> typeBook;
    }
}
