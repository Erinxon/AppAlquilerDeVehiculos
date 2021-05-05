using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Model;

namespace ProyectoFinal.Services
{
    public class ServicesVehiculo : IServicesVehiculo
    {
        private readonly AlquilerVehiculoDbContext _context;

        public ServicesVehiculo(AlquilerVehiculoDbContext context) 
        {
            this._context = context;
        }

        public async Task<IEnumerable<Vehiculo>> GetAllVehiculosAsync()
        {
            return await _context.Vehiculos.ToListAsync();
        }

        public async Task<Vehiculo> GetVehiculoByIdAsync(int id)
        {
            return await _context.Vehiculos.FindAsync(id);
        }

        public async Task SaveVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            await _context.SaveChangesAsync();
        }

        public async Task EditVehiculo(Vehiculo vehiculo)
        {
            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task CambiarCampoHabilitado(Vehiculo vehiculo)
        {
            _context.Entry(vehiculo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(vehiculo).State = EntityState.Detached;
        }

        public async Task<IEnumerable<ViewModelVehiculo>> GetAllVehiculos()
        {
            var vehiculos = await (from vehiculo in _context.Vehiculos
                                   join tipo in _context.TipoVehiculos
                                   on vehiculo.IdTipoVehiculo equals tipo.IdTipoVehiculo
                                   select new ViewModelVehiculo
                                   {
                                       IdVehiculo = vehiculo.IdVehiculo,
                                       Marca = vehiculo.Marca,
                                       Modelo = vehiculo.Modelo,
                                       Anio = (int) vehiculo.Anio,
                                       Color = vehiculo.Color,
                                       PrecioPorDia = (decimal) vehiculo.PrecioPorDia,
                                       TipoVehiculo = tipo.Nombre,
                                       CapacidadCarga = (decimal) vehiculo.CapacidadCarga,
                                       Pasajeros = (int) vehiculo.Pasajeros,
                                       Matricula = vehiculo.Matricula,
                                       NumSeguro = vehiculo.NumSeguro,
                                       Foto = vehiculo.Foto,
                                       Latitud = vehiculo.Latitud,
                                       Longitud = vehiculo.Longitud,
                                       Ishabilitado = (int) vehiculo.Ishabilitado,
                                       IdTipoVehiculo = (int) vehiculo.IdTipoVehiculo                                   
                                   }).ToListAsync();
            return vehiculos;
        }

        public decimal getPrecioPordia(int id)
        {
            return (decimal) _context.Vehiculos.Where(x => x.IdVehiculo == id)
                .FirstOrDefault()
                .PrecioPorDia;
        }

        public bool IsMatriculaExist(string matricula)
        {
            Vehiculo vehiculo = _context.Vehiculos.Where(x => x.Matricula == matricula).FirstOrDefault();
            return vehiculo != null;
        }

        public bool IsNumSuguroExist(string seguro)
        {
            Vehiculo vehiculo = _context.Vehiculos.Where(x => x.NumSeguro == seguro).FirstOrDefault();
            return vehiculo != null;
        }

        public async Task<IEnumerable<ViewModelVehiculo>> GetfilterVehiculosAsync(string search)
        {
            var vehiculos = await (from vehiculo in _context.Vehiculos
                                   join tipo in _context.TipoVehiculos
                                   on vehiculo.IdTipoVehiculo equals tipo.IdTipoVehiculo
                                   where vehiculo.Marca.Contains(search) ||
                                   vehiculo.Modelo.Contains(search)
                                   || (vehiculo.Marca + " " + vehiculo.Modelo).Contains(search)
                                   select new ViewModelVehiculo
                                   {
                                       IdVehiculo = vehiculo.IdVehiculo,
                                       Marca = vehiculo.Marca,
                                       Modelo = vehiculo.Modelo,
                                       Anio = (int)vehiculo.Anio,
                                       Color = vehiculo.Color,
                                       PrecioPorDia = (decimal)vehiculo.PrecioPorDia,
                                       TipoVehiculo = tipo.Nombre,
                                       CapacidadCarga = (decimal)vehiculo.CapacidadCarga,
                                       Pasajeros = (int)vehiculo.Pasajeros,
                                       Matricula = vehiculo.Matricula,
                                       NumSeguro = vehiculo.NumSeguro,
                                       Foto = vehiculo.Foto,
                                       Latitud = vehiculo.Latitud,
                                       Longitud = vehiculo.Longitud,
                                       Ishabilitado = (int)vehiculo.Ishabilitado,
                                       IdTipoVehiculo = (int)vehiculo.IdTipoVehiculo
                                   }).ToListAsync();
            return vehiculos;
        }
    }
}
