using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnionBookOnline.Models
{
    public class Book
    {
        public string bookid { get; set; }

        public string isbn { get; set; }

        public string name { get; set; }

        public string primaryId { get; set; }

        public string secondaryId { get; set; }

        public string publisher { get; set; }

        public double price { get; set; }

        public int pages { get; set; }

        public double discount { get; set; }

        public int stock { get; set; }

        public double score { get; set; }

        public int sale { get; set; }

        public string publichingDate { get; set; }        
    }

    public class Author
    {
        public string authorId { get; set; }

        public string name { get; set; }
    }

    public class Category
    {
        public string primaryId { get; set; }

        public string secondaryId { get; set; }

        public string name { get; set; }
    }

    public class PrimaryCategory
    {
        public string primaryId { get; set; }

        public string name { get; set; }
    }

    public class Picture
    {
        public string bookId { get; set; }

        public string pictureId { get; set; }

        public string path { get; set; }
    }

    public class Write
    {
        public string authorId { get; set; }

        public string bookId { get; set; }
    }


    //public class BasicAddress
    //{
    //    public string ID { get; set; }

    //    public string country { get; set; }

    //    public string province { get; set; }

    //    public string city { get; set; }

    //    public string district { get; set; }
    //}

    //public class Recipient
    //{
    //    public string CustomerID { get; set; }

    //    public string ID { get; set; }

    //    public string name { get; set; }

    //    public string telephone { get; set; }

    //    public BasicAddress basicAddress { get; set; }

    //    public string additionalAddress { get; set; }
    //}

    //public class Order
    //{
    //    public string ID { get; set; }

    //    public string CustomerID { get; set; }

    //    public string RecipientID { get; set; }

    //    public double total { get; set; }

    //    public DateTime time { get; set; }

    //    public double count { get; set; }

    //    public string remark { get; set; }

    //    public string status { get; set; }

    //    public double score { get; set; }

    //    public string feedback { get; set; }
    //}

    //public class Customer
    //{
    //    public string ID { get; set; }

    //    public string name { get; set; }

    //    public string password { get; set; }

    //    public string email { get; set; }

    //    public string avatar { get; set; }

    //    public double balacne { get; set; }

    //    public int credits { get; set; }
    //}

    //public class Comment
    //{
    //    public string CustomerID { get; set; }

    //    public string BookID { get; set; }

    //    public string ID { get; set; }

    //    public string title { get; set; }

    //    public string contents { get; set; }

    //    public DateTime timeAttribute { get; set; }
    //}

    //public class Star
    //{
    //    public string CustomerID { get; set; }

    //    public string BookID { get; set; }

    //    public DateTime time { get; set; }
    //}

    //public class PreOrder
    //{
    //    public string CustomerID { get; set; }

    //    public string BookID { get; set; }

    //    public double amount { get; set; }
    //}

    //public class Advertisement
    //{
    //    public string ID { get; set; }

    //    public string title { get; set; }

    //    public DateTime startTime { get; set; }

    //    public DateTime endTime { get; set; }

    //    public string posterPath { get; set; }
    //}

    //public class Engage
    //{
    //    public string AdvertisementID { get; set; }

    //    public string BookID { get; set; }
    //}



    //public class Contain
    //{
    //    public string OrderID { get; set; }

    //    public string BookID { get; set; }

    //    public double amount { get; set; }

    //    public double sum { get; set; }
    //}
}
