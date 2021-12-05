using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models
{
    public class Email
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Customer id for this email is required")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
