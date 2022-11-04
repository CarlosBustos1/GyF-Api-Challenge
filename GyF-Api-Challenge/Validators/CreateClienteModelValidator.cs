using FluentValidation;
using GyF_Api_Challenge.Models;

namespace GyF_Api_Challenge.Validators
{
    public class CreateClienteModelValidator : AbstractValidator<CreateClienteModel>
    {
        public CreateClienteModelValidator()
        {

            RuleFor(x => x.Nombre)
                .NotEmpty();
        }
    }
}
