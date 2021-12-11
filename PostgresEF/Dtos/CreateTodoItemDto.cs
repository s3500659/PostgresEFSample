using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Dtos
{
    public class CreateTodoItemDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public bool IsComplete { get; set; }
    }
}
