using Castle.Core.Configuration;
using FluentValidation;
using Microsoft.VisualStudio.TestPlatform.TestHost;
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
        //[Fact]
        //public void Test1()
        //{
        //    // Arrange
        //    int a = 3;
        //    int b = 5;

        //    // Act
        //    int result = a + b;

        //    // Assert
        //    Assert.Equal(8, result); // Check if the result is as expected.
        //}

        // public sealed record Request(string Email, string FirstName, string LastName, string Password, string confirmPassword);

        [Fact]
        public void Register_ShouldReturnError_WhenEmailEmpty()
        {
            //Arrange
            RegisterUser.Request testRequest = new RegisterUser.Request("mail","name","surname","pwd","pwd");
            var _configMock = Substitute.For<Microsoft.Extensions.Configuration.IConfiguration>();
            var _swimContextMock = Substitute.For<SwimContext>(_configMock);
            var _utentiRepositoryMock = Substitute.For<UtentiRepository>(_swimContextMock);

            _utentiRepositoryMock.Configure().IsEmailUiniqueAsync(Arg.Any<string>()).Returns(true);


            RegisterUserValidator validator = new RegisterUserValidator(_utentiRepositoryMock);

            //RegisterUser.Request testRequest = new RegisterUser.Request("mail","name","surname","pwd","pwd");
            //RegisterUser useCase = null;
            //IValidator<RegisterUser.Request> validator;
            //Act
            var result = validator.ValidateAsync(testRequest);

            //var tmp =  async (RegisterUser.Request request, RegisterUser useCase) =>
            //    await useCase.Handle(request);

            //var result = useCase.Handle(testRequest);

            //public async Task<JsonResult> Handle(Request request)

            //Assert
            Assert.Equal(1, 1);
        }
            
    }
}