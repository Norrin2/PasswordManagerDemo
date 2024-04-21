using PasswordManager.Models;
using PasswordManager.Repositories;

namespace PasswordManager.Tests
{
    public class PasswordCardRepositoryTests
    {
        [Fact]
        public void Add_AddsNewPassword()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var password = new PasswordCard { Id = Guid.NewGuid(), Name = "Test", Password = "Test123", Url = "www.google.com" };

            // Act
            repository.Add(password);

            // Assert
            Assert.Contains(password, repository.FindAll());
        }

        [Fact]
        public void Delete_RemovesPassword()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var password = new PasswordCard { Id = Guid.NewGuid(), Name = "Test", Password = "Test123", Url = "www.google.com" };
            repository.Add(password);

            // Act
            var deleted = repository.Delete(password.Id.GetValueOrDefault());

            // Assert
            Assert.True(deleted);
            Assert.DoesNotContain(password, repository.FindAll());
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsFalse()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var password = new PasswordCard { Id = Guid.NewGuid(), Name = "Test", Password = "Test123", Url = "www.google.com" };
            repository.Add(password);
            var previousCount = repository.FindAll().Count();

            // Act
            var deleted = repository.Delete(Guid.NewGuid());

            // Assert
            Assert.False(deleted);
            Assert.Equal(previousCount, repository.FindAll().Count());
        }

        [Fact]
        public void Update_UpdatesExistingPassword()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var password = new PasswordCard { Id = Guid.NewGuid(), Name = "Test", Password = "Test123", Url = "www.google.com" };
            repository.Add(password);
            var updatedPassword = new PasswordCard { Id = password.Id, Name = "Updated", Password = "Updated123", Url = "www.google.com" };

            // Act
            var updated = repository.Update(updatedPassword);

            // Assert
            Assert.NotNull(updated);
            Assert.Equal(updatedPassword, updated);
            Assert.Contains(updatedPassword, repository.FindAll());
        }

        [Fact]
        public void Update_ReturnsNullIfPasswordNotFound()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var password = new PasswordCard { Id = Guid.NewGuid(), Name = "Test", Password = "Test123", Url = "www.google.com" };

            // Act
            var updated = repository.Update(password);

            // Assert
            Assert.Null(updated);
        }

        [Fact]
        public void FindAll_ReturnsAllPasswords()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var passwords = new List<PasswordCard>
            {
                new PasswordCard { Id = Guid.NewGuid(), Name = "Test1", Password = "Test123", Url = "www.google.com" },
                new PasswordCard { Id = Guid.NewGuid(), Name = "Test2", Password = "Test123", Url = "www.google.com" },
                new PasswordCard { Id = Guid.NewGuid(), Name = "Test3", Password = "Test123", Url = "www.google.com" }
            };
            foreach (var p in passwords)
            {
                repository.Add(p);
            }

            // Act
            var foundPasswords = repository.FindAll();

            // Assert
            Assert.Equal(passwords, foundPasswords);
        }

        [Fact]
        public void FindByName_ReturnsPasswordsMatchingName()
        {
            // Arrange
            var repository = new PasswordCardRepository();
            var passwords = new List<PasswordCard>
            {
                new PasswordCard { Id = Guid.NewGuid(), Name = "Test1", Password = "Test123", Url = "www.google.com" },
                new PasswordCard { Id = Guid.NewGuid(), Name = "AnotherTest", Password = "Test123", Url = "www.google.com" },
                new PasswordCard { Id = Guid.NewGuid(), Name = "DifferentName", Password = "Test123", Url = "www.google.com" }
            };
            foreach (var p in passwords)
            {
                repository.Add(p);
            }

            // Act
            var foundPasswords = repository.FindByName("Test");

            // Assert
            Assert.Equal(2, foundPasswords.Count());
            Assert.Contains(passwords[0], foundPasswords);
            Assert.Contains(passwords[1], foundPasswords);
        }
    }
}