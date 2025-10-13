using FluentEmail.Core;
using FluentValidation;
using VitoSwimPT.Server.Repository;
using VitoSwimPT.Server.Users;

namespace VitoSwimPT.Server.Validators
{
    public  class RegisterUserValidator:AbstractValidator<RegisterUser.Request>
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

            RuleFor(r => r.Password).Must( (req, _) =>
            {
                return (req.Password.Count(Char.IsNumber) > 0 && req.Password.Count(Char.IsLetter) > 0
                && req.Password.Count(Char.IsUpper) > 0)  ;
            }).WithMessage("Password should contain letters, digits and uppercase");

            RuleFor(r => r.confirmPassword).Equal(r => r.Password).WithMessage("Passwords do not match");

            RuleFor(r => r.Email).MustAsync(async (email, _) =>
            {
                return await utenteRepository.IsEmailUiniqueAsync(email);
            }).WithMessage("The email is already in use");

        }
    }
}
