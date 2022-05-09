using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApp.Models;
using TodoApp.Repositories.Interfaces;
using TodoApp.Services;
using Xunit;

namespace TodoApp.Tests.TodoServiceTests
{
    public class Get
    {
        [Fact]
        public void ItShould_GetATodoById()
        {
            Mock<IRepository<Todo>> todoRepo = new();
            todoRepo.Setup(m => m.GetById(It.IsAny<int>())).Returns(new Todo() { Title = "Did you ever hear the tragedy of Darth Plagueis The Wise?" });

            TodoService todoService = new(todoRepo.Object);
            Todo returnTodo = todoService.Get(4);
            Assert.NotNull(returnTodo);
        }

        [Fact]
        public void ItShould_WhenTodoIsNotFound()
        {
            Mock<IRepository<Todo>> todoRepo = new();
            todoRepo.Setup(m => m.GetById(It.IsAny<int>())).Throws(new ArgumentNullException());

            TodoService todoService = new(todoRepo.Object);
            Assert.Throws<ArgumentNullException>(() => todoService.Get(4));
        }

        [Fact]
        public void ItShould_GetAllTodos()
        {
            Mock<IRepository<Todo>> todoRepo = new();
            todoRepo.Setup(m => m.GetAll()).Returns(new List<Todo>() {
                new Todo(),
                new Todo(),
                new Todo()
            }.AsQueryable);

            TodoService todoService = new(todoRepo.Object);
            List<Todo> todoList = todoService.GetAll().ToList();
            Assert.Equal(3, todoList.Count);
        }
    }
}
