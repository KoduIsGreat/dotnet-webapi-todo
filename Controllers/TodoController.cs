using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EspAPI.Models;
using EspAPI.Services;

namespace EspAPI.Controllers
{
    [Route("api/todos/")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService service)
        {
            this._todoService = service;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodos()
        {
            var result = await _todoService.GetTodos();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(int id)
        {
            var result = await _todoService.GetTodo(id);
            return result;
        }

        [HttpPost("")]
        public async Task<ActionResult<Todo>> PostTodo(Todo model)
        {

            var result = await _todoService.SaveTodo(model);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodoById(int id)
        {
            // TODO: Your code here
            await Task.Yield();

            return null;
        }
    }
}