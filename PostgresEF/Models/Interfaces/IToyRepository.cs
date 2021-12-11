using PostgresEF.Models.Entities;
using System.Threading.Tasks;

namespace PostgresEF.Models.Interfaces
{
    public interface IToyRepository
    {
        Task<Toy> GetToyById(int id);
        Task CreateToy(Toy book);
    }
}
