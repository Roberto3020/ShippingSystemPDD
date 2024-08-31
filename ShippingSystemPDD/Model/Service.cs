namespace ShippingSystemPDD
{
    public abstract class Service
    {
        public int IdService { get; set; }
        public string Reciver { get; set; }
        public string Addres { get; set; }
        public double Weigth { get; set; }
        public double Value { get; set; }
        public bool IsInternational { get; set; }
        public string Status { get; set; }
        public double Costo { get; set; }


        public virtual double CalculaCosto()
        {
            double baseValue = 5000;

            if (IsInternational)
            {
                return baseValue * 1.12;
            }
            return baseValue;
        }

    }
}
