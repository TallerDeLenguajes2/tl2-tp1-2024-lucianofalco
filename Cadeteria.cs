public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedido> listadoPedidos;
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes { get => listadoCadetes; set => listadoCadetes = value; }
    public List<Pedido> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }

    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.listadoCadetes = listadoCadetes;
    }

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

    public void AsignarCadeteAPedido(int idCad , int idPed){
        Cadete cadete = BuscarCadetePorId(idCad);
        Pedido pedido = BuscarPedidoPorId(idPed);
        if (cadete != null && pedido!=null)
        {
            pedido.CadeteAsignado = cadete ;
        }
    }

    public void agregarCadete(Cadete cadete)
    {
        listadoCadetes.Add(cadete);
    }
    public void EliminarCadete(Cadete cadete)
    {
        foreach (var p in ListadoCadetes)
        {
            if (p.Id == cadete.Id)
            {
                listadoCadetes.Remove(cadete);
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
        }
    }
    public void ActualizarPedido(Pedido pedidoActualizado)
    {
        var pedido = BuscarPedidoPorId(pedidoActualizado.Nro);
        if (pedido != null)
        {
            pedido.Cliente = pedidoActualizado.Cliente;
            pedido.CadeteAsignado = pedidoActualizado.CadeteAsignado;
            pedido.Cliente = pedidoActualizado.Cliente;
            pedido.Estado = pedidoActualizado.Estado;
            pedido.Observacion = pedidoActualizado.Observacion;
        }
    }
}