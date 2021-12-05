using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "An email is required")]
        public ICollection<Email> Emails { get; set; }
        public ICollection<Invoice> Invoices { get; set; }

    }
}
