using System.ComponentModel.DataAnnotations;

namespace StoreProject.Models
{
    public class StorexItem
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}
