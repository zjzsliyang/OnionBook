using OnionBookOnline.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnionBookOnline.DAL
{
    public class OnionContext : DbContext
    {
        public OnionContext(): base("name=OnionContext")
        {
            Database.SetInitializer<OnionContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ONIONBOOK");
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<ADVERTISEMENT> advertisements { get; set; }

        public DbSet<AREA> areas { get; set; }

        public DbSet<AUTHOR> authors { get; set; }

        public DbSet<BOOK> books { get; set; }

        public DbSet<CATEGORY> categorys { get; set; }

        //public DbSet<CITY> citys { get; set; }

        //public DbSet<CONTAIN> contains  { get; set; }

        //public DbSet<COUNTRY> countrys { get; set; }

        //public DbSet<CUSTOMER> customers { get; set; }

        //public DbSet<ENGAGE> engages { get; set; }

        //public DbSet<OCOMMENT> ocomments { get; set; }

        //public DbSet<OORDER> oorders { get; set; }

        //public DbSet<PICTURE> pictures { get; set; }

        //public DbSet<PREORDER> preorders { get; set; }

        //public DbSet<PRIMARYCATEGORY> primarycategorys { get; set; }

        //public DbSet<PROVINCE> provinces { get; set; }

        //public DbSet<RECIPIENT> recipients { get; set; }

        //public DbSet<STAR> stars { get; set; }

        //public DbSet<WRITE> writes { get; set; }
    }
}