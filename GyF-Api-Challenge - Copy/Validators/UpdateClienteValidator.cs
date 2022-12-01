using FluentValidation;
using GyF_Api_Challenge.Core.Models;
using GyF_Api_Challenge.Models;

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
        }
    }
}
