using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models.Entities
{
    public class AccountInfo
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
