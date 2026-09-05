using System;

namespace GoXelaDelivery
{
    public class Entrega
    {
        public string Codigo { get; set; }
        public Cliente Cliente { get; set; }
        public Paquete Paquete { get; set; }
        public Repartidor Repartidor { get; set; }
        public Vehiculo Vehiculo { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string DireccionOrigen { get; set; }
        public string DireccionDestino { get; set; }
        public double DistanciaEstimada { get; set; }
        public string TipoServicio { get; set; }
        public string Estado { get; set; }
        public double TarifaBase { get; set; }
        public double Recargos { get; set; }
        public double Descuentos { get; set; }
        public double Total { get; set; }

        public Entrega(string codigo, Cliente cliente, Paquete paquete, string direccionOrigen, string direccionDestino, double distanciaEstimada, string tipoServicio)
        {
            if (distanciaEstimada < 0)
            {
                throw new Exception("La distancia no puede ser negativa.");
            }

            Codigo = codigo;
            Cliente = cliente;
            Paquete = paquete;
            DireccionOrigen = direccionOrigen;
            DireccionDestino = direccionDestino;
            DistanciaEstimada = distanciaEstimada;
            TipoServicio = tipoServicio;
            FechaSolicitud = DateTime.Now;
            Estado = "Solicitada";
        }
        public Entrega(string codigo, Cliente cliente, Paquete paquete, string direccionOrigen, string direccionDestino, double distanciaEstimada)
    : this(codigo, cliente, paquete, direccionOrigen, direccionDestino, distanciaEstimada, "Normal")
        {
        }
        public void AsignarRecursos(Repartidor repartidor, Vehiculo vehiculo)
        {
            Repartidor = repartidor;
            Vehiculo = vehiculo;
            Estado = "Asignada";
        }

        public void CambiarEstado(string nuevoEstado)
        {
            Estado = nuevoEstado;
        }
    }
}