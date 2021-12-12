using PostgresEF.Models.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace PostgresEF.Models.Entities
{
    public class Card : ICard
    {
        public int Id { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        public DateTime ValidTo { get; set; }
        
    }
}
