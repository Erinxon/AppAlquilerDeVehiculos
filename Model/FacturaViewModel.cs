using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Model
{
    public class FacturaViewModel
    {
        public int IdFactura { get; set; }
        public decimal Monto { get; set; }
        public decimal TotalPagado { get; set; }
        public DateTime? Fecha { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public int Pasajeros { get; set; }
        public string Matricula { get; set; }
        public string NumSeguro { get; set; }
        public string NombreCliente { get; set; }
        public decimal PrecioPorDia { get; set; }
    }
}
