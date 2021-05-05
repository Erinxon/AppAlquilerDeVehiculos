using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Services
{
    public interface IServicesTipoVehiculo
    {
        Task<IEnumerable<TipoVehiculo>> GetAllTipoVehiculosAsync();
        Task<TipoVehiculo> GetVehiculo(int id);
        string GetTipoVehiculoById(int id);
        Task SaveTipoVehiculo(TipoVehiculo tipoVehiculo);
        Task EditTipoVehiculo(TipoVehiculo tipoVehiculo);
        bool IsExist(string typevehiculo);
        Task<IEnumerable<TipoVehiculo>> GetFilterTipoVehiculosAsync(string search);
    }
}
