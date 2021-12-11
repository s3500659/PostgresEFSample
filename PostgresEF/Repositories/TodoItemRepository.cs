using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PostgresEF.Data;
using PostgresEF.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEF.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly IDataContext _context;

        public TodoItemRepository(IDataContext context)
        {
            _context = context;
        }

        public async Task<TodoItem> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
                return null;

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return todoItem;
        }

        public async Task<TodoItem> GetTodoItem(int id)
        {
            return await _context.TodoItems.FindAsync(id);  
        }

        public async Task<IEnumerable<TodoItem>> GetTodoItems()
        {
            return await _context.TodoItems.ToListAsync();
        }

        public async Task PostTodoItem(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();

        }

        public async Task PutTodoItem(TodoItem item)
        {
            _context.TodoItems.Update(item);
            await _context.SaveChangesAsync();
        }


    }
}
