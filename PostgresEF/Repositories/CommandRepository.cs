using Microsoft.EntityFrameworkCore;
using PostgresEF.Data;
using PostgresEF.Models.Entities;
using PostgresEF.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEF.Repositories
{
    public class CommandRepository : ICommanderRepository
    {
        private readonly IDataContext _context;

        public CommandRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task CreateCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Add(command);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Remove(command);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Command>> GetAllCommands()
        {
            return await _context.Commands.ToListAsync();
        }

        public async Task<Command> GetCommandById(int id)
        {
            return await _context.Commands.FirstOrDefaultAsync(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChangesAsync().Result >= 0);
            
        }

        public async Task UpdateCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Update(command);
            await _context.SaveChangesAsync();
        }
    }
}
