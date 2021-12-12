using System;

namespace PostgresEF.Models.Interfaces
{
    public interface ICard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Name { get; set; }
        public DateTime ValidTo { get; set; }
    }
}