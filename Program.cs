using System;
using System.Collections.Generic;

namespace GoXelaDelivery
{
    class Program
    {
        public static double SumarCapacidadRecursiva(List<Vehiculo> lista, int indice)
        {
            if (indice >= lista.Count)
            {
                return 0;
            }
            return lista[indice].CapacidadMaxima + SumarCapacidadRecursiva(lista, indice + 1);
        }

        public static double AplicarDescuento(double tarifa, double porcentajeDescuento)
        {
            if (porcentajeDescuento > 0 && porcentajeDescuento <= 100)
            {
                return tarifa - (tarifa * (porcentajeDescuento / 100.0));
            }
            return tarifa;
        }

        static void Main(string[] args)
        {
            List<Vehiculo> vehiculos = new List<Vehiculo>();
            List<Paquete> paquetes = new List<Paquete>();

            int opcion = 0;

            while (opcion != 5)
            {
                Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine("     SISTEMA DE GESTIÓN GOXELA DELIVERY    ");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Registrar Vehículo");
                Console.WriteLine("2. Registrar Paquete");
                Console.WriteLine("3. Mostrar Flota y Paquetes");
                Console.WriteLine("4. Reporte Especial (Recursividad)");
                Console.WriteLine("5. Salir");
                Console.WriteLine("===========================================");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarVehiculoMenu(vehiculos);
                        break;

                    case 2:
                        RegistrarPaqueteMenu(paquetes);
                        break;

                    case 3:
                        MostrarTodo(vehiculos, paquetes);
                        break;

                    case 4:
                        MostrarReporteRecursivo(vehiculos);
                        break;

                    case 5:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegistrarVehiculoMenu(List<Vehiculo> vehiculos)
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE VEHICULO ---");
            Console.WriteLine("1. Bicicleta");
            Console.WriteLine("2. Motocicleta");
            Console.WriteLine("3. Automóvil");
            Console.Write("Seleccione el tipo: ");

            int tipo;
            while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 3)
            {
                Console.Write("Tipo inválido. Ingrese 1, 2 o 3: ");
            }

            string codigo = "";
            while (codigo == "" || codigo == null)
            {
                Console.Write("Ingrese código: ");
                codigo = Console.ReadLine();
            }

            string marca = "";
            while (marca == "" || marca == null)
            {
                Console.Write("Ingrese marca: ");
                marca = Console.ReadLine();
            }

            string modelo = "";
            while (modelo == "" || modelo == null)
            {
                Console.Write("Ingrese modelo: ");
                modelo = Console.ReadLine();
            }

            string placa = "N/A";
            if (tipo != 1)
            {
                while (placa == "N/A" || placa == "" || placa == null)
                {
                    Console.Write("Ingrese placa: ");
                    placa = Console.ReadLine();
                }
            }

            double capacidad;
            Console.Write("Ingrese capacidad máxima (kg): ");
            while (!double.TryParse(Console.ReadLine(), out capacidad) || capacidad <= 0)
            {
                Console.Write("Valor inválido. Ingrese una capacidad numérica mayor a 0: ");
            }

            double costo;
            Console.Write("Ingrese costo operativo por km: ");
            while (!double.TryParse(Console.ReadLine(), out costo) || costo < 0)
            {
                Console.Write("Valor inválido. Ingrese un costo mayor o igual a 0: ");
            }

            if (tipo == 1)
            {
                vehiculos.Add(new Bicicleta(codigo, marca, modelo, capacidad, costo));
            }
            else if (tipo == 2)
            {
                vehiculos.Add(new Motocicleta(codigo, placa, marca, modelo, capacidad, costo));
            }
            else if (tipo == 3)
            {
                vehiculos.Add(new Automovil(codigo, placa, marca, modelo, capacidad, costo));
            }

            Console.WriteLine("Vehículo registrado exitosamente. Presione cualquier tecla...");
            Console.ReadKey();
        }

        private static void RegistrarPaqueteMenu(List<Paquete> paquetes)
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE PAQUETE ---");
            Console.WriteLine("1. Documento");
            Console.WriteLine("2. Paquete Estandar");
            Console.WriteLine("3. Paquete Fragil");
            Console.WriteLine("4. Producto Refrigerado");
            Console.Write("Seleccione el tipo: ");

            int tipo;
            while (!int.TryParse(Console.ReadLine(), out tipo) || tipo < 1 || tipo > 4)
            {
                Console.Write("Tipo invalido. Ingrese un número entre 1 y 4: ");
            }

            string codigo = "";
            while (codigo == "" || codigo == null)
            {
                Console.Write("Ingrese codigo: ");
                codigo = Console.ReadLine();
            }

            string descripcion = "";
            while (descripcion == "" || descripcion == null)
            {
                Console.Write("Ingrese descripción: ");
                descripcion = Console.ReadLine();
            }

            double peso;
            Console.Write("Ingrese peso (kg): ");
            while (!double.TryParse(Console.ReadLine(), out peso) || peso <= 0)
            {
                Console.Write("Error: El peso debe ser mayor a 0: ");
            }

            double valor;
            Console.Write("Ingrese valor declarado (Q): ");
            while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0)
            {
                Console.Write("Error: El valor no puede ser negativo: ");
            }

            string origen = "";
            while (origen == "" || origen == null)
            {
                Console.Write("Ingrese dirección de origen: ");
                origen = Console.ReadLine();
            }

            string destino = "";
            while (destino == "" || destino == null)
            {
                Console.Write("Ingrese dirección de destino: ");
                destino = Console.ReadLine();
            }

            if (tipo == 1)
            {
                paquetes.Add(new Documento(codigo, descripcion, peso, valor, origen, destino));
            }
            else if (tipo == 2)
            {
                paquetes.Add(new PaqueteEstandar(codigo, descripcion, peso, valor, origen, destino));
            }
            else if (tipo == 3)
            {
                paquetes.Add(new PaqueteFragil(codigo, descripcion, peso, valor, origen, destino));
            }
            else if (tipo == 4)
            {
                paquetes.Add(new ProductoRefrigerado(codigo, descripcion, peso, valor, origen, destino));
            }

            Console.WriteLine("Paquete registrado exitosamente! Presione cualquier tecla...");
            Console.ReadKey();
        }

        private static void MostrarTodo(List<Vehiculo> vehiculos, List<Paquete> paquetes)
        {
            Console.Clear();
            Console.WriteLine("--- LISTADO DE VEHiCULOS ---");
            if (vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
            }
            else
            {
                for (int i = 0; i < vehiculos.Count; i++)
                {
                    vehiculos[i].MostrarInformacion();
                }
            }

            Console.WriteLine("--- LISTADO DE PAQUETES ---");
            if (paquetes.Count == 0)
            {
                Console.WriteLine("No hay paquetes registrados.");
            }
            else
            {
                for (int i = 0; i < paquetes.Count; i++)
                {
                    paquetes[i].MostrarInformacion();
                    double tarifa = paquetes[i].CalcularTarifa(10.0);
                    Console.WriteLine($"   Tarifa estimada (10 km): Q{tarifa}");
                }
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }

        private static void MostrarReporteRecursivo(List<Vehiculo> vehiculos)
        {
            Console.Clear();
            Console.WriteLine("--- REPORTE DE CAPACIDAD TOTAL ---");

            double capacidadTotal = SumarCapacidadRecursiva(vehiculos, 0);

            Console.WriteLine($"Cantidad de vehículos: {vehiculos.Count}");
            Console.WriteLine($"Capacidad total acumulada : {capacidadTotal} kg");

            Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }
    }
}