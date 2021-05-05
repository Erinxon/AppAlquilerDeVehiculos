using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinal.Data
{
    public partial class Factura
    {
        public int IdFactura { get; set; }
        public int? IdReserva { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal? Monto { get; set; }
        public decimal? TotalPagado { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Reserva IdReservaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
