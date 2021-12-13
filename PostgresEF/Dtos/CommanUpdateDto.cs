using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Dtos
{
    public class CommanUpdateDto
    {
        [Required]
        [MaxLength(255)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; }

        [Required]
        public string Platform { get; set; }
    }
}
