using FluentValidation;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Validations
{
    public class ClienteValidation : AbstractValidator<Cliente>
    {
        public ClienteValidation()
        {
            Rules();
        }

        private void Rules()
        {
            RuleForNombre();
            RuleForApellido();
            RuleForCorreo();
            RuleForCedula();
            RuleForLicencia();
            RuleForNacionalidad();
            RuleForTipoSangre();
            RuleForFotoLicencia();
        }

        private void RuleForNombre()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es es requerido");
        }

        private void RuleForApellido()
        {
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("El apellido es es requerido");
        }

        private void RuleForCorreo()
        {
            RuleFor(x => x.Correo).NotEmpty().WithMessage("El correo es es requerido")
                .EmailAddress().WithMessage("El correo no es valido");
        }

        private void RuleForCedula()
        {
            RuleFor(x => x.Cedula).NotEmpty().WithMessage("La cedula es es requerida");
        }

        private void RuleForLicencia()
        {
            RuleFor(x => x.Licencia).NotEmpty().WithMessage("La licencia es es requerida");
        }

        private void RuleForNacionalidad()
        {
            RuleFor(x => x.Nacionalidad).NotEmpty().WithMessage("La nacionalidad es es requerida");
        }
        private void RuleForTipoSangre()
        {
            RuleFor(x => x.TipoSangre).NotEmpty().WithMessage("El tipo de sangre es requerido");
        }
        private void RuleForFotoLicencia()
        {
            RuleFor(x => x.FotoLicencia).NotEmpty().WithMessage("La foto de la licencia es requerida");
        }
    }
}
