using Xunit;
using Moq;
using TodoApp.Services;
using TodoApp.Models;
using TodoApp.Repositories.Interfaces;
using System;

namespace TodoApp.Tests.TodoServiceTests
{
    public class Create
    {
        [Fact]
        public void ItShould_CreateTodo()
        {
            Mock<IRepository<Todo>> todoRepo = new();
            
            TodoService todoService = new(todoRepo.Object);
            Todo returnTodo = todoService.Create(
                new Todo()
                {
                    Title = "We're no strangers to love",
                    Description = "You know the rules and so do I"
                }
            );
            Assert.Equal("We're no strangers to love", returnTodo.Title);
            Assert.Equal("You know the rules and so do I", returnTodo.Description);
        }

        [Fact]
        public void ItShould_CreateATodo_FromTitleAndDescriptionStrings()
        {
            Mock<IRepository<Todo>> todoRepo = new();

            TodoService todoService = new(todoRepo.Object);
            Todo returnTodo = todoService.Create("A full commitment's what I'm thinking of", "You wouldn't get this from any other guy");
            Assert.Equal("A full commitment's what I'm thinking of", returnTodo.Title);
            Assert.Equal("You wouldn't get this from any other guy", returnTodo.Description);
        }

        [Fact]
        public void ItShould_CreateATodo_FromTitleAndDescriptionStringsAndCheckedBool()
        {
            Mock<IRepository<Todo>> todoRepo = new();

            TodoService todoService = new(todoRepo.Object);
            Todo returnTodo = todoService.Create("I just wanna tell you how I'm feeling", "Gotta make you understand", true);
            Assert.Equal("I just wanna tell you how I'm feeling", returnTodo.Title);
            Assert.Equal("Gotta make you understand", returnTodo.Description);
            Assert.True(returnTodo.IsDone);
        }

        [Fact]
        public void ItShould_CreateADefaultTodo_WhenArgumentsAreEmpty()
        {
            Mock<IRepository<Todo>> todoRepo = new();

            TodoService todoService = new(todoRepo.Object);
            Todo returnTodo = todoService.Create();
            Assert.NotNull(returnTodo);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void ItShould_ArgumentNullException_WhenTitleIsEmpty(string inputTitle)
        {
            Mock<IRepository<Todo>> todoRepo = new();

            TodoService todoService = new(todoRepo.Object);

            Assert.Throws<ArgumentNullException>(() => todoService.Create(
                new Todo()
                {
                    Title = inputTitle
                }
            ));
        }
    }
}
