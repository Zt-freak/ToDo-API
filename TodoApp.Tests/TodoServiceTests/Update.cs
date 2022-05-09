using Moq;
using TodoApp.Models;
using TodoApp.Repositories.Interfaces;
using TodoApp.Services;
using Xunit;

namespace TodoApp.Tests.TodoServiceTests
{
    public class Update
    {
        [Fact]
        public void ItShould_UpdateTodo()
        {
            Mock<IRepository<Todo>> todoRepo = new();
            todoRepo.Setup(m => m.Update(It.IsAny<Todo>())).Returns(new Todo() { Title = "Did you ever hear the tragedy of Darth Plagueis The Wise?" });

            Todo tempTodo = new()
            {
                Title = "I thought not. It’s not a story the Jedi would tell you.",
                Description = "It’s a Sith legend. Darth Plagueis was a Dark Lord of the Sith, so powerful and so wise he could use the Force to influence the midichlorians to create life."
            };
            TodoService todoService = new(todoRepo.Object);
            Todo returnTodo = todoService.Update(tempTodo);
            Assert.Equal("Did you ever hear the tragedy of Darth Plagueis The Wise?", returnTodo.Title);
        }
    }
}
