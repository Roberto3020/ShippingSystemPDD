using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingSystemPDD
{
    public class Paquete
    {
        public int Id { get; set; } // Llave primaria
        public int TipoDePaqueteId { get; set; }
        public PaqueteEstandar TipoDePaquete { get; set; } // Relación con TipoDePaquete

        public int RemitenteId { get; set; }
        public Remitente Remitente { get; set; } // Relación con Remitente

        public int DestinarioId { get; set; }
        public Destinario Destinario { get; set; } // Relación con Destinario
    }
}
