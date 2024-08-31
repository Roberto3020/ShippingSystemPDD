using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystemPDD
{
    public class Direccion
    {
        public int Id { get; set; } // Llave primaria
        public string Calle { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }
        public string Barrio { get; set; }
        public string Complemento { get; set; }
    }
}
