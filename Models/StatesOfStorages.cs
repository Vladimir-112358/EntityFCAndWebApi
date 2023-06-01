using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFCAndWebApi.Models
{
    [Table("StatesOfStorages")]
    public class StatesOfStorages
    {
        [Key] public int StateOfStorageId { get; set; }

        public int ProductId { get; set; }
        public Products? Products { get; set; }

        public int StorageId { get; set; }
        public Storages? Storages { get; set; }

        [Required] public int Quantity { get; set; }

    }
}
