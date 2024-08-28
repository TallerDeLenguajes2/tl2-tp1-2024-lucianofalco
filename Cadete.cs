public class Cadete{
    private int id ;
    private string nombre ;
    private string direccion ;
    private string telefono ;

    List<Pedido> listadPedidos;

    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedido> ListadPedidos { get => listadPedidos; set => listadPedidos = value; }
    public Cadete(int id, string nombre, string direccion, string telefono, List<Pedido> listadPedidos)
    {
        this.id = id;
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.listadPedidos = listadPedidos;
    }
    public double JornalCobrar(){
        int contador = 0 ;
        foreach (var pedido in ListadPedidos)
        {
            if (pedido.Estado)
            {
                contador ++ ;
            }
        }
        return Convert.ToDouble(contador * 500); //Calcula el jornal total a cobrar por el cadete basado en el número de pedidos entregados.
    }

    public void EliminarPedido(Pedido pedido){
        foreach (var p in ListadPedidos)
        {
            if (p.Nro == pedido.Nro)
            {
                listadPedidos.Remove(pedido);
            }
        }
    }
    public void AgregarPedido(Pedido pedido){
        if (pedido != null)
        {
        ListadPedidos.Add(pedido);
        }
    }
    
    public List<Pedido> ListarPedidos()
    {
        return listadPedidos;
    }


}