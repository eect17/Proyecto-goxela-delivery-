using System;

namespace GoXelaDelivery
{
    public abstract class Vehiculo
    {
        private string codigo;
        private string placa;
        private string marca;
        private string modelo;
        private double capacidadMaxima;
        private double costoOperativo;
        private string estado;

        public string Codigo
        {
            get { return codigo; }
            private set
            {
                if (value != null && value != "")
                    codigo = value;
                else
                    codigo = "V000";
            }
        }

        public string Placa
        {
            get { return placa; }
            private set
            {
                if (value != null && value != "")
                    placa = value;
                else
                    placa = "N/A";
            }
        }

        public string Marca
        {
            get { return marca; }
            private set
            {
                if (value != null && value != "")
                    marca = value;
                else
                    marca = "Genérica";
            }
        }

        public string Modelo
        {
            get { return modelo; }
            private set
            {
                if (value != null && value != "")
                    modelo = value;
                else
                    modelo = "N/A";
            }
        }

        public double CapacidadMaxima
        {
            get { return capacidadMaxima; }
            private set
            {
                if (value > 0)
                    capacidadMaxima = value;
                else
                    capacidadMaxima = 1.0;
            }
        }

        public double CostoOperativo
        {
            get { return costoOperativo; }
            private set
            {
                if (value >= 0)
                    costoOperativo = value;
                else
                    costoOperativo = 0.0;
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value != null && value != "")
                    estado = value;
                else
                    estado = "Disponible";
            }
        }

        public Vehiculo(string codigo, string placa, string marca, string modelo, double capacidadMaxima, double costoOperativo)
        {
            Codigo = codigo;
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            CapacidadMaxima = capacidadMaxima;
            CostoOperativo = costoOperativo;
            Estado = "Disponible";
        }

        public abstract bool PuedeTransportar(Paquete paquete);

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Vehículo: {Codigo} | Tipo: {GetType().Name} | Placa: {Placa} | Marca: {Marca} | Capacidad: {CapacidadMaxima}kg | Costo/km: Q{CostoOperativo}");
        }
    }
}