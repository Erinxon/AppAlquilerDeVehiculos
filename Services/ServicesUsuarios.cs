using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;

namespace ProyectoFinal.Services
{
    public class ServicesUsuarios : IServicesUsuarios
    {
        private readonly AlquilerVehiculoDbContext _context;

        public ServicesUsuarios(AlquilerVehiculoDbContext context)
        {
            this._context = context;
        }

        public async Task<Usuario> GetUsuarioById(int id)
        {
            return await _context.Usuarios.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task SaveUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task EditUsuario(Usuario usuario)
        {
            _context.Attach(usuario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool IsExist(string usuario)
        {
            return _context.Usuarios.Any(x => x.NombreUsuario == usuario);
        }

        public Usuario GetUsuarioByNombreUsuario(string usuario)
        {
            return _context.Usuarios.Where(x => x.NombreUsuario == usuario).FirstOrDefault();
        }

        public int GetIdUsuarioByUsuario(string usuario)
        {
            return _context.Usuarios.Where(x => x.NombreUsuario == usuario).FirstOrDefault().Id;
        }

        public async Task<IEnumerable<Usuario>> GetFilterUsuariosAsync(string search)
        {
            return await _context.Usuarios.Where(x=>x.NombreUsuario.Contains(search)
                         || x.Nombre.Contains(search) || x.Apellido.Contains(search)
                         || (x.Nombre + " " + x.Apellido).Contains(search))
                         .ToListAsync();
        }

        public bool IsExistCorreo(string correo)
        {
            return _context.Usuarios.Any(x => x.Correo == correo);
        }
    }
}
