using PostgresEF.Models.Entities;
using PostgresEF.Models.Interfaces;

namespace PostgresEF.Factory
{
    public class ToyFactory : IToyFactory
    {
        public Toy CreateToy()
        {
            return new Toy();
        }
    }
}
