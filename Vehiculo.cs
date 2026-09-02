using System;

namespace GoXelaDelivery
{
    public abstract class Vehiculo
    {
        public string Codigo { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double CapacidadMaxima { get; set; }
        public string Estado { get; set; }
        public double CostoOperativo { get; set; }

        public Vehiculo(string codigo, string placa, string marca, string modelo, double capacidadMaxima, double costoOperativo)
        {
            if (capacidadMaxima < 0)
            {
                throw new Exception("La capacidad no puede ser negativa.");
            }

            Codigo = codigo;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            CapacidadMaxima = capacidadMaxima;
            CostoOperativo = costoOperativo;
            Estado = "Disponible";
        }

        public abstract bool PuedeTransportar(Paquete paquete);

        public abstract double CalcularCostoOperativo(double distancia);
    }
}