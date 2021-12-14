using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using PostgresEF.Dtos;
using PostgresEF.Models.Entities;
using PostgresEF.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostgresEF.Controllers.API
{
    [ApiController]
    [Route("api/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepository _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        // GET: api/commands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Command>>> GetAllCommands()
        {
            var commands = await _repo.GetAllCommands();
            
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        // GET: api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public async Task<ActionResult<CommandReadDto>> GetCommandById(int id)
        {
            var command = await _repo.GetCommandById(id);

            if (command == null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        // POST: api/commands
        [HttpPost]
        public async Task<ActionResult<CommandReadDto>> CreateCommand(
            CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            await _repo.CreateCommand(commandModel);

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById), 
                new { commandReadDto.Id }, commandReadDto);
        }

        // PUT: api/commands/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCommand(
            int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = await _repo.GetCommandById(id);

            if (commandModelFromRepo == null)
                return NotFound();

            // modifies EF entity 
            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        // PATCH: api/commands/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialCommandUpdate(
            int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = await _repo.GetCommandById(id);

            if (commandModelFromRepo == null)
                return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
                return ValidationProblem(ModelState);

            // modifies EF entity 
            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repo.UpdateCommand(commandModelFromRepo);

            _repo.SaveChanges();

            return NoContent();
        }

        // DELETE: api/commands/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCommand(int id)
        {
            var commandToDelete = await _repo.GetCommandById(id);

            if (commandToDelete == null)
                return NotFound();

            await _repo.DeleteCommand(commandToDelete);

            return NoContent();
        }


    }
}
