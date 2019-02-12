using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace StoreProject.Models
{
    public class StoreCMSContext : DbContext
    {
        public StoreCMSContext()
        {

        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}