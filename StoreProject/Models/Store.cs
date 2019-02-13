using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StoreProject.Models
{
    public class Store
    {
        [Key]
        public int StoreId { get; set; }

        [Required, StringLength(255), Display (Name = "Store Name")]
        public string StoreName { get; set; }

        [StringLength(255), Display (Name = "Store Address")]
        public string StoreAddress { get; set; }

        [InverseProperty("Store")]
        public virtual List<StorexItem> storexitems { get; set; }
        


    }
}