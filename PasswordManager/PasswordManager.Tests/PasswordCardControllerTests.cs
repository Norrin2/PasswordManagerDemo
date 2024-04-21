using Microsoft.AspNetCore.Mvc;
using PasswordManager.Controllers;
using PasswordManager.Models;
using PasswordManager.Repositories;

namespace PasswordManager.Tests
{
    public class PasswordCardControllerTests
    {
        [Fact]
        public void FindAll_ReturnsOkResultWithListOfPasswordCards()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var controller = new PasswordCardController(repository);

            // Act
            var result = controller.FindAll() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<PasswordCard>>(result.Value);
        }

        [Fact]
        public void Create_ReturnsOkResultWithCreatedPasswordCard()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var controller = new PasswordCardController(repository);
            var password = new PasswordCard { Name = "Test", Password = "Test123" };

            // Act
            var result = controller.Create(password) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(password, result.Value);
        }

        [Fact]
        public void FindByName_ReturnsOkResultWithListOfPasswordCards()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var controller = new PasswordCardController(repository);
            var password = new PasswordCard { Id = Guid.NewGuid(), Name = "Test", Password = "Test123" };
            repository.Add(password);

            // Act
            var result = controller.FindById("Test") as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<PasswordCard>>(result.Value);
        }

        [Fact]
        public void Update_ReturnsOkResult()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var controller = new PasswordCardController(repository);
            var id = Guid.NewGuid();
            var password = new PasswordCard { Id = id, Name = "Test", Password = "Test123" };
            repository.Add(password);
            var updatedPassword = new PasswordCard { Id = id, Name = "Updated", Password = "Updated123" };

            // Act
            var result = controller.Update(id, updatedPassword) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(updatedPassword, result.Value);
        }

        [Fact]
        public void Delete_ReturnsOkResult()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var controller = new PasswordCardController(repository);
            var id = Guid.NewGuid();
            var password = new PasswordCard { Id = id, Name = "Test", Password = "Test123" };
            repository.Add(password);

            // Act
            var result = controller.Delete(id);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsNotFound()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var controller = new PasswordCardController(repository);
            var password = new PasswordCard { Id = Guid.NewGuid(), Name = "Test", Password = "Test123" };
            repository.Add(password);

            // Act
            var result = controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}
