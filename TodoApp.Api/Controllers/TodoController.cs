using Microsoft.AspNetCore.Mvc;
using System;
using TodoApp.Models;
using TodoApp.Services.Interfaces;

namespace TodoApp.Api.Controllers
{
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        [Route("/todos")]
        public IActionResult GetTodos() => Ok(new { Results = _todoService.GetAll()});

        [HttpPost]
        [Route("/todo/create")]
        public IActionResult CreateTodo(Todo todo) => Ok(_todoService.Create(todo));

        [HttpGet]
        [Route("/todo/{id}")]
        public IActionResult GetTodo(int id) => Ok(_todoService.Get(id));

        [HttpGet]
        [Route("/todo/{id}/check")]
        public IActionResult CheckTodo(int id) => Ok(_todoService.ToggleDone(_todoService.Get(id)));

        [HttpPost]
        [Route("/todo/edit")]
        public IActionResult EditTodo(Todo todo) => Ok(_todoService.Update(todo));

        [HttpGet]
        [Route("/todo/{id}/delete")]
        public IActionResult DeleteTodo(int id)
        {
            try { _todoService.Delete(id); } 
            catch(Exception)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        [Route("/todo/owo")]
        public IActionResult Index(string notFound) => NotFound(
            "< OwO >\n" +
            "    \\   ^__ ^\n" +
            "     \\  (oo)\\_______\n" +
            "        (__)\\       )\\/\\\n" +
            "            || ----w |\n" +
            "            ||     ||"
        );
    }
}
