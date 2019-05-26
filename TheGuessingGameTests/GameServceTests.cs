using Moq;
using System;
using System.Collections.Generic;
using TheGuessingGame.Models;
using TheGuessingGame.Services;
using Xunit;

namespace TheGuessingGameTests
{
    public class GameServiceTests
    {
        [Fact]
        public async void Create_ReturnsGame()
        {
            //Arrange
            var seedService = new Mock<ISeedService<Employee>>();

            var employees = new List<Employee>();
            var employee = new Employee() { Id = "abc" };
            var employee2 = new Employee() { Id = "def" };
            employees.Add(employee);
            employees.Add(employee2);

            seedService.Setup(x => x.RetrieveData(It.IsAny<int>())).ReturnsAsync(employees).Verifiable();

            var gameService = new GameService(seedService.Object);

            //Act
            var result = await gameService.Create();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(0, result.Id);
        }

        [Fact]
        public async void Create_GuessWithInvalidIds_ReturnsNull()
        {
            //Arrange
            var seedService = new Mock<ISeedService<Employee>>();

            var employees = new List<Employee>();

            var employee = new Employee() { Id = "abc" };
            var employee2 = new Employee() { Id = "def" };

            employees.Add(employee);
            employees.Add(employee2);

            seedService.SetupGet(x => x.Cache).Returns(employees).Verifiable();

            var gameService = new GameService(seedService.Object);

            var guess = new Dictionary<string, string>
            {
                { "abc", "bob" },
                { "ddd", "billy" }
            };

            //Act
            var result = await gameService.AddGuess(0, guess);



            //Assert
        }
    }
}
