using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Probando Cliente ===");
        cliente miCliente = new cliente();
        miCliente.AcctualizarInfo("Juan Perez", "C001", "8091234567", "Calle 5", "juan@mail.com");
        miCliente.MostrarInformacion();

        Console.WriteLine();
        Console.WriteLine("=== Probando Repartidor ===");
        repartidor miRepartidor = new repartidor();
        miRepartidor.Nombre = "Pedro Gomez";
        miRepartidor.Codigo = "R001";
        miRepartidor.Telefono = "8097654321";
        miRepartidor.Licencia = "LIC123";
        miRepartidor.MostrarInformacion();

        Console.WriteLine();
        Console.WriteLine("Presiona una tecla para salir...");
        Console.ReadKey();
    }
}
