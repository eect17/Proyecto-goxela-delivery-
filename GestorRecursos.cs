using System;
using System.Collections.Generic;
using System.Linq;

 class GestorRecursos
{
    private List<Cliente> clientes = new List<Cliente>();
    private List<Repartidor> repartidores = new List<Repartidor>();
    private List<Vehiculo> vehiculos = new List<Vehiculo>();
    private List<Paquete> paquetes = new List<Paquete>();

    public bool RegistrarCliente(Cliente cliente)
    {
        if (!ValidarCodigoUnico(cliente.Codigo)) return false;
        clientes.Add(cliente);
        return true;
    }

    public bool RegistrarRepartidor(Repartidor repartidor)
    {
        if (!ValidarCodigoUnico(repartidor.Codigo)) return false;
        repartidores.Add(repartidor);
        return true;
    }

    public bool RegistrarVehiculo(Vehiculo vehiculo)
    {
        if (!ValidarCodigoUnico(vehiculo.Codigo)) return false;
        vehiculos.Add(vehiculo);
        return true;
    }

    public bool RegistrarPaquete(Paquete paquete)
    {
        if (!ValidarCodigoUnico(paquete.Codigo)) return false;
        paquetes.Add(paquete);
        return true;
    }

    public bool ValidarCodigoUnico(string codigo)
    {
        return !clientes.Any(c => c.Codigo == codigo)
            && !repartidores.Any(r => r.Codigo == codigo)
            && !vehiculos.Any(v => v.Codigo == codigo)
            && !paquetes.Any(p => p.Codigo == codigo);
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