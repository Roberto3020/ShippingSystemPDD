namespace ShippingSystemPDD
{
    public class Caja : Service
    {
        public int Id { get; set; } // Clave primaria
        public override double CalculaCosto()
        {
            return base.CalculaCosto() + (Weigth * 5000) + 25000;
        }
    }
}
