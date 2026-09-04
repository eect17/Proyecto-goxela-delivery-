using System;
using System.Collections.Generic;
using System.Linq;

public class GestorRecursos
{
    private List<cliente> clientes = new List<cliente>();
    private List<repartidor> repartidores = new List<repartidor>();
    private List<vehiculo> vehiculos = new List<vehiculo>();
    private List<paquete> paquetes = new List<paquete>();

    public bool RegistrarCliente(cliente cliente)
    {
        if (!ValidarCodigoUnico(cliente.Codigo))
        {
            Console.WriteLine("Error: ya existe un cliente con ese código.");
            return false;
        }
        clientes.Add(cliente);
        return true;
    }

    public bool RegistrarRepartidor(repartidor repartidor)
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
        return repartidores.FirstOrDefault(r => r.EstadoDisponibilidad == EstadoRepartidor.Disponible);
    }

    public Vehiculo BuscarVehiculoCompatible(Paquete paquete)
    {
        return vehiculos.FirstOrDefault(v => v.Estado == EstadoVehiculo.Disponible && v.PuedeTransportar(paquete));
    }
}