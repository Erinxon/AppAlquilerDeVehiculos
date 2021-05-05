using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Services
{
    public interface IServicesUsuarios
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task SaveUsuario(Usuario usuario);
        Task EditUsuario(Usuario usuario);
        Task<Usuario> GetUsuarioById(int id);
        Usuario GetUsuarioByNombreUsuario(string usuario);
        bool IsExist(string usuario);
        bool IsExistCorreo(string correo);
        int GetIdUsuarioByUsuario(string usuario);
        Task<IEnumerable<Usuario>> GetFilterUsuariosAsync(string search);
    }
}
