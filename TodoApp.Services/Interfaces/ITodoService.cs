using TodoApp.Models;

namespace TodoApp.Services.Interfaces
{
    public interface ITodoService
    {
        Todo Create();
        Todo Create(string title, string description);
        Todo Create(string title, string description, bool isDone);
        Todo Create(Todo newTodo);
        Todo Get(int id);
        Todo Update(int id, string title, string description);
        Todo Update(Todo updateTodo);
        Todo ToggleDone(Todo doneTodo);
        void Delete(int id);
        void Delete(Todo deleteTodo);
    }
}
