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
            GestorRecursos gestorRecursos = new GestorRecursos();
            GestorEntregas gestorEntregas = new GestorEntregas();
            List<Incidencia> incidencias = new List<Incidencia>();

            int opcion = 0;

            while (opcion != 12)
            {
                Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine("     SISTEMA DE GESTIÓN GOXELA DELIVERY    ");
                Console.WriteLine("===========================================");
                Console.WriteLine("1. Registrar Vehículo");
                Console.WriteLine("2. Registrar Paquete");
                Console.WriteLine("3. Mostrar Flota y Paquetes");
                Console.WriteLine("4. Reporte Especial (Recursividad)");
                Console.WriteLine("5. Registrar Cliente");
                Console.WriteLine("6. Registrar Repartidor");
                Console.WriteLine("7. Crear Entrega");
                Console.WriteLine("8. Asignar Repartidor y Vehículo a Entrega");
                Console.WriteLine("9. Cambiar Estado de Entrega");
                Console.WriteLine("10. Registrar Incidencia");
                Console.WriteLine("11. Ver Reportes Generales");
                Console.WriteLine("12. Salir");
                Console.WriteLine("===========================================");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    opcion = 0;
                }

                switch (opcion)
                {
                    case 1:
                        RegistrarVehiculoMenu(gestorRecursos);
                        break;

                    case 2:
                        RegistrarPaqueteMenu(gestorRecursos);
                        break;

                    case 3:
                        MostrarTodo(gestorRecursos);
                        break;

                    case 4:
                        MostrarReporteRecursivo(gestorRecursos);
                        break;

                    case 5:
                        RegistrarClienteMenu(gestorRecursos);
                        break;

                    case 6:
                        RegistrarRepartidorMenu(gestorRecursos);
                        break;

                    case 7:
                        CrearEntregaMenu(gestorRecursos, gestorEntregas);
                        break;

                    case 8:
                        AsignarRecursosMenu(gestorRecursos, gestorEntregas);
                        break;

                    case 9:
                        CambiarEstadoEntregaMenu(gestorEntregas);
                        break;

                    case 10:
                        RegistrarIncidenciaMenu(gestorEntregas, incidencias);
                        break;

                    case 11:
                        MostrarReportesMenu(gestorEntregas, incidencias);
                        break;

                    case 12:
                        Console.WriteLine("Saliendo del sistema...");
                        break;

                    default:
                        Console.WriteLine("Opción inválida. Presione cualquier tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void RegistrarVehiculoMenu(GestorRecursos gestorRecursos)
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

            Console.Write("Ingrese código: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese marca: ");
            string marca = Console.ReadLine();

            Console.Write("Ingrese modelo: ");
            string modelo = Console.ReadLine();

            string placa = "N/A";
            if (tipo != 1)
            {
                Console.Write("Ingrese placa: ");
                placa = Console.ReadLine();
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

            Vehiculo nuevoVehiculo = null;

            if (tipo == 1)
            {
                nuevoVehiculo = new Bicicleta(codigo, marca, modelo, capacidad, costo);
            }
            else if (tipo == 2)
            {
                nuevoVehiculo = new Motocicleta(codigo, placa, marca, modelo, capacidad, costo);
            }
            else if (tipo == 3)
            {
                nuevoVehiculo = new Automovil(codigo, placa, marca, modelo, capacidad, costo);
            }

            bool registrado = gestorRecursos.RegistrarVehiculo(nuevoVehiculo);
            if (registrado)
            {
                Console.WriteLine("Vehículo registrado exitosamente.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void RegistrarPaqueteMenu(GestorRecursos gestorRecursos)
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

            Console.Write("Ingrese codigo: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese descripción: ");
            string descripcion = Console.ReadLine();

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

            Console.Write("Ingrese dirección de origen: ");
            string origen = Console.ReadLine();

            Console.Write("Ingrese dirección de destino: ");
            string destino = Console.ReadLine();

            Paquete nuevoPaquete = null;

            if (tipo == 1)
            {
                nuevoPaquete = new Documento(codigo, descripcion, peso, valor, origen, destino);
            }
            else if (tipo == 2)
            {
                nuevoPaquete = new PaqueteEstandar(codigo, descripcion, peso, valor, origen, destino);
            }
            else if (tipo == 3)
            {
                nuevoPaquete = new PaqueteFragil(codigo, descripcion, peso, valor, origen, destino);
            }
            else if (tipo == 4)
            {
                nuevoPaquete = new ProductoRefrigerado(codigo, descripcion, peso, valor, origen, destino);
            }

            bool registrado = gestorRecursos.RegistrarPaquete(nuevoPaquete);
            if (registrado)
            {
                Console.WriteLine("Paquete registrado exitosamente!");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarTodo(GestorRecursos gestorRecursos)
        {
            Console.Clear();
            List<Vehiculo> vehiculos = gestorRecursos.ObtenerVehiculos();
            List<Paquete> paquetes = gestorRecursos.ObtenerPaquetes();

            Console.WriteLine("--- LISTADO DE VEHÍCULOS ---");
            if (vehiculos.Count == 0)
            {
                Console.WriteLine("No hay vehículos registrados.");
            }
            else
            {
                for (int i = 0; i < vehiculos.Count; i++)
                {
                    Console.WriteLine("Código: " + vehiculos[i].Codigo + " | Tipo: " + vehiculos[i].GetType().Name + " | Capacidad: " + vehiculos[i].CapacidadMaxima + "kg");
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
                    Console.WriteLine("Código: " + paquetes[i].Codigo + " | Descripción: " + paquetes[i].Descripcion);
                    double tarifa = paquetes[i].CalcularTarifa(10.0);
                    Console.WriteLine("   Tarifa estimada (10 km): Q" + tarifa);
                }
            }

            Console.WriteLine("Presione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }

        private static void MostrarReporteRecursivo(GestorRecursos gestorRecursos)
        {
            Console.Clear();
            Console.WriteLine("--- REPORTE DE CAPACIDAD TOTAL ---");

            List<Vehiculo> vehiculos = gestorRecursos.ObtenerVehiculos();
            double capacidadTotal = SumarCapacidadRecursiva(vehiculos, 0);

            Console.WriteLine("Cantidad de vehículos: " + vehiculos.Count);
            Console.WriteLine("Capacidad total acumulada: " + capacidadTotal + " kg");

            Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }

        private static void RegistrarClienteMenu(GestorRecursos gestorRecursos)
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE CLIENTE ---");

            Console.Write("Ingrese código: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese dirección: ");
            string direccion = Console.ReadLine();

            Console.Write("Ingrese correo: ");
            string correo = Console.ReadLine();

            Cliente nuevoCliente = new Cliente();
            nuevoCliente.AcctualizarInfo(nombre, codigo, telefono, direccion, correo);

            bool registrado = gestorRecursos.RegistrarCliente(nuevoCliente);
            if (registrado)
            {
                Console.WriteLine("Cliente registrado exitosamente.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void RegistrarRepartidorMenu(GestorRecursos gestorRecursos)
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRO DE REPARTIDOR ---");

            Console.Write("Ingrese código: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese nombre completo: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese teléfono: ");
            string telefono = Console.ReadLine();

            Console.Write("Ingrese licencia: ");
            string licencia = Console.ReadLine();

            Console.Write("Ingrese tipo de licencia: ");
            string tipoLicencia = Console.ReadLine();

            Repartidor nuevoRepartidor = new Repartidor();
            nuevoRepartidor.Codigo = codigo;
            nuevoRepartidor.Nombre = nombre;
            nuevoRepartidor.Telefono = telefono;
            nuevoRepartidor.Licencia = licencia;
            nuevoRepartidor.TipoLicenciaProp = tipoLicencia;
            nuevoRepartidor.EstadoEntrega = "Disponible";

            bool registrado = gestorRecursos.RegistrarRepartidor(nuevoRepartidor);
            if (registrado)
            {
                Console.WriteLine("Repartidor registrado exitosamente.");
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CrearEntregaMenu(GestorRecursos gestorRecursos, GestorEntregas gestorEntregas)
        {
            Console.Clear();
            Console.WriteLine("--- CREAR ENTREGA ---");

            Console.Write("Ingrese código de la entrega: ");
            string codigo = Console.ReadLine();

            Console.Write("Ingrese código del cliente: ");
            string codigoCliente = Console.ReadLine();
            Cliente cliente = gestorRecursos.BuscarClientePorCodigo(codigoCliente);

            if (cliente == null)
            {
                Console.WriteLine("Error: no existe un cliente con ese código.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese código del paquete: ");
            string codigoPaquete = Console.ReadLine();
            Paquete paquete = gestorRecursos.ObtenerPaquetes().Find(p => p.Codigo == codigoPaquete);

            if (paquete == null)
            {
                Console.WriteLine("Error: no existe un paquete con ese código.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese dirección de origen: ");
            string origen = Console.ReadLine();

            Console.Write("Ingrese dirección de destino: ");
            string destino = Console.ReadLine();

            double distancia;
            Console.Write("Ingrese distancia estimada (km): ");
            while (!double.TryParse(Console.ReadLine(), out distancia) || distancia < 0)
            {
                Console.Write("Valor inválido. Ingrese una distancia mayor o igual a 0: ");
            }

            Entrega nuevaEntrega = new Entrega(codigo, cliente, paquete, origen, destino, distancia);

            double tarifa = paquete.CalcularTarifa(distancia);
            nuevaEntrega.TarifaBase = tarifa;
            nuevaEntrega.Total = tarifa;

            bool creada = gestorEntregas.CrearEntrega(nuevaEntrega);
            if (creada)
            {
                Console.WriteLine("Entrega creada con estado: " + nuevaEntrega.Estado);
                Console.WriteLine("Tarifa calculada: Q" + nuevaEntrega.Total);
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void AsignarRecursosMenu(GestorRecursos gestorRecursos, GestorEntregas gestorEntregas)
        {
            Console.Clear();
            Console.WriteLine("--- ASIGNAR REPARTIDOR Y VEHÍCULO ---");

            Console.Write("Ingrese código de la entrega: ");
            string codigoEntrega = Console.ReadLine();
            Entrega entrega = gestorEntregas.BuscarEntrega(codigoEntrega);

            if (entrega == null)
            {
                Console.WriteLine("Error: no existe una entrega con ese código.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese código del repartidor: ");
            string codigoRepartidor = Console.ReadLine();
            Repartidor repartidor = gestorRecursos.BuscarRepartidorPorCodigo(codigoRepartidor);

            if (repartidor == null)
            {
                Console.WriteLine("Error: no existe un repartidor con ese código.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese código del vehículo: ");
            string codigoVehiculo = Console.ReadLine();
            Vehiculo vehiculo = gestorRecursos.ObtenerVehiculos().Find(v => v.Codigo == codigoVehiculo);

            if (vehiculo == null)
            {
                Console.WriteLine("Error: no existe un vehículo con ese código.");
                Console.ReadKey();
                return;
            }

            bool asignado = gestorEntregas.AsignarRecursos(entrega, repartidor, vehiculo);
            if (asignado)
            {
                Console.WriteLine("Recursos asignados. Estado de la entrega: " + entrega.Estado);
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void CambiarEstadoEntregaMenu(GestorEntregas gestorEntregas)
        {
            Console.Clear();
            Console.WriteLine("--- CAMBIAR ESTADO DE ENTREGA ---");

            Console.Write("Ingrese código de la entrega: ");
            string codigoEntrega = Console.ReadLine();
            Entrega entrega = gestorEntregas.BuscarEntrega(codigoEntrega);

            if (entrega == null)
            {
                Console.WriteLine("Error: no existe una entrega con ese código.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Estado actual: " + entrega.Estado);
            Console.Write("Ingrese el nuevo estado (Recogida, En ruta, Entregada, Cancelada, Reprogramada): ");
            string nuevoEstado = Console.ReadLine();

            bool cambiado = gestorEntregas.CambiarEstadoEntrega(entrega, nuevoEstado);
            if (cambiado)
            {
                Console.WriteLine("Estado actualizado a: " + entrega.Estado);
            }

            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void RegistrarIncidenciaMenu(GestorEntregas gestorEntregas, List<Incidencia> incidencias)
        {
            Console.Clear();
            Console.WriteLine("--- REGISTRAR INCIDENCIA ---");

            Console.Write("Ingrese código de la entrega: ");
            string codigoEntrega = Console.ReadLine();
            Entrega entrega = gestorEntregas.BuscarEntrega(codigoEntrega);

            if (entrega == null)
            {
                Console.WriteLine("Error: no existe una entrega con ese código.");
                Console.ReadKey();
                return;
            }

            Console.Write("Ingrese código de la incidencia: ");
            string codigoIncidencia = Console.ReadLine();

            Console.Write("Ingrese tipo (Cliente ausente, Dirección incorrecta, Paquete dañado, etc.): ");
            string tipo = Console.ReadLine();

            Console.Write("Ingrese descripción: ");
            string descripcion = Console.ReadLine();

            Incidencia nuevaIncidencia = new Incidencia(codigoIncidencia, tipo, descripcion, entrega);
            incidencias.Add(nuevaIncidencia);

            entrega.CambiarEstado("Con incidencia");

            Console.WriteLine("Incidencia registrada. La entrega quedó en estado: " + entrega.Estado);
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }

        private static void MostrarReportesMenu(GestorEntregas gestorEntregas, List<Incidencia> incidencias)
        {
            Console.Clear();
            Console.WriteLine("--- REPORTES GENERALES ---");

            ResumenEntregas resumen = gestorEntregas.GenerarResumen();

            Console.WriteLine("Entregas activas: " + resumen.CantidadActivas);
            Console.WriteLine("Entregas finalizadas: " + resumen.CantidadFinalizadas);
            Console.WriteLine("Entregas canceladas: " + resumen.CantidadCanceladas);
            Console.WriteLine("Total de ingresos: Q" + resumen.TotalIngresos);
            Console.WriteLine("Cantidad de incidencias registradas: " + incidencias.Count);

            Console.WriteLine("\nPresione cualquier tecla para regresar al menú...");
            Console.ReadKey();
        }
    }
}