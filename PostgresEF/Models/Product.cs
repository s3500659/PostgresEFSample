using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresEF.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column("Id")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Product needs a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product needs a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product needs a price")]
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
