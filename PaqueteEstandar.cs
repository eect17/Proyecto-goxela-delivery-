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
            return distancia * 1.5;
        }
    }
}