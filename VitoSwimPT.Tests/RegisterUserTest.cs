using Microsoft.Extensions.Configuration;
using FluentValidation;
using NSubstitute;
using NSubstitute.Extensions;
using VitoSwimPT.Server.Models;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.Users;
using VitoSwimPT.Server.Validators;

namespace VitoSwimPT.Tests
{
    

    public class RegisterUserTest
    {
        private readonly IConfiguration _configMock;
        private readonly SwimContext _swimContextMock;
        private readonly UtentiRepository _utentiRepositoryMock;
        private readonly RegisterUserValidator _validator;

        public RegisterUserTest()
        {
            _configMock = Substitute.For<IConfiguration>();
            _swimContextMock = Substitute.For<SwimContext>(_configMock);
            _utentiRepositoryMock = Substitute.For<UtentiRepository>(_swimContextMock);
            _utentiRepositoryMock.Configure().IsEmailUiniqueAsync(Arg.Any<string>()).Returns(Task.FromResult(false));
            _validator = new RegisterUserValidator(_utentiRepositoryMock);
        }

        [Fact]
        public async void Register_ShouldReturnError_WhenFirstNameEmpty()
        {
            //Arrange
            RegisterUser.Request testRequest = new RegisterUser.Request("mail@mail.com",string.Empty,"lastname","CorrectPwd82", "CorrectPwd82");

            //Act
            var result = await _validator.ValidateAsync(testRequest);
            string errorMessage = result.Errors.First().ErrorMessage;

            //Assert
            Assert.Equal("First Name is required", errorMessage);
        }
        [Fact]
        public async void Register_ShouldReturnError_WhenLastNameEmpty()
        {
            //Arrange
            RegisterUser.Request testRequest = new RegisterUser.Request("mail@mail.com", "firstname", string.Empty, "CorrectPwd82", "CorrectPwd82");

            //Act
            var result = await _validator.ValidateAsync(testRequest);
            string errorMessage = result.Errors.First().ErrorMessage;

            //Assert
            Assert.Equal("Last Name is required", errorMessage);
        }

        [Fact]
        public async void Register_ShouldReturnError_WhenPasswordShort()
        {
            //Arrange
            RegisterUser.Request testRequest = new RegisterUser.Request("mail@mail.com", "firstname", "lastname", "Short82", "Short82");

            //Act
            var result = await _validator.ValidateAsync(testRequest);
            string errorMessage = result.Errors.First().ErrorMessage;

            //Assert
            Assert.Equal("Password must be at least 8 characters long", errorMessage);
        }
        [Fact]
        public async void Register_ShouldReturnError_WhenPasswordNotWellFormed()
        {
            //Arrange
            RegisterUser.Request testRequest = new RegisterUser.Request("mail@mail.com", "firstname", "lastname", "PasswordNotWell", "PasswordNotWell");

            //Act
            var result = await _validator.ValidateAsync(testRequest);
            string errorMessage = result.Errors.First().ErrorMessage;

            //Assert
            Assert.Equal("Password should contain letters, digits and uppercase", errorMessage);
        }
        [Fact]
        public async void Register_ShouldReturnError_WhenPasswordNotMatch()
        {
            //Arrange
            RegisterUser.Request testRequest = new RegisterUser.Request("mail@mail.com", "firstname", "lastname", "Password82", "Password71");

            //Act
            var result = await _validator.ValidateAsync(testRequest);
            string errorMessage = result.Errors.First().ErrorMessage;

            //Assert
            Assert.Equal("Passwords do not match", errorMessage);
        }
        [Fact]
        public async void Register_ShouldReturnError_WhenEmailInUse()
        {
            //Arrange
            RegisterUser.Request testRequest = new RegisterUser.Request("mail@mail.com", "firstname", "lastname", "Password82", "Password82");

            //Act
            var result = await _validator.ValidateAsync(testRequest);
            string errorMessage = result.Errors.First().ErrorMessage;

            //Assert
            Assert.Equal("The email is already in use", errorMessage);
        }

    }
}