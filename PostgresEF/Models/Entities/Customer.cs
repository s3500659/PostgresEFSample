using PostgresEF.Models.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength (255)]
        public string LastName { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<CheckingAccount> CheckingAccounts  { get; set; }



    }
}
