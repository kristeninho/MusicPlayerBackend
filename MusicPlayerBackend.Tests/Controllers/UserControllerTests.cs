using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicPlayerBackend.Controllers;
using MusicPlayerBackend.Models.DTOs;
using MusicPlayerBackend.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayerBackend.Tests.Controllers
{
    public class UserControllerTests
    {
        private readonly Mock<IUserRepository> _userRepository;
        public UserControllerTests()
        {
            _userRepository = new Mock<IUserRepository>();
        }
        
        [Fact]
        public void AddUserTest_ValidCredentials()
        {
            //arrange
            var validUserCredentials = new UserCredentialsDTO
            {
                UserName = "Username1",
                Password = "Password1!"
            };

            _userRepository.Setup(x => x.AddAsync(validUserCredentials))
                .ReturnsAsync(validUserCredentials);

            var userController = new UserController(_userRepository.Object);

            //act
            var addUserResult = userController.AddUser(validUserCredentials).Result;
            
            //assert
            Assert.NotNull(addUserResult);
            Assert.Equal(validUserCredentials, ((ObjectResult)addUserResult.Result).Value);
        }
        [Fact] //all other invalid variations will be tested under helper tests
        public void AddUserTest_InValidCredentials()
        {
            //arrange
            var invalidUserCredentials = new UserCredentialsDTO
            {
                UserName = "Us",
                Password = "Password1!"
            };
            var expectedError = "Invalid user credentials";

            var userController = new UserController(_userRepository.Object);

            //act
            var addUserResult = userController.AddUser(invalidUserCredentials).Result;

            //assert
            Assert.NotNull(addUserResult);
            Assert.Equal(expectedError, ((BadRequestObjectResult)addUserResult.Result).Value);
        }
        [Fact] //all other invalid variations will be tested under helper tests
        public void AddUserTest_UserAlreadyExists()
        {
            //arrange
            var userCredentials = new UserCredentialsDTO
            {
                UserName = "Username1",
                Password = "Password1!"
            };
            var expectedError = "Username already taken";

            _userRepository.Setup(x => x.CheckIfUserExistsByUsername(userCredentials.UserName))
                .ReturnsAsync(true);

            var userController = new UserController(_userRepository.Object);

            //act
            var addUserResult = userController.AddUser(userCredentials).Result;

            //assert
            Assert.NotNull(addUserResult);
            Assert.Equal(expectedError, ((BadRequestObjectResult)addUserResult.Result).Value);
        }


        // TODO: ADD TESTS FOR CONTROLLER!
    }
}
