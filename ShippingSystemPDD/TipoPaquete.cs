using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystemPDD
{
    public class PaqueteEstandar : TipoPaquete
    {
        // Puedes agregar atributos específicos si los necesitas
        public override void ManejarPaquete()
        {
            // Implementación específica
        }
    }
    public abstract class TipoPaquete
    {
        public int Id { get; set; }
        public string Description { get; set; }  
        public float Peso { get; set; }

        public abstract void ManejarPaquete();
    }
}
