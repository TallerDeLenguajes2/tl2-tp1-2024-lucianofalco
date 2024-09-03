public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    private string rutaArchivoCadete;
    private string rutaArchivoPedidos;
    private AccesoADatos accesoADatos;

    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes, List<Pedido> listadoPedidos, string rutaArchivoCadete, string rutaArchivoPedidos, AccesoADatos accesoADatos)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes;
        this.listadoPedidos = listadoPedidos;
        this.rutaArchivoCadete = rutaArchivoCadete;
        this.rutaArchivoPedidos = rutaArchivoPedidos;
        this.accesoADatos = accesoADatos;
    }

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public string RutaArchivoCadete { get => rutaArchivoCadete; set => rutaArchivoCadete = value; }
    public string RutaArchivoPedidos { get => rutaArchivoPedidos; set => rutaArchivoPedidos = value; }
    public AccesoADatos AccesoADatos { get => accesoADatos; set => accesoADatos = value; }

    public double JornalCobrar(int id)
    {
        int contador = 0;
        Cadete cadete = BuscarCadetePorId(id);
        if (cadete != null)
        {
            foreach (var pedido in ListadoPedidos)
            {
                if (pedido.Estado)
                {
                    contador++;
                }
            }
        }
        return Convert.ToDouble(contador * 500);
    }

    public void AsignarCadeteAPedido(int idCad, int idPed)
    {
        Cadete cadete = BuscarCadetePorId(idCad);
        Pedido pedido = BuscarPedidoPorId(idPed);
        if (cadete != null && pedido != null)
        {
            pedido.CadeteAsignado = cadete;
            accesoADatos.EscribirCadetesArchivo(rutaArchivoCadete, listadoCadetes);
        }
    }

    public void agregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
        accesoADatos.EscribirCadetesArchivo(rutaArchivoCadete, listadoCadetes);
    }
    public void agregarPedido(Pedido pedido)
    {
        listadoPedidos.Add(pedido);
        accesoADatos.EscribirPedidosArchivo(rutaArchivoPedidos, listadoPedidos);
    }
    public void EliminarCadete(int id)
    {
        Cadete cadete = BuscarCadetePorId(id);
        if (cadete != null)
        {
            foreach (var p in ListadoCadetes)
            {
                if (p.Id == id)
                {
                    listadoCadetes.Remove(cadete);
                    accesoADatos.EscribirCadetesArchivo(rutaArchivoCadete, listadoCadetes);
                }
            }
        }
    }
    public void EliminarPedido(int id)
    {
        Pedido pedido = BuscarPedidoPorId(id);
        if (pedido != null)
        {
            foreach (var p in ListadoPedidos)
            {
                if (p.Nro == id)
                {
                    listadoPedidos.Remove(pedido);
                    accesoADatos.EscribirPedidosArchivo(rutaArchivoPedidos, listadoPedidos);
                }
            }
        }
    }

    public Cadete BuscarCadetePorId(int id)
    {
        foreach (var cadete in listadoCadetes)
        {
            if (cadete.Id == id)
            {
                return cadete;
            }
        }
        return null;
    }
    public Pedido BuscarPedidoPorId(int id)
    {
        foreach (var pedido in listadoPedidos)
        {
            if (pedido.Nro == id)
            {
                return pedido;
            }
        }
        return null;
    }
    public void ActualizarCadete(Cadete cadeteActualizado)
    {
        var cadete = BuscarCadetePorId(cadeteActualizado.Id);
        if (cadete != null)
        {
            cadete.Nombre = cadeteActualizado.Nombre;
            cadete.Direccion = cadeteActualizado.Direccion;
            cadete.Telefono = cadeteActualizado.Telefono;
            accesoADatos.EscribirCadetesArchivo(rutaArchivoCadete, listadoCadetes);
        }
    }
    public void ActualizarPedido(Pedido pedidoActualizado)
    {
        var pedido = BuscarPedidoPorId(pedidoActualizado.Nro);
        if (pedido != null)
        {
            pedido.CadeteAsignado = pedidoActualizado.CadeteAsignado;
            pedido.Estado = pedidoActualizado.Estado;
            pedido.Observacion = pedidoActualizado.Observacion;
            pedido.Cliente.Nombre = pedidoActualizado.Cliente.Nombre;
            pedido.Cliente.Direccion = pedidoActualizado.Cliente.Direccion;
            pedido.Cliente.Telefono = pedidoActualizado.Cliente.Telefono;
            pedido.Cliente.DatosReferentesDireccion = pedidoActualizado.Cliente.DatosReferentesDireccion;
            accesoADatos.EscribirPedidosArchivo(RutaArchivoPedidos, listadoPedidos);
        }
    }

    public void MostrarCadedes()
    {
        foreach (var cadete in listadoCadetes)
        {
            Console.WriteLine();
            Console.WriteLine($"ID{cadete.Id}");
            Console.WriteLine($"\t Nombre: {cadete.Nombre}");
            Console.WriteLine($"\t Direccion: {cadete.Direccion}");
            Console.WriteLine($"\t Telefono: {cadete.Telefono}");
        }
    }
    public void MostrarPedidos()
    {
        foreach (var pedido in listadoPedidos)
        {
            Console.WriteLine();
            Console.WriteLine($"ID pedido {pedido.Nro}");
            Console.WriteLine($"\t Cadete asignado: ID: {pedido.CadeteAsignado.Id} Nombre: {pedido.CadeteAsignado.Nombre}");
            Console.WriteLine($"\t Cliente: {pedido.Cliente.Nombre} Direccion: {pedido.Cliente.Direccion}");
            Console.WriteLine($"\t Estado: {pedido.Estado}");
            Console.WriteLine($"\t Observacion: {pedido.Observacion}");
        }
    }

}