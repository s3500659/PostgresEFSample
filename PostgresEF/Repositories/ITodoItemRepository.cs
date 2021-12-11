using Microsoft.AspNetCore.Mvc;
using PostgresEF.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEF.Repositories
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetTodoItems();
        Task<TodoItem> GetTodoItem(int id);
        Task PutTodoItem(TodoItem item);
        Task PostTodoItem(TodoItem item);
        Task<TodoItem> DeleteTodoItem(int id);
    }
}