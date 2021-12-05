using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostgresEF.Models
{
    public class Product
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Product needs a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product needs a description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Product needs a price")]
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
        public ICollection<ProductInvoice> ProductInvoices { get; set; }
    }
}
