using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
