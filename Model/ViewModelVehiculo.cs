using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal.Model
{
    public class ViewModelVehiculo
    {
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public string Color { get; set; }
        public decimal PrecioPorDia { get; set; }
        public string TipoVehiculo { get; set; }
        public decimal CapacidadCarga { get; set; }
        public int Pasajeros { get; set; }
        public string Matricula { get; set; }
        public string NumSeguro { get; set; }
        public string Foto { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public int Ishabilitado { get; set; }
        public int IdTipoVehiculo { get; set; }
    }
}
