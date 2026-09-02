using System;

namespace GoXelaDelivery
{
    public class Paquete
    {
        // Atributos privados simples
        private string codigo;
        private string descripcion;
        private double peso;
        private double valorDeclarado;
        private string direccionOrigen;
        private string direccionDestino;
        private string estado;

        // Propiedades públicas con validaciones directas dentro del set usando 'if'
        public string Codigo
        {
            get { return codigo; }
            private set
            {
                if (value != null && value != "")
                {
                    codigo = value;
                }
                else
                {
                    codigo = "P000";
                }
            }
        }

        public string Descripcion
        {
            get { return descripcion; }
            private set
            {
                if (value != null && value != "")
                {
                    descripcion = value;
                }
                else
                {
                    descripcion = "Sin descripcion";
                }
            }
        }

        public double Peso
        {
            get { return peso; }
            private set
            {
                if (value > 0)
                {
                    peso = value;
                }
                else
                {
                    peso = 0.1;
                }
            }
        }

        public double ValorDeclarado
        {
            get { return valorDeclarado; }
            private set
            {
                if (value >= 0)
                {
                    valorDeclarado = value;
                }
                else
                {
                    valorDeclarado = 0;
                }
            }
        }

        public string DireccionOrigen
        {
            get { return direccionOrigen; }
            private set
            {
                if (value != null && value != "")
                {
                    direccionOrigen = value;
                }
                else
                {
                    direccionOrigen = "No especificada";
                }
            }
        }

        public string DireccionDestino
        {
            get { return direccionDestino; }
            private set
            {
                if (value != null && value != "")
                {
                    direccionDestino = value;
                }
                else
                {
                    direccionDestino = "No especificada";
                }
            }
        }

        public string Estado
        {
            get { return estado; }
            set
            {
                if (value != null && value != "")
                {
                    estado = value;
                }
                else
                {
                    estado = "Registrado";
                }
            }
        }

        // Constructor 1: Completo
        public Paquete(string codigo, string descripcion, double peso, double valorDeclarado, string origen, string destino)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Peso = peso;
            ValorDeclarado = valorDeclarado;
            DireccionOrigen = origen;
            DireccionDestino = destino;
            Estado = "Registrado";
        }

        // Constructor 2: Sobrecarga (simplificado)
        public Paquete(string codigo, string descripcion, double peso)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Peso = peso;
            ValorDeclarado = 0;
            DireccionOrigen = "No especificada";
            DireccionDestino = "No especificada";
            Estado = "Registrado";
        }

        // Método virtual para calcular la tarifa base
        public virtual double CalcularTarifa(double distancia)
        {
            if (distancia < 0)
            {
                distancia = 0;
            }

            return (distancia * 5.0) + (peso * 2.0);
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Paquete: {codigo} | {descripcion} | Peso: {peso}kg | Valor: Q{valorDeclarado} | Estado: {estado}");
        }
    }
}