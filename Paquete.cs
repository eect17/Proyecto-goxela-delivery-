using System;

namespace GoXelaDelivery
{
    public abstract class Paquete
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public double Peso { get; set; }
        public double ValorDeclarado { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public string Estado { get; set; }

        public Paquete(string codigo, string descripcion, double peso, double valorDeclarado, string origen, string destino)
        {
            if (peso < 0)
            {
                throw new Exception("El peso no puede ser negativo.");
            }

            Codigo = codigo;
            Descripcion = descripcion;
            Peso = peso;
            ValorDeclarado = valorDeclarado;
            DireccionOrigen = origen;
            DireccionDestino = destino;
            Estado = "Registrado";
        }

        public abstract double CalcularTarifa(double distancia);
    }
}