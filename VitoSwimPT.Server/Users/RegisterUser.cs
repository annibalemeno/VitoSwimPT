using FluentEmail.Core;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using VitoSwimPT.Server.Infrastructure;
using VitoSwimPT.Server.Models;

namespace VitoSwimPT.Server.Users
{
    internal sealed class RegisterUser(SwimContext context, PasswordHasher passwordHasher, IFluentEmail fluentEmail, EmailVerificationLinkFactory emailfactory, IValidator<RegisterUser.Request> validator)
    {
        public sealed record Request(string Email, string FirstName, string LastName, string Password);

        public async Task<JsonResult> Handle(Request request)
        {
            try
            {
                validator.ValidateAndThrow(request);

                if (await context.Utenti.Exists(request.Email))
                {
                    throw new Exception("The email is already in use");
                }

                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    PasswordHash = passwordHasher.Hash(request.Password)
                };


                context.Utenti.Add(user);

                DateTime utcNow = DateTime.UtcNow;
                var verificationToken = new EmailVerificationToken
                {
                    Id = Guid.NewGuid(),
                    UserId = user.Id,
                    CreatedOnUtc = utcNow,
                    ExpiresOnUtc = utcNow.AddDays(1)
                };

                context.EmailVerificationTokens.Add(verificationToken);

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException e)
                //  when (e.InnerException is NpgsqlException { SqlState: PostgresErrorCodes.UniqueViolation })
                {
                    throw new Exception("The email is already in use", e);
                }

                string verificationLink = emailfactory.Create(verificationToken);

                await fluentEmail
                    .To(user.Email)
                    .Subject("Email verification for VitoSWimPT")
                    .Body($"To verify your email address <a href='{verificationLink}'>click here</a>", isHtml: true)
                    .SendAsync();

                return new JsonResult(user);
            }
            catch (Exception ex)
            {

                throw;
            }

            //var validationResult = validator.Validate(request);

            //if (!validationResult.IsValid)
            //{
            //    var problemDetail = new HttpValidationProblemDetails(validationResult.ToDictionary())
            //    {
            //        Status = StatusCodes.Status400BadRequest,
            //        Title = "Validation Failed",
            //        Detail = "One or more validation errors occurred",
            //        Instance = "users/register"
            //    };
            //    //return Results.Problem(problemDetail);
            //    return new JsonResult(problemDetail);
            //}
            //else
            //{
            //}


           


        }


    }
}
