using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StoreProject.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required, StringLength(255), Display (Name = "Item Name")]
        public string ItemName { get; set; }

        [Required, Display (Name ="Item Price")]
        public float ItemPrice { get; set; }

        public virtual Store Store { get; set; }
    }
}