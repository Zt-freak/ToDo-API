using System;
using TodoApp.Models;
using TodoApp.Repositories.Interfaces;
using TodoApp.Services.Interfaces;

namespace TodoApp.Services
{
    public class TodoService : ITodoService
    {
        private static IRepository<Todo> _todoRepo;
        public TodoService(IRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public Todo Create() => Create(new Todo() {
            Title = "Hello, world!",
            Description = "Default description."
        });

        public Todo Create(string title, string description) => Create(new Todo() {
            Title = title,
            Description = description
        });

        public Todo Create(string title, string description, bool isDone) => Create(new Todo() {
            Title = title,
            Description = description,
            IsDone = isDone
        });

        public Todo Create(Todo newTodo)
        {
            if (string.IsNullOrEmpty(newTodo.Title))
            {
                throw new ArgumentNullException("Title name cannot be empty.");
            }

            _todoRepo.Insert(newTodo);
            _todoRepo.SaveChanges();

            return newTodo;
        }

        public Todo Get(int id)
        {
            return _todoRepo.GetById(id);
        }

        public Todo Update (int id, string title)
        {
            Todo updateTodo = _todoRepo.GetById(id);
            updateTodo.Title = title;

            return Update(updateTodo);
        }

        public Todo Update(int id, string title, string description)
        {
            Todo updateTodo = _todoRepo.GetById(id);
            updateTodo.Title = title;
            updateTodo.Description = description;

            return Update(updateTodo);
        }

        public Todo Update(Todo updateTodo)
        {
            return _todoRepo.Update(updateTodo);
        }

        public Todo ToggleDone(Todo doneTodo)
        {
            doneTodo.IsDone = !(doneTodo.IsDone);
            return _todoRepo.Update(doneTodo);
        }

        public void Delete(int id)
        {
            _todoRepo.Remove(id);
        }

        public void Delete(Todo deleteTodo)
        {
            _todoRepo.Remove(deleteTodo);
        }
    }
}
