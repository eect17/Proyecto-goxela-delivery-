namespace GoXelaDelivery
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta(string codigo, string placa, string marca, string modelo, double costoOperativo)
            : base(codigo, placa, marca, modelo, 30, costoOperativo)
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