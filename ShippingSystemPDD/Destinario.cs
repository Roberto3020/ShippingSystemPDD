using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystemPDD
{
    public class Destinario
    {
        public int Id { get; set; } // Llave primaria
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }
    }
}
