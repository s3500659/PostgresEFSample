using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models.Entities
{
    public class Command
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }


    }
}
