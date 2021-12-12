using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models
{
    public class ProductInvoice
    {
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int InvoiceId { get; set; }
        public virtual Invoice Invoice { get; set; }
    }
}