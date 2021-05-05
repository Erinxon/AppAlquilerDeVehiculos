using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinal.Data
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdCliente { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Licencia { get; set; }
        public string Nacionalidad { get; set; }
        public string TipoSangre { get; set; }
        public string FotoPersona { get; set; }
        public string FotoLicencia { get; set; }
        public int? Ishabilitado { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
