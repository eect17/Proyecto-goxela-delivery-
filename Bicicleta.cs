using System;

namespace GoXelaDelivery
{
    public class Bicicleta : Vehiculo
    {
        public Bicicleta(string codigo, string marca, string modelo, double capacidadMaxima, double costoOperativo)
            : base(codigo, "N/A", marca, modelo, capacidadMaxima, costoOperativo)
        {
        }

        public override bool PuedeTransportar(Paquete paquete)
        {
            if (paquete == null) return false;

            if (paquete is ProductoRefrigerado)
            {
                return false;
            }

            return paquete.Peso <= CapacidadMaxima;
        }
    }
}