using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnionBookOnline.Models
{
    public class BasicAddress
    {
        public string ID { get; set; }

        public string country { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string district { get; set; }
    }

    public class Recipient
    {
        public string CustomerID { get; set; }

        public string ID { get; set; }

        public string name { get; set; }

        public string telephone { get; set; }

        public BasicAddress basicAddress { get; set; }

        public string additionalAddress { get; set; }
    }

    public class Order
    {
        public string ID { get; set; }

        public string CustomerID { get; set; }

        public string RecipientID { get; set; }

        public double total { get; set; }

        public DateTime time { get; set; }

        public double count { get; set; }

        public string remark { get; set; }

        public string status { get; set; }

        public double score { get; set; }

        public string feedback { get; set; }
    }

    public class Customer
    {
        public string ID { get; set; }

        public string name { get; set; }

        public string password { get; set; }

        public string email { get; set; }

        public string avatar { get; set; }

        public double balacne { get; set; }

        public int credits { get; set; }
    }

    public class Comment
    {
        public string CustomerID { get; set; }

        public string BookID { get; set; }

        public string ID { get; set; }

        public string title { get; set; }

        public string contents { get; set; }

        public DateTime timeAttribute { get; set; }
    }

    public class Star
    {
        public string CustomerID { get; set; }

        public string BookID { get; set; }

        public DateTime time { get; set; }
    }

    public class PreOrder
    {
        public string CustomerID { get; set; }

        public string BookID { get; set; }

        public double amount { get; set; }
    }

    public class PICTURE
    {
        public string BOOKID { get; set; }

        public string ID { get; set; }

        public string PATH { get; set; }
    }

    public class category
    {
        public string ID { get; set; }

        public string primary { get; set; }

        public string secondary { get; set; }
    }

    public class AUTHOR
    {
        [Key]
        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string AUTHORID { get; set; }

        [MaxLength(128)]
        [Column(TypeName = "varchar2")]
        public string NAME { get; set; }
    }

    public class WRITE
    {
        [Key]
        [Column(Order = 1)]
        public string AUTHORID { get; set; }

        [Key]
        [Column(Order = 2)]
        public string BOOKID { get; set; }
    }

    public class Advertisement
    {
        public string ID { get; set; }

        public string title { get; set; }

        public DateTime startTime { get; set; }

        public DateTime endTime { get; set; }

        public string posterPath { get; set; }
    }

    public class Engage
    {
        public string AdvertisementID { get; set; }

        public string BookID { get; set; }
    }

    public class BOOK
    {
        [Key]
        public string BOOKID { get; set; }

        public string ISBN { get; set; }

        public string NAME { get; set; }

        public string PRIMARYID { get; set; }

        public string SECONDARYID { get; set; }

        public string PUBLISHER { get; set; }

        public double PRICE { get; set; }

        public int PAGES { get; set; }

        public double DISCOUNT { get; set; }

        public int STOCK { get; set; }

        public double SCORE { get; set; }

        public int SALE { get; set; }

        public string PUBLISHINGDATE { get; set; }

       
    }

    public class Contain
    {
        public string OrderID { get; set; }

        public string BookID { get; set; }

        public double amount { get; set; }

        public double sum { get; set; }
    }

    //Necessary book information in homepage
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