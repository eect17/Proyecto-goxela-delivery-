using System;

namespace GoXelaDelivery
{
    public class PaqueteFragil : Paquete
    {
        public PaqueteFragil(string codigo, string descripcion, double peso, double valorDeclarado, string origen, string destino)
            : base(codigo, descripcion, peso, valorDeclarado, origen, destino)
        {
        }

        public override double CalcularTarifa(double distancia)
        {
            if (distancia < 0)
            {
                distancia = 0;
            }

            double tarifaBase = (distancia * 5.0) + (Peso * 4.0);
            double seguro = ValorDeclarado * 0.05;

            return tarifaBase + seguro;
        }
    }
}