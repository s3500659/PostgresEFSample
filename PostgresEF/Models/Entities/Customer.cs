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
        public ICollection<Email> Emails { get; set; } = new List<Email>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public Customer(string firstName, string lastName, Email email)
        {
            FirstName = firstName;
            LastName = lastName;
            Emails.Add(email);

        }

    }
}
