using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinal.Data
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int? Anio { get; set; }
        public string Color { get; set; }
        public decimal? PrecioPorDia { get; set; }
        public int? IdTipoVehiculo { get; set; }
        public decimal? CapacidadCarga { get; set; }
        public int? Pasajeros { get; set; }
        public string Matricula { get; set; }
        public string NumSeguro { get; set; }
        public string Foto { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int? Ishabilitado { get; set; }

        public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
