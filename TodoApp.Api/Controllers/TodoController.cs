using Microsoft.AspNetCore.Mvc;
using System;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("owo")]
        public IActionResult Index() => Ok(
                " _______________________\n" +
                "< OwO >\n" +
                "-----------------------\n" +
                "    \\   ^__ ^\n" +
                "     \\  (oo)\\_______\n" +
                "        (__)\\       )\\/\\\n" +
                "            || ----w |\n" +
                "            ||     ||"
        );

        [HttpPost]
        [Route("create")]
        public IActionResult CreateTodo(Todo todo) => Ok(_todoService.Create(todo));

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetTodo(int id) => Ok(_todoService.Get(id));

        [HttpGet]
        [Route("toggle/{id}")]
        public IActionResult ToggleDone(int id) => Ok(_todoService.ToggleDone(_todoService.Get(id)));

        [HttpPost]
        [Route("edit")]
        public IActionResult EditTodo(Todo todo) => Ok(_todoService.Update(todo));

        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult DeleteTodo(int id)
        {
            try { _todoService.Delete(id); } 
            catch(Exception)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}
