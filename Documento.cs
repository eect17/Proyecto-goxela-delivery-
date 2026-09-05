using System;

namespace GoXelaDelivery
{
    public class Documento : Paquete
    {
        public Documento(string codigo, string descripcion, double peso, double valorDeclarado, string origen, string destino)
            : base(codigo, descripcion, peso, valorDeclarado, origen, destino)
        {
        }

        public override double CalcularTarifa(double distancia)
        {
            if (distancia < 0)
            {
                distancia = 0;
            }

            return 15.0 + (distancia * 2.0);
        }
    }
}