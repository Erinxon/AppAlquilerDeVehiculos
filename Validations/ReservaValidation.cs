using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ProyectoFinal.Data;
using ProyectoFinal.Services;

namespace ProyectoFinal.Validations
{
    public class ReservaValidation : AbstractValidator<Reserva>
    {
        public ReservaValidation()
        {
            Rules();
        }

        private void Rules()
        {
            RulesForVehiculo();
            RulesForCliente();
            RulesForFechaInicio();
            RulesForFechaFin();
        }

        private void RulesForVehiculo()
        {
            RuleFor(x => x.IdVehiculo)
                .NotNull().WithMessage("El vehículo es requerido")
                .Custom((id, context) => {
                    if (id == 0)
                    {
                        context.AddFailure("Por favor seleccione el vehículo");
                    }
                });

        }

        private void RulesForCliente()
        {
            RuleFor(x => x.IdCliente)
                .NotNull().WithMessage("El cliente es requerido")
                .Custom((id, context) => {
                    if (id == 0)
                    {
                        context.AddFailure("Por favor seleccione el cliente");
                    }
                });
        }

        private void RulesForFechaInicio()
        {
            RuleFor(x => x.FechaInicio)
               .NotNull().WithMessage("La fecha de inicio es requerida");
        }

        private void RulesForFechaFin()
        {
            RuleFor(x => x.FechaFin)
                .NotNull().WithMessage("La fecha final es requerida");
        }  
    }
}
