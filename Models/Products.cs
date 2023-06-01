using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFCAndWebApi.Models
{
    [Table("Products")]
    public class Products
    {
        [Key] 
        public int ProductId { get; set; }
        [Required] 
        public string? Name { get; set; }
        [Required] 
        public decimal? Cost { get; set; }
    }


}
