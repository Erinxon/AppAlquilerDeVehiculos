using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinal.Data
{
    public partial class Reserva
    {
        public Reserva()
        {
            Facturas = new HashSet<Factura>();
        }

        public int IdReserva { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int? IdVehiculo { get; set; }
        public int? IdCliente { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
