using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Services
{
    public class ServicesFactura : IServicesFactura
    {
        private readonly AlquilerVehiculoDbContext _context;

        public ServicesFactura(AlquilerVehiculoDbContext context)
        {
            this._context = context;
        }

        public async Task EditFactura(Factura factura)
        {
            _context.Entry(factura).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        public async Task<Factura> GetFacturaById(int id)
        {
            return await _context.Facturas.Where(x => x.IdFactura == id).FirstOrDefaultAsync();
        }


        public async Task SaveFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();
        }
    }
}
