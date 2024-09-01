using System;
using System.Collections.Generic;
using System.Linq;

internal class Program
{
    private static List<Pedido> pedidos = new List<Pedido>();
    private static List<Cadete> cadetesDisponibles = new List<Cadete>();
    private static Cadeteria cadeteria = new Cadeteria("Cadeteria el gigante" , "1155785708" , cadetesDisponibles); // Instancia de la clase Cadeteria para la gestión de cadetes

    private static void Main(string[] args)
    {
        string rutaCadetes = "cadete.csv";
        string rutaPedidos = "pedido.csv";

        pedidos = Pedido.CargarPedidosDesdeCsv(rutaPedidos);
        cadetesDisponibles = Cadete.CargarDesdeCsv(rutaCadetes);
        
        foreach (var cadete in cadetesDisponibles)
        {
            cadeteria.agregarCadete(cadete);
        }

        Menu();
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
                    DarDeAltaPedidos(pedidos);
                    break;
                case 2:
                    AsignarPedidosACadetes(pedidos, cadetesDisponibles, cadeteria);
                    break;
                case 3:
                    CambiarEstadosDePedidos(pedidos);
                    break;
                case 4:
                    ReasignarPedidoACadete(pedidos, cadetesDisponibles, cadeteria);
                    break;
                case 0:
                    Salir();
                    break;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo.");
                    break;
            }
        }
    }

    private static void Salir()
    {
        Console.Clear();
        Environment.Exit(0);
    }

    private static void DarDeAltaPedidos(List<Pedido> pedidos)
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
        pedidos.Add(nuevoPedido);

        Console.WriteLine("Pedido agregado exitosamente.");
    }

    public static void AsignarPedidosACadetes(List<Pedido> nuevosPedidos, List<Cadete> cadetesDisponibles, Cadeteria cadeteria)
    {
        Console.WriteLine("Lista de cadetes disponibles:");
        foreach (var cad in cadetesDisponibles)
        {
            Console.WriteLine($"ID: {cad.Id}, Nombre: {cad.Nombre}");
        }

        Console.Write("Ingrese el ID del cadete al que se le asignarán los pedidos: ");
        int idCadete = int.Parse(Console.ReadLine());

        var cadete = cadeteria.BuscarCadetePorId(idCadete);
        if (cadete == null)
        {
            Console.WriteLine("Cadete no encontrado.");
            return;
        }

        foreach (var pedido in nuevosPedidos)
        {
            cadete.AgregarPedido(pedido);
        }

        Console.WriteLine("Pedidos asignados exitosamente.");
    }

    private static void CambiarEstadosDePedidos(List<Pedido> pedidosDisponibles)
    {
        Console.Write("Ingrese el número del pedido cuyo estado desea cambiar: ");
        int nroPedido = int.Parse(Console.ReadLine());

        var pedido = pedidosDisponibles.FirstOrDefault(p => p.Nro == nroPedido);
        if (pedido == null)
        {
            Console.WriteLine("Pedido no encontrado.");
            return;
        }

        Console.Write("Ingrese el nuevo estado del pedido (true/false): ");
        bool nuevoEstado = bool.Parse(Console.ReadLine());
        pedido.Estado = nuevoEstado;

        Console.WriteLine("Estado del pedido actualizado exitosamente.");
    }

    private static void ReasignarPedidoACadete(List<Pedido> pedidos, List<Cadete> cadetesDisponibles, Cadeteria cadeteria)
    {
        Console.Write("Ingrese el número del pedido que desea reasignar: ");
        int nroPedido = int.Parse(Console.ReadLine());

        var pedido = pedidos.FirstOrDefault(p => p.Nro == nroPedido);
        if (pedido == null)
        {
            Console.WriteLine("Pedido no encontrado.");
            return;
        }

        Console.WriteLine("Lista de cadetes disponibles:");
        foreach (var cad in cadetesDisponibles)
        {
            Console.WriteLine($"ID: {cad.Id}, Nombre: {cad.Nombre}");
        }

        Console.Write("Ingrese el ID del nuevo cadete al que se le asignará el pedido: ");
        int idCadete = int.Parse(Console.ReadLine());

        var nuevoCadete = cadeteria.BuscarCadetePorId(idCadete);
        if (nuevoCadete == null)
        {
            Console.WriteLine("Cadete no encontrado.");
            return;
        }

        foreach (var cadete in cadetesDisponibles)
        {
            cadete.EliminarPedido(pedido);
        }

        nuevoCadete.AgregarPedido(pedido);

        Console.WriteLine("Pedido reasignado exitosamente.");
    }
}