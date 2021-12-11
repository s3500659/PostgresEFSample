using PostgresEF.Models.Entities;
using PostgresEF.Models.Interfaces;

namespace PostgresEF.Factory
{
    public interface IToyFactory
    {
        Toy CreateToy();
    }
}