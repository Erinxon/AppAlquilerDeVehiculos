using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoFinal.Model;
using ProyectoFinal.Data;


namespace ProyectoFinal.Services
{
    public interface IServicesPersona
    {
        Task<IEnumerable<Cliente>> GetAllClienteAsync();
        Task<IEnumerable<Cliente>> GetFilterClienteAsync(string search);
        Task<Cliente> GetClienteByIdAsync(int id);
        Task SavePersona(Cliente vehiculo);
        Task EditCliente(Cliente cli);
        Task CambiarCampoHabilitado(Cliente cl);
        bool IsExistLicencia(string licencia);
        bool IsExistCorreo(string correo);

    }
}
