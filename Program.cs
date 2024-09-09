using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CadeteriaApp
{
    internal class Program
    {
        private static Cadeteria cadeteria;
        private static AccesoADatos accesoDatos;
        private static List<Cadete> cadetesDisponibles;
        private static List<Pedido> pedidos ;
        private static string tipoArchivo;

        private static void Main(string[] args)
        {
            tipoArchivo = getExtensionArchivo();
            if (tipoArchivo == ".csv")
            {
                accesoDatos = new AccesoCSV();
            }
            else
            {
                accesoDatos = new AccesoJson();
            }

            string rutaArchivoCadete = $"cadete{tipoArchivo}" ;
            string rutaArchivoPedidos = $"pedido{tipoArchivo}" ;
            cadetesDisponibles = accesoDatos.GetListCadetes(rutaArchivoCadete);
            pedidos = accesoDatos.GetListPedidos(rutaArchivoPedidos);
            cadeteria = new Cadeteria("Cadetería el gigante", "1155785708", cadetesDisponibles , pedidos , rutaArchivoCadete , rutaArchivoPedidos, accesoDatos);

            Menu();
        }

        private static string getExtensionArchivo()
        {
            int opcionArchivo;
            string extension;

            Console.WriteLine("Seleccione con qué tipo de archivos trabajará:");
            Console.WriteLine("(1). JSON");
            Console.WriteLine("(2). CSV");

            while (!int.TryParse(Console.ReadLine(), out opcionArchivo) || (opcionArchivo != 1 && opcionArchivo != 2))
            {
                Console.WriteLine("Por favor, introduce un número válido.\n");
            }

            if (opcionArchivo == 1)
            {
                extension = ".json";
            }
            else
            {
                extension = ".csv";
            }

            return extension;
        }

        public static void Menu()
        {
            int opcion = -1;

            while (opcion != 0)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción:");
                Console.WriteLine("(1). DAR DE ALTA PEDIDOS");
                Console.WriteLine("(2). ASIGNAR PEDIDOS A CADETES");
                Console.WriteLine("(3). CAMBIAR ESTADOS DE PEDIDOS");
                Console.WriteLine("(4). REASIGNAR PEDIDO A OTRO CADETE");
                Console.WriteLine("(0). SALIR");

                while (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Por favor, introduce un número válido.\n");
                }

                switch (opcion)
                {
                    case 1:
                        DarDeAltaPedidos();
                        break;
                    case 2:
                        AsignarPedidosACadetes();
                        break;
                    case 3:
                        CambiarEstadosDePedidos();
                        break;
                    case 4:
                        ReasignarPedidoACadete();
                        break;
                    case 0:
                        Salir();
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intenta de nuevo.");
                        break;
                }
            }
        }

        private static void Salir()
        {
            Console.Clear();
            Console.WriteLine("Saliendo del programa...");
            Environment.Exit(0);
        }

        private static void DarDeAltaPedidos()
        {
            Console.WriteLine("Ingrese los datos del nuevo pedido:");
            Console.Write("Número: ");
            int nro = int.Parse(Console.ReadLine());
            Console.Write("Observación: ");
            string observacion = Console.ReadLine();
            Console.Write("Estado (true/false): ");
            bool estado = bool.Parse(Console.ReadLine());
            Console.Write("Nombre del Cliente: ");
            string nombreCliente = Console.ReadLine();
            Console.Write("Dirección del Cliente: ");
            string direccionCliente = Console.ReadLine();
            Console.Write("Teléfono del Cliente: ");
            string telefonoCliente = Console.ReadLine();
            Console.Write("Datos Referentes a la Dirección: ");
            string datosReferentesDireccion = Console.ReadLine();

            var nuevoPedido = new Pedido(nro, observacion, estado, nombreCliente, direccionCliente, telefonoCliente, datosReferentesDireccion);
            cadeteria.agregarPedido(nuevoPedido);
            
            Console.WriteLine("Pedido agregado exitosamente.");
        }

        public static void AsignarPedidosACadetes() 
        {
            Console.WriteLine("Lista de cadetes disponibles:");
            Console.WriteLine(cadeteria.MostrarCadedes());

            Console.Write("Ingrese el ID del cadete al que se le asignarán los pedidos: ");
            int idCadete = int.Parse(Console.ReadLine());

            var cadete = cadeteria.BuscarCadetePorId(idCadete);
            if (cadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return;
            }
            Console.WriteLine("Lista de pedidos disponibles:");
            Console.WriteLine(cadeteria.MostrarPedidos());
            Console.Write($"Ingrese el ID del pedido al que se le asignarán al cadete {cadete.Nombre}");
            int idpedido = int.Parse(Console.ReadLine());
            cadeteria.AsignarCadeteAPedido(cadete.Id, idpedido);
            Console.WriteLine("Pedidos asignados exitosamente.");
        }

        private static void CambiarEstadosDePedidos()
        {
            Console.Write("Ingrese el número del pedido cuyo estado desea cambiar: ");
            Console.WriteLine(cadeteria.MostrarPedidos());
            int nroPedido = int.Parse(Console.ReadLine());

            var pedido = cadeteria.BuscarPedidoPorId(nroPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return;
            }

            Console.Write($"Ingrese el nuevo estado del pedido: ID: {pedido.Nro} - {pedido.Observacion} (true/false): ");
            bool nuevoEstado = bool.Parse(Console.ReadLine());
            pedido.Estado = nuevoEstado;
            cadeteria.ActualizarPedido(pedido);
            Console.WriteLine("Estado del pedido actualizado exitosamente.");
        }

        private static void ReasignarPedidoACadete()
        {
            Console.Write("Ingrese el número del pedido que desea reasignar: ");
            Console.WriteLine(cadeteria.MostrarPedidos());
            int nroPedido = int.Parse(Console.ReadLine());

            var pedido = cadeteria.BuscarPedidoPorId(nroPedido);
            if (pedido == null)
            {
                Console.WriteLine("Pedido no encontrado.");
                return;
            }

            Console.WriteLine("Lista de cadetes disponibles:");
           Console.WriteLine(cadeteria.MostrarCadedes());

            Console.Write("Ingrese el ID del nuevo cadete al que se le asignará el pedido: ");
            int idCadete = int.Parse(Console.ReadLine());

            var nuevoCadete = cadeteria.BuscarCadetePorId(idCadete);
            if (nuevoCadete == null)
            {
                Console.WriteLine("Cadete no encontrado.");
                return;
            }
            cadeteria.AsignarCadeteAPedido(nuevoCadete.Id, pedido.Nro);
            Console.WriteLine("Pedido reasignado exitosamente.");
        }
    }
}
