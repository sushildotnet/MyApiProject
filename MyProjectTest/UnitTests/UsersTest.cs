using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Moq;
using MyProjectBL.Handlers.QueryHandlers;
using MyProjectBL.Models;
using MyProjectBL.RequestModels;
using MyProjectBL.ResponseModels;
using MyProjectDL.Entities;
using MyProjectDL.Interfaces;
using Xunit;

namespace MyProjectTest.UnitTests
{
    public class UsersTest
    {
        public Mock<IUserDBService> mock = new Mock<IUserDBService>();


        [Fact]
        public void GetUserById_ReturnsUser()
        {
            //Arrange
            const int expected = 1;
            const int id = 1;
            mock.Setup(p => p.GetUserById(id)).Returns(new User() { Id = id });
            var req = new GetUsersRequestModel() { Id = id };

            //Act
            var user = new GetUsersQueryHandler(mock.Object).Handle(req, CancellationToken.None);

            //Assert
            Assert.Equal(expected, user.Id);
        }

        [Fact]
        public async Task ValidUser_Authentication_Returns_Token()
        {
            //Arrange
            var user = new User
            {
                Id = 1,
                FirstName = "test",
                LastName = "test",
                Username = "test",
                Password = "testpP",
                IsAdmin = true
            };
            var opt = Options.Create(new AppSettings() { Secret= "this is my custom Secret key for authnetication" });
            mock.Setup(p => p.AuthenticateUser("test","test"))
                .Returns(user);
            var req = new AuthenticateUserRequestModel() { Username = "test",Password="test" };

            //Act
            var result = await new AuthenticateUserQueryHandler(mock.Object, opt).Handle(req, CancellationToken.None);

            //Assert
            Assert.NotEmpty(result.Token);
        }

        [Fact]
        public async Task InvalidUser_Authentication_Returns_Empty()
        {
            //Arrange
            var user = new User
            {
                Id = 0,
                FirstName = "",
                LastName = "",
                Username = "",
                Password = "",
                IsAdmin = false
            };
            var opt = Options.Create(new AppSettings() { Secret= "this is my custom Secret key for authnetication" });
            mock.Setup(p => p.AuthenticateUser("test", "test"))
                .Returns(user);
            var req = new AuthenticateUserRequestModel() { Username = "test", Password = "test" };

            //Act
            var result = await new AuthenticateUserQueryHandler(mock.Object,opt).Handle(req, CancellationToken.None);

            //Assert
            Assert.Empty(result.Token);
        }
    }
}
