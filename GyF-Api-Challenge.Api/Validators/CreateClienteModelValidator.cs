using FluentValidation;
using GyF_Api_Challenge.Api.Models;
using GyF_Api_Challenge.Core.Enums;

namespace GyF_Api_Challenge.Validators
{
    public class CreateClienteModelValidator : AbstractValidator<BaseClienteModel>
    {
        public CreateClienteModelValidator()
        {

            RuleFor(x => x.Nombre)
                .NotEmpty();

            RuleFor(x => x.Cuil)
               .MaximumLength(13);

            RuleFor(x => x.Telefono)
               .MaximumLength(50);

            RuleFor(x => x.Genero)
                .NotEmpty();
        

        }
    }
}
