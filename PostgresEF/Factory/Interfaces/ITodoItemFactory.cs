using PostgresEF.Models.Entities;

namespace PostgresEF.Factory
{
    public interface ITodoItemFactory
    {
        public TodoItem CreateTodoItem();
    }
}
