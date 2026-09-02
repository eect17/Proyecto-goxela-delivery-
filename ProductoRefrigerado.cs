using System;

namespace GoXelaDelivery
{
    public class ProductoRefrigerado : Paquete
    {
        public ProductoRefrigerado(string codigo, string descripcion, double peso, double valorDeclarado, string origen, string destino)
            : base(codigo, descripcion, peso, valorDeclarado, origen, destino)
        {
        }

        public override double CalcularTarifa(double distancia)
        {
            if (distancia < 0)
            {
                distancia = 0;
            }

            return (distancia * 6.0) + (Peso * 4.5) + 20.0;
        }
    }
}