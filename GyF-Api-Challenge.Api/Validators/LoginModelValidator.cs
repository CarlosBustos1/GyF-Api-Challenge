using FluentValidation;
using GyF_Api_Challenge.Api.Models.Auth;

namespace GyF_Api_Challenge.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(30);

            RuleFor(x => x.Password)
                .NotEmpty()
                .MaximumLength(30);

        }
    }
}
