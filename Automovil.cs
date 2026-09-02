namespace GoXelaDelivery
{
    public class Automovil : Vehiculo
    {
        public Automovil(string codigo, string placa, string marca, string modelo, double costoOperativo)
            : base(codigo, placa, marca, modelo, 150, costoOperativo)
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