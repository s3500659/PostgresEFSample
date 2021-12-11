using Microsoft.AspNetCore.Mvc;
using PostgresEF.Data;
using PostgresEF.Dtos;
using PostgresEF.Factory;
using PostgresEF.Models.Entities;
using PostgresEF.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEF.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly ITodoItemRepository _repo;
        private readonly ITodoItemFactory _factory;

        public TodoItemsController(ITodoItemRepository repo, ITodoItemFactory factory)
        {
            _repo = repo;
            _factory = factory;
        }

        // GET: api/TodoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var items = await _repo.GetTodoItems();
            return Ok(items);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var item = await _repo.GetTodoItem(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoItem(int id, TodoItem item)
        {
            if (id != item.Id)
                return BadRequest();

            var exist = TodoItemExists(id).Result;

            if (exist)
            {
                await _repo.PutTodoItem(item);
                return NoContent();
            }

            return BadRequest();
        }

        // POST: api/TodoItems
        [HttpPost]
        public async Task<ActionResult> PostTodoItem(CreateTodoItemDto createTodoItemDto)
        {
            if (createTodoItemDto == null)
                return BadRequest();

            var todoItem = _factory.CreateTodoItem();
            todoItem.Name = createTodoItemDto.Name;
            todoItem.IsComplete = createTodoItemDto.IsComplete;

            await _repo.PostTodoItem(todoItem);

            return Ok();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodoItem(int id)
        {

            var item = await _repo.DeleteTodoItem(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }




        private async Task<bool> TodoItemExists(int id)
        {
            var item = await _repo.GetTodoItem(id);

            if (item == null)
                return false;

            return true;
        }
    }
}
