using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Install "Entity Framework"
//Right click solution > Manage NuGet Packages
//Search Entity Framework and install to solution
//using System.Data.Entity;
//using System.Data.Entity.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

using System.Configuration;

//This is a Model. What we're doing is defining classes
//That will define our database and tables.

namespace StoreProject.Models
{
    public class StoreCMSContext : DbContext
    {
        public StoreCMSContext()
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }

        //Entity framework core asks me to specify sql server
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["StoreCMSContext"].ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //describing that a pagextag PK is composite of page and tag
            modelBuilder.Entity<StorexItem>()
                .HasKey(pxt => new { pxt.StoreId, pxt.ItemId });

            //describing that pagextag is associated with one page
            //AND one page has many pagesxtags
            //AND pagesxtags has foreign key to pageid
            modelBuilder.Entity<StorexItem>()
                .HasOne(pxt => pxt.Store)
                .WithMany(pxt => pxt.storexitems)
                .HasForeignKey(pxt => pxt.StoreId);

            // Describing that pagextag is associated to one tag
            //AND one tag has many pagesxtags
            //and pagesxtags has foreign key to tagid
            modelBuilder.Entity<StorexItem>()
                .HasOne(pxt => pxt.Item)
                .WithMany(pxt => pxt.storexitems)
                .HasForeignKey(pxt => pxt.ItemId);



            base.OnModelCreating(modelBuilder);
            //also need to specify that these models make tables
            modelBuilder.Entity<Store>().ToTable("Stores");
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<StorexItem>().ToTable("StoresxItems");
           // modelBuilder.Entity<PagexTag>().ToTable("PagesxTags");

        }

    }
}