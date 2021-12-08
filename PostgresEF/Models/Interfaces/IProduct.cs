using System;

namespace PostgresEF.Interfaces
{
    public interface IProduct
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
