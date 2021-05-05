using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Services
{
    public class ServicesReserva : IServicesReserva
    {
        private readonly AlquilerVehiculoDbContext _context;

        public ServicesReserva(AlquilerVehiculoDbContext context)
        {
            this._context = context;
        }

        public async Task SaveReserva(Reserva reserva)
        {
            _context.Reservas.Add(reserva);
            await _context.SaveChangesAsync();

        }

        public int GetLastIdReserva()
        {
            return _context.Reservas.OrderByDescending(x => x.IdReserva).FirstOrDefault().IdReserva;
        }


        public bool IsVehiculoDisponible(int idvehiculo, DateTime fechaInicio, DateTime fechaFin)
        {
            bool isDisponible = false;

            var allReservasVehiculo = _context.Reservas
                .Where(x => x.IdVehiculo == idvehiculo).ToList();

            var reservas1 = allReservasVehiculo.Where(x => x.FechaInicio >= fechaInicio && x.FechaFin <= fechaFin
            || fechaInicio == x.FechaFin || fechaFin == x.FechaFin || fechaInicio == x.FechaInicio || fechaFin == x.FechaInicio
            || fechaInicio >= x.FechaInicio && fechaInicio <= x.FechaFin
            || fechaFin >= x.FechaInicio && fechaFin <= x.FechaFin).ToList();

            isDisponible = reservas1.Count == 0;
            return isDisponible;
        }

        public async Task<Reserva> GetReservaByIdAsync(int id)
        {
            return await _context.Reservas.Where(x => x.IdCliente == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Reserva>> GetAllReservaAsync()
        {
            return await _context.Reservas.ToListAsync();
        }

        public bool IsVehiculoReservado(int idVehiculo)
        {
            return _context.Reservas.Where(x => x.IdVehiculo == idVehiculo).Count() > 0 ? true : false;
        }
    }
}
