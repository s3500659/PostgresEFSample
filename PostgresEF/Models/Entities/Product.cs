using PostgresEF.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresEF.Models
{
    public class Product : IProduct
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Product needs a name")]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product needs a description")]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product needs a price")]
        public decimal Price { get; set; }

        [MaxLength(255)]
        public DateTime DateCreated { get; set; }
        public virtual ICollection<ProductInvoice> ProductInvoices { get; set; }
    }
}
