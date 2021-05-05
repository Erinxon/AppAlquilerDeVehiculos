using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoFinal.Data
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdTipoVehiculo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
