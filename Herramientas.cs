using System;

namespace GoXelaDelivery
{
    public class Herramientas
    {
        public static unsafe void AplicarRecargoPorPuntero(double* valorTarifa, double porcentajeRecargo)
        {
            *valorTarifa = *valorTarifa + (*valorTarifa * (porcentajeRecargo / 100.0));
        }
    }
}