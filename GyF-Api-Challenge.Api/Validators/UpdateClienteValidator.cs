using FluentValidation;
using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Api.Models;

namespace GyF_Api_Challenge.Validators
{
    public class UpdateClienteModelValidator : AbstractValidator<UpdateClienteModel>
    {
        public UpdateClienteModelValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

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
