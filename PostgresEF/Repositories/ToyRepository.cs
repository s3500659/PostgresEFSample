using Microsoft.EntityFrameworkCore;
using PostgresEF.Data;
using PostgresEF.Models.Entities;
using PostgresEF.Models.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace PostgresEF.Services
{
    public class ToyRepository : IToyRepository
    {
        private readonly IDataContext _context;

        public ToyRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task CreateToy(Toy toy)
        {
            _context.Toys.Add(toy);
            await _context.SaveChangesAsync();
        }

        public async Task<Toy> GetToyById(int id)
        {
            return await _context.Toys
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();
        }

    }
}
