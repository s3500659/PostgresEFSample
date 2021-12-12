using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength (255)]
        public string Name { get; set; }

        [Required]
        [MaxLength (255)]
        public string Designation { get; set; }
    }
}
