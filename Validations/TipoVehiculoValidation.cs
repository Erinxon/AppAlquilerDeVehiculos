using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProyectoFinal.Data;
using ProyectoFinal.Services;

namespace ProyectoFinal.Validations
{
    public class TipoVehiculoValidation : AbstractValidator<TipoVehiculo>
    {
        public TipoVehiculoValidation()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("Por favor escriba el tipo de vehiculo");
        }
    }
}
