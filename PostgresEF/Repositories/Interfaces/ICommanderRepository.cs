using PostgresEF.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEF.Repositories.Interfaces
{
    public interface ICommanderRepository
    {
        bool SaveChanges();

        Task<IEnumerable<Command>> GetAllCommands();
        Task<Command> GetCommandById(int id);
        Task CreateCommand(Command command);
        Task UpdateCommand(Command command);
        Task DeleteCommand(Command command);
    }
}
