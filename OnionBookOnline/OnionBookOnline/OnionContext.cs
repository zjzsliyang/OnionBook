using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.EntityFramework;
using OnionBookOnline.Models;

namespace OnionBookOnline.DAL
{
    public class OnionContext : DbContext
    {
        public OnionContext(): base("name=OnionContext")
        {
            //Database.SetInitializer<DbContext>(null);
            //Database.SetInitializer<OnionContext>(new CreateDatabaseIfNotExists<OnionContext>());
            Database.SetInitializer<OnionContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ONIONBOOK");
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<AUTHOR> authors { get; set; }
    }
}