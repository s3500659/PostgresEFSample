using PostgresEF.Models.Interfaces;
using System;

namespace PostgresEF.Models.Entities
{
    public class Card : ICard
    {
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public DateTime ValidTo { get; set; }
    }
}
