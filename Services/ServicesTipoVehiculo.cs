using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProyectoFinal.Services
{
    public class ServicesTipoVehiculo : IServicesTipoVehiculo
    {
        private readonly AlquilerVehiculoDbContext _context;

        public ServicesTipoVehiculo(AlquilerVehiculoDbContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TipoVehiculo>> GetAllTipoVehiculosAsync()
        {
            return await _context.TipoVehiculos.ToListAsync();
        }

        public string GetTipoVehiculoById(int id)
        {
            return _context.TipoVehiculos.Where(x => x.IdTipoVehiculo == id).FirstOrDefault().Nombre;
        }

        public async Task SaveTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            _context.TipoVehiculos.Add(tipoVehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task EditTipoVehiculo(TipoVehiculo tipoVehiculo)
        {
            _context.Entry(tipoVehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool IsExist(string tipoVehiculo)
        {
            return _context.TipoVehiculos.Any(x => x.Nombre == tipoVehiculo);
        }

        public Task<TipoVehiculo> GetVehiculo(int id)
        {
            return _context.TipoVehiculos.Where(x => x.IdTipoVehiculo == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TipoVehiculo>> GetFilterTipoVehiculosAsync(string search)
        {
            return await _context.TipoVehiculos.Where(x=>x.Nombre.Contains(search))
                .ToListAsync();
        }
    }
}
