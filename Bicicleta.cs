namespace GoXelaDelivery
{
    public class Bicicleta : Vehiculo
    {
        public Bicicleta(string codigo, string marca, string modelo, double costoOperativo)
            : base(codigo, "", marca, modelo, 10, costoOperativo)
        {
        }

        public override bool PuedeTransportar(Paquete paquete)
        {
            if (paquete.Peso > CapacidadMaxima)
            {
                return false;
            }
            return true;
        }

        public override double CalcularCostoOperativo(double distancia)
        {
            return distancia * CostoOperativo;
        }
    }
}