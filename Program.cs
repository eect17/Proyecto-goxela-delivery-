using System;

namespace GoXelaDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            Bicicleta bici = new Bicicleta("V001", "Yamaha", "R1", 5);
            PaqueteEstandar paquete = new PaqueteEstandar("P001", "Ropa", 8, 100, "Zona 1", "Zona 3");

            Console.WriteLine("Código del vehículo: " + bici.Codigo);
            Console.WriteLine("Capacidad máxima: " + bici.CapacidadMaxima);
            Console.WriteLine("Estado: " + bici.Estado);

            bool puede = bici.PuedeTransportar(paquete);
            Console.WriteLine("¿La bicicleta puede transportar el paquete? " + puede);

            double tarifa = paquete.CalcularTarifa(10);
            Console.WriteLine("Tarifa calculada: " + tarifa);
        }
    }
}