using System;
using System.Collections.Generic;
using System.Linq;

namespace GoXelaDelivery
{
    public struct ResumenEntregas
    {
        public int CantidadActivas;
        public int CantidadFinalizadas;
        public int CantidadCanceladas;
        public double TotalIngresos;
    }

    public class GestorEntregas
    {
        private List<Entrega> entregas = new List<Entrega>();

        public bool CrearEntrega(Entrega nuevaEntrega)
        {
            bool yaExiste = entregas.Any(e => e.Codigo == nuevaEntrega.Codigo);
            if (yaExiste)
            {
                Console.WriteLine("Error: ya existe una entrega con ese código.");
                return false;
            }

            bool paqueteOcupado = entregas.Any(e => e.Paquete.Codigo == nuevaEntrega.Paquete.Codigo && e.Estado != "Entregada" && e.Estado != "Cancelada");
            if (paqueteOcupado)
            {
                Console.WriteLine("Error: ese paquete ya está asignado a otra entrega activa.");
                return false;
            }

            entregas.Add(nuevaEntrega);
            return true;
        }

        public bool AsignarRecursos(Entrega entrega, Repartidor repartidor, Vehiculo vehiculo)
        {
            if (repartidor.EstadoEntrega != "Disponible")
            {
                Console.WriteLine("Error: el repartidor no está disponible.");
                return false;
            }

            if (vehiculo.Estado != "Disponible")
            {
                Console.WriteLine("Error: el vehículo no está disponible.");
                return false;
            }

            if (!vehiculo.PuedeTransportar(entrega.Paquete))
            {
                Console.WriteLine("Error: este vehículo no puede transportar ese paquete (peso o tipo incompatible).");
                return false;
            }

            entrega.AsignarRecursos(repartidor, vehiculo);
            repartidor.EstadoEntrega = "Asignado";
            vehiculo.Estado = "Asignado";
            return true;
        }

        public bool CambiarEstadoEntrega(Entrega entrega, string nuevoEstado)
        {
            string[] ordenValido = { "Solicitada", "Asignada", "Recogida", "En ruta", "Entregada" };

            int posicionActual = Array.IndexOf(ordenValido, entrega.Estado);
            int posicionNueva = Array.IndexOf(ordenValido, nuevoEstado);

            if (nuevoEstado == "Cancelada" || nuevoEstado == "Reprogramada" || nuevoEstado == "Con incidencia")
            {
                if (entrega.Estado == "Entregada" || entrega.Estado == "Cancelada")
                {
                    Console.WriteLine("Error: no se puede modificar una entrega ya finalizada o cancelada.");
                    return false;
                }
                entrega.CambiarEstado(nuevoEstado);
                return true;
            }

            if (posicionNueva != posicionActual + 1)
            {
                Console.WriteLine("Error: no se puede saltar de '" + entrega.Estado + "' a '" + nuevoEstado + "' directamente.");
                return false;
            }

            entrega.CambiarEstado(nuevoEstado);
            return true;
        }

        public ResumenEntregas GenerarResumen()
        {
            ResumenEntregas resumen = new ResumenEntregas();

            resumen.CantidadActivas = entregas.Count(e => e.Estado != "Entregada" && e.Estado != "Cancelada");
            resumen.CantidadFinalizadas = entregas.Count(e => e.Estado == "Entregada");
            resumen.CantidadCanceladas = entregas.Count(e => e.Estado == "Cancelada");
            resumen.TotalIngresos = entregas.Where(e => e.Estado == "Entregada").Sum(e => e.Total);

            return resumen;
        }

        public List<Entrega> ObtenerTodas()
        {
            return entregas;
        }
        public Entrega BuscarEntrega(string codigo)
        {
            return entregas.Find(e => e.Codigo == codigo);
        }
    }
}