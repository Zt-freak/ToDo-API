using System;
using TodoApp.Models;
using TodoApp.Repositories.Interfaces;

namespace TodoApp.Services
{
    public class TodoService
    {
        private static IRepository<Todo> _todoRepo;
        public TodoService(IRepository<Todo> todoRepo)
        {
            _todoRepo = todoRepo;
        }

        public static Todo Create() => Create(new Todo() {
            Title = "Hello, world!",
            Description = "Default description."
        });

        public static Todo Create(string title, string description) => Create(new Todo() {
            Title = title,
            Description = description
        });

        public static Todo Create(string title, string description, bool isDone) => Create(new Todo() {
            Title = title,
            Description = description,
            IsDone = isDone
        });

        public static Todo Create(Todo newTodo)
        {
            if (string.IsNullOrEmpty(newTodo.Title))
            {
                throw new ArgumentNullException("Title name cannot be empty.");
            }

            _todoRepo.Insert(newTodo);
            _todoRepo.SaveChanges();

            return newTodo;
        }

        public static Todo Get(int id)
        {
            return _todoRepo.GetById(id);
        }

        public static Todo Update (int id, string title)
        {
            Todo updateTodo = _todoRepo.GetById(id);
            updateTodo.Title = title;

            return Update(updateTodo);
        }

        public static Todo Update(int id, string title, string description)
        {
            Todo updateTodo = _todoRepo.GetById(id);
            updateTodo.Title = title;
            updateTodo.Description = description;

            return Update(updateTodo);
        }

        public static Todo Update(Todo updateTodo)
        {
            return _todoRepo.Update(updateTodo);
        }

        public static Todo ToggleDone(Todo doneTodo)
        {
            doneTodo.IsDone = !doneTodo.IsDone;
            return _todoRepo.Update(doneTodo);
        }

        public static void Delete(int id)
        {
            _todoRepo.Remove(id);
        }

        public static void Delete(Todo deleteTodo)
        {
            _todoRepo.Remove(deleteTodo);
        }
    }
}
