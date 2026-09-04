using System;

namespace GoXelaDelivery
{
    public class PaqueteEstandar : Paquete
    {
        public PaqueteEstandar(string codigo, string descripcion, double peso, double valorDeclarado, string origen, string destino)
            : base(codigo, descripcion, peso, valorDeclarado, origen, destino)
        {
        }

        public override double CalcularTarifa(double distancia)
        {
            if (distancia < 0)
            {
                distancia = 0;
            }

            return (distancia * 4.0) + (Peso * 3.0);
        }
    }
}