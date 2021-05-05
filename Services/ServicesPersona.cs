using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Model;

namespace ProyectoFinal.Services
{
    public class ServicesPersona : IServicesPersona
    {
        private readonly AlquilerVehiculoDbContext _context;

        public ServicesPersona(AlquilerVehiculoDbContext context)
        {
            this._context = context;
        }


        public async Task CambiarCampoHabilitado(Cliente cl)
        {
            _context.Entry(cl).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(cl).State = EntityState.Detached;
        }

        public async Task EditCliente(Cliente cli)
        {
            _context.Entry(cli).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cliente>> GetAllClienteAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _context.Clientes.Where(x => x.IdCliente==id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cliente>> GetFilterClienteAsync(string search)
        {
            return await _context.Clientes.Where(x=>x.Nombre.Contains(search) || x.Apellido.Contains(search)
                || x.Cedula.Contains(search) || (x.Nombre + " " + x.Apellido).Contains(search))
                .ToListAsync();
        }

        public bool IsExistCorreo(string correo)
        {
            return _context.Clientes.Any(x => x.Correo == correo);
        }

        public bool IsExistLicencia(string licencia)
        {
            return _context.Clientes.Any(x => x.Licencia == licencia);
        }

        public async Task SavePersona(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
