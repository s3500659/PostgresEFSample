using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
