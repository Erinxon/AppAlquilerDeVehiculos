using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProyectoFinal.Data;
using ProyectoFinal.Model;

namespace ProyectoFinal.Validations
{
    public class UsuarioValidation : AbstractValidator<UsuarioViewModel>
    {
        public UsuarioValidation()
        {
            RuleFor(x => x.NombreUsuario)
                .NotEmpty().WithMessage("El nombre de usuario es requerido");
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es requerido");
            RuleFor(x => x.Correo)
                .NotEmpty().WithMessage("El correo es requerido")
                .EmailAddress().WithMessage("El correo no es valido");
            RuleFor(x => x.Apellido)
                .NotEmpty().WithMessage("El apellido es requerido");
            RuleFor(x => x.Pass)
                .NotEmpty().WithMessage("La contraseña es requerida");
            RuleFor(x => x.ConfirmPass)
                .NotEmpty().WithMessage("El campo Confirmar contraseña es requeridp")
                .Must((fooArgs, p) =>
                    fooArgs.Pass == fooArgs.ConfirmPass)
                    .WithMessage("Las contraseñas deben ser iguales");

        }
    }
}
