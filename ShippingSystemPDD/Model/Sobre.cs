namespace ShippingSystemPDD
{
    public class Sobre : Service

    {
        public int Id { get; set; } // Clave primaria
        public override double CalculaCosto()
        {
            return base.CalculaCosto() + 10000;
        }
    }
}
