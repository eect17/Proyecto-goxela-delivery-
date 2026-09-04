using System;

namespace GoXelaDelivery
{
    public class Motocicleta : Vehiculo
    {
        public Motocicleta(string codigo, string placa, string marca, string modelo, double capacidadMaxima, double costoOperativo)
            : base(codigo, placa, marca, modelo, capacidadMaxima, costoOperativo)
        {
        }

        public override bool PuedeTransportar(Paquete paquete)
        {
            if (paquete == null) return false;

            return paquete.Peso <= CapacidadMaxima;
        }
    }
}