using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Services
{
    public interface IServicesReserva
    {
        Task<IEnumerable<Reserva>> GetAllReservaAsync();
        Task SaveReserva(Reserva reserva);
        bool IsVehiculoDisponible(int idvehiculo, DateTime fechaInicio, DateTime fechaFin);
        bool IsVehiculoReservado(int idVehiculo);
        int GetLastIdReserva();
        Task<Reserva> GetReservaByIdAsync(int id);


    }
}
