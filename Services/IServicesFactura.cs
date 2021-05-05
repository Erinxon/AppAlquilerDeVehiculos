using ProyectoFinal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Services
{
    public interface IServicesFactura
    {
        Task SaveFactura(Factura factura);
        Task<Factura> GetFacturaById(int id);
        Task EditFactura(Factura factura);
    }
}
