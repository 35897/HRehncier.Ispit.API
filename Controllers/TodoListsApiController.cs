using Ispit.API.Models;
using Ispit.API.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ispit.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoListsApiController : ControllerBase
    {
        private readonly ITodoService todoService;

        public TodoListsApiController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        // GET: api/<TodoApiController>
        [HttpGet]
        public IActionResult GetTodoLists()
        {
            return Ok(todoService.GetTodoLists());
        }

        // GET api/<TodoApiController>/5
        [HttpGet("{id}")]
        public IActionResult GetTodoList(int id)
        {

            return Ok(todoService.GetTodoList(id));
        }

        // POST api/<TodoApiController>
        [HttpPost]
        public IActionResult Post([FromBody] TodoList model)
        {
            return Ok(todoService.CreateTodoList(model));
        }

        // PUT api/<TodoApiController>/5
        [HttpPut]
        public IActionResult Put([FromBody] TodoList model)
        {
            return Ok(todoService.UpdateTodoList(model));
        }

        // DELETE api/<TodoApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            todoService.DeleteTodoList(id);
        }
    }
}
