using System;
using System.Collections.Generic;
using System.Linq;

namespace GoXelaDelivery
{
    public class GestorRecursos
    {
        private List<Cliente> clientes = new List<Cliente>();
        private List<Repartidor> repartidores = new List<Repartidor>();
        private List<Vehiculo> vehiculos = new List<Vehiculo>();
        private List<Paquete> paquetes = new List<Paquete>();

        public bool RegistrarCliente(Cliente cliente)
        {
            if (!ValidarCodigoUnico(cliente.Codigo))
            {
                Console.WriteLine("Error: ya existe un cliente con ese código.");
                return false;
            }
            clientes.Add(cliente);
            return true;
        }

        public bool RegistrarRepartidor(Repartidor repartidor)
        {
            if (!ValidarCodigoUnico(repartidor.Codigo))
            {
                Console.WriteLine("Error: ya existe un repartidor con ese código.");
                return false;
            }
            repartidores.Add(repartidor);
            return true;
        }

        public bool RegistrarVehiculo(Vehiculo vehiculo)
        {
            if (!ValidarCodigoUnico(vehiculo.Codigo))
            {
                Console.WriteLine("Error: ya existe un vehículo con ese código.");
                return false;
            }
            vehiculos.Add(vehiculo);
            return true;
        }

        public bool RegistrarPaquete(Paquete paquete)
        {
            if (!ValidarCodigoUnico(paquete.Codigo))
            {
                Console.WriteLine("Error: ya existe un paquete con ese código.");
                return false;
            }
            paquetes.Add(paquete);
            return true;
        }

        public bool ValidarCodigoUnico(string codigo)
        {
            bool existeEnClientes = clientes.Any(c => c.Codigo == codigo);
            bool existeEnRepartidores = repartidores.Any(r => r.Codigo == codigo);
            bool existeEnVehiculos = vehiculos.Any(v => v.Codigo == codigo);
            bool existeEnPaquetes = paquetes.Any(p => p.Codigo == codigo);

            return !(existeEnClientes || existeEnRepartidores || existeEnVehiculos || existeEnPaquetes);
        }

        public Repartidor BuscarRepartidorDisponible()
        {
            return repartidores.FirstOrDefault(r => r.EstadoEntrega == "Disponible");
        }

        public Vehiculo BuscarVehiculoCompatible(Paquete paquete)
        {
            return vehiculos.FirstOrDefault(v => v.Estado == "Disponible" && v.PuedeTransportar(paquete));
        }
    }
}