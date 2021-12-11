using PostgresEF.Models.Entities;

namespace PostgresEF.Factory
{
    public class TodoItemFactory : ITodoItemFactory
    {
        public TodoItem CreateTodoItem()
        {
            return new TodoItem();
        }
    }
}
