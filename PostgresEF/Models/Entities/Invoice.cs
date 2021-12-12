using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models
{
    public class Invoice
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Date created is required")]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Due date is required")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Total is required")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Customer id created is required")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public virtual ICollection<ProductInvoice> ProductInvoices { get; set; } = new List<ProductInvoice>();
    }
}
