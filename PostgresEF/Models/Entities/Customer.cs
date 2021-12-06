using PostgresEF.Models.Entities;
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
        public virtual ICollection<Email> Emails { get; set; } = new List<Email>();
        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public virtual ICollection<CheckingAccount> CheckingAccounts  { get; set; }



    }
}
