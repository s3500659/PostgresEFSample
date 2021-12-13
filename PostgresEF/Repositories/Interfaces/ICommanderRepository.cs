using PostgresEF.Models.Entities;
using System.Collections.Generic;

namespace PostgresEF.Repositories.Interfaces
{
    public interface ICommanderRepository
    {
        bool SaveChanges();

        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
        void CreateCommand(Command command);
        void UpdateCommand(Command command);
        void DeleteCommand(Command command);
    }
}
