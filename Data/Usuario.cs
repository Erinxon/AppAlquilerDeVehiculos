using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ProyectoFinal.Data
{
    public partial class Usuario
    {
        public Usuario()
        {
            Facturas = new HashSet<Factura>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre de usuaruo no puede estar vacio")]
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [Required(ErrorMessage = "La contraseña no puede estar vacia")]
        public string Pass { get; set; }

        public virtual ICollection<Factura> Facturas { get; set; }
    }
}
