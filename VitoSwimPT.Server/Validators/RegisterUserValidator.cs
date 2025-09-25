using FluentEmail.Core;
using FluentValidation;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.Validators
{
    internal sealed class RegisterUserValidator:AbstractValidator<RegisterUser.Request>
    {
        public RegisterUserValidator(IUtenteRepository utenteRepository)
        {
            //string Email, string FirstName, string LastName, string Password

            //Email Validation
            RuleFor(r => r.Email).NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Mail Format");

            //Firstname Validation
            RuleFor(r => r.FirstName).NotEmpty().WithMessage("First Name is required");

            //Lastname Validation
            RuleFor(r => r.LastName).NotEmpty().WithMessage("Last Name is required");

            //Password Validation
            RuleFor(r => r.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long");

            RuleFor(r => r.Email).MustAsync(async (email, _) =>
            {
                return await utenteRepository.IsEmailUiniqueAsync(email);
            }).WithMessage("The email is already in use");

            //Confirm Password
            //RuleFor(r => r.Password)
            //    .Equal(r => r.Password).WithMessage("Password do not match");

        }
    }
}
