using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinal.Model;

namespace ProyectoFinal.Services
{
    public interface IServicesVehiculo
    {
        Task<IEnumerable<Vehiculo>> GetAllVehiculosAsync();
        Task<IEnumerable<ViewModelVehiculo>> GetAllVehiculos();
        Task<Vehiculo> GetVehiculoByIdAsync(int id);
        Task SaveVehiculo(Vehiculo vehiculo);
        Task EditVehiculo(Vehiculo vehiculo);
        Task CambiarCampoHabilitado(Vehiculo vehiculo);
        decimal getPrecioPordia(int id);
        bool IsMatriculaExist(string matricula);
        bool IsNumSuguroExist(string seguro);
        Task<IEnumerable<ViewModelVehiculo>> GetfilterVehiculosAsync(string search);
    }
}
