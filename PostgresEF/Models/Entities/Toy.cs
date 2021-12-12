using PostgresEF.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models.Entities
{
    public class Toy
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }
    }
}
