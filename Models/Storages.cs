using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFCAndWebApi.Models
{
    [Table("Storages")]
    public class Storages
    {
        [Key] 
        public int StorageId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string KindOfStorage { get; set; } = string.Empty;
    }
}
