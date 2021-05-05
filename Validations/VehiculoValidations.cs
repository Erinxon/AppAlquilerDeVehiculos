using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.FluentValidation;
using FluentValidation;
using ProyectoFinal.Data;

namespace ProyectoFinal.Validations
{
    public class VehiculoValidations : AbstractValidator<Vehiculo>
    {
        public VehiculoValidations()
        {
            Rules();
        }

        private void Rules()
        {
            RulesForMarca();
            RulesForModelo();
            RulesForAnio();
            RulesForColor();
            RulesForPrecioPorDia();
            RulesForTipoVehiculo();
            RulesForCapacidadCarga();
            RulesForPasajeros();
            RulesForMatricula();
            RulesForNumSeguro();
            RulesForFoto();
            RulesForlatitud();
            RulesForlongitud();
        }

        private void RulesForMarca()
        {
            RuleFor(x => x.Marca)
              .NotEmpty()
              .WithMessage("La marca del vehiculo es requerida")
              .MaximumLength(100)
              .WithMessage("Solo puede escribir un maximo de 100 caracteres");
        }

        private void RulesForModelo()
        {
            RuleFor(x => x.Modelo)
              .NotEmpty()
              .WithMessage("El modelo del vehiculo es requerido")
              .MaximumLength(100)
              .WithMessage("Solo puede escribir un maximo de 100 caracteres");

        }

        private void RulesForAnio()
        {
            RuleFor(x => x.Anio)
              .NotNull()
              .WithMessage("El año del vehiculo es requerido")
              .Custom((anio, context) => {
                  if (anio <0 || anio < 1900 || anio > DateTime.Now.Year)
                  {
                      context.AddFailure("El año no es valido");
                  }
              });
        }

        private void RulesForColor()
        {
            RuleFor(x => x.Color)
              .NotEmpty()
              .WithMessage("El color del vehiculo es requerido")
              .MaximumLength(100)
              .WithMessage("Solo puede escribir un maximo de 100 caracteres");
        }

        private void RulesForPrecioPorDia()
        {
            RuleFor(x => x.PrecioPorDia)
              .NotNull()
              .WithMessage("El precio por dia vehiculo es requerido")
              .Custom((precio, context) => {
                  if (precio <= 0)
                  {
                      context.AddFailure("El precio no es valido");
                  }
              });
        }

        private void RulesForTipoVehiculo()
        {
            RuleFor(x => x.IdTipoVehiculo)
              .NotNull()
              .WithMessage("El tipo de vehiculo es requerido")
              .Custom((tipo, context) => {
                  if (tipo == 0)
                  {
                      context.AddFailure("Por favor seleccione el tipo de vehiculo");
                  }
              });
        }

        private void RulesForCapacidadCarga()
        {
            RuleFor(x => x.CapacidadCarga)
              .NotNull()
              .WithMessage("La capacidad de carga es requerida")
              .Custom((capacidad, context) => {
                  if (capacidad <= 0)
                  {
                      context.AddFailure("La capacidad que ingresó no es valida");
                  }
              });
        }

        private void RulesForPasajeros()
        {
            RuleFor(x => x.Pasajeros)
              .NotNull()
              .WithMessage("El número de pasajeros es requerido")
              .Custom((pasajeros, context) => {
                  if (pasajeros <= 0)
                  {
                      context.AddFailure("El número de pasajeros no es valido");
                  }
              });
        }

        private void RulesForMatricula()
        {
            RuleFor(x => x.Matricula)
              .NotEmpty()
              .WithMessage("La matricula del vehiculo es requerida")
              .MaximumLength(100)
              .WithMessage("Solo puede escribir un maximo de 100 caracteres");
        }

        private void RulesForNumSeguro()
        {
            RuleFor(x => x.NumSeguro)
              .NotEmpty()
              .WithMessage("El número del seguro es requerido")
              .MaximumLength(100)
              .WithMessage("Solo puede escribir un maximo de 100 caracteres");
        }

        private void RulesForFoto()
        {
            RuleFor(x => x.Foto)
              .NotEmpty()
              .WithMessage("La fotografia del vehiculo es requerida");
        }

        private void RulesForlatitud()
        {
            RuleFor(x => x.Latitud)
              .NotEmpty()
              .WithMessage("La latitud es requerida");
        }

        private void RulesForlongitud()
        {
            RuleFor(x => x.Longitud)
              .NotEmpty()
              .WithMessage("La longitud es requerida");
        }


    }
}
